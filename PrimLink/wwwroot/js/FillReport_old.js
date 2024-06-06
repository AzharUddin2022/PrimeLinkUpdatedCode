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

$(document).ready(function () {

    //$('.fileInput').change(function (event) {
    //    var selectedFile = event.target.files[0];

    //    if (selectedFile) {
    //        //console.log('Selected file name:', selectedFile.name);
    //        //console.log('Selected file type:', selectedFile.type);
    //        //console.log('Selected file size:', selectedFile.size, 'bytes');
    //        var hiddenField = $(this).closest('tr').find('.hiddenField');
    //        hiddenField.val(selectedFile.name);
    //    }
    //});



    $(".hrefAddARemark").click(function () {
        var _html1 = '<tr class="tr_1">' + $('#tblDoc').find('tr:eq(0)').html() + '</tr>';
        _html1 += '<tr class="tr_2">' + $('#tblDoc').find('tr:eq(1)').html() + '</tr>';

        $('#tblDoc tr:last').after(_html1);

        var rowCount = $('#tblDoc tbody tr').length;
        if (rowCount >= 2) {
            $('#tblDoc tbody tr').find('.btnRemove').show();
            
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

        //alert('call');

        //event.preventDefault();
        //debugger;
        //FillDataToForm();

        event.preventDefault();

        var formData = new FormData();

        //-------------------------- Start SamplingInformationData ------------------------------------------//

        var txtTotalCartonsNumForSamplingInfo = $('.txtTotalCartonsNumForSamplingInfo').val();
        var txtSelectedCartonsNumForSamplingInfo = $('.txtSelectedCartonsNumForSamplingInfo').val();

        SamplingInformationData.push({
            "TotalCartonsNum": txtTotalCartonsNumForSamplingInfo, "SelectedCartonsNum": txtSelectedCartonsNumForSamplingInfo
        });



        for (var i = 0; i < SamplingInformationData.length; i++) {
            var item = SamplingInformationData[i];
            console.log(item.TotalCartonsNum)
            console.log(item.SelectedCartonsNum)
            formData.append('SamplingInformationData[' + i + '].TotalCartonsNum', item.TotalCartonsNum);
            formData.append('SamplingInformationData[' + i + '].SelectedCartonsNum', item.SelectedCartonsNum);
        }

        //-------------------------- End SamplingInformationData ------------------------------------------//

        //-------------------------- Start ItemRemarkListData ------------------------------------------//

        $("#tblDoc .tr_1").each(function () {
            var ddlForAddARemark = $(this).find(".ddlForAddARemark").val();
            var textareaForAddARemark = $(this).find(".textareaForAddARemark").val();
            var fileInput = $(this).closest('tr').next().find('.fileInput');
            var filename = fileInput.val();
            ItemRemarkListData.push({
                "ItemRemarkStatus": ddlForAddARemark,
                "ItemRemarkComments": textareaForAddARemark,
                "FilePath": filename
            });
        });

        //ItemRemarkListData
        for (var i = 0; i < ItemRemarkListData.length; i++) {
            var item = ItemRemarkListData[i];

            formData.append('ItemRemarkListData[' + i + '].ItemRemarkStatus', item.ItemRemarkStatus);
            formData.append('ItemRemarkListData[' + i + '].ItemRemarkComments', item.ItemRemarkComments);
            formData.append('ItemRemarkListData[' + i + '].FilePath', item.FilePath);
        }
        //-------------------------- End ItemRemarkListData ------------------------------------------//



        //-------------------------- Start ItemData ------------------------------------------//

        $('.txtUnitsOrCartonForItem').each(function (index, element) {
            var txtUnitsOrCartonForItem = $(element).val();
            var txtPackedUnitsForItem = $('.txtPackedUnitsForItem').eq(index).val();
            var txtPackedCartonsForItem = $('.txtPackedCartonsForItem').eq(index).val();
            var txtFinishedUnpackedForItem = $('.txtFinishedUnpackedForItem').eq(index).val();
            var txtNotFinishedUnitsForItem = $('.txtNotFinishedUnitsForItem').eq(index).val();
            var ddlOverallResultForItem = $('.ddlOverallResultForItem').eq(index).find(":selected").val();

            formData.append('ItemData[' + index + '].UnitsOrCarton', txtUnitsOrCartonForItem);
            formData.append('ItemData[' + index + '].PackedUnits', txtPackedUnitsForItem);
            formData.append('ItemData[' + index + '].PackedCartons', txtPackedCartonsForItem);
            formData.append('ItemData[' + index + '].FinishedUnpacked', txtFinishedUnpackedForItem);
            formData.append('ItemData[' + index + '].NotFinishedUnits', txtNotFinishedUnitsForItem);
            formData.append('ItemData[' + index + '].OverallResult', ddlOverallResultForItem);
        });

        //-------------------------- End ItemData ------------------------------------------//



        //-------------------------- Start  Item AQL Defect ------------------------------------------//

        debugger;
        var txtLotSizeForItemAQLDefect = $('.txtLotSizeForItemAQLDefect').val();
        
        var ddlInspectionlevelForItemAQLDefect = $('.ddlInspectionlevelForItemAQLDefect').find(":selected").val();


        var txtSampleSize_Critical_ForItemAQLDefect = $('.txtSampleSize_Critical_ForItemAQLDefect').val();
        var txtSampleSize_Major_ForItemAQLDefect = $('.txtSampleSize_Major_ForItemAQLDefect').val();
        var txtSampleSize_Minor_ForItemAQLDefect = $('.txtSampleSize_Minor_ForItemAQLDefect').val();


        var ddlSampleSize_Critical_ForItemAQLDefect = $('.ddlSampleSize_Critical_ForItemAQLDefect').find(":selected").val();
        var ddlSampleSize_Major_ForItemAQLDefect = $('.ddlSampleSize_Major_ForItemAQLDefect').find(":selected").val();
        var ddlSampleSize_Minor_ForItemAQLDefect = $('.ddlSampleSize_Minor_ForItemAQLDefect').find(":selected").val();


        var txtMaxDefectAllowed_Critical_ForItemAQLDefect = $('.txtMaxDefectAllowed_Critical_ForItemAQLDefect').val();
        var txtMaxDefectAllowed_Major_ForItemAQLDefect = $('.txtMaxDefectAllowed_Major_ForItemAQLDefect').val();
        var txtMaxDefectAllowed_Minor_ForItemAQLDefect = $('.txtMaxDefectAllowed_Minor_ForItemAQLDefect').val();


        var txtMaxDefectsFound_Critical_ForItemAQLDefect = $('.txtMaxDefectsFound_Critical_ForItemAQLDefect').val();
        var txtMaxDefectsFound_Major_ForItemAQLDefect = $('.txtMaxDefectsFound_Major_ForItemAQLDefect').val();
        var txtMaxDefectsFound_Minor_ForItemAQLDefect = $('.txtMaxDefectsFound_Minor_ForItemAQLDefect').val();


        var ddlAOLResultForItemAQLDefect = $('.ddlAOLResultForItemAQLDefect').find(":selected").val();




        ItemAQLDefect.push({
            "LotSize": txtLotSizeForItemAQLDefect,
            "Inspectionlevel": ddlInspectionlevelForItemAQLDefect,

            "SampleSizeCritical": txtSampleSize_Critical_ForItemAQLDefect,
            "SampleSizeMajor": txtSampleSize_Major_ForItemAQLDefect,
            "SampleSizeMinor": txtSampleSize_Minor_ForItemAQLDefect,


            "AQLCritical": ddlSampleSize_Critical_ForItemAQLDefect,
            "AQLMajor": ddlSampleSize_Major_ForItemAQLDefect,
            "AQLMinor": ddlSampleSize_Minor_ForItemAQLDefect,


            "MaxDefectsAllowedCritical": txtMaxDefectAllowed_Critical_ForItemAQLDefect,
            "MaxDefectsAllowedMajor": txtMaxDefectAllowed_Major_ForItemAQLDefect,
            "MaxDefectsAllowedMinor": txtMaxDefectAllowed_Minor_ForItemAQLDefect,


            "DefectsAllowedCritical": txtMaxDefectsFound_Critical_ForItemAQLDefect,
            "DefectsAllowedMajor": txtMaxDefectsFound_Major_ForItemAQLDefect,
            "DefectsAllowedMinor": txtMaxDefectsFound_Minor_ForItemAQLDefect,

            "AQLResult": ddlAOLResultForItemAQLDefect



        });


        for (var i = 0; i < ItemAQLDefect.length; i++) {
            var item = ItemAQLDefect[i];
            formData.append('ItemAQLDefect[' + i + '].LotSize', item.LotSize);
            formData.append('ItemAQLDefect[' + i + '].Inspectionlevel', item.Inspectionlevel);
            formData.append('ItemAQLDefect[' + i + '].SampleSizeCritical', item.SampleSizeCritical);
            formData.append('ItemAQLDefect[' + i + '].SampleSizeMajor', item.SampleSizeMajor);
            formData.append('ItemAQLDefect[' + i + '].SampleSizeMinor', item.SampleSizeMinor);
            formData.append('ItemAQLDefect[' + i + '].AQLCritical', item.AQLCritical);
            formData.append('ItemAQLDefect[' + i + '].AQLMajor', item.AQLMajor);
            formData.append('ItemAQLDefect[' + i + '].AQLMinor', item.AQLMinor);
            formData.append('ItemAQLDefect[' + i + '].MaxDefectsAllowedCritical', item.MaxDefectsAllowedCritical);
            formData.append('ItemAQLDefect[' + i + '].MaxDefectsAllowedMajor', item.MaxDefectsAllowedMajor);
            formData.append('ItemAQLDefect[' + i + '].MaxDefectsAllowedMinor', item.MaxDefectsAllowedMinor);
            formData.append('ItemAQLDefect[' + i + '].DefectsAllowedCritical', item.DefectsAllowedCritical);
            formData.append('ItemAQLDefect[' + i + '].DefectsAllowedMajor', item.DefectsAllowedMajor);
            formData.append('ItemAQLDefect[' + i + '].DefectsAllowedMinor', item.DefectsAllowedMinor);
            formData.append('ItemAQLDefect[' + i + '].AQLResult', item.AQLResult);
        }

        //-------------------------- End  Item AQL Defect ------------------------------------------//



        //-------------------------- Start AQL Defect ------------------------------------------//

        $("#tblAQLDefects .tr_1").each(function () {

            var ddlDefectsForAQLDefects = $(this).find(".ddlDefectsForAQLDefects").val();
            //var ddlDefectsForAQLDefects = $(".ddlDefectsForAQLDefects optgroup:selected option:first-child").text();
            //var selectedOptgroupValue = $(".ddlDefectsForAQLDefects optgroup:selected option:first-child").val();

            var txtRemarkContentForAQLDefects = $(this).find(".txtRemarkContentForAQLDefects").val();
            var txtCriticalForAQLDefects = $(this).find(".txtCriticalForAQLDefects").val();
            var txtMajorForAQLDefects = $(this).find(".txtMajorForAQLDefects").val();
            var txtMinorForAQLDefects = $(this).find(".txtMinorForAQLDefects").val();
            var fileInput = $(this).closest('tr').next().find('.fileInput');
            var filename = fileInput.val();

            AQLDefect.push({
                "Defects": ddlDefectsForAQLDefects,
                "RemarkContent": txtRemarkContentForAQLDefects,
                "Major": txtMajorForAQLDefects,
                "Critical": txtCriticalForAQLDefects,
                "Minor": txtMinorForAQLDefects,
                "FilePath": filename
            });
        });


        for (var i = 0; i < AQLDefect.length; i++) {
            var item = AQLDefect[i];
            formData.append('AQLDefect[' + i + '].Defects', item.Defects);
            formData.append('AQLDefect[' + i + '].RemarkContent', item.RemarkContent);
            formData.append('AQLDefect[' + i + '].Major', item.Major);
            formData.append('AQLDefect[' + i + '].Critical', item.Critical);
            formData.append('AQLDefect[' + i + '].Minor', item.Minor);
            formData.append('AQLDefect[' + i + '].FilePath', item.FilePath);

        }

        //-------------------------- End AQL Defect ------------------------------------------//

        //-------------------------- Start Shipper Carton Packaging------------------------------------------//

        var ddlShipperCartonDimensions_Result = $(".ddlShipperCartonDimensions_Result").find(":selected").val();
        var txtShipperCartonDimensions_MeasuredData = $(".txtShipperCartonDimensions_MeasuredData").val();

        var ddlShipperCartonWeight_Result = $(".ddlShipperCartonDimensions_Result").find(":selected").val();
        var txtShipperCartonWeight_MeasuredData = $(".txtShipperCartonWeight_MeasuredData").val();

        var ddlShipperCartonMarkingsLabeling_Result = $(".ddlShipperCartonMarkingsLabeling_Result").find(":selected").val();
        var ddlPackagingMethodAssortment_Result = $(".ddlPackagingMethodAssortment_Result").find(":selected").val();



        ShipperCartonPackaging.push({
            "ShipperCartonDimensionsResult": ddlShipperCartonDimensions_Result,
            "ShipperCartonDimensionsMeasuredData": txtShipperCartonDimensions_MeasuredData,
            "ShipperCartonWeightResult": ddlShipperCartonWeight_Result,
            "ShipperCartonWeightMeasuredData": txtShipperCartonWeight_MeasuredData,
            "ShipperCartonMarkingsLabelingResult": ddlShipperCartonMarkingsLabeling_Result,
            "PackagingMethodAssortmentResult": ddlPackagingMethodAssortment_Result,
        });


        for (var i = 0; i < ShipperCartonPackaging.length; i++) {
            var item = ShipperCartonPackaging[i];
            formData.append('ShipperCartonPackaging[' + i + '].ShipperCartonDimensionsResult', item.ShipperCartonDimensionsResult);
            formData.append('ShipperCartonPackaging[' + i + '].ShipperCartonDimensionsMeasuredData', item.ShipperCartonDimensionsMeasuredData);
            formData.append('ShipperCartonPackaging[' + i + '].ShipperCartonWeightResult', item.ShipperCartonWeightResult);
            formData.append('ShipperCartonPackaging[' + i + '].ShipperCartonWeightMeasuredData', item.ShipperCartonWeightMeasuredData);
            formData.append('ShipperCartonPackaging[' + i + '].ShipperCartonMarkingsLabelingResult', item.ShipperCartonMarkingsLabelingResult);
            formData.append('ShipperCartonPackaging[' + i + '].PackagingMethodAssortmentResult', item.PackagingMethodAssortmentResult);
        }


        //-------------------------- End Shipper Carton Packaging------------------------------------------//


        //-------------------------- Start Inner Packaging------------------------------------------//

        var ddlInnerPackagingMarkingsLabeling = $(".ddlInnerPackagingMarkingsLabeling").find(":selected").val();
        var ddlInnerPackagingMethodAssortment_Result = $(".ddlInnerPackagingMethodAssortment_Result").find(":selected").val();

        InnerPackaging.push({
            "InnerPackagingMarkingsLabeling": ddlInnerPackagingMarkingsLabeling,
            "InnerPackagingMethodAssortmentResult": ddlInnerPackagingMethodAssortment_Result,
        });

        for (var i = 0; i < InnerPackaging.length; i++) {
            var item = InnerPackaging[i];
            formData.append('InnerPackaging[' + i + '].InnerPackagingMarkingsLabeling', item.InnerPackagingMarkingsLabeling);
            formData.append('InnerPackaging[' + i + '].InnerPackagingMethodAssortmentResult', item.InnerPackagingMethodAssortmentResult);

        }

        //-------------------------- End Inner Packaging------------------------------------------//


        //--------------------------------------------Start Retail Packaging--------------------------------------------//

        var ddlRetailPackagingPrintings = $(".ddlRetailPackagingPrintings").find(":selected").val();
        var ddlRetailPackagingUserInstructions = $(".ddlRetailPackagingUserInstructions").find(":selected").val();
        var ddlRetailPackagingMethods = $(".ddlRetailPackagingMethods").find(":selected").val();

        RetailPackaging.push({
            "RetailPackagingPrintings": ddlRetailPackagingPrintings,
            "RetailPackagingUserInstructions": ddlRetailPackagingUserInstructions,
            "RetailPackagingMethods": ddlRetailPackagingMethods,
        });

        for (var i = 0; i < RetailPackaging.length; i++) {
            var item = RetailPackaging[i];
            formData.append('RetailPackaging[' + i + '].RetailPackagingPrintings', item.RetailPackagingPrintings);
            formData.append('RetailPackaging[' + i + '].RetailPackagingUserInstructions', item.RetailPackagingUserInstructions);
            formData.append('RetailPackaging[' + i + '].RetailPackagingMethods', item.RetailPackagingMethods);

        }


        //--------------------------------------------End Retail Packaging --------------------------------------------//


        //--------------------------------------------Start ItemOverall Dimensions --------------------------------------------//


        var ddlItemOverallDimensions_Result = $(".ddlItemOverallDimensions_Result").find(":selected").val();
        var txtItemOverallDimensions_MeasuredData = $(".txtItemOverallDimensions_MeasuredData").val();


        var ddlOtherDimensions_Result = $(".ddlOtherDimensions_Result").find(":selected").val();
        var txtOtherDimensions_MeasuredData = $(".txtOtherDimensions_MeasuredData").val();


        var ddlItemNetWeight_Result = $(".ddlItemNetWeight_Result").find(":selected").val();
        var txtItemNetWeight_MeasuredData = $(".txtItemNetWeight_MeasuredData").val();


        var ddlItemMarkingsLabeling = $(".ddlItemMarkingsLabeling").find(":selected").val();
        var ddlItemColor = $(".ddlItemColor").find(":selected").val();

        var ddlGeneralConstructionAndMaterial = $(".ddlGeneralConstructionAndMaterial").find(":selected").val();

        ItemOverall.push({
            "ItemOverallDimensionsResult": ddlItemOverallDimensions_Result,
            "ItemOverallDimensionsMeasuredData": txtItemOverallDimensions_MeasuredData,

            "OtherDimensionsResult": ddlOtherDimensions_Result,
            "OtherDimensionsMeasuredData": txtOtherDimensions_MeasuredData,

            "ItemNetWeightResult": ddlItemNetWeight_Result,
            "ItemNetWeightMeasuredData": txtItemNetWeight_MeasuredData,

            "ItemMarkingsLabeling": ddlItemMarkingsLabeling,
            "ItemColor": ddlItemColor,

            "GeneralConstructionAndMaterial": ddlGeneralConstructionAndMaterial,

        });


        for (var i = 0; i < ItemOverall.length; i++) {
            var item = ItemOverall[i];
            formData.append('ItemOverall[' + i + '].ItemOverallDimensionsResult', item.ItemOverallDimensionsResult);
            formData.append('ItemOverall[' + i + '].ItemOverallDimensionsMeasuredData', item.ItemOverallDimensionsMeasuredData);
            formData.append('ItemOverall[' + i + '].OtherDimensionsResult', item.OtherDimensionsResult);
            formData.append('ItemOverall[' + i + '].OtherDimensionsMeasuredData', item.OtherDimensionsMeasuredData);
            formData.append('ItemOverall[' + i + '].ItemNetWeightResult', item.ItemNetWeightResult);
            formData.append('ItemOverall[' + i + '].ItemNetWeightMeasuredData', item.ItemNetWeightMeasuredData);

            formData.append('ItemOverall[' + i + '].ItemMarkingsLabeling', item.ItemMarkingsLabeling);
            formData.append('ItemOverall[' + i + '].ItemColor', item.ItemColor);
            formData.append('ItemOverall[' + i + '].GeneralConstructionAndMaterial', item.GeneralConstructionAndMaterial);

        }

        //--------------------------------------------End ItemOverall Dimensions --------------------------------------------//



        //-------------------------------------------Start OnSiteTestResults ---------------------------------------------------------//


        $("#tblOnSiteTestResults .tr_1").each(function () {

            var txtTestDescForOnSiteTestResults = $(this).find(".txtTestDescForOnSiteTestResults").val();
            var txtSampleSizeForOnSiteTestResults = $(this).find(".txtSampleSizeForOnSiteTestResults").val();

            var ddlResultsForOnSiteTestResults = $(this).find(".ddlResultsForOnSiteTestResults").find(":selected").val();
            var txtResultCommentsForOnSiteTestResults = $(this).find(".txtResultCommentsForOnSiteTestResults").val();

            var fileInput = $(this).closest('tr').next().find('.fileInput');
            var filename = fileInput.val();

       
            OnSiteTestResult.push({
                "TestDescription": txtTestDescForOnSiteTestResults,
                "SampleSize": txtSampleSizeForOnSiteTestResults,
                "Results": ddlResultsForOnSiteTestResults,
                "ResultComments": txtResultCommentsForOnSiteTestResults,
                "FilePath": filename
            });
        });


        for (var i = 0; i < OnSiteTestResult.length; i++) {
            var item = OnSiteTestResult[i];
            formData.append('OnSiteTestResult[' + i + '].TestDescription', item.TestDescription);
            formData.append('OnSiteTestResult[' + i + '].SampleSize', item.SampleSize);
            formData.append('OnSiteTestResult[' + i + '].Results', item.Results);
            formData.append('OnSiteTestResult[' + i + '].ResultComments', item.ResultComments);
            formData.append('OnSiteTestResult[' + i + '].FilePath', item.FilePath);
        }


        //debugger;
        //-------------------------------------------End OnSiteTestResults ---------------------------------------------------------//



        //-------------------------------------------Start ItemOtherPhotos ---------------------------------------------------------//

        var fileInputItemOtherPhotos = $('.FileUploadItemOtherPhotos').val();
        
        ItemOtherPhotos.push({
            "FilePath": fileInputItemOtherPhotos
        });


        for (var i = 0; i < ItemOtherPhotos.length; i++) {
            var item = ItemOtherPhotos[i];
            formData.append('ItemOtherPhotos[' + i + '].FilePath', item.FilePath);
        }

        //-------------------------------------------End ItemOtherPhotos ---------------------------------------------------------//

        var url = window.location.href;
        var parts = url.split('/');
        var id = parts[parts.length - 1];

        // Create FormData and append the extracted value
        formData.append('id', id);

        //alert($('.FileUploadForAddARemark')[0].files[0]);
        $('.FileUploadForAddARemark').each(function (index, element) {

            formData.append('files', $('.FileUploadForAddARemark')[index].files[0]);
        });

        $('.FileUploadForGeneralDefects').each(function (index, element) {

            formData.append('files', $('.FileUploadForGeneralDefects')[index].files[0]);
        });

        $('.FileUploadForOnSiteTestResults').each(function (index, element) {

            formData.append('files', $('.FileUploadForOnSiteTestResults')[index].files[0]);
        });

        //formData.append('files', $('.FileUploadForGeneralDefects')[0].files[0]);
        //formData.append('files', $('.FileUploadForOnSiteTestResults')[0].files[0]);
        formData.append('files', $('.FileUploadItemOtherPhotos')[0].files[0]);
        
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
