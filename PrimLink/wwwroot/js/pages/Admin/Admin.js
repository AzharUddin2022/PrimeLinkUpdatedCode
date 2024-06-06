htmlLoader = '<div class="k-loading-mask" style="width: 100%; height: 100%; top: 0px; left: 0px;"><span class="k-loading-text">Loading...</span><div class="k-loading-image"></div><div class="k-loading-color"></div></div>';

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

    this.expandRow(!this.tbody.find("tr.k-master-row").first());
}

$("#UserGrid").on("click", "#addUser", function (e) {
    var gridview = $("#UserGrid").data("kendoGrid");
    var dataItem = gridview.dataItem(e.currentTarget.parentNode.parentNode);
    var Id = dataItem != undefined ? dataItem.Id : 0;
    $.ajax({
        type: "Get",
        url: '/Admin/AddEditUser?Id=' + Id,
        success: function (response) {

            ShowPopup("Add User", response);
        }
    })
});

function onCancel() {
    $("#AddEditUser").data("kendoWindow").close();
}

function onCancelRequest() {
    $("#AddEditUserRequest").data("kendoWindow").close();
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
    var ele = $("#AddEditUser").data("kendoWindow");
    $('.k-window-title').text(title);
    ele.content(content);
    ele.center();
    ele.open();
}

function ShowPopupUserRequest(title, content) {
    var ele = $("#AddEditUserRequest").data("kendoWindow");
    $('.k-window-title').text(title);
    ele.content(content);
    ele.center();
    ele.open();
}

function validateNumericInput(e) {
    var input = e.sender;
    var inputValue = input.value();
    var sanitizedValue = inputValue.replace(/[^0-9+\-]/g, ''); // Remove non-numeric, +, and - characters
    input.value(sanitizedValue);
}

function approveUser(e) {

    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var userId = dataItem.Id;
    if (userId == undefined && userId == null) {
        return;
    }

    var _urlToAction = '/Admin/AddEditUserRequest';

    $.ajax({
        type: 'GET',
        url: _urlToAction,
        data: { Id: userId, Status: 'Approved' },
        success: function (response) {
            var html = '';
            if (response) {
                html = response;

                if (html != null || html != undefined) {
                    ShowPopupUserRequest('Approve User Request', html);
                    $('#SaveUser').text('Approve');
                }
            }
        }, error: function (response) {
            AlertError(response.responseText);
        }
    });
}

function editUser(e) {

    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var userId = dataItem.Id;
    if (userId == undefined && userId == null) {
        return;
    }

    var _urlToAction = '/Admin/AddEditUser';

    $.ajax({
        type: 'GET',
        url: _urlToAction,
        data: { Id: userId },
        success: function (response) {
            var html = '';
            if (response) {
                html = response;

                if (html != null || html != undefined) {
                    ShowPopup('Update User', html);
                    $('#SaveUser').text('Update');
                }
            }
        }, error: function (response) {
            AlertError(response.responseText);
        }
    });
}

function rejectUser(e) {

    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var userId = dataItem.Id;

    if (userId == null || userId == undefined) {
        return;
    }
    var _urlToAction = '/Admin/DeleteUser';

    swal({
        title: "Are you sure?",
        text: 'User will be rejected.',
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {

                $.ajax({
                    type: 'POST',
                    url: _urlToAction,
                    data: { Id: userId },
                    success: function (response) {
                        if (response.Data.IsSuccess == true) {

                            var successMsg = response.Data.Message;
                            AlertSuccess("User rejected successfully");
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

function deleteUser(e) {

    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var userId = dataItem.Id;

    if (userId == null || userId == undefined) {
        return;
    }
    var _urlToAction = '/Admin/DeleteUser';

    swal({
        title: "Are you sure?",
        text: 'User will be deleted.',
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {

                $.ajax({
                    type: 'POST',
                    url: _urlToAction,
                    data: { Id: userId },
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

function deleteUser1(e) {

    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var userId = dataItem.Id;

    if (userId == null || userId == undefined) {
        return;
    }
    var _urlToAction = '/Home/DeleteForm';

    swal({
        title: "Are you sure?",
        text: 'Form will be deleted.',
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {

                $.ajax({
                    type: 'POST',
                    url: _urlToAction,
                    data: { Id: userId },
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

function isDestroyVisible(dataItem) {

    if (dataItem.Role == "10001") {
        return false;
    }
    else {
        return true;
    }
}

function onRowSelect() {
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
            window.location.href = _urlToAction + "?Id=" + data.UserId + "&userFormId=" + data.Id + "&IsAdmin=" + true;
        }, error: function (response) {
            AlertValidation(response.responseText);
        }
    });
}

function onClickApprove(userId) {
    
    var _urlToAction = '/Home/Approved';

    var isAdmin = $("#isAdmin").val();
    swal({
        title: "Are you sure?",
        text: 'You want to approve this Form?',
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((yes) => {
            if (yes) {
                $("#htmlLoader").html(htmlLoader);
                $("#htmlLoader").show();
                $.ajax({
                    type: 'GET',
                    url: _urlToAction,
                    data: {
                        Id: userId,
                        IsAdmin: isAdmin
                    },
                    success: function (response) {
                        $("#htmlLoader").hide();
                        var model = response.Data;
                        AlertSuccess1(model.Message, 'true');
                    }, error: function (response) {
                        $("#htmlLoader").hide();
                        AlertValidation(response.responseText);
                    }
                });

            } else {
                $("#htmlLoader").hide();
            }
        });
}
var isTitleAllow = false;
function locNameKeyUp(obj) {

    var input = $(obj);
    $.ajax({
        url: '/Admin/IsEmailAlreadyExist',
        data: { Email: input.val(), Id: $("#Id").val() },
        dataType: "json",
        type: 'post',
        async: false,
        success: function (response) {
            if (response) {
                $('#lblEmail').hide();
                $('#SaveUser').removeAttr('disabled');
                isTitleAllow = true;
            }
            else {
                $('#lblEmail').show();
                $('#SaveUser').attr('disabled', 'disabled');
                isTitleAllow = false;
            }
        },
        error: function (error) {
            AlertError(error.responseText);
        }
    });
}

//function locNameKeyUp1(obj) {

//    var input = $(obj);
//    $.ajax({
//        url: '/Admin/IsUsernameAlreadyExist',
//        data: { Username: input.val(), Id: $("#Id").val() },
//        dataType: "json",
//        type: 'post',
//        async: false,
//        success: function (response) {
//            if (response) {
//                $('#lblUsername').hide();
//                $('#SaveUser').removeAttr('disabled');
//                isTitleAllow = true;
//            }
//            else {
//                $('#lblUsername').show();
//                $('#SaveUser').attr('disabled', 'disabled');
//                isTitleAllow = false;
//            }
//        },
//        error: function (error) {
//            AlertError(error.responseText);
//        }
//    });
//}