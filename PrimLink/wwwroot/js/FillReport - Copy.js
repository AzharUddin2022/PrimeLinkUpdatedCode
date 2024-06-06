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

function totals_12910045() {


}
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

        debugger;
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
       
            formData.append('SamplingInformationData[' + i + '].TotalCartonsNum', item.TotalCartonsNum);
            formData.append('SamplingInformationData[' + i + '].SelectedCartonsNum', item.SelectedCartonsNum);
        }

        //-------------------------- End SamplingInformationData ------------------------------------------//

        ////-------------------------- Start ImportantRemarks ------------------------------------------//

        $("#tblDoc .tr_1").each(function () {
            var ddlForAddARemark = $(this).find(".ddlForAddARemark").val();
            var textareaForAddARemark = $(this).find(".textareaForAddARemark").val();
            var fileInput = $(this).closest('tr').next().find('.fileInput');
            var filename = fileInput.val();

            ImportantRemarks.push
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
        ////-------------------------- End ImportantRemarks ------------------------------------------//

        //-------------------------- Start Your Product ------------------------------------------//

        debugger;
        //var Path = $(".fileInputYourProduct").val();
        //formData.append('YourProducts[0].Path', Path);




        var Path1 = $('.fileInputYourProduct').val();
        
        YourProducts.push({
            "Path": Path1
        });

        for (var i = 0; i < YourProducts.length; i++) {
            var item = YourProducts[i];
            formData.append('YourProducts[' + i + '].Path', item.Path);
        }


        //-------------------------- End Your Product ------------------------------------------//


        //-------------------------- Start Customer Special Checkpoints ------------------------------------------//

        var ddlforCustomerCheckPointA = $(".ddlforCustomerCheckPointA").val();
        var textA = $(".textA").val();
        var fileInputA = $('.fileInputA').val();
        CustomerSpecialCheckPoints.push({
            "Type":'A',
            "Status": ddlforCustomerCheckPointA,
            "Comment": textA,
            "FilePath": fileInputA
            });
        var ddlforCustomerCheckPointB = $(".ddlforCustomerCheckPointB").val();
        var textB = $(".textB").val();
        var fileInputB = $('.fileInputB').val();
        CustomerSpecialCheckPoints.push({
            "Type": 'B',
            "Status": ddlforCustomerCheckPointB,
            "Comment": textB,
            "FilePath": fileInputB
        });
        var ddlforCustomerCheckPointC = $(".ddlforCustomerCheckPointC").val();
        var textC = $(".textC").val();
        var fileInputC = $('.fileInputC').val();
        CustomerSpecialCheckPoints.push({
            "Type": 'C',
            "Status": ddlforCustomerCheckPointC,
            "Comment": textC,
            "FilePath": fileInputC
        });
        var ddlforCustomerCheckPointD = $(".ddlforCustomerCheckPointD").val();
        var textD = $(".textD").val();
        var fileInputD = $('.fileInputD').val();
        CustomerSpecialCheckPoints.push({
            "Type": 'D',
            "Status": ddlforCustomerCheckPointD,
            "Comment": textD,
            "FilePath": fileInputD
        });
        var ddlforCustomerCheckPointE = $(".ddlforCustomerCheckPointE").val();
        var textE = $(".textE").val();
        var fileInputE = $('.fileInputE').val();
        CustomerSpecialCheckPoints.push({
            "Type": 'E',
            "Status": ddlforCustomerCheckPointE,
            "Comment": textE,
            "FilePath": fileInputE
        });
        var ddlforCustomerCheckPointF = $(".ddlforCustomerCheckPointF").val();
        var textF = $(".textF").val();
        var fileInputF = $('.fileInputF').val();
        CustomerSpecialCheckPoints.push({
            "Type": 'F',
            "Status": ddlforCustomerCheckPointF,
            "Comment": textF,
            "FilePath": fileInputF
        });
        console.log(ddlforCustomerCheckPointA);
        var overAllResult =document.querySelector('.CustomerSpecialCheckPointOverAllResult').textContent;
        for (var i = 0; i < CustomerSpecialCheckPoints.length; i++) {
            var item = CustomerSpecialCheckPoints[i];

            formData.append('CustomerSpecialCheckPoints[' + i + '].Type', item.Type);
            formData.append('CustomerSpecialCheckPoints[' + i + '].Result', item.Status);
            formData.append('CustomerSpecialCheckPoints[' + i + '].Description', item.Comment);
            formData.append('CustomerSpecialCheckPoints[' + i + '].FilePath', item.FilePath);
            formData.append('CustomerSpecialCheckPoints[' + i + '].OverAllResult', overAllResult);
        }
        //-------------------------- End Customer Special Checkpoints ------------------------------------------//

        //------------------------- Start Sampling Information 2 ----------------------------------------------------//

        var APONUmber = document.querySelector('.APONumber').textContent;
        var AMOdelNumber = document.querySelector('.AModelNumber').textContent;
        var PackedCTNSA = $(".PackedCTNSA").val();
        var FinshedUnpackedA = $(".FinshedUnpackedA").val();
        var InspectedCartonCTNA = $('.InspectedCartonCTNA').val();
        var InspectedCartonCTNNumberA = $('.InspectedCartonCTNNumberA').val();
        var AllowDrawingSamplesNonPacked = $('.AllowDrawingSamplesNonPacked').val();
        var HundredPercentQtyForSampling = $('.HundredPercentQtyForSampling').val();

        SamplingInformation2.push({
            "PONumber": APONUmber,
            "ModelNumber": AMOdelNumber,
            "PackedCTNS": PackedCTNSA,
            "FinshedUnpacked": FinshedUnpackedA,
            "InspectedCartonCTN": InspectedCartonCTNA,
            "InspectedCartonCTNNumber": InspectedCartonCTNNumberA,
            "AllowDrawingSamplesNonPacked": AllowDrawingSamplesNonPacked,
            "HundredPercentQtyForSampling": HundredPercentQtyForSampling
        });

        var BPONUmber = document.querySelector('.BPONumber').textContent;
        var BMOdelNumber = document.querySelector('.BModelNumber').textContent;
        var PackedCTNSB = $(".PackedCTNSB").val();
        var FinshedUnpackedB = $(".FinshedUnpackedB").val();
        var InspectedCartonCTNB = $('.InspectedCartonCTNB').val();
        var InspectedCartonCTNNumberB = $('.InspectedCartonCTNNumberB').val();

        SamplingInformation2.push({
            "PONumber": BPONUmber,
            "ModelNumber": BMOdelNumber,
            "PackedCTNS": PackedCTNSB,
            "FinshedUnpacked": FinshedUnpackedB,
            "InspectedCartonCTN": InspectedCartonCTNB,
            "InspectedCartonCTNNumber": InspectedCartonCTNNumberB,
            "AllowDrawingSamplesNonPacked": AllowDrawingSamplesNonPacked,
            "HundredPercentQtyForSampling": HundredPercentQtyForSampling
        });

        var CPONUmber = document.querySelector('.CPONumber').textContent;
        var CMOdelNumber = document.querySelector('.CModelNumber').textContent;
        var PackedCTNSC = $(".PackedCTNSC").val();
        var FinshedUnpackedC = $(".FinshedUnpackedC").val();
        var InspectedCartonCTNC = $('.InspectedCartonCTNC').val();
        var InspectedCartonCTNNumberC = $('.InspectedCartonCTNNumberC').val();

        SamplingInformation2.push({
            "PONumber": CPONUmber,
            "ModelNumber": CMOdelNumber,
            "PackedCTNS": PackedCTNSC,
            "FinshedUnpacked": FinshedUnpackedC,
            "InspectedCartonCTN": InspectedCartonCTNC,
            "InspectedCartonCTNNumber": InspectedCartonCTNNumberC,
            "AllowDrawingSamplesNonPacked": AllowDrawingSamplesNonPacked,
            "HundredPercentQtyForSampling": HundredPercentQtyForSampling
        });

        var DPONUmber = document.querySelector('.DPONumber').textContent;
        var DMOdelNumber = document.querySelector('.DModelNumber').textContent;
        var PackedCTNSD = $(".PackedCTNSD").val();
        var FinshedUnpackedD = $(".FinshedUnpackedD").val();
        var InspectedCartonCTND = $('.InspectedCartonCTND').val();
        var InspectedCartonCTNNumberD = $('.InspectedCartonCTNNumberD').val();

        SamplingInformation2.push({
            "PONumber": DPONUmber,
            "ModelNumber": DMOdelNumber,
            "PackedCTNS": PackedCTNSD,
            "FinshedUnpacked": FinshedUnpackedD,
            "InspectedCartonCTN": InspectedCartonCTND,
            "InspectedCartonCTNNumber": InspectedCartonCTNNumberD,
            "AllowDrawingSamplesNonPacked": AllowDrawingSamplesNonPacked,
            "HundredPercentQtyForSampling": HundredPercentQtyForSampling
        });


        var EPONUmber = document.querySelector('.EPONumber').textContent;
        var EMOdelNumber = document.querySelector('.EModelNumber').textContent;
        var PackedCTNSE = $(".PackedCTNSE").val();
        var FinshedUnpackedE = $(".FinshedUnpackedE").val();
        var InspectedCartonCTNE = $('.InspectedCartonCTNE').val();
        var InspectedCartonCTNNumberE = $('.InspectedCartonCTNNumberE').val();

        SamplingInformation2.push({
            "PONumber": EPONUmber,
            "ModelNumber": EMOdelNumber,
            "PackedCTNS": PackedCTNSE,
            "FinshedUnpacked": FinshedUnpackedE,
            "InspectedCartonCTN": InspectedCartonCTNE,
            "InspectedCartonCTNNumber": InspectedCartonCTNNumberE,
            "AllowDrawingSamplesNonPacked": AllowDrawingSamplesNonPacked,
            "HundredPercentQtyForSampling": HundredPercentQtyForSampling
        });


        var SampleSizeFromPackedCTNSTotal = $('#12910035-sample-size-packed-total').val();
        var SampleSizeFromFinishedUnPackedTotal = $('#12910035-sample-size-finished-unpacked-total').val();
        var InspectedCartonCTNTotal = $('#12910035-cartons-total').val();

        for (var i = 0; i < SamplingInformation2.length; i++) {
            var item = SamplingInformation2[i];

            formData.append('SamplingInformation2[' + i + '].PONumber', item.PONumber);
            formData.append('SamplingInformation2[' + i + '].ModelNumber', item.ModelNumber);
            formData.append('SamplingInformation2[' + i + '].SampleSizeFromPackedCTNS', item.PackedCTNS);
            formData.append('SamplingInformation2[' + i + '].SampleSizeFromFinsihedUnPacked', item.FinshedUnpacked);
            formData.append('SamplingInformation2[' + i + '].InspectedCartonCTN', item.InspectedCartonCTN);
            formData.append('SamplingInformation2[' + i + '].InspectedCartonNUmber', item.InspectedCartonCTNNumber);
            formData.append('SamplingInformation2[' + i + '].SampleSizeFromPackedCTNSTotal', item.FinshedUnpacked);
            formData.append('SamplingInformation2[' + i + '].SampleSizeFromFinishedUnPackedTotal', item.FinshedUnpacked);
            formData.append('SamplingInformation2[' + i + '].InspectedCartonCTNTotal', item.FinshedUnpacked);
            formData.append('SamplingInformation2[' + i + '].FactoryAllowsDrawingSamples', item.AllowDrawingSamplesNonPacked);
            formData.append('SamplingInformation2[' + i + '].QuantityAvailableForSampling', item.HundredPercentQtyForSampling);
        }


        //------------------------- End Sampling Information 2 ----------------------------------------------------//



        //------------------------- Start Inspection Standard ----------------------------------------------------//
        var InspectionPONumber = $(".InspectionPONumber").val();
        var InspectionDefectDescriptionStatus = $(".InspectionDefectDescriptionStatus").val();
        var InspectionDefectDescription = $(".InspectionDefectDescription").val();
        var InspectionStatus = $(".InspectionStatus").val();
        var InspectionGeneralDefectsFound = $(".InspectionGeneralDefectsFound").val();
        var InspectionGeneralDefectsDescription = $(".InspectionGeneralDefectsDescription").val();
        var InspectionNonConformityFound = $('.InspectionNonConformityFound').val();
        var InspectionNonConformityRemark = $('.InspectionNonConformityRemark').val();
        var InspectionOverAllResult = $(".InspectionOverAllResult").val();
        InspectionStandard.push({
            "PONumber": InspectionPONumber,
            "DefectDescriptionStatus": InspectionDefectDescriptionStatus,
            "DefectDescription": InspectionDefectDescription,
            "Status": InspectionStatus,
            "GeneralDefectsFound": InspectionGeneralDefectsFound,
            "GeneralDefectsDescription": InspectionGeneralDefectsDescription,
            "NonConformityFound": InspectionNonConformityFound,
            "NonConformityRemark": InspectionNonConformityRemark,
            "OverAllResult": InspectionOverAllResult
        });

        formData.append('InspectionStandards[0].PONumber', InspectionPONumber);
        formData.append('InspectionStandards[0].DefectDescriptionStatus', InspectionDefectDescriptionStatus);
        formData.append('InspectionStandards[0].DefectDescription', InspectionDefectDescription);
        formData.append('InspectionStandards[0].Status', InspectionStatus);
        formData.append('InspectionStandards[0].GeneralDefectsFound', InspectionGeneralDefectsFound);
        formData.append('InspectionStandards[0].GeneralDefectsDescription', InspectionGeneralDefectsDescription);
        formData.append('InspectionStandards[0].NonConformityFound', InspectionNonConformityFound);
        formData.append('InspectionStandards[0].NonConformityRemark', InspectionNonConformityRemark);
        formData.append('InspectionStandards[0].OverallResult', InspectionOverAllResult);

            
        //------------------------- End Inspection Standard ----------------------------------------------------//


        //------------------------- Start Quantity Check Result ----------------------------------------------------//
        var PONUmberA = document.querySelector('.product-255962-purchaseOrderNumber').textContent;
        var ModelNumberA = document.querySelector('.product-255962-modelNumber').textContent;
        var OrderQtyA = document.querySelector('.product-255962-quantity').textContent;
        var UnitsCartonA = $("#12910045-255962-units-carton").val();
        var UnitsA = $("#12910045-255962-finished-packed-units").val();
        var CartonsA = $("#12910045-255962-finished-packed-cartons").val();
        var Units_Finished_NotPackedA = $("#12910045-255962-finished-not-packed-units").val();
        var Units_NotFinishedA = $("#12910045-255962-not-finished-units").val();
        var StatusA = $("#12910045-255962-result").val();

        var PONUmberB = document.querySelector('.product-255959-purchaseOrderNumber').textContent;
        var ModelNumberB = document.querySelector('.product-255959-modelNumber').textContent;
        var OrderQtyB = document.querySelector('.product-255959-quantity').textContent;
        var UnitsCartonB = $("#12910045-255959-units-carton").val();
        var UnitsB = $("#12910045-255959-finished-packed-units").val();
        var CartonsB = $("#12910045-255959-finished-packed-cartons").val();
        var Units_Finished_NotPackedB = $("#12910045-255959-finished-not-packed-units").val();
        var Units_NotFinishedB = $("#12910045-255959-not-finished-units").val();
        var StatusB = $("#12910045-255959-result").val();

        var PONUmberC = document.querySelector('.product-255960-purchaseOrderNumber').textContent;
        var ModelNumberC = document.querySelector('.product-255960-modelNumber').textContent;
        var OrderQtyC = document.querySelector('.product-255960-quantity').textContent;
        var UnitsCartonC = $("#12910045-255960-units-carton").val();
        var UnitsC = $("#12910045-255960-finished-packed-units").val();
        var CartonsC = $("#12910045-255960-finished-packed-cartons").val    
        var Units_Finished_NotPackedC = $("#12910045-255960-finished-not-packed-units").val();
        var Units_NotFinishedC = $("#12910045-255960-not-finished-units").val();
        var StatusC = $("#12910045-255960-result").val();

        var PONUmberD = document.querySelector('.product-255961-purchaseOrderNumber').textContent;
        var ModelNumberD = document.querySelector('.product-255961-modelNumber').textContent;
        var OrderQtyD = document.querySelector('.product-255961-quantity').textContent;
        var UnitsCartonD = $("#12910045-255961-units-carton").val();
        var UnitsD = $("#12910045-255961-finished-packed-units").val();
        var CartonsD = $("#12910045-255961-finished-packed-cartons").val();
        var Units_Finished_NotPackedD = $("#12910045-255961-finished-not-packed-units").val();
        var Units_NotFinishedD = $("#12910045-255961-not-finished-units").val();
        var StatusD = $("#12910045-255961-result").val();

        var PONUmberE = document.querySelector('.product-255958-purchaseOrderNumber').textContent;
        var ModelNumberE = document.querySelector('.product-255958-modelNumber').textContent;
        var OrderQtyE = document.querySelector('.product-255958-quantity').textContent;
        var UnitsCartonE = $("#12910045-255958-units-carton").val();
        var UnitsE = $("#12910045-255958-finished-packed-units").val();
        var CartonsE = $("#12910045-255958-finished-packed-cartons").val();
        var Units_Finished_NotPackedE = $("#12910045-255958-finished-not-packed-units").val();
        var Units_NotFinishedE = $("#12910045-255958-not-finished-units").val();
        var StatusE = $("#12910045-255958-result").val();

        var Result_Remark = $("#12910045-remarks").val();
        var File = $("#12910045-photos").val();
        var TotalFinishedAndPackedUnits = $("#12910045-finished-packed-units-total").val();
        var TotalFinishedAndPackedCartons = $("#12910045-finished-packed-cartons-total").val();
        var TotalFinishedButNotPackedUnits = $("#12910045-finished-not-packed-units-total").val(); 
        var TotalNotFinishedUnits = $("#not-finished-units-total").val();

        formData.append('QuantityCheckResult[0].PONumber', PONUmberA);
        formData.append('QuantityCheckResult[0].ModelNUmber', ModelNumberA);
        formData.append('QuantityCheckResult[0].OrderQtyUnits', OrderQtyA);
        formData.append('QuantityCheckResult[0].UnitsOrCarton', UnitsCartonA);
        formData.append('QuantityCheckResult[0].FinishedAndPackedUnits', UnitsA);
        formData.append('QuantityCheckResult[0].FinishedAndPackedCartons', CartonsA);
        formData.append('QuantityCheckResult[0].FinishedButNotPackedUnits', Units_Finished_NotPackedA);
        formData.append('QuantityCheckResult[0].NotFinishedUnits', Units_NotFinishedA);
        formData.append('QuantityCheckResult[0].Results', StatusA);
        formData.append('QuantityCheckResult[0].TotalFinishedAndPackedUnits', TotalFinishedAndPackedUnits);
        formData.append('QuantityCheckResult[0].TotalFinishedAndPackedCartons', TotalFinishedAndPackedCartons);
        formData.append('QuantityCheckResult[0].TotalFinishedButNotPackedUnits', TotalFinishedButNotPackedUnits);
        formData.append('QuantityCheckResult[0].TotalNotFinishedUnits', TotalNotFinishedUnits);
        formData.append('QuantityCheckResult[0].File', File);
        formData.append('QuantityCheckResult[0].ResultOrremarksDesc', Result_Remark);

        formData.append('QuantityCheckResult[1].PONumber', PONUmberB);
        formData.append('QuantityCheckResult[1].ModelNUmber', ModelNumberB);
        formData.append('QuantityCheckResult[1].OrderQtyUnits', OrderQtyB);
        formData.append('QuantityCheckResult[1].UnitsOrCarton', UnitsCartonB);
        formData.append('QuantityCheckResult[1].FinishedAndPackedUnits', UnitsB);
        formData.append('QuantityCheckResult[1].FinishedAndPackedCartons', CartonsB);
        formData.append('QuantityCheckResult[1].FinishedButNotPackedUnits', Units_Finished_NotPackedB);
        formData.append('QuantityCheckResult[1].NotFinishedUnits', Units_NotFinishedB);
        formData.append('QuantityCheckResult[1].Results', StatusB);
        formData.append('QuantityCheckResult[1].TotalFinishedAndPackedUnits', TotalFinishedAndPackedUnits);
        formData.append('QuantityCheckResult[1].TotalFinishedAndPackedCartons', TotalFinishedAndPackedCartons);
        formData.append('QuantityCheckResult[1].TotalFinishedButNotPackedUnits', TotalFinishedButNotPackedUnits);
        formData.append('QuantityCheckResult[1].TotalNotFinishedUnits', TotalNotFinishedUnits);
        formData.append('QuantityCheckResult[1].File', File);
        formData.append('QuantityCheckResult[1].ResultOrremarksDesc', Result_Remark);

        formData.append('QuantityCheckResult[2].PONumber', PONUmberC);
        formData.append('QuantityCheckResult[2].ModelNUmber', ModelNumberC);
        formData.append('QuantityCheckResult[2].OrderQtyUnits', OrderQtyC);
        formData.append('QuantityCheckResult[2].UnitsOrCarton', UnitsCartonC);
        formData.append('QuantityCheckResult[2].FinishedAndPackedUnits', UnitsC);
        formData.append('QuantityCheckResult[2].FinishedAndPackedCartons', CartonsC);
        formData.append('QuantityCheckResult[2].FinishedButNotPackedUnits', Units_Finished_NotPackedC);
        formData.append('QuantityCheckResult[2].NotFinishedUnits', Units_NotFinishedC);
        formData.append('QuantityCheckResult[2].Results', StatusC);
        formData.append('QuantityCheckResult[2].TotalFinishedAndPackedUnits', TotalFinishedAndPackedUnits);
        formData.append('QuantityCheckResult[2].TotalFinishedAndPackedCartons', TotalFinishedAndPackedCartons);
        formData.append('QuantityCheckResult[2].TotalFinishedButNotPackedUnits', TotalFinishedButNotPackedUnits);
        formData.append('QuantityCheckResult[2].TotalNotFinishedUnits', TotalNotFinishedUnits);
        formData.append('QuantityCheckResult[2].File', File);
        formData.append('QuantityCheckResult[2].ResultOrremarksDesc', Result_Remark);

        formData.append('QuantityCheckResult[3].PONumber', PONUmberD);
        formData.append('QuantityCheckResult[3].ModelNUmber', ModelNumberD);
        formData.append('QuantityCheckResult[3].OrderQtyUnits', OrderQtyD);
        formData.append('QuantityCheckResult[3].UnitsOrCarton', UnitsCartonD);
        formData.append('QuantityCheckResult[3].FinishedAndPackedUnits', UnitsD);
        formData.append('QuantityCheckResult[3].FinishedAndPackedCartons', CartonsD);
        formData.append('QuantityCheckResult[3].FinishedButNotPackedUnits', Units_Finished_NotPackedD);
        formData.append('QuantityCheckResult[3].NotFinishedUnits', Units_NotFinishedD);
        formData.append('QuantityCheckResult[3].Results', StatusD);
        formData.append('QuantityCheckResult[3].TotalFinishedAndPackedUnits', TotalFinishedAndPackedUnits);
        formData.append('QuantityCheckResult[3].TotalFinishedAndPackedCartons', TotalFinishedAndPackedCartons);
        formData.append('QuantityCheckResult[3].TotalFinishedButNotPackedUnits', TotalFinishedButNotPackedUnits);
        formData.append('QuantityCheckResult[3].TotalNotFinishedUnits', TotalNotFinishedUnits);
        formData.append('QuantityCheckResult[3].File', File);
        formData.append('QuantityCheckResult[3].ResultOrremarksDesc', Result_Remark);

        formData.append('QuantityCheckResult[4].PONumber', PONUmberE);
        formData.append('QuantityCheckResult[4].ModelNUmber', ModelNumberE);
        formData.append('QuantityCheckResult[4].OrderQtyUnits', OrderQtyE);
        formData.append('QuantityCheckResult[4].UnitsOrCarton', UnitsCartonE);
        formData.append('QuantityCheckResult[4].FinishedAndPackedUnits', UnitsE);
        formData.append('QuantityCheckResult[4].FinishedAndPackedCartons', CartonsE);
        formData.append('QuantityCheckResult[4].FinishedButNotPackedUnits', Units_Finished_NotPackedE);
        formData.append('QuantityCheckResult[4].NotFinishedUnits', Units_NotFinishedE);
        formData.append('QuantityCheckResult[4].Results', StatusE);
        formData.append('QuantityCheckResult[4].TotalFinishedAndPackedUnits', TotalFinishedAndPackedUnits);
        formData.append('QuantityCheckResult[4].TotalFinishedAndPackedCartons', TotalFinishedAndPackedCartons);
        formData.append('QuantityCheckResult[4].TotalFinishedButNotPackedUnits', TotalFinishedButNotPackedUnits);
        formData.append('QuantityCheckResult[4].TotalNotFinishedUnits', TotalNotFinishedUnits);
        formData.append('QuantityCheckResult[4].File', File);
        formData.append('QuantityCheckResult[4].ResultOrremarksDesc', Result_Remark);

        //------------------------- End Booking Requirements ----------------------------------------------------//


        //-------------------------- Start PackingAndProductSpecificationModel --------------------------------------------//

        var C1Status = $("#12909896-result").val();
        var CorugatedPaperPly = $("#12909896-corrugated-paper-ply").val();
        var Fastening = $("#12909896-fastening").val();
        var SealedBy = $("#12909896-sealed-by").val();
        var Strapping = $("#12909896-strapping").val();
        var C2Status = $("#12910022-result").val();
        var C3Status = $("#12910023-result").val();
        var C4Status = $("#12910024-result").val();
        var C5Status = $("#12910025-result").val();
        var C6Status = $("#12910026-result").val();
        var C7Status = $("#12910027-result").val();
        var C8Status = $("#12910028-result").val();
        var C9Status = $("#12910029-result").val();
        var C10Status = $("#12910033-result").val();
        var C11Status = $("#12910036-result").val();
        var C12Status = $("#12910037-result").val();
        var fileDuvetCore = $("#fileDuvetCore").val();
        var fileDyedFitted140 = $("#fileDyedFitted140").val();
        var fileDyedFitted160 = $("#fileDyedFitted160").val();
        var fileDyedFitted180 = $("#fileDyedFitted180").val();
        var fileDyedFitted90 = $("#fileDyedFitted90").val();

        formData.append('PackingandProductSpecificationModel[0].C1Status', C1Status);
        formData.append('PackingandProductSpecificationModel[0].CorugatedPaperPly', CorugatedPaperPly);
        formData.append('PackingandProductSpecificationModel[0].Fastening', Fastening);
        formData.append('PackingandProductSpecificationModel[0].SealedBy', SealedBy);
        formData.append('PackingandProductSpecificationModel[0].Strapping', Strapping);
        formData.append('PackingandProductSpecificationModel[0].C2Status', C2Status);
        formData.append('PackingandProductSpecificationModel[0].C3Status', C3Status);
        formData.append('PackingandProductSpecificationModel[0].C4Status', C4Status);
        formData.append('PackingandProductSpecificationModel[0].C5Status', C5Status);
        formData.append('PackingandProductSpecificationModel[0].C6Status', C6Status);
        formData.append('PackingandProductSpecificationModel[0].C7Status', C7Status);
        formData.append('PackingandProductSpecificationModel[0].C8Status', C8Status);
        formData.append('PackingandProductSpecificationModel[0].C9Status', C9Status);
        formData.append('PackingandProductSpecificationModel[0].C10Status', C10Status);
        formData.append('PackingandProductSpecificationModel[0].C11Status', C11Status);
        formData.append('PackingandProductSpecificationModel[0].C12Status', C12Status);
        formData.append('PackingandProductSpecificationModel[0].FileDuvetCore', fileDuvetCore);
        formData.append('PackingandProductSpecificationModel[0].FileDyedFitted140', fileDyedFitted140);
        formData.append('PackingandProductSpecificationModel[0].FileDyedFitted160', fileDyedFitted160);
        formData.append('PackingandProductSpecificationModel[0].FileDyedFitted180', fileDyedFitted180);
        formData.append('PackingandProductSpecificationModel[0].FileDyedFitted90', fileDyedFitted90);




        //-------------------------- End PackingAndProductSpecificationModel --------------------------------------------//

        //------------------------- Start Defect Photos ----------------------------------------------------//

        var file = $('.defect-upload-photo').val();
        defectPhotos.push({
            "Path": file
        });


        formData.append('DefectPhotos[0].Path',file);

        //------------------------- End Defect Photos 2 ----------------------------------------------------//



        ////-------------------------- Start ItemData ------------------------------------------//

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



        ////-------------------------- Start  Item AQL Defect ------------------------------------------//

        //debugger;
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

        ////-------------------------- End  Item AQL Defect ------------------------------------------//



        ////-------------------------- Start AQL Defect ------------------------------------------//

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

        ////-------------------------- End AQL Defect ------------------------------------------//

        ////-------------------------- Start Shipper Carton Packaging------------------------------------------//

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


        ////-------------------------- End Shipper Carton Packaging------------------------------------------//


        ////-------------------------- Start Inner Packaging------------------------------------------//

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

        ////-------------------------- End Inner Packaging------------------------------------------//


        ////--------------------------------------------Start Retail Packaging--------------------------------------------//

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


        ////--------------------------------------------End Retail Packaging --------------------------------------------//


        ////--------------------------------------------Start ItemOverall Dimensions --------------------------------------------//


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

        ////--------------------------------------------End ItemOverall Dimensions --------------------------------------------//



        ////-------------------------------------------Start OnSiteTestResults ---------------------------------------------------------//


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


        ////debugger;
        ////-------------------------------------------End OnSiteTestResults ---------------------------------------------------------//



        ////-------------------------------------------Start ItemOtherPhotos ---------------------------------------------------------//

        var fileInputItemOtherPhotos = $('.FileUploadItemOtherPhotos').val();

        ItemOtherPhotos.push({
            "FilePath": fileInputItemOtherPhotos
        });


        for (var i = 0; i < ItemOtherPhotos.length; i++) {
            var item = ItemOtherPhotos[i];
            formData.append('ItemOtherPhotos[' + i + '].FilePath', item.FilePath);
        }

        ////-------------------------------------------End ItemOtherPhotos ---------------------------------------------------------//

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
        //formData.append('files', $('.FileUploadItemOtherPhotos')[0].files[0]);

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
