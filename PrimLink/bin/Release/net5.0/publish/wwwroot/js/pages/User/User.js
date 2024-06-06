htmlLoader = '<div class="k-loading-mask" style="width: 100%; height: 100%; top: 0px; left: 0px;"><span class="k-loading-text">Loading...</span><div class="k-loading-image"></div><div class="k-loading-color"></div></div>';

$(document).ready(function () {
    var totalRef = $(".divReferenceLevel").length;
    var total = parseInt(0);
    for (var i = 0; i < totalRef; i++) {
        var quantity = $("#Quantity" + i).val();
        if (quantity != undefined && quantity != "") {
            total += parseInt(quantity);
        }
    }
    $("#total").empty();
    $("#total").append(total);
});

function onSaveGeneralInformation() {
    debugger
    $("#htmlLoader").html(htmlLoader);
    $("#htmlLoader").show();
    var frm = $("#generalInformationForm").data("kendoValidator");
    if (!frm.validate()) {
        $("#htmlLoader").hide();
        return false;
    }
    $('#SaveGeneralInformation').attr('disabled', 'disabled');
    $('#SaveGeneralInformation').addClass('k-state-disabled');

    var referenceList = [];
    var getLastId = $(".divReferenceLevel").last().attr('Id');
    for (var i = 0; i < getLastId; i++) {
        if ($("#Rowid-" + i).val() != undefined) {
            var detailObj =
            {
                "Id": $("#Rowid-" + i).val(),
                "GeneralInformationId": $("#GeneralInformationId-" + i).val(),
                "PO": $("#PO" + i).val(),
                "SKU": $("#SKU" + i).val(),
                "Name": $("#Name" + i).val(),
                "LevelNo": $("#LevelNo-" + i).val(),
                "Quantity": $("#Quantity" + i).val(),
                "ProductType": $("#ProductType" + i).val()
            };
            referenceList.push(detailObj);
        }
    }

    var vendor =
    {
        "Id": $("#vendorId").val(),
        "GeneralInformationId": $("#generalInformationId").val(),
        "VendorPreset": $("#VendorPreset").val(),
        "VendorCompanyName": $("#VendorCompanyName").val(),
        "CompanyPhoneNumber": $("#CompanyPhoneNumber").val(),
        "CompanyAddress": $("#CompanyAddress").val(),
        "Country": $("#Country").val(),
        "Province": $("#Province").val(),
        "City": $("#City").val(),
        "NatureOfVendor": $("#NatureOfVendor").val(),
        "FirstName": $("#FirstName").val(),
        "LastName": $("#LastName").val(),
        "Email": $("#Email").val(),
        "PhoneNumber": $("#PhoneNumber").val(),
        "IsVendorEmailIncluded": $("#isEmailIncluded").val().toLowerCase() == 'true' ? true : false,
    };
    var factory =
    {
        "Id": $("#factoryId").val(),
        "GeneralInformationId": $("#generalInformationId").val(),
        "FactoryPreset": $("#FactoryPreset").val(),
        "FactoryCompanyName": $("#FactoryCompanyName").val(),
        "FactoryEmail": $("#FactoryEmail").val(),
        "CompanyPhoneNumber": $("#CompanyPhoneNumber1").val(),
        "Address": $("#CompanyAddress1").val(),
        "Country": $("#Country1").val(),
        "Province": $("#Province1").val(),
        "City": $("#City1").val(),
        "PayByLC": $("#isPayByLC").val().toLowerCase() == 'true' ? true : false,
        "IsFactoryEmailIncluded": $("#isEmailIncluded1").val().toLowerCase() == 'true' ? true : false,
    };

    var model =
    {
        "Id": $("#Id").val(),
        "UserId": $("#userId").val(),
        "IsAdmin": $("#isAdmin").val(),
        "UserFormId": $("#userFormId").val(),
        "ProductLine": $("#ProductLine").val(),
        "ProductCategory": $("#ProductCategory").val(),
        "MinPercentProductToFinish": $("#MinPercentProductToFinish").val(),
        "MinPercentProductToFinishAndPacked": $("#MinPercentProductToFinishAndPacked").val(),
        "DestinationCountry": $("#DestinationCountry").val(),
        "QuantityUnit": $("#QuantityUnit").val(),
        "ServiceDate": $("#ServiceDate").val(),
        "ShipmentDate": $("#ShipmentDate").val(),
        "IsActive": true,
        "References": referenceList,
        "Vendor": vendor,
        "Factory": factory
    };
    $.ajax({
        url: '/GeneralInformation/AddEditGeneralInformation',
        data: model,
        type: "POST",
        success: function (response) {
            $("#htmlLoader").hide();
            var model = response.Data;
            AlertSuccess2(model.Message, $("#userId").val(), model.Id, model.IsAdmin);

        },
        error: function (error) {
            $("#htmlLoader").hide();
            AlertError(error.responseText);
            $('#SaveGeneralInformation').removeAttr('disabled');
            $('#SaveGeneralInformation').removeClass('k-state-disabled');
        }
    });
}

function AddLevel(Id) {
    if ($(".divReferenceLevel").length >= 10) {
        AlertValidation("Only 10 Levels are allowed.");
        return false;
    }
    var getLastId = $(".divReferenceLevel").last().attr('Id');
    $("#ItemNo").val(getLastId);
    var obj =
    {
        "Id": Id
    };
    $.ajax({
        url: '/GeneralInformation/AddNewLevel?model=' + obj + "&iterator=" + getLastId,
        type: 'Get',
        success: function (response) {
            $('#referencesLevels').append(response);
            //var getPrevId = getLastId - 1;
            //$("#deleteBtn_" + getPrevId).hide();
            //$("#deleteBtn_" + getLastId).show();
        },
        error: function (error) {
            $(".AddButton").removeAttr('disabled');
            AlertError(error.responseText);
        },
    });
}

function DeleteLevel(Id) {
    var getId = Id.split('-')[2];
    if (getId == null || getId == null || getId == undefined) {
        event.preventDefault();
        return;
    }
    else {
        $("#" + getId).remove();
        var getLastId = $(".divReferenceLevel").last().attr('Id');
        var getPrevId = getLastId - 1;
        $("#deleteBtn_" + getLastId).hide();
        $("#deleteBtn_" + getPrevId).show();

        var totalRef = $(".divReferenceLevel").length;
        var total = parseInt(0);
        for (var i = 0; i < totalRef; i++) {
            var quantity = $("#Quantity" + i).val();
            if (quantity != undefined && quantity != "") {
                total += parseInt(quantity);
            }
        }
        $("#total").empty();
        $("#total").append(total);
    }
}

function onClickExport() {
    $.ajax({
        url: '/GeneralInformation/DownloadTemplate',
        type: 'Post',
        success: function (response) {
            debugger
        },
        error: function (error) {
            AlertError(error.responseText);
        },
    });
}

function AlertSuccess(message, redirectionUrl) {
    swal({
        title: "Success!",
        text: message,
        icon: "success",
        button: "Ok",
        confirmButtonColor: '#f46930',
    }).then(function () {
        if (redirectionUrl != undefined && redirectionUrl != null) {
            location.reload();
        }
    });
}

function AlertSuccessSignUp(message, redirectionUrl) {
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

function AlertSuccess1(message, isAdmin) {
    swal({
        title: "Success!",
        text: message,
        icon: "success",
        button: "Ok",
        confirmButtonColor: '#f46930',
    }).then(function () {
        if (isAdmin == 'true' || isAdmin == true) {
            window.location.href = "/Admin/Index";
        }
        else {
            window.location.href = "/Home/Index";
        }

    });
}

function AlertSuccess2(message, userId, userFormId, isAdmin) {
    swal({
        title: "Success!",
        text: message,
        icon: "success",
        button: "Ok",
        confirmButtonColor: '#f46930',
    }).then(function () {
        window.location.href = '/Home/UserForm' + "?Id=" + userId + "&userFormId=" + userFormId + "&isAdmin=" + isAdmin;
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

function onSuccessSignUp(response) {
    var alert = response.Data;
    AlertSuccessSignUp(alert.Message);
}

function onFailure(response) {
    var alert = response.Data;
    AlertError(alert.Message);
}

function onFailureSignUp(response) {
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

function ShowPopupAttachment(title, content) {
    var ele = $("#AddEditAttachment").data("kendoWindow");
    $('.k-window-title').text(title);
    ele.content(content);
    ele.center();
    ele.open();
}

function ShowPopupSignUp(title, content) {
    var ele = $("#SignUpWindow").data("kendoWindow");
    $('.k-window-title').text(title);
    ele.content(content);
    ele.center();
    ele.open();
}

function showLoader() {
    $("#FileId_validationMessage").hide();

    var frm = $("#frmUploadFile").data("kendoValidator");
    var Id = $("#Id").val();
    if (Id == 0 || Id == undefined) {
        if (!frm.validate()) {
            return false;
        }
        if ($('#File')[0].value == "true" || $('#File')[0].value == true || $('#File')[0].value == "") {

            if (myObj.length == 0) {

                //AlertValidation("File is empty! Please select any File.");
                $("#FileId_validationMessage").show();
                $("#FileId_validationMessage").removeClass("k-hidden");
                return false;

            }
        }
    }
    else {
        if (!frm.validate()) {
            return false;
        }
        if ($('#File')[0].value == "true" || $('#File')[0].value == true || $('#File')[0].value == "") {
            if ($('#File')[0] == undefined) {
                if (myObj.length == 0) {
                    $("#FileId_validationMessage").show();
                    $("#FileId_validationMessage").removeClass("k-hidden");
                    //AlertValidation("File is empty! Please select any File.");
                    return false;

                }
            }
        }
        var source = $('#file')[0].src;
    }
    $("#htmlLoader").show();
    $("#htmlLoader").html(htmlLoader);
}

function onSuccessUpload(e) {
    var levels = $("#references").val();
    for (var i = 0; i < levels; i++) {
        var po = $("#PO" + i).data("kendoTextBox");
        var sku = $("#SKU" + i).data("kendoTextBox");
        var name = $("#Name" + i).data("kendoTextBox");
        var quantity = $("#Quantity" + i).data("kendoNumericTextBox");
        var productType = $("#ProductType" + i).data("kendoTextBox");
        var deleteBtn = $("#delete_" + i).attr('disabled', 'disabled');

        po.enable(false);
        sku.enable(false);
        name.enable(false);
        quantity.enable(false);
        productType.enable(false);
    }


    $("#btnAddLevel").kendoButton({
        enable: false
    }).data("kendoButton");
}

function onRemoveUpload(e) {

    var levels = $("#references").val();
    for (var i = 0; i < levels; i++) {
        var po = $("#PO" + i).data("kendoTextBox");
        var sku = $("#SKU" + i).data("kendoTextBox");
        var name = $("#Name" + i).data("kendoTextBox");
        var quantity = $("#Quantity" + i).data("kendoNumericTextBox");
        var productType = $("#ProductType" + i).data("kendoTextBox");
        var deleteBtn = $("#delete_" + i).removeClass('disabled');

        po.enable(true);
        sku.enable(true);
        name.enable(true);
        quantity.enable(true);
        productType.enable(true);
    }

    $("#btnAddLevel").kendoButton({
        enable: true
    }).data("kendoButton");
    $("#btnAddLevel").prop("disabled", false);
    $("#btnAddLevel").removeAttr('disabled');
    $("#btnAddLevel").removeClass('k-state-disabled');
    $("#btnAddLevel").removeClass('disabled');
}

function OnChangeQuantity() {
    var totalRef = $(".divReferenceLevel").length;
    var total = parseInt(0);
    for (var i = 0; i < totalRef; i++) {
        var quantity = $("#Quantity" + i).val();
        if (quantity != undefined && quantity != "") {
            total += parseInt(quantity);
        }
    }
    $("#total").empty();
    $("#total").append(total);
}

function onChangeStatus(e) {
    if (e.checked) {
        $("#isEmailIncluded").val(true); // for Active Status
    }
    else {
        $("#isEmailIncluded").val(false); // for InActive Status
    }
}

function onChangeStatus1(e) {

    if (e.checked) {
        $("#isEmailIncluded1").val(true); // for Active Status
    }
    else {
        $("#isEmailIncluded1").val(false); // for InActive Status
    }
}

function onChangeStatus2(e) {
    if (e.checked) {
        $("#isFinalReportToPerson").val(true); // for Active Status
    }
    else {
        $("#isFinalReportToPerson").val(false); // for InActive Status
    }
}

function onChangeStatus3(e) {

    if (e.checked) {
        $("#isFinalReportToVendor").val(true); // for Active Status
    }
    else {
        $("#isFinalReportToVendor").val(false); // for InActive Status
    }
}

function onChangeStatus4(e) {
    if (e.checked) {
        $("#isEmailIncluded2").val(true); // for Active Status
    }
    else {
        $("#isEmailIncluded2").val(false); // for InActive Status
    }
}

function onChangeStatus5(e) {

    if (e.checked) {
        $("#isUrgent").val(true); // for Active Status
    }
    else {
        $("#isUrgent").val(false); // for InActive Status
    }
}

function onChangeStatus6(e) {
    if (e.checked) {
        $("#isReferSample").val(true); // for Active Status
    }
    else {
        $("#isReferSample").val(false); // for InActive Status
    }
}

function onChangeStatus7(e) {

    if (e.checked) {
        $("#isCollectSample").val(true); // for Active Status
    }
    else {
        $("#isCollectSample").val(false); // for InActive Status
    }
}

function onChangeStatus8(e) {

    if (e.checked) {
        $("#isFunctionCheck").val(true); // for Active Status
    }
    else {
        $("#isFunctionCheck").val(false); // for InActive Status
    }
}

function onChangeStatus9(e) {
    if (e.checked) {
        $("#isQuantityCheck").val(true); // for Active Status
    }
    else {
        $("#isQuantityCheck").val(false); // for InActive Status
    }
}

function onChangeStatus10(e) {

    if (e.checked) {
        $("#isPkgePackShipCheck").val(true); // for Active Status
    }
    else {
        $("#isPkgePackShipCheck").val(false); // for InActive Status
    }
}

function onChangeStatus11(e) {
    if (e.checked) {
        $("#isProductLabelCheck").val(true); // for Active Status
    }
    else {
        $("#isProductLabelCheck").val(false); // for InActive Status
    }
}

function onChangeStatus12(e) {

    if (e.checked) {
        $("#isDimensionCheck").val(true); // for Active Status
    }
    else {
        $("#isDimensionCheck").val(false); // for InActive Status
    }
}

function onChangeStatus13(e) {

    if (e.checked) {
        $("#isOnSiteTest").val(true); // for Active Status
    }
    else {
        $("#isOnSiteTest").val(false); // for InActive Status
    }
}

function onChangePayByLC(e) {

    if (e.checked) {
        $("#isPayByLC").val(true); // for Active Status
        $("#PayByLC").val(true); // for Active Status
    }
    else {
        $("#isPayByLC").val(false); // for InActive Status
        $("#PayByLC").val(false); // for InActive Status
    }
}

function onChangeVendor(e) {

    if (e.checked) {
        $("#VendorPreset").data("kendoTextBox").enable(true);
        $("#VendorCompanyName").data("kendoTextBox").enable(true);
        $("#CompanyPhoneNumber").data("kendoTextBox").enable(true);
        $("#CompanyAddress").data("kendoTextBox").enable(true);
        $("#Country").data("kendoTextBox").enable(true);
        $("#Province").data("kendoTextBox").enable(true);
        $("#City").data("kendoTextBox").enable(true);
        $("#NatureOfVendor").data("kendoTextBox").enable(true);
        $("#FirstName").data("kendoTextBox").enable(true);
        $("#LastName").data("kendoTextBox").enable(true);
        $("#Email").data("kendoTextBox").enable(true);
        $("#PhoneNumber").data("kendoTextBox").enable(true);
        $("#IsVendorEmailIncluded").data("kendoSwitch").enable(true);
    }
    else {
        $("#VendorPreset").data("kendoTextBox").enable(false);
        $("#VendorCompanyName").data("kendoTextBox").enable(false);
        $("#CompanyPhoneNumber").data("kendoTextBox").enable(false);
        $("#CompanyAddress").data("kendoTextBox").enable(false);
        $("#Country").data("kendoTextBox").enable(false);
        $("#Province").data("kendoTextBox").enable(false);
        $("#City").data("kendoTextBox").enable(false);
        $("#NatureOfVendor").data("kendoTextBox").enable(false);
        $("#FirstName").data("kendoTextBox").enable(false);
        $("#LastName").data("kendoTextBox").enable(false);
        $("#Email").data("kendoTextBox").enable(false);
        $("#PhoneNumber").data("kendoTextBox").enable(false);
        $("#IsVendorEmailIncluded").data("kendoSwitch").enable(false);
    }
}

function onChangeFactory(e) {

    if (e.checked) {
        $("#FactoryPreset").data("kendoTextBox").enable(true);
        $("#FactoryCompanyName").data("kendoTextBox").enable(true);
        $("#FactoryEmail").data("kendoTextBox").enable(true);
        $("#CompanyPhoneNumber1").data("kendoTextBox").enable(true);
        $("#CompanyAddress1").data("kendoTextBox").enable(true);
        $("#Country1").data("kendoTextBox").enable(true);
        $("#Province1").data("kendoTextBox").enable(true);
        $("#City1").data("kendoTextBox").enable(true);
        $("#IsFactoryEmailIncluded").data("kendoSwitch").enable(true);
        $("#PayByLC").data("kendoSwitch").enable(true);
    }
    else {
        $("#FactoryPreset").data("kendoTextBox").enable(false);
        $("#FactoryCompanyName").data("kendoTextBox").enable(false);
        $("#FactoryEmail").data("kendoTextBox").enable(false);
        $("#CompanyPhoneNumber1").data("kendoTextBox").enable(false);
        $("#CompanyAddress1").data("kendoTextBox").enable(false);
        $("#Country1").data("kendoTextBox").enable(false);
        $("#Province1").data("kendoTextBox").enable(false);
        $("#City1").data("kendoTextBox").enable(false);
        $("#IsFactoryEmailIncluded").data("kendoSwitch").enable(false);
        $("#PayByLC").data("kendoSwitch").enable(false);
    }
}

function onClickApprove(userId) {
    $('.animated-button5').attr('disabled', 'disabled');
    $('.animated-button5').addClass('k-state-disabled');

    $('#FillTheReport').attr('disabled', 'disabled');
    $('#FillTheReport').addClass('k-state-disabled');

    $('#ViewTheReport').attr('disabled', 'disabled');
    $('#ViewTheReport').addClass('k-state-disabled');
    var _urlToAction = '/Home/Approved';

    var isAdmin = $("#isAdmin").val();
    var userFormId = $("#userFormId").val();
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
                        IsAdmin: isAdmin,
                        UserFormId: userFormId
                    },
                    success: function (response) {
                        $("#htmlLoader").hide();
                        $('.animated-button5').removeAttr('disabled');
                        $('.animated-button5').removeClass('k-state-disabled');

                        $('#FillTheReport').removeAttr('disabled');
                        $('#FillTheReport').removeClass('k-state-disabled');

                        var model = response.Data;
                        AlertSuccess1(model.Message, model.IsAdmin);
                        
                    }, error: function (response) {
                        $("#htmlLoader").hide();
                        $('.animated-button5').removeAttr('disabled');
                        $('.animated-button5').removeClass('k-state-disabled');

                        $('#FillTheReport').removeAttr('disabled');
                        $('#FillTheReport').removeClass('k-state-disabled');

                        $('#ViewTheReport').removeAttr('disabled');
                        $('#ViewTheReport').removeClass('k-state-disabled');
                        AlertValidation(response.responseText);
                    }
                });

            } else {
                $("#htmlLoader").hide();
                $('.animated-button5').removeAttr('disabled');
                $('.animated-button5').removeClass('k-state-disabled');
                $('#FillTheReport').removeAttr('disabled');
                $('#FillTheReport').removeClass('k-state-disabled');
                $('#ViewTheReport').removeAttr('disabled');
                $('#ViewTheReport').removeClass('k-state-disabled');
            }
        });
}

$("#UserFormGrid").on("click", "#addForm", function (e) {
    var userId = $("#userId").val();

    window.location.href = '/Home/UserForm' + "?Id=" + userId;
});

function editUser(e) {

    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var userId = dataItem.UserId;
    var userFormId = dataItem.Id;
    if (userId == undefined && userId == null) {
        return;
    }

    window.location.href = '/Home/UserForm' + "?Id=" + userId + "&userFormId=" + userFormId;
}

function deleteUser(e) {

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
                            debugger
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

function onFillTheReport() {
    var userId = $("#userId").val();
    var userFormId = $("#userFormId").val();
    if (userId == undefined && userId == null) {
        return;
    }

    window.location.href = '/Report/GetViewReport' + "?Id=" + 0;
}

function onViewTheReport() {
    debugger
    var userId = $("#userId").val();
    var userFormId = $("#userFormId").val();
    if (userId == undefined && userId == null) {
        return;
    }

    window.location.href = '/Report/GetViewReport' + "?Id=" + 0;
}

function onSaveSpecificationsInstruction() {
    debugger
    var frm = $("#specificationsInstructionForm").data("kendoValidator");
    if (!frm.validate()) {
        return false;
    }
    $('#SaveSpecificationsInstruction').attr('disabled', 'disabled');
    $('#SaveSpecificationsInstruction').addClass('k-state-disabled');

    var files = $("#Sifiles").getKendoUpload().getFiles();
    var formData = new FormData();

    if (files.length > 0) {
        for (var i = 0; i < files.length; i++) {
            formData.append("files", files[i].rawFile);
        }
    }
    var model =
    {
        "Id": $("#SiId").val(),
        "UserId": $("#userId").val(),
        "IsAdmin": $("#isAdmin").val(),
        "UserFormId": $("#userFormId").val(),
        "MeasurementPoints": $("#MeasurementPoints").val(),
        "Sizes": $("#Sizes").val(),
        "FinalReportToPerson": $("#isFinalReportToPerson").val().toLowerCase() == 'true' ? true : false,
        "FinalReportToVendor": $("#isFinalReportToVendor").val().toLowerCase() == 'true' ? true : false,
        "IsEmailIncluded": $("#isEmailIncluded2").val().toLowerCase() == 'true' ? true : false,
        "IsUrgent": $("#isUrgent").val().toLowerCase() == 'true' ? true : false,
        "IsActive": true
    };
    formData.append("model", JSON.stringify(model));

    $.ajax({
        url: '/SpecificationsInstructions/InsertUpdateSpecificationsInstructions',
        type: "POST",
        async: true,
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: formData,
        success: function (response) {
            var model = response.Data;
            AlertSuccess(model.Message, $("#userId").val());

        },
        error: function (error) {
            AlertError(error.responseText);
            $('#SaveGeneralInformation').removeAttr('disabled');
            $('#SaveGeneralInformation').removeClass('k-state-disabled');
        }
    });
}

function deleteAttachment(e) {
    debugger
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var Id = dataItem.Id;

    if (Id == null || Id == undefined) {
        return;
    }
    var _urlToAction = '/Attachments/DeleteAttachment';

    swal({
        title: "Are you sure?",
        text: 'Attachment will be deleted.',
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {

                $.ajax({
                    type: 'POST',
                    url: _urlToAction,
                    data: { Id: Id },
                    success: function (response) {
                        debugger
                        if (response.Data.IsSuccess == true) {

                            var successMsg = response.Data.Message;
                            AlertSuccess(successMsg);
                            $("#ClientAttachmentGrid").data("kendoGrid").dataSource.read();
                            $("#ClientAttachmentGrid").data('kendoGrid').refresh();
                        }
                    },
                    error: function (response) {
                        debugger
                        AlertError(response.responseText);
                        $("#ClientAttachmentGrid").data("kendoGrid").dataSource.read();
                        $("#ClientAttachmentGrid").data('kendoGrid').refresh();
                    }
                });

            } else {

            }
        });
}

function DownloadAttachment(Id) {
    debugger
    var getId = Id.split('-')[2];
    if (getId == null || getId == null || getId == undefined) {
        event.preventDefault();
        return;
    }
    else {
        window.location.href = "/SpecificationsInstructions/DownloadAttachment?Id=" + Id.split('-')[1];

    }
}

function downloadClientAttachment(e) {
    debugger
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var Id = dataItem.Id;
    window.location.href = "/Attachments/DownloadAttachment?Id=" + Id;
}

function validateNumericInput(e) {
    var input = e.sender;
    var inputValue = input.value();
    var sanitizedValue = inputValue.replace(/[^0-9+\-]/g, ''); // Remove non-numeric, +, and - characters
    input.value(sanitizedValue);
}

$("#ClientAttachmentGrid").on("click", "#addAttachment", function (e) {
    var gridview = $("#ClientAttachmentGrid").data("kendoGrid");
    var dataItem = gridview.dataItem(e.currentTarget.parentNode.parentNode);
    var Id = dataItem != undefined ? dataItem.UserId : 0;
    var FormId = dataItem != undefined ? dataItem.UserFormId : 0;
    $.ajax({
        type: "Get",
        url: '/Attachments/AddEditAttachment?UserId=' + Id + '&UserFormId=' + FormId,
        success: function (response) {

            ShowPopupAttachment("Add Attachments", response);
        }
    })
});

function onCancelAttachment() {
    $("#AddEditAttachment").data("kendoWindow").close();
}

function onCancelSignUp() {
    $("#SignUpWindow").data("kendoWindow").close();
}

function onSaveAttachment() {
    debugger
    $("#htmlLoaderAttachment").html(htmlLoader);
    $("#htmlLoaderAttachment").show();
    var filesAttachment = $("#filesAttachment").getKendoUpload().getFiles();
    var formData1 = new FormData();

    if (filesAttachment.length > 0) {
        for (var i = 0; i < filesAttachment.length; i++) {
            formData1.append("filesAttachment", filesAttachment[i].rawFile);
        }
    }

    var modelAttachment =
    {
        "UserId": $("#userId").val(),
        "IsAdmin": $("#isAdmin").val(),
        "UserFormId": $("#userFormId").val(),
        "Description": $("#txt_Description").val(),
        "FileType": $("#fileType").val(),
        "IsActive": true
    };
    formData1.append("model", JSON.stringify(modelAttachment));

    $.ajax({
        url: '/Attachments/InsertAttachments',
        type: "POST",
        async: true,
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: formData1,
        success: function (response) {
            debugger
            $("#htmlLoaderAttachment").hide();
            var model = response.Data;
            AlertSuccessAttachment(model.Message, $("#userId").val());

        },
        error: function (error) {
            $("#htmlLoaderAttachment").hide();
            AlertError(error.responseText);
        }
    });
}

function AlertSuccessAttachment(message, redirectionUrl) {
    swal({
        title: "Success!",
        text: message,
        icon: "success",
        button: "Ok",
        confirmButtonColor: '#f46930',
    }).then(function () {
        $("#AddEditAttachment").data("kendoWindow").close();
        $("#ClientAttachmentGrid").data("kendoGrid").dataSource.read();
        $("#ClientAttachmentGrid").data('kendoGrid').refresh();
    });
}

function SignUpPopup() {
    debugger
    $.ajax({
        type: "Get",
        url: '/Login/SignUpPopup',
        success: function (response) {
            ShowPopupSignUp("Create an Account", response);
        }
    })
}