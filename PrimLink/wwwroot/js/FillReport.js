const ItemData = [];
const SamplingInformationData = [];
const ItemRemarkListData = [];
const AQLDefect = [];
const ItemAQLDefect = [];
const ShipperCartonPackaging = [];
const InnerPackaging = [];
const RetailPackaging = [];
const ItemOverall = [];
const OnSiteTestResult = [];
const ItemOtherPhotos = [];
const CustomerSpecialCheckPoints = [];
const SamplingInformation2 = [];
const defectPhotos = [];
const InspectionStandard = [];
const QuantityCheckResult = [];
const PackingandProductSpecificationModel = [];
const YourProducts = [];
const ImportantRemarks = [];
const DefectPhotosListData = [];
const InspectionStandardResultListData = [];
const BKResultListData = [];


function GetOverallResultForCheckpoints() {
    var notconformedCount = 0;
    var pendingCount = 0;
    $('.ddl1').each(function () {

        var selectedValue = $(this).val();
        if (selectedValue == 'notconformed') {
            $(this).closest('td').css('background-color', 'red');
            notconformedCount++;
        }
        if (selectedValue == 'pending') {
            $(this).closest('td').css('background-color', '#edad2e');
            pendingCount++;
        }
        if (selectedValue == 'conformed') {
            $(this).closest('td').css('background-color', 'green');
        }

        if ((selectedValue == 'notapplicable') || (selectedValue == 'notapplicable')) {
            $(this).closest('td').css('background-color', '#999999');
        }

        if ((selectedValue == '')) {
            $(this).closest('td').css('background-color', 'white');
        }


        var selectedtext = $(this).text();
        //console.log('selectedValue :' + selectedValue + ' selectedtext :' + selectedtext);
    });


    if ((notconformedCount == 0) && (pendingCount > 0)) {
        $('.CustomerSpecialCheckPointOverAllResult').text('Pending').closest('td').css('background-color', '#edad2e');

    }
    else if (notconformedCount > 0) {
        $('.CustomerSpecialCheckPointOverAllResult').text('Not conformed').closest('td').css('background-color', 'red');
    }
    else {
        $('.CustomerSpecialCheckPointOverAllResult').text('Conformed').closest('td').css('background-color', 'green');;
    }

}



function CalculatePackedCTNS() {
    var TotalSampleSizeFromPackedCTNS = 0;
    $('.SampleData').each(function () {
        //if (index > 1) {
        // Get the values from each cell in the current row
        var packedCTNS = $(this).find('.PackedCTNS').val();

        // Do something with the retrieved values (e.g., console.log, store in variables, etc.)
        if (packedCTNS === null || packedCTNS.trim() === "") {
            //console.log('packedCTNS is null or empty');
        } else {
            TotalSampleSizeFromPackedCTNS += parseInt(packedCTNS);
            //console.log('packedCTNS : ' + packedCTNS);
        }

        //}
    });

    $('.TotalSampleSizeFromPackedCTNS').val(TotalSampleSizeFromPackedCTNS);

    //console.log('TotalSampleSizeFromPackedCTNS : ' + TotalSampleSizeFromPackedCTNS);


}


function CalculateFinishedUnPacked() {
    var TotalSampleSizeFinishedUnPacked = 0;
    $('.SampleData').each(function () {

        var finishedUnpacked = $(this).find('.FinshedUnpacked').val();

        // Do something with the retrieved values (e.g., console.log, store in variables, etc.)
        if (finishedUnpacked === null || finishedUnpacked.trim() === "") {
            //console.log('packedCTNS is null or empty');
        } else {
            TotalSampleSizeFinishedUnPacked += parseInt(finishedUnpacked);
            console.log('TotalSampleSizeFinishedUnPacked : ' + TotalSampleSizeFinishedUnPacked);
        }

        //}
    });

    $('.TotalSampleSizeFinishedUnPacked').val(TotalSampleSizeFinishedUnPacked);

}


function CalculateInspectedCartonCTN() {
    var TotalInspectedCartonCTN = 0;
    $('.SampleData').each(function () {

        var InspectedCartonCTN = $(this).find('.InspectedCartonCTN').val();

        // Do something with the retrieved values (e.g., console.log, store in variables, etc.)
        if (InspectedCartonCTN === null || InspectedCartonCTN.trim() === "") {
            //console.log('packedCTNS is null or empty');
        } else {
            TotalInspectedCartonCTN += parseInt(InspectedCartonCTN);
            console.log('TotalInspectedCartonCTN : ' + InspectedCartonCTN);
        }

        //}
    });

    $('.TotalInspectedCartonCTN').val(TotalInspectedCartonCTN);

}

$(document).ready(function () {


    $(".hrefAddARemark").click(function () {
        var _html1 = '<tr class="tr_1">' + $('#tblDoc').find('tr:eq(0)').html() + '</tr>';
        _html1 += '<tr class="tr_2">' + $('#tblDoc').find('tr:eq(1)').html() + '</tr>';

        $('#tblDoc tr:last').after(_html1);

        var rowCount = $('#tblDoc tbody tr').length;
        if (rowCount >= 2) {
            $('#tblDoc tbody tr').find('.btnRemove').show();

        }


    });

    $(".hrefAddDefectPhotos").click(function () {
        var _html1 = '<tr class="tr_1">' + $('#tblDefectPhotos').find('tr:eq(0)').html() + '</tr>';
        $('#tblDefectPhotos tr:last').after(_html1);

        var rowCount = $('#tblDefectPhotos tbody tr').length;

        if (rowCount > 1) {
            $('#tblDefectPhotos tbody tr').find('.btnRemove').show();

        }


    });


    $("#tblDefectPhotos").on("click", ".btnRemove", function () {
        var tr1 = $(this).closest(".tr_1");
        tr1.remove();
        var rowCount = $('#tblDefectPhotos tbody tr').length;
        if (rowCount == 1) {
            $('#tblDefectPhotos tbody tr').find('.btnRemove').hide();
        }
        else {

            $('#tblDefectPhotos tbody tr').find('.btnRemove').show();
        }

    });

    $(".hrefAddAnAQLDefect").click(function () {

        var _html1 = '<tr class="tr_1">' + $('#tblAQLDefects').find('tr:eq(1)').html() + '</tr>';
        var _html2 = '<tr class="tr_2">' + $('#tblAQLDefects').find('tr:eq(2)').html() + '</tr>';
        var _htmlFinal = _html1 + _html2;
        $('#tblAQLDefects tr:last').after(_htmlFinal);


        var rowCount = $('#tblAQLDefects tbody tr').length;
        if (rowCount >= 2) {
            $('#tblAQLDefects tbody tr').find('.btnRemove').show();

        }
    });


    $(".hrefOnSiteTestResults").click(function () {

        var _html1 = '<tr class="tr_1">' + $('#tblOnSiteTestResults').find('tr:eq(1)').html() + '</tr>';
        var _html2 = '<tr class="tr_2">' + $('#tblOnSiteTestResults').find('tr:eq(2)').html() + '</tr>';
        var _htmlFinal = _html1 + _html2;
        $('#tblOnSiteTestResults tr:last').after(_htmlFinal);
        var rowCount = $('#tblOnSiteTestResults tbody tr').length;
        if (rowCount >= 2) {
            $('#tblOnSiteTestResults tbody tr').find('.btnRemove').show();

        }
    });





    $("#tblDoc").on("click", ".btnRemove", function () {
        var tr1 = $(this).closest(".tr_1");
        var tr2 = tr1.next(".tr_2");
        tr1.remove();
        tr2.remove();
        var rowCount = $('#tblDoc tbody tr').length;
        if (rowCount == 2) {
            $('#tblDoc tbody tr').find('.btnRemove').hide();
            //$('#tblDoc tbody').find('.tr_1').find('.btnRemove').hide();
        }
        else {

            $('#tblDoc tbody tr').find('.btnRemove').show();
        }

    });

    $("#tblAQLDefects").on("click", ".btnRemove", function () {
        var tr1 = $(this).closest(".tr_1");
        var tr2 = tr1.next(".tr_2");
        tr1.remove();
        tr2.remove();

        var rowCount = $('#tblAQLDefects').find('.tbodyAQLDefects tr').length;
        console.log('tblAQLDefects==' + rowCount)
        if (rowCount == 2) {
            $('#tblAQLDefects tbody tr').find('.btnRemove').hide();
        }
        else {

            $('#tblAQLDefects tbody tr').find('.btnRemove').show();
        }
    });




    $("#tblOnSiteTestResults").on("click", ".btnRemove", function () {
        var tr1 = $(this).closest(".tr_1");
        var tr2 = tr1.next(".tr_2");
        tr1.remove();
        tr2.remove();

        var rowCount = $('#tblOnSiteTestResults').find('.tbodytblOnSiteTestResults tr').length;
        if (rowCount == 2) {
            $('#tblOnSiteTestResults tbody tr').find('.btnRemove').hide();
        }
        else {

            $('#tblOnSiteTestResults tbody tr').find('.btnRemove').show();
        }
    });


    //
    $("#FrmSubmit").submit(function (event) {


        var url = window.location.href;
        var parts = url.split('/');
        var id = parts[parts.length - 1];

        // Create FormData and append the extracted value



        //alert('call');

        //event.preventDefault();
        //debugger;
        //FillDataToForm();

        event.preventDefault();

        var formData = new FormData();
        formData.append('id', id);

        //-------------------------- Start Your Product ------------------------------------------//


        var fileInputYourProduct = '';//$('.fileInputYourProduct')[0].files[0].name;
        //var fileInputYourProduct = file.name;
        if ($('.fileInputYourProduct')[0].files.length > 0) {

            fileInputYourProduct = $('.fileInputYourProduct')[0].files[0].name;
        }


        //var fileInputYourProduct = $(".fileInputYourProduct").val();
        formData.append('YourProducts[0].Path', fileInputYourProduct);
        formData.append('YourProducts[0].ReferenceId', id);


        //$('.fileInputYourProduct').each(function (index, element) {

        //    formData.append('files', $('.fileInputYourProduct')[index].files[0].name);
        //});


        $('.fileInputYourProduct').each(function (index, element) {

            //formData.append('files', $('.fileInputYourProduct')[index].files[0].name);
            var fileforYourProduct = '';// $('.fileInputYourProduct')[index].files[0];
            if ($('.fileInputYourProduct')[index].files.length > 0) {

                fileforYourProduct = $('.fileInputYourProduct')[index].files[0];
            }

            formData.append('files', fileforYourProduct);
        });


        //-------------------------- End Your Product ------------------------------------------//




        ////-------------------------- Start ImportantRemarks ------------------------------------------//


        $("#tblDoc .tr_1").each(function () {
            var ddlForAddARemark = $(this).find(".ddlForAddARemark").val();
            var textareaForAddARemark = $(this).find(".textareaForAddARemark").val();
            var fileInput = '';//$(this).closest('tr').next().find('.fileInput')[0].files[0];
            var filename = '';// fileInput.name;

            if ($(this).closest('tr').next().find('.fileInput')[0].files.length > 0) {

                fileInput = $(this).closest('tr').next().find('.fileInput')[0].files[0];
                filename = fileInput.name;
            }

            ImportantRemarks.push({
                "RemarkType": ddlForAddARemark,
                "Description": textareaForAddARemark,
                "FilePath": filename
            });
        });


        for (var i = 0; i < ImportantRemarks.length; i++) {
            var item = ImportantRemarks[i];

            formData.append('ImportantRemarks[' + i + '].RemarkType', item.RemarkType);
            formData.append('ImportantRemarks[' + i + '].Description', item.Description);
            formData.append('ImportantRemarks[' + i + '].FilePath', item.FilePath);
        }


        //formData.append('ImportantRemarks[0].RemarkType', 'ABC');

        $('.FileUploadForAddARemark').each(function (index, element) {
            var fileForAddARemark = '';// $('.FileUploadForAddARemark')[index].files[0];

            if ($('.FileUploadForAddARemark')[index].files.length > 0) {

                fileForAddARemark = $('.FileUploadForAddARemark')[index].files[0];
            }

            formData.append('files', fileForAddARemark);
        });
        ////-------------------------- End ImportantRemarks ------------------------------------------//



        //-------------------------- Start Customer Special Checkpoints ------------------------------------------//

        var ddlforCustomerCheckPointA = $(".ddlforCustomerCheckPointA").val();
        var textA = $(".textA").val();
        //var fileInputA = $('.fileInputA').val();
        var fileInputA = '';// $('.fileInputA')[0].files[0].name;

        if ($('.fileInputA')[0].files.length > 0) {

            fileInputA = $('.fileInputA')[0].files[0].name;
        }

        CustomerSpecialCheckPoints.push({
            "Type": 'A',
            "Status": ddlforCustomerCheckPointA,
            "Comment": textA,
            "FilePath": fileInputA
        });
        var ddlforCustomerCheckPointB = $(".ddlforCustomerCheckPointB").val();
        var textB = $(".textB").val();
        //var fileInputB = $('.fileInputB').val();
        var fileInputB = '';//$('.fileInputB')[0].files[0].name;


        if ($('.fileInputB')[0].files.length > 0) {

            fileInputB = $('.fileInputB')[0].files[0].name;
        }

        CustomerSpecialCheckPoints.push({
            "Type": 'B',
            "Status": ddlforCustomerCheckPointB,
            "Comment": textB,
            "FilePath": fileInputB
        });


        var overAllResult = document.querySelector('.CustomerSpecialCheckPointOverAllResult').textContent;
        for (var i = 0; i < CustomerSpecialCheckPoints.length; i++) {
            var item = CustomerSpecialCheckPoints[i];

            formData.append('CustomerSpecialCheckPoints[' + i + '].Type', item.Type);
            formData.append('CustomerSpecialCheckPoints[' + i + '].Result', item.Status);
            formData.append('CustomerSpecialCheckPoints[' + i + '].Description', item.Comment);
            formData.append('CustomerSpecialCheckPoints[' + i + '].FilePath', item.FilePath);
            formData.append('CustomerSpecialCheckPoints[' + i + '].OverAllResult', overAllResult);
        }


        $('.CustomerSpChkFileUload').each(function (index, element) {

            //console.log('CustomerSpChkFileUload==' + $('.CustomerSpChkFileUload')[index].files[0]);

            //formData.append('files', $('.CustomerSpChkFileUload')[index].files[0].name);
            var fileForSpChkFileUload = $('.CustomerSpChkFileUload')[index].files[0];
            formData.append('files', fileForSpChkFileUload);
        })
        //-------------------------- End Customer Special Checkpoints ------------------------------------------//

        //------------------------- Start Sampling Information 2 ----------------------------------------------------//

        var TotalSampleSizeFromPackedCTNS = $('.TotalSampleSizeFromPackedCTNS').val();
        var TotalSampleSizeFinishedUnPacked = $('.TotalSampleSizeFinishedUnPacked').val();
        var TotalInspectedCartonCTN = $('.TotalInspectedCartonCTN').val();

        var AllowDrawingSamplesNonPacked = $('.AllowDrawingSamplesNonPacked').val();
        var HundredPercentQtyForSampling = $('.HundredPercentQtyForSampling ').val();

        $('.SampleData').each(function (index) {

            var poNumber = $(this).find('.PONumber').text();
            var modelNumber = $(this).find('.ModelNumber').text();
            var packedCTNS = $(this).find('.PackedCTNS').val();
            var finishedUnpacked = $(this).find('.FinshedUnpacked').val();
            var inspectedCartonCTN = $(this).find('.InspectedCartonCTN').val();
            var inspectedCartonCTNNumber = $(this).find('.InspectedCartonCTNNumber').val();


            SamplingInformation2.push({
                "PONumber": poNumber,
                "ModelNumber": modelNumber,
                "SampleSizeFromPackedCTNS": packedCTNS,
                "SampleSizeFromFinishedUnPacked": finishedUnpacked,
                "InspectedCartonCTN": inspectedCartonCTN,
                "InspectedCartonNumber": inspectedCartonCTNNumber,
                "TotalSampleSizePackedCTNS": TotalSampleSizeFromPackedCTNS,
                "TotalSampleSizeFinishedUnpacked": TotalSampleSizeFinishedUnPacked,
                "TotalInspectedCartonCTN": TotalInspectedCartonCTN,
                "FactoryAllowsDrawingSamples": AllowDrawingSamplesNonPacked,
                "QuantityAvailableForSampling": HundredPercentQtyForSampling
            });



            for (var i = 0; i < SamplingInformation2.length; i++) {
                var item = SamplingInformation2[i];

                formData.append('SamplingInformation2[' + i + '].PONumber', item.PONumber);
                formData.append('SamplingInformation2[' + i + '].ModelNumber', item.ModelNumber);
                formData.append('SamplingInformation2[' + i + '].SampleSizeFromPackedCTNS', item.SampleSizeFromPackedCTNS);
                formData.append('SamplingInformation2[' + i + '].SampleSizeFromFinishedUnPacked', item.SampleSizeFromFinishedUnPacked);
                formData.append('SamplingInformation2[' + i + '].InspectedCartonCTN', item.InspectedCartonCTN);
                formData.append('SamplingInformation2[' + i + '].InspectedCartonNumber', item.InspectedCartonNumber);
                formData.append('SamplingInformation2[' + i + '].TotalSampleSizePackedCTNS', item.TotalSampleSizePackedCTNS);
                formData.append('SamplingInformation2[' + i + '].TotalSampleSizeFinishedUnpacked', item.TotalSampleSizeFinishedUnpacked);
                formData.append('SamplingInformation2[' + i + '].TotalInspectedCartonCTN', item.TotalInspectedCartonCTN);
                formData.append('SamplingInformation2[' + i + '].FactoryAllowsDrawingSamples', item.FactoryAllowsDrawingSamples);
                formData.append('SamplingInformation2[' + i + '].QuantityAvailableForSampling', item.QuantityAvailableForSampling);

            }

            //console.log('*******************************************************************************')
            //console.log('index #: ' + index);
            //// Do something with the retrieved values (e.g., console.log, store in variables, etc.)
            //console.log('PO #: ' + poNumber);
            //console.log('Model #: ' + modelNumber);
            //console.log('Sample Size from packed CTNS: ' + packedCTNS);
            //console.log('Sample Size from finished un-packed: ' + finishedUnpacked);
            //console.log('Inspected Carton CTN: ' + inspectedCartonCTN);
            //console.log('Inspected Carton CTN Number: ' + inspectedCartonCTNNumber);
            //console.log('*******************************************************************************')
            //}
        });


        //------------------------- End Sampling Information 2 ----------------------------------------------------//





        ////-------------------------- Start Defect Photos New------------------------------------------//


        $("#tblDefectPhotos .tr_1").each(function () {
            var ReferenceId = id;
            //var filename = $(this).find('.fileInputDefectPhotos').val();
            var filename = '';//$(this).find('.fileInputDefectPhotos')[0].files[0].name;

            if ($(this).find('.fileInputDefectPhotos')[0].files.length > 0) {

                filename = $(this).find('.fileInputDefectPhotos')[0].files[0].name;
            }


            var DefectType = $(this).find(".ddlDefectType").val();
            var LevelName = $(this).find(".ddlDefectLevelName").val();
            var LevelNo = $(this).find(".ddlDefectLevelNo").val();

            DefectPhotosListData.push({
                "ReferenceId": ReferenceId,
                "Path": filename,
                "DefectType": DefectType,
                "LevelName": LevelName,
                "LevelNo": LevelNo
            });
        });


        for (var i = 0; i < DefectPhotosListData.length; i++) {
            var item = DefectPhotosListData[i];

            formData.append('DefectPhotos[' + i + '].ReferenceId', item.ReferenceId);
            formData.append('DefectPhotos[' + i + '].Path', item.Path);
            formData.append('DefectPhotos[' + i + '].DefectType', item.DefectType);
            formData.append('DefectPhotos[' + i + '].LevelName', item.LevelName);
            formData.append('DefectPhotos[' + i + '].LevelNo', item.LevelNo);

        }


        //formData.append('ImportantRemarks[0].RemarkType', 'ABC');

        $('.fileInputDefectPhotos').each(function (index, element) {

            //formData.append('files', $('.fileInputDefectPhotos')[index].files[0].name);

            var fileForDefectPhotos = '';//$('.fileInputDefectPhotos')[index].files[0];
            if ($('.fileInputDefectPhotos')[index].files.length > 0) {
                fileForDefectPhotos = $('.fileInputDefectPhotos')[index].files[0];
            }

            formData.append('files', fileForDefectPhotos);
        });



        ////-------------------------- End Defect Photos New ------------------------------------------//



        ////-------------------------- Start InspectionStandardResults------------------------------------------//


        $("#tbInspectionStandard .tr_1").each(function () {

            var ReferenceId = id;

            var ddlPOORModelNo = $(this).find(".ddlPOORModelNo").val();
            var tdPictureNo = $(this).find(".tdPictureNo").val().replace("A", "");;
            var ddlDefectDesc = $(this).find(".ddlDefectDesc").val();
            var filename = '';//$(this).find('.fileInputInspectionStandardDefectPhoto')[0].files[0].name;
            if ($(this).find('.fileInputInspectionStandardDefectPhoto')[0].files.length > 0) {
                filename = $(this).find('.fileInputInspectionStandardDefectPhoto')[0].files[0].name;
            }
            var txtCritical = $(this).find(".txtCritical").val();
            var txtMajor = $(this).find(".txtMajor").val();
            var txtMinor = $(this).find(".txtMinor").val();
            var SampleSizeCritical = $(".SampleSizeCritical").val();
            var SampleSizeMajor = $(".SampleSizeMajor").val();
            var SampleSizeMinor = $(".SampleSizeMinor").val();

            var TotalfounddefectsCritical = $(".TotalfounddefectsCritical").val();
            var TotalfounddefectsMajor = $(".TotalfounddefectsMajor").val();
            var TotalfounddefectsMinor = $(".TotalfounddefectsMinor").val();

            var AQLAllowedDefectsCritical = $(".AQLAllowedDefectsCritical").val();
            var AQLAllowedDefectsMajor = $(".AQLAllowedDefectsMajor").val();
            var AQLAllowedDefectsMinor = $(".AQLAllowedDefectsMinor").val();

            var ddlAQLResults = $(".ddlAQLResults").val();
            var ddlGeneralDefectsFound = $(".ddlGeneralDefectsFound").val();
            var txtGeneralDefectDesc = $(".txtGeneralDefectDesc").val();
            var ddlNonConformityFound = $(".ddlNonConformityFound").val();
            var txtOverallResult = $(".txtOverallResult").val();

            InspectionStandardResultListData.push({
                "POorModelNo": ddlPOORModelNo,
                "PictureNo": tdPictureNo,
                "PhotoPath": filename,
                "DefectDescription": ddlDefectDesc,
                "Critical": txtCritical,
                "Major": txtMajor,
                "Minor": txtMinor,
                "SampleSizeCritical": SampleSizeCritical,
                "SampleSizeMajor": SampleSizeMajor,
                "SampleSizeMinor": SampleSizeMinor,
                "TotalFoundDefectsCritical": TotalfounddefectsCritical,
                "TotalFoundDefectsMajor": TotalfounddefectsMajor,
                "TotalFoundDefectsMinor": TotalfounddefectsMinor,
                "AQLAllowedDefectsCritical": AQLAllowedDefectsCritical,
                "AQLAllowedDefectsMajor": AQLAllowedDefectsMajor,
                "AQLAllowedDefectsMinor": AQLAllowedDefectsMinor,
                "AQLResults": ddlAQLResults,
                "GeneralDefectNotIncludedAQLResultAbove": ddlGeneralDefectsFound,
                "GeneralDefectDescription": txtGeneralDefectDesc,
                "NonConformityFound": ddlNonConformityFound,
                "NonConformityRemark": txtOverallResult


            });
        });


        for (var i = 0; i < InspectionStandardResultListData.length; i++) {
            var item = InspectionStandardResultListData[i];

            formData.append('InspectionStandardResults[' + i + '].POorModelNo', item.POorModelNo);
            formData.append('InspectionStandardResults[' + i + '].PictureNo', item.PictureNo);
            formData.append('InspectionStandardResults[' + i + '].PhotoPath', item.PhotoPath);
            formData.append('InspectionStandardResults[' + i + '].DefectDescription', item.DefectDescription);
            formData.append('InspectionStandardResults[' + i + '].Critical', item.Critical);
            formData.append('InspectionStandardResults[' + i + '].Major', item.Major);
            formData.append('InspectionStandardResults[' + i + '].Minor', item.Minor);
            formData.append('InspectionStandardResults[' + i + '].SampleSizeCritical', item.SampleSizeCritical);
            formData.append('InspectionStandardResults[' + i + '].SampleSizeMajor', item.SampleSizeMajor);
            formData.append('InspectionStandardResults[' + i + '].SampleSizeMinor', item.SampleSizeMinor);

            formData.append('InspectionStandardResults[' + i + '].TotalFoundDefectsCritical', item.TotalFoundDefectsCritical);
            formData.append('InspectionStandardResults[' + i + '].TotalFoundDefectsMajor', item.TotalFoundDefectsMajor);
            formData.append('InspectionStandardResults[' + i + '].TotalFoundDefectsMinor', item.TotalFoundDefectsMinor);
            formData.append('InspectionStandardResults[' + i + '].AQLAllowedDefectsCritical', item.AQLAllowedDefectsCritical);
            formData.append('InspectionStandardResults[' + i + '].AQLAllowedDefectsMajor', item.AQLAllowedDefectsMajor);



            formData.append('InspectionStandardResults[' + i + '].AQLAllowedDefectsMinor', item.AQLAllowedDefectsMinor);
            formData.append('InspectionStandardResults[' + i + '].AQLResults', item.AQLResults);
            formData.append('InspectionStandardResults[' + i + '].GeneralDefectNotIncludedAQLResultAbove', item.GeneralDefectNotIncludedAQLResultAbove);
            formData.append('InspectionStandardResults[' + i + '].GeneralDefectDescription', item.GeneralDefectDescription);
            formData.append('InspectionStandardResults[' + i + '].NonConformityFound', item.NonConformityFound);
            formData.append('InspectionStandardResults[' + i + '].NonConformityRemark', item.NonConformityRemark);


        }


        //formData.append('ImportantRemarks[0].RemarkType', 'ABC');

        $('.fileInputInspectionStandardDefectPhoto').each(function (index, element) {

            var fileInputInspectionPhoto = '';// $('.fileInputInspectionStandardDefectPhoto')[index].files[0];
            if ($('.fileInputInspectionStandardDefectPhoto')[index].files.length > 0) {
                fileInputInspectionPhoto = $('.fileInputInspectionStandardDefectPhoto')[index].files[0];
            }
            formData.append('files', fileInputInspectionPhoto);
        });



        ////-------------------------- End InspectionStandardResults ------------------------------------------//



        ////-------------------------- Start Booking RequirementsResults------------------------------------------//


        $("#tableQuantityCheck .productline").each(function () {
            debugger;
            var ReferenceId = id;
            var BKPONumber = $(this).find(".BKPONumber").val();
            var BKModelNo = $(this).find(".BKModelNo").val();
            var BKOrderQty = $(this).find(".BKOrderQty").val();

            var txtBKUnitsORCarton = $(this).find(".txtBKUnitsORCarton").val();

            var txtBKFinishedAndPackedUnits = $(this).find(".txtBKFinishedAndPackedUnits").val();
            var txtBKFinishedAndPackedCartons = $(this).find(".txtBKFinishedAndPackedCartons").val();

            var txtBKFinishedButNotPackedUnits = $(".txtBKFinishedButNotPackedUnits").val();
            var txtBKNotFinishedPackedUnits = $(".txtBKNotFinishedPackedUnits").val();
            var ddlBKResults = $(".ddlBKResults").val();



            var txtAQTotalFinishedAndPackedUnits = $(".txtAQTotalFinishedAndPackedUnits").val();
            var txtAQTotalFinishedAndPackedCartons = $(".txtAQTotalFinishedAndPackedCartons").val();
            var txtAQTotalFinishedButNotPackedUnits = $(".txtAQTotalFinishedButNotPackedUnits").val();
            var txtAQTotalNotFinishedPackedUnits = $(".txtAQTotalNotFinishedPackedUnits").val();
            var ddlBKOverAllResultTotal = $(".ddlBKOverAllResultTotal").val();


            var txtBKResultOrRemarks = $(".txtBKResultOrRemarks").val();

            if ($('.fileUploadForBK')[0].files.length > 0) {
                filename = $('.fileUploadForBK')[0].files[0].name;
            }


            BKResultListData.push({
                "PONumber": BKPONumber,
                "ModelNumber": BKModelNo,
                "OrderQtyUnits": BKOrderQty,
                "UnitOrCartoons": txtBKUnitsORCarton,
                "AQFinishedAndPackedUnits": txtBKFinishedAndPackedUnits,
                "AQFinishedAndPackedCartons": txtBKFinishedAndPackedCartons,
                "AQFinishedButNotPackedUnits": txtBKFinishedButNotPackedUnits,
                "AQNotFinishedPackedUnits": txtBKNotFinishedPackedUnits,
                "Results": ddlBKResults,
                "ResultsORRemarks": txtBKResultOrRemarks,
                "FilePath": filename,
                "AQTotalFinishedAndPackedUnits": txtAQTotalFinishedAndPackedUnits,
                "AQTotalFinishedAndPackedCartons": txtAQTotalFinishedAndPackedCartons,
                "AQTotalFinishedButNotPackedUnits": txtAQTotalFinishedButNotPackedUnits,
                "AQTotalNotFinishedPackedUnits": txtAQTotalNotFinishedPackedUnits

            });
        });


        for (var i = 0; i < BKResultListData.length; i++) {
            var item = BKResultListData[i];

            formData.append('BookingRequirementsResults[' + i + '].PONumber', item.PONumber);
            formData.append('BookingRequirementsResults[' + i + '].ModelNumber', item.ModelNumber);
            formData.append('BookingRequirementsResults[' + i + '].OrderQtyUnits', item.OrderQtyUnits);
            formData.append('BookingRequirementsResults[' + i + '].UnitOrCartoons', item.UnitOrCartoons);
            formData.append('BookingRequirementsResults[' + i + '].AQFinishedAndPackedUnits', item.AQFinishedAndPackedUnits);
            formData.append('BookingRequirementsResults[' + i + '].AQFinishedAndPackedCartons', item.AQFinishedAndPackedCartons);
            formData.append('BookingRequirementsResults[' + i + '].AQFinishedButNotPackedUnits', item.AQFinishedButNotPackedUnits);
            formData.append('BookingRequirementsResults[' + i + '].AQNotFinishedPackedUnits', item.AQNotFinishedPackedUnits);
            formData.append('BookingRequirementsResults[' + i + '].Results', item.Results);
            formData.append('BookingRequirementsResults[' + i + '].ResultsORRemarks', item.ResultsORRemarks);

            formData.append('BookingRequirementsResults[' + i + '].FilePath', item.FilePath);
            formData.append('BookingRequirementsResults[' + i + '].AQTotalFinishedAndPackedUnits', item.AQTotalFinishedAndPackedUnits);
            formData.append('BookingRequirementsResults[' + i + '].AQTotalFinishedAndPackedCartons', item.AQTotalFinishedAndPackedCartons);
            formData.append('BookingRequirementsResults[' + i + '].AQTotalFinishedButNotPackedUnits', item.AQTotalFinishedButNotPackedUnits);
            formData.append('BookingRequirementsResults[' + i + '].AQTotalNotFinishedPackedUnits', item.AQTotalNotFinishedPackedUnits);

        }


        $('.fileUploadForBK').each(function (index, element) {

            var fileUploadForBK1 = '';
            if ($('.fileUploadForBK')[index].files.length > 0) {
                fileUploadForBK1 = $('.fileUploadForBK')[index].files[0];
            }
            formData.append('files', fileUploadForBK1);
        });



        ////-------------------------- End Booking RequirementsResults ------------------------------------------//


        $.ajax({
            url: '/Report/SaveReport',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (result) {
                // Handle success response
                //console.log(result);
            },
            error: function (error) {
                // Handle error
                console.error(error);
            }
        });

        // If your function is successful, trigger the form submission
        // In this example, assuming yourFunction always returns true
        //$(this).off('submit').submit();

        //$(this).unbind('submit').submit();

    });


});

