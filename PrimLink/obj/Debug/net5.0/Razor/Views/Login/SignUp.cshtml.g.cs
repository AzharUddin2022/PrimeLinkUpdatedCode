#pragma checksum "D:\Prime\PrimLink\Views\Login\SignUp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6392a4ddb8887a1557f856c6a44d55bc1942543d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PrimLink.Pages.Login.Views_Login_SignUp), @"mvc.1.0.view", @"/Views/Login/SignUp.cshtml")]
namespace PrimLink.Pages.Login
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
#line 1 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
using Model.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6392a4ddb8887a1557f856c6a44d55bc1942543d", @"/Views/Login/SignUp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18e57a331d4e28b5ccd17f1aef09b2ee05452014", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_SignUp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SignUpUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frmSignup"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("POST"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-failure", new global::Microsoft.AspNetCore.Html.HtmlString("onFailureSignUp"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-success", new global::Microsoft.AspNetCore.Html.HtmlString("onSuccessSignUp"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/pages/Admin/Admin.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div id=\"htmlLoader\" style=\"z-index:10008 !important;\"></div>\r\n<style type=\"text/css\">\r\n\r\n    .swal-overlay {\r\n        z-index: 10006;\r\n    }\r\n</style>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6392a4ddb8887a1557f856c6a44d55bc1942543d6553", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 13 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
Write(Html.HiddenFor(model => model.Id, new { @id = "Id" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 14 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
Write(Html.HiddenFor(model => model.CreatedBy, new { @createdBy = "CreatedBy" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 15 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
Write(Html.HiddenFor(model => model.CreatedDate, new { @createdDate = "CreatedDate" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 16 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
Write(Html.HiddenFor(model => model.IsActive, new { @isActive = "IsActive" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""row align-content-center"">
                    <div class=""col-md-6"">
                        <label>First Name<span class=""c_red"">*</span></label>
                        <div class=""form-group"">
                            ");
#nullable restore
#line 24 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
                        Write(Html.Kendo().TextBoxFor(x => x.FirstName)
							.HtmlAttributes(new { @class = "w-100", @id = "txt_FirstName", @required = "required" })
							.Placeholder("Enter First Name")
							);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <label>Last Name<span class=""c_red"">*</span></label>
                        <div class=""form-group"">
                            ");
#nullable restore
#line 33 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
                        Write(Html.Kendo().TextBoxFor(x => x.LastName)
							.HtmlAttributes(new { @class = "w-100", @id = "txt_LastName", @required = "required" })
							.Placeholder("Enter Last Name")
							);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <br />
                <div class=""row align-content-center"">
                    <div class=""col-md-6"">
                        <label>Company<span class=""c_red"">*</span></label>
                        <div class=""form-group"">
                            ");
#nullable restore
#line 45 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
                        Write(Html.Kendo().TextBoxFor(x => x.Company)
                                .HtmlAttributes(new { @class = "w-100", @id = "txt_Company", @required = "required"/*, @onblur = "locNameKeyUp1(this)"*/ })
                                .Placeholder("Enter UserName")
                                );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
                WriteLiteral(@"                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <label>Country<span class=""c_red"">*</span></label>
                        <div class=""form-group"">
                            ");
#nullable restore
#line 55 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
                        Write(Html.Kendo().DropDownListFor(x => x.Country)
                                .HtmlAttributes(new { @class = "w-100", @id = "LoadCountry", @required = "required" })
                                .OptionLabel("Select Country")
                                .DataTextField("DisplayName")
                                .DataValueField("DisplayName")
                                .BindTo(Model.dropdownBinderModel1)
                                .Filter(FilterType.StartsWith)

                                );

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <br />
                <div class=""row align-content-center"">
                    <div class=""col-md-6"">
                        <label>UserName<span class=""c_red"">*</span></label>
                        <div class=""form-group"">
                            ");
#nullable restore
#line 72 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
                        Write(Html.Kendo().TextBoxFor(x => x.UserName)
                            .HtmlAttributes(new { @class = "w-100", @id = "txt_UserName", @required = "required"/*, @onblur = "locNameKeyUp1(this)"*/ })
                            .Placeholder("Enter UserName")
							);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
                WriteLiteral(@"                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <label>Email Address<span class=""c_red"">*</span></label>
                        <div class=""form-group"">
                            ");
#nullable restore
#line 82 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
                        Write(Html.Kendo().TextBoxFor(x => x.Email)
							.HtmlAttributes(new { @class = "w-100", @id = "txt_Email", @required = "required", @onblur = "locNameKeyUp(this)" })
							.Placeholder("Enter Email Address")
							);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            <label id=""lblEmail"" style=""display:none;"" class=""k-form-error k-invalid-msg field-validation-error"">Email already exists.</label>
                        </div>
                    </div>
                </div>
                <br />
                <div class=""row align-content-center"">
                    <div class=""col-md-6"">
                        <label>Create Password<span class=""c_red"">*</span></label>
                        <div class=""form-group"">
                            ");
#nullable restore
#line 95 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
                        Write(Html.Kendo().TextBoxFor(x => x.Password)
							.HtmlAttributes(new { @class = "w-100", @id = "txt_Password", @required = "required" })
							.Placeholder("Enter Password")
							);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            <span id=""casd"" class=""glyphicon glyphicon-ok form-control-feedback"" aria-hidden=""true""></span>
                        </div>
                    </div>
                    <div class=""col-md-6"">
                        <label>Phone Number<span class=""c_red"">*</span></label>
                        <div class=""form-group"">
                            ");
#nullable restore
#line 105 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
                        Write(Html.Kendo().TextBoxFor(x => x.PhoneNumber)
                            .HtmlAttributes(new { @class = "w-100", @id = "txt_PhoneNumber", @required = "required" })
                            .Placeholder("Enter Phone Number")
                                .Events(e => e.Change("validateNumericInput"))
                            );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
                WriteLiteral(@"                        </div>
                    </div>
                </div>
                <br />

                <div class=""row align-content-center"">
                    <div class=""col-md-12"">
                        <div class=""from-group mb-0"">
                            ");
#nullable restore
#line 123 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
                        Write(Html.Kendo().Button()
							.Name("CancelUser")
							.Content("Cancel")
							.HtmlAttributes(new { type = "button", @class = "btn-style-1" })
                                .Events(ev => ev.Click("onCancelSignUp"))
							);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
#nullable restore
#line 129 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
                        Write(Html.Kendo().Button()
							.Name("SaveUser")
							.Content("Create my Account")
							.HtmlAttributes(new { type = "submit", @class = "btn-style-1" })
							);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
#nullable restore
#line 12 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
__Kendo_Mvc_TagHelpers_ValidatorTagHelper.IsEnabled = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("kendo-validator", __Kendo_Mvc_TagHelpers_ValidatorTagHelper.IsEnabled, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 12 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
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
            WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\"form\").kendoValidator();\r\n\r\n        \r\n    });\r\n</script>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6392a4ddb8887a1557f856c6a44d55bc1942543d18781", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
#nullable restore
#line 149 "D:\Prime\PrimLink\Views\Login\SignUp.cshtml"
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
