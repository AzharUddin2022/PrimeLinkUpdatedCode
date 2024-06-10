#pragma checksum "D:\Prime\PrimLink\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4dac22b9ccb76c4964931dd9b7dbdd31862c8465"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PrimLink.Pages.Home.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace PrimLink.Pages.Home
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Prime\PrimLink\Views\_ViewImports.cshtml"
using PrimLink;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Prime\PrimLink\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Prime\PrimLink\Views\Home\Index.cshtml"
using Model.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4dac22b9ccb76c4964931dd9b7dbdd31862c8465", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18e57a331d4e28b5ccd17f1aef09b2ee05452014", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/pages/User/User.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Prime\PrimLink\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\Prime\PrimLink\Views\Home\Index.cshtml"
Write(Html.HiddenFor(x => x.IsAdmin, new { id = "isAdmin" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\Prime\PrimLink\Views\Home\Index.cshtml"
Write(Html.HiddenFor(x => x.Id, new { id = "userId" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"content-wrapper\">\r\n    <!-- Content Header (Page header) -->\r\n    <section class=\"content-header\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                ");
#nullable restore
#line 15 "D:\Prime\PrimLink\Views\Home\Index.cshtml"
            Write(Html.Kendo().Grid<UserFormModel>()
                    .Name("UserFormGrid")
                    .Columns(columns =>
                    {
                        columns.Command(command =>
                        {
                            command.Custom("Edit").Text("").IconClass("icon-pencil7").Click("editUser")
                            .HtmlAttributes(new { title = "Edit", data_toggle = "tooltip", @class = "grid-edit-icon c_blue" });
                            command.Custom("Delete").Text("").IconClass("icon-cancel-square").Click("deleteUser")
                            .HtmlAttributes(new { title = "Delete", data_toggle = "tooltip", @class = "grid-trash-icon c_theme" });
                        }).Width(40).Title("Action");
                        columns.Bound(reason => reason.Id).Hidden(true);
                        columns.Bound(reason => reason.MissionReference).Title("Mission Reference").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                        columns.Bound(reason => reason.ProductLine).Title("Product Line").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                        columns.Bound(reason => reason.ProductCategory).Title("Product Category").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                        columns.Bound(reason => reason.QuantityUnit).Title("Quantity Unit").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                        columns.Bound(reason => reason.DestinationCountry).Title("Destination Country").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                        columns.Bound(reason => reason.ServiceDate).Title("Service Date").Format("{0:MM/dd/yyyy}").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                        columns.Bound(reason => reason.ShipmentDate).Title("Shipment Date").Format("{0:MM/dd/yyyy}").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                        columns.Bound(reason => reason.Approved).Title("Approved").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                    })
                    .Pageable()
                    .Resizable(x => x.Columns(true))
                    .Filterable(filterable => filterable.Messages(m => m.IsFalse("No")).Mode(GridFilterMode.Row)
                    .Messages(m => m.IsTrue("Yes")))
                    .Selectable()
                    .Scrollable()
                    .ToolBar(e =>
                    {
                        e.Custom().Text("Add Form").HtmlAttributes(new { id = "addForm", @class = "floatRight" });
                        e.Excel().Text("Export to Excel").HtmlAttributes(new { id = "excel", @class = "floatRight" });
                    })
                    .Excel(excel => excel
                    .FileName("UserFormList.xlsx")
                    .Filterable(true)
                    .AllPages()
                    .ProxyURL(Url.Action("Excel_Export_Save", "Home")))
                    .HtmlAttributes(new { style = "height:100%;" })
                    .DataSource(dataSource => dataSource
                    .Ajax()
                    .PageSize(8)
                    .ServerOperation(false)
                    .Read(read => read.Action("GetUserFormGrid", "Home", new { userId = Model.Id })))
                    .NoRecords(true)
                    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </section>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4dac22b9ccb76c4964931dd9b7dbdd31862c84658662", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 65 "D:\Prime\PrimLink\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script src=\"//cdnjs.cloudflare.com/ajax/libs/jszip/2.4.0/jszip.min.js\"></script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
