#pragma checksum "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1017c6eadb7de3a33df9abef567d010a5acd296f04b0037998946714429cbe7b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PrimLink.Pages.InspectionScopeAndAQL.Views_InspectionScopeAndAQL__InspectionScopeAndAQL), @"mvc.1.0.view", @"/Views/InspectionScopeAndAQL/_InspectionScopeAndAQL.cshtml")]
namespace PrimLink.Pages.InspectionScopeAndAQL
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\_ViewImports.cshtml"
using PrimLink;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
using Model.Common.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
using Model.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"1017c6eadb7de3a33df9abef567d010a5acd296f04b0037998946714429cbe7b", @"/Views/InspectionScopeAndAQL/_InspectionScopeAndAQL.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"e53d7b0bf4f7f7aeabde534ef584e632607b98e9a137c086afa7c4f4687f8998", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_InspectionScopeAndAQL__InspectionScopeAndAQL : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InspectionScopeAndAQLModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "InspectionScopeAndAQL", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "InsertUpdateInspectionScopeAndAQL", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("InspectionScopeAndAQLForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-failure", new global::Microsoft.AspNetCore.Html.HtmlString("onFailure"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-success", new global::Microsoft.AspNetCore.Html.HtmlString("onSuccess"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/pages/User/User.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Kendo.Mvc.TagHelpers.ValidatorTagHelper __Kendo_Mvc_TagHelpers_ValidatorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1017c6eadb7de3a33df9abef567d010a5acd296f04b0037998946714429cbe7b7100", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 6 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
Write(Html.HiddenFor(x => x.Id, new { id = "Id" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 7 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
Write(Html.HiddenFor(x => x.UserId, new { id = "userId" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 8 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
Write(Html.HiddenFor(x => x.UserFormId, new { id = "userFormId" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 9 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
Write(Html.HiddenFor(x => x.IsAdmin, new { id = "isAdmin" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 10 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
Write(Html.HiddenFor(x => x.IsFunctionCheck, new { id = "isFunctionCheck" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 11 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
Write(Html.HiddenFor(x => x.IsQuantityCheck, new { id = "isQuantityCheck" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 12 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
Write(Html.HiddenFor(x => x.IsPkgePackShipCheck, new { id = "isPkgePackShipCheck" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 13 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
Write(Html.HiddenFor(x => x.IsProductLabelCheck, new { id = "isProductLabelCheck" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 14 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
Write(Html.HiddenFor(x => x.IsDimensionCheck, new { id = "isDimensionCheck" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 15 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
Write(Html.HiddenFor(x => x.IsOnSiteTest, new { id = "isOnSiteTest" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <div class=""col-lg-12"">
        <h1 style=""font-weight:bold"">Inspection Scope and AQL</h1>
        <h3 style=""font-weight:bold"">Inspection Scope</h3>
        <br />
        <div class=""row"">
            <div class=""col-lg-6"">
                <label>Workmanship and Basic Function Check</label>
                <div class=""form-group"">
                    ");
#nullable restore
#line 24 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                Write(Html.Kendo().SwitchFor(m => m.IsFunctionCheck)
                        .Checked(Model != null ? Model.IsFunctionCheck == true ? true : false : false)
                        .Events(ev => ev.Change("onChangeStatus8"))
                        .HtmlAttributes(new { style = "width:100px;" })
                        .Messages(c => c.Checked("Yes").Unchecked("No"))
                        .Enabled(Model != null && Model.IsApproved == true ? false : true)
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <label>Quantity Check</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 36 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                Write(Html.Kendo().SwitchFor(m => m.IsQuantityCheck)
                        .Checked(Model != null ? Model.IsQuantityCheck == true ? true : false : false)
                        .Events(ev => ev.Change("onChangeStatus9"))
                        .HtmlAttributes(new { style = "width:100px;" })
                        .Messages(c => c.Checked("Yes").Unchecked("No"))
                        .Enabled(Model != null && Model.IsApproved == true ? false : true)
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
            </div>
        </div>
        <br />
        <div class=""row"">
            <div class=""col-lg-6"">
                <label>Packaging/Packing/Shipping Marks</label>
                <div class=""form-group"">
                    ");
#nullable restore
#line 51 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                Write(Html.Kendo().SwitchFor(m => m.IsPkgePackShipCheck)
                        .Checked(Model != null ? Model.IsPkgePackShipCheck == true ? true : false : false)
                        .Events(ev => ev.Change("onChangeStatus10"))
                        .HtmlAttributes(new { style = "width:100px;" })
                        .Messages(c => c.Checked("Yes").Unchecked("No"))
                        .Enabled(Model != null && Model.IsApproved == true ? false : true)
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <label>Product Labeling/Marking and Other Specifications Check</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 63 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                Write(Html.Kendo().SwitchFor(m => m.IsProductLabelCheck)
                        .Checked(Model != null ? Model.IsProductLabelCheck == true ? true : false : false)
                        .Events(ev => ev.Change("onChangeStatus11"))
                        .HtmlAttributes(new { style = "width:100px;" })
                        .Messages(c => c.Checked("Yes").Unchecked("No"))
                        .Enabled(Model != null && Model.IsApproved == true ? false : true)
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
            </div>
        </div>
        <br />
        <div class=""row"">
            <div class=""col-lg-6"">
                <label>Dimensions & Weight Check</label>
                <div class=""form-group"">
                    ");
#nullable restore
#line 78 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                Write(Html.Kendo().SwitchFor(m => m.IsDimensionCheck)
                        .Checked(Model != null ? Model.IsDimensionCheck == true ? true : false : false)
                        .Events(ev => ev.Change("onChangeStatus12"))
                        .HtmlAttributes(new { style = "width:100px;" })
                        .Messages(c => c.Checked("Yes").Unchecked("No"))
                        .Enabled(Model != null && Model.IsApproved == true ? false : true)
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <label>Specific On Site Tests</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 90 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                Write(Html.Kendo().SwitchFor(m => m.IsOnSiteTest)
                        .Checked(Model != null ? Model.IsOnSiteTest == true ? true : false : false)
                        .Events(ev => ev.Change("onChangeStatus13"))
                        .HtmlAttributes(new { style = "width:100px;" })
                        .Messages(c => c.Checked("Yes").Unchecked("No"))
                        .Enabled(Model != null && Model.IsApproved == true ? false : true)
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
            </div>
        </div>
        <br />
        <h3 style=""font-weight:bold"">Quantity To Inspect per day</h3>
        <br />
        <div class=""row"">
            <div class=""col-lg-6"">
                <label>
                    Based on experience,
                    how many pieces can be inspected in 1 day of work?
                </label>
                <div class=""form-group"">
                    ");
#nullable restore
#line 110 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                Write(Html.Kendo().NumericTextBoxFor(x => x.PiecesInspected)
                        .Min(0)
                        .HtmlAttributes(new { style = "width: 100%;", @class = "w-60", id = "PiecesInspected", required = "required", ValidationMessage = "Please enter Mininum Pieces Inspected" })
                        .Enable(Model != null && Model.IsApproved == true ? false : true)
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
            </div>
        </div>
        <br />
        <h3 style=""font-weight:bold"">Sampling</h3>
        <br />
        <div class=""row"">
            <div class=""col-lg-6"">
                <label>Choose Your Sampling Plan</label>
                <div class=""form-group"">
                    ");
#nullable restore
#line 125 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.SamplePlan)
                        .Placeholder("Enter Sample Plan")
                        .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Sample Plan", id = "SamplePlan" })
                        .Enable(Model != null && Model.IsApproved == true ? false : true)
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <label>Sampling Size</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 135 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.SampleSize)
                        .Placeholder("Enter Sample Size")
                        .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Sample Size", id = "SampleSize" })
                        .Enable(Model != null && Model.IsApproved == true ? false : true)
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
            </div>
        </div>
        <br />
        <h3 style=""font-weight:bold"">Acceptable Quality Limits</h3>
        <br />
         <div class=""row"">
            <div class=""col-lg-4"">
                <label>For Critical Defects</label>
                <div class=""form-group"">
                    ");
#nullable restore
#line 150 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                Write(Html.Kendo().NumericTextBoxFor(x => x.CriticalDefects)
                        .Min(0)
                        .HtmlAttributes(new { style = "width: 100%;", @class = "w-60", id = "CriticalDefects", required = "required", ValidationMessage = "Please enter Critical Defects" })
                        .Enable(Model != null && Model.IsApproved == true ? false : true)
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-4\">\r\n                <label>For Major Defects</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 160 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                Write(Html.Kendo().NumericTextBoxFor(x => x.MajorDefects)
                        .Min(0)
                        .HtmlAttributes(new { style = "width: 100%;", @class = "w-60", id = "MajorDefects", required = "required", ValidationMessage = "Please enter Major Defects" })
                        .Enable(Model != null && Model.IsApproved == true ? false : true)
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-4\">\r\n                <label>For Minor Defects</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 170 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                Write(Html.Kendo().NumericTextBoxFor(x => x.MinorDefects)
                        .Min(0)
                        .HtmlAttributes(new { style = "width: 100%;", @class = "w-60", id = "MinorDefects", required = "required", ValidationMessage = "Please enter Minor Defects" })
                        .Enable(Model != null && Model.IsApproved == true ? false : true)
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\" style=\"float:right\">\r\n            <div class=\"col-md-12\" id=\"eventBtns\">\r\n");
#nullable restore
#line 180 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                 if (Model != null && Model.IsApproved == false)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 182 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                Write(Html.Kendo().Button()
                    .Name("SaveInspectionScopeAndAQL")
                    .HtmlAttributes(new { type = "submit" })
                    .Content(Model.Id > 0 ? "Update" : "Save")
                    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 186 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Kendo_Mvc_TagHelpers_ValidatorTagHelper = CreateTagHelper<global::Kendo.Mvc.TagHelpers.ValidatorTagHelper>();
            __tagHelperExecutionContext.Add(__Kendo_Mvc_TagHelpers_ValidatorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
#nullable restore
#line 5 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
__Kendo_Mvc_TagHelpers_ValidatorTagHelper.IsEnabled = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("kendo-validator", __Kendo_Mvc_TagHelpers_ValidatorTagHelper.IsEnabled, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
#nullable restore
#line 5 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-antiforgery", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\"form\").kendoValidator();\r\n    });\r\n</script>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1017c6eadb7de3a33df9abef567d010a5acd296f04b0037998946714429cbe7b26393", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
#nullable restore
#line 199 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\InspectionScopeAndAQL\_InspectionScopeAndAQL.cshtml"
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
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InspectionScopeAndAQLModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
