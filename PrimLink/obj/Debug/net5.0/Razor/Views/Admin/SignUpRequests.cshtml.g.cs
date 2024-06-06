#pragma checksum "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Admin\SignUpRequests.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1adf97b002a1795c48d9640f231b315c24b926df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PrimLink.Pages.Admin.Views_Admin_SignUpRequests), @"mvc.1.0.view", @"/Views/Admin/SignUpRequests.cshtml")]
namespace PrimLink.Pages.Admin
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
#line 1 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Admin\SignUpRequests.cshtml"
using Model.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1adf97b002a1795c48d9640f231b315c24b926df", @"/Views/Admin/SignUpRequests.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18e57a331d4e28b5ccd17f1aef09b2ee05452014", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_SignUpRequests : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/pages/Admin/Admin.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Admin\SignUpRequests.cshtml"
  
    ViewData["Title"] = "Admin Panel";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""content-wrapper"">
    <!-- Content Header (Page header) -->
    <section class=""content-header"">
        <h1>
            User Account Requests
        </h1>
        <ol class=""breadcrumb"">
            <li><a href=""#""><i class=""fa fa-dashboard""></i> Home</a></li>
            <li class=""active"">User Account Requests</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class=""content"">
        <!-- Main row -->
        <div class=""row"">
            <div class=""col-md-12"">
                ");
#nullable restore
#line 24 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Admin\SignUpRequests.cshtml"
            Write(Html.Kendo().Grid<UserModel>()
                    .Name("UserRequestGrid")
                    .Columns(columns =>
                    {
                        columns.Command(command =>
                        {
                            command.Custom("Approve").Text("").IconClass("icon-pencil7").Click("approveUser")
                        .HtmlAttributes(new { title = "Approve", data_toggle = "tooltip", @class = "grid-edit-icon c_blue" }).Visible("isDestroyVisible");
                            command.Custom("Reject").Text("").IconClass("icon-cancel-square").Click("rejectUser")
                        .HtmlAttributes(new { title = "Reject", data_toggle = "tooltip", @class = "grid-trash-icon c_theme" }).Visible("isDestroyVisible");
                        }).Width(40).Title("Action");
                        columns.Bound(reason => reason.Id).Hidden(true);
                        columns.Bound(reason => reason.FirstName).Title("First Name").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                        columns.Bound(reason => reason.LastName).Title("Last Name").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                        columns.Bound(reason => reason.UserName).Title("Username").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                        columns.Bound(reason => reason.Email).Title("Email Address").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                        columns.Bound(reason => reason.Company).Title("Company").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                        columns.Bound(reason => reason.Country).Title("Country").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                        columns.Bound(reason => reason.Status).Title("Status").Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").ShowOperators(false).SuggestionOperator(FilterType.Contains))).Width(40);
                    })
                    .Pageable()
                    .Scrollable()
                    .Resizable(x => x.Columns(true))
                    .ToolBar(e =>
                    {
                        e.Excel().Text("Export to Excel").HtmlAttributes(new { id = "excel", @class = "floatRight" });
                    })
                    .Excel(excel => excel
                    .FileName("UserRequestList.xlsx")
                    .Filterable(true)
                    .AllPages()
                    .ProxyURL(Url.Action("Excel_Export_Save", "Admin")))
                    .Filterable(ftb => ftb.Mode(GridFilterMode.Row))
                    .HtmlAttributes(new { style = "height:100%;" })
                    .DataSource(dataSource => dataSource
                    .Ajax()
                    .PageSize(8)
                    .ServerOperation(false)
                    .Read(read => read.Action("GetUserRequestGrid", "Admin")))
                    .NoRecords(true)
                    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n        <!-- /.row (main row) -->\r\n\r\n    </section>\r\n    <!-- /.content -->\r\n</div>\r\n\r\n");
#nullable restore
#line 74 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Admin\SignUpRequests.cshtml"
Write(Html.Kendo().Window()
.Name("AddEditUserRequest")
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1adf97b002a1795c48d9640f231b315c24b926df8865", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 83 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Admin\SignUpRequests.cshtml"
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
            WriteLiteral("\r\n<script src=\"//cdnjs.cloudflare.com/ajax/libs/jszip/2.4.0/jszip.min.js\"></script>\r\n\r\n\r\n\r\n");
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
