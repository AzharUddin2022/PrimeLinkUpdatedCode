$(document).ready(function () {
});

function onDataBound(e) {
    var grid = this;
    grid.table.find("tr").each(function () {
        var dataItem = grid.dataItem(this);
        var themeColor = dataItem.Role ? 'success' : 'error';
        var text = 'available'; //dataItem.Discontinued ? 'available' : 'not available';

        $(this).find('script').each(function () {
            eval($(this).html());
        });

        $(this).find(".badgeTemplate").kendoBadge({
            themeColor: themeColor,
            text: text,
        });


        kendo.bind($(this), dataItem);
    });
}

$("#InspectorGrid").on("click", "#addInspector", function (e) {
    var gridview = $("#InspectorGrid").data("kendoGrid");
    var dataItem = gridview.dataItem(e.currentTarget.parentNode.parentNode);
    var Id = dataItem != undefined ? dataItem.Id : 0;
    $.ajax({
        type: "Get",
        url: '/InspectorAllocation/AddEditInspector?Id=' + Id,
        success: function (response) {

            ShowPopup("Allocate Inspector", response);
        }
    })
});

function onCancel() {
    $("#AddEditInspector").data("kendoWindow").close();
}

function AlertSuccess(message, redirectionUrl) {
    swal({
        title: "Success!",
        text: message,
        icon: "success",
        button: "Ok",
        confirmButtonColor: '#f46930',
    }).then(function () {
        location.reload();
    });
}

function AlertError(message) {
    swal({
        title: "Error!",
        text: message,
        icon: "error",
        button: "Ok",
        confirmButtonColor: '#f46930',
    });
}

function AlertValidation(message) {
    swal({
        title: "Validation Error!",
        text: message,
        icon: "warning",
        button: "Ok",
        confirmButtonColor: '#f46930',
    });
}

function onSuccess(response) {
    var alert = response.Data;
    AlertSuccess(alert.Message);
}

function onFailure(response) {
    var alert = response.Data;
    AlertError(alert.Message);
}

function ShowPopup(title, content) {
    var ele = $("#AddEditInspector").data("kendoWindow");
    $('.k-window-title').text(title);
    ele.content(content);
    ele.center();
    ele.open();
}

function editInspector(e) {

    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var InspectorId = dataItem.Id;
    if (InspectorId == undefined && InspectorId == null) {
        return;
    }

    var _urlToAction = '/InspectorAllocation/AddEditInspector';

    $.ajax({
        type: 'GET',
        url: _urlToAction,
        data: { Id: InspectorId },
        success: function (response) {
            var html = '';
            if (response) {
                html = response;

                if (html != null || html != undefined) {
                    ShowPopup('Update Inspector', html);
                    $('#SaveInspector').text('Update');
                }
            }
        }, error: function (response) {
            AlertError(response.responseText);
        }
    });
}

function deleteInspector(e) {
    
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var InspectorId = dataItem.Id;

    if (InspectorId == null || InspectorId == undefined) {
        return;
    }
    var _urlToAction = '/InspectorAllocation/DeleteInspector';

    swal({
        title: "Are you sure?",
        text: 'Inspector will be deleted.',
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {

                $.ajax({
                    type: 'POST',
                    url: _urlToAction,
                    data: { Id: InspectorId },
                    success: function (response) {
                        if (response.Data.IsSuccess == true) {
                            
                            var successMsg = response.Data.Message;
                            AlertSuccess(successMsg);
                        }
                    },
                    error: function (response) {
                        AlertError(response.responseText);
                    }
                });

            } else {

            }
        });
}

function onRowSelect() {
    if (this.select != null) {
        var data = this.dataItem(this.select());
        //window.location.href = "/Home/Index?Id=" + data.Id + "&IsAdmin=" + true;

        var _urlToAction = '/Home/UserForm';

        $.ajax({
            type: 'GET',
            url: _urlToAction,
            data: {
                Id: data.UserId,
                userFormId: data.Id,
                IsAdmin: true
            },
            success: function (response) {
                window.location.href = _urlToAction + "?Id=" + data.UserId + "&userFormId=" + data.Id + "&IsAdmin=" + false;
            }, error: function (response) {
                AlertValidation(response.responseText);
            }
        });
    }
    
}

function isDestroyVisible(dataItem) {

    if (dataItem.Role == "10001") {
        return false;
    }
    else {
        return true;
    }
}

function filterForms(e) {
    var id = e.filter.filters[0].value;
    return {
        inspectorId: $("#Id").val(),
        userId: id
    };
}