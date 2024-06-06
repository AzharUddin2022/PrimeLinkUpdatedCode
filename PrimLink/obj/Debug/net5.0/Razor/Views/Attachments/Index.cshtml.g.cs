#pragma checksum "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Attachments\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "009cd82eb0c3df00107ca6b5afba002763e4d505"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PrimLink.Pages.Attachments.Views_Attachments_Index), @"mvc.1.0.view", @"/Views/Attachments/Index.cshtml")]
namespace PrimLink.Pages.Attachments
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
#line 1 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\_ViewImports.cshtml"
using PrimLink;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Attachments\Index.cshtml"
using Model.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"009cd82eb0c3df00107ca6b5afba002763e4d505", @"/Views/Attachments/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18e57a331d4e28b5ccd17f1aef09b2ee05452014", @"/Views/_ViewImports.cshtml")]
    public class Views_Attachments_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ClientAttachmentModel>
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
#line 3 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Attachments\Index.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Attachments\Index.cshtml"
Write(Html.HiddenFor(x => x.UserId, new { id = "userId" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Attachments\Index.cshtml"
Write(Html.HiddenFor(x => x.UserFormId, new { id = "userFormId" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        ");
#nullable restore
#line 12 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Attachments\Index.cshtml"
    Write(Html.Kendo().Grid<ClientAttachmentModel>()
            .Name("ClientAttachmentGrid")
            .Columns(columns =>
            {
                columns.Command(command =>
                {
                    command.Custom("Download").Text("").IconClass("icon-download").Click("downloadClientAttachment")
                .HtmlAttributes(new { title = "Download", data_toggle = "tooltip", @class = "grid-download-icon c_theme" });
                    if (Model != null && Model.IsApproved == false)
                    {
                        command.Custom("Delete").Text("").IconClass("icon-cancel-square").Click("deleteAttachment")
                    .HtmlAttributes(new { title = "Delete", data_toggle = "tooltip", @class = "grid-trash-icon c_theme" });
                    }
                    
                }).Width(30).Title("Action");
                columns.Bound(reason => reason.Id).Hidden(true);
                columns.Bound(reason => reason.CreatedDate).Title("Created At").Format("{0:MM/dd/yyyy}").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(30);
                columns.Bound(reason => reason.FileName).Title("File Name").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                columns.Bound(reason => reason.FileType).Title("Type").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(30);
                columns.Bound(reason => reason.Description).Title("Description").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
            })
            .Pageable()
            .Scrollable()
            .Resizable(x => x.Columns(true))
            .ToolBar(e =>
            {
                if (Model != null && Model.IsApproved == false)
                {
                    e.Custom().Text("Add Attachment").HtmlAttributes(new { id = "addAttachment", @class = "floatRight" });

                }
            })
            .Excel(excel => excel
            .FileName("AttachmentsList.xlsx")
            .Filterable(true)
            .AllPages()
            .ProxyURL(Url.Action("Excel_Export_Save", "Attachments")))
            .Filterable(ftb => ftb.Mode(GridFilterMode.Row))
            .HtmlAttributes(new { style = "height:100%;" })
            .DataSource(dataSource => dataSource
            .Ajax()
            .PageSize(8)
            .Read(read => read.Action("GetAttachmentsGrid", "Attachments", new { userId = Model != null ? Model.UserId : 0, userFormId = Model != null ? Model.UserFormId : 0 })))
            .NoRecords(true)
            );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 61 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Attachments\Index.cshtml"
Write(Html.Kendo().Window()
.Name("AddEditAttachment")
.Title("")
.Draggable(false)
.Width(800)
.Modal(true)
.Visible(false)
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "009cd82eb0c3df00107ca6b5afba002763e4d5058224", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 70 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Attachments\Index.cshtml"
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
            WriteLiteral("\r\n<script src=\"//cdnjs.cloudflare.com/ajax/libs/jszip/2.4.0/jszip.min.js\"></script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ClientAttachmentModel> Html { get; private set; }
    }
}
#pragma warning restore 1591