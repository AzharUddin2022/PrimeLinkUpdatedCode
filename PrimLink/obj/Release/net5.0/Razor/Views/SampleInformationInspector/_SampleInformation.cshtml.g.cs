#pragma checksum "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5c47753c18e89019b72fb50c38e0c19c936dc634692878c03a1e13c0c0232575"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PrimLink.Pages.SampleInformationInspector.Views_SampleInformationInspector__SampleInformation), @"mvc.1.0.view", @"/Views/SampleInformationInspector/_SampleInformation.cshtml")]
namespace PrimLink.Pages.SampleInformationInspector
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
#line 1 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
using Model.Common.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
using Model.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"5c47753c18e89019b72fb50c38e0c19c936dc634692878c03a1e13c0c0232575", @"/Views/SampleInformationInspector/_SampleInformation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"e53d7b0bf4f7f7aeabde534ef584e632607b98e9a137c086afa7c4f4687f8998", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_SampleInformationInspector__SampleInformation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SampleInformationModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "SampleInformation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "InsertUpdateSampleInformation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("sampleInformationForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c47753c18e89019b72fb50c38e0c19c936dc634692878c03a1e13c0c02325757101", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 6 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
Write(Html.HiddenFor(x => x.Id, new { id = "Id" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 7 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
Write(Html.HiddenFor(x => x.UserId, new { id = "userId" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 8 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
Write(Html.HiddenFor(x => x.UserFormId, new { id = "userFormId" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 9 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
Write(Html.HiddenFor(x => x.IsAdmin, new { id = "isAdmin" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 10 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
Write(Html.HiddenFor(x => x.IsReferSample, new { id = "isReferSample" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 11 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
Write(Html.HiddenFor(x => x.IsCollectSample, new { id = "isCollectSample" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <div class=""col-lg-12"">
        <h1 style=""font-weight:bold"">Sample Information</h1>
        <h3 style=""font-weight:bold"">Approval Samples</h3>
        <br />
        <div class=""row"">
            <div class=""col-lg-6"">
                <label>Will you provide us with reference/golden sample(s) ?</label>
                <div class=""form-group"">
                    ");
#nullable restore
#line 20 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
                Write(Html.Kendo().SwitchFor(m => m.IsReferSample)
                        .Checked(Model != null ? Model.IsReferSample == true ? true : false : false)
                        .Events(ev => ev.Change("onChangeStatus6"))
                        .HtmlAttributes(new { style = "width:100px;" })
                        .Messages(c => c.Checked("Yes").Unchecked("No"))
                        
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <label>Where do you want to send ?</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 32 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.SendingDestination)
                        .Placeholder("Enter Sending Destination")
                        .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Your Sending Destination", id = "SendingDestination" })
                        
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
                <label>Courier Company Name</label>
                <div class=""form-group"">
                    ");
#nullable restore
#line 45 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.CourierCompanyName)
                        .Placeholder("Enter Courier Company Name")
                        .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Your Sending Destination", id = "CourierCompanyName" })
                        
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <label>Tracking Number</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 55 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.TrackingNumber)
                        .Placeholder("Enter Tracking Number")
                        .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Your Sending Destination", id = "TrackingNumber" })
                        
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
                <label>What to do of your samples after the inspection ?</label>
                <div class=""form-group"">
                    ");
#nullable restore
#line 68 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.ToDoAfterInspection)
                        .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter To Do After Inspection", id = "ToDoAfterInspection" })
                        
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <label>Courier Account number</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 77 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.CourierAccountNumber)
                        .Placeholder("Enter Courier Account Number")
                        .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Courier Account Number", id = "CourierAccountNumber" })
                        
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <br />\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-6\">\r\n                <label>Delivery Address</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 90 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.DeliveryAddress)
                        .Placeholder("Enter Delivery Address")
                        .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Delivery Address", id = "DeliveryAddress" })
                        
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <label>Contact Person</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 100 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.ContactPerson)
                        .Placeholder("Enter Contact Person")
                        .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Contact Person", id = "ContactPerson" })
                        
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <br />\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-6\">\r\n                <label>Email Address</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 113 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.Email)
                        .Placeholder("Enter Email Address")
                        .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Email Address", id = "SampleInfoEmail" })
                        
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <label>Phone Number</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 123 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.PhoneNumber)
                        .Placeholder("Enter Phone Number")
                        .HtmlAttributes(new { @class = "w-100", required = "required", id = "SampleInfoPhoneNumber", type = "tel", pattern = "03[0-9]{2}-(?!1234567)(?!1111111)(?!7654321)[0-9]{7}", ValidationMessage = "Enter exactly this format 0312-3456789" })
                        
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <br />\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-6\">\r\n                <label>Comment</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 136 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
                Write(Html.Kendo().TextAreaFor(m => m.Comment)
                        .Placeholder("Enter Comment")
                        .Rows(3)
                        .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Comment", id = "Comment" })
                        
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
            </div>
        </div>
        <br />
        <h3 style=""font-weight:bold"">Production Samples</h3>
        <br />
        <div class=""row"">
            <div class=""col-lg-6"">
                <label>Do you want us to collect samples from mass production ? </label>
                <div class=""form-group"">
                    ");
#nullable restore
#line 152 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
                Write(Html.Kendo().SwitchFor(m => m.IsCollectSample)
                        .Checked(Model != null ? Model.IsCollectSample == true ? true : false : false)
                        .Events(ev => ev.Change("onChangeStatus7"))
                        .HtmlAttributes(new { style = "width:100px;" })
                        .Messages(c => c.Checked("Yes").Unchecked("No"))
                        
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <br />\r\n        <div class=\"row\" style=\"float:right\">\r\n            <div class=\"col-md-12\" id=\"eventBtns\">\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
#line 5 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
__Kendo_Mvc_TagHelpers_ValidatorTagHelper.IsEnabled = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("kendo-validator", __Kendo_Mvc_TagHelpers_ValidatorTagHelper.IsEnabled, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
#nullable restore
#line 5 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c47753c18e89019b72fb50c38e0c19c936dc634692878c03a1e13c0c023257522987", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
#nullable restore
#line 176 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\SampleInformationInspector\_SampleInformation.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SampleInformationModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
