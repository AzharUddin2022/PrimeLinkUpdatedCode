#pragma checksum "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "277dba9293295689b4239a9d175eb33840108146"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PrimLink.Pages.GeneralInformationInspector.Views_GeneralInformationInspector__GeneralInformation), @"mvc.1.0.view", @"/Views/GeneralInformationInspector/_GeneralInformation.cshtml")]
namespace PrimLink.Pages.GeneralInformationInspector
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
#line 1 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
using Model.Common.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
using Model.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"277dba9293295689b4239a9d175eb33840108146", @"/Views/GeneralInformationInspector/_GeneralInformation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18e57a331d4e28b5ccd17f1aef09b2ee05452014", @"/Views/_ViewImports.cshtml")]
    public class Views_GeneralInformationInspector__GeneralInformation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GeneralInformationModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/GeneralInformationInspector/_Reference.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/GeneralInformationInspector/_Vendor.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/GeneralInformationInspector/_Factory.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("generalInformationForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-failure", new global::Microsoft.AspNetCore.Html.HtmlString("onFailure"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-success", new global::Microsoft.AspNetCore.Html.HtmlString("onSuccess"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/pages/Inspector/Inspector.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<style>
    .k-button {
        padding: 15px 40px;
        background: #000;
        border: 0;
        color: #fff;
        text-transform: uppercase;
        font-family: helvetica;
        font-size: 12px;
        letter-spacing: 3px;
        position: relative;
        transition: all .4s cubic-bezier(0.645, 0.045, 0.355, 1);
        cursor: pointer;
        display: block;
    }

        .k-button::after,
        .k-button::before {
            content: """";
            position: absolute;
            top: 50%;
            right: 0px;
            transform: translateY(-50%);
            opacity: 0;
            transition: all .4s cubic-bezier(0.645, 0.045, 0.355, 1);
        }

        .k-button::after {
            width: 30px;
            height: 1px;
            background: white;
            transform: translateX(-3px);
            margin-top: 0px;
        }

        .k-button::before {
            content: """";
            transform: rotate(-135deg) translateX(5");
            WriteLiteral(@"0%);
            width: 11px;
            height: 11px;
            background: transparent;
            border-left: 1px solid white;
            border-bottom: 1px solid white;
            margin-top: -1px;
        }


        .k-button:hover {
            padding: 15px 60px 15px 20px;
        }

            .k-button:hover::after,
            .k-button:hover::before {
                opacity: 1;
                right: 15px;
            }


    .btn-hover {
        width: 200px;
        font-size: 16px;
        font-weight: 600;
        color: #fff;
        cursor: pointer;
        margin: 20px;
        height: 55px;
        text-align: center;
        border: none;
        background-size: 300% 100%;
        border-radius: 50px;
        moz-transition: all .4s ease-in-out;
        -o-transition: all .4s ease-in-out;
        -webkit-transition: all .4s ease-in-out;
        transition: all .4s ease-in-out;
    }

        .btn-hover:hover {
            background-positi");
            WriteLiteral(@"on: 100% 0;
            moz-transition: all .4s ease-in-out;
            -o-transition: all .4s ease-in-out;
            -webkit-transition: all .4s ease-in-out;
            transition: all .4s ease-in-out;
        }

        .btn-hover:focus {
            outline: none;
        }

        .btn-hover.color-11 {
            background-image: linear-gradient(to right, #eb3941, #f15e64, #e14e53, #e2373f);
            box-shadow: 0 5px 15px rgba(242, 97, 103, .4);
        }
</style>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "277dba9293295689b4239a9d175eb3384010814610221", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 100 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
Write(Html.HiddenFor(x => x.Id, new { id = "Id" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 101 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
Write(Html.HiddenFor(x => x.UserId, new { id = "userId" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 102 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
Write(Html.HiddenFor(x => x.IsAdmin, new { id = "isAdmin" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 103 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
Write(Html.HiddenFor(x => x.UserFormId, new { id = "userFormId" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 104 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
Write(Html.HiddenFor(x => x.References.Count, new { id = "references" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <div class=""col-lg-12"">
        <h1 style=""font-weight:bold"">General Information</h1>
        <br />
        <div class=""row"">
            <div class=""col-lg-6"">
                <label>Client Expected Service Date</label>
                <div class=""form-group"">
                    ");
#nullable restore
#line 112 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
                Write(Html.Kendo().DatePickerFor(x => x.ServiceDate)
                                .Min(DateTime.Now.ToString())
                                .HtmlAttributes(new { style = "width: 100%", title = "Service Date", id = "ServiceDate", required = "required", ValidationMessage = "Please select service date" })
                                .DateInput(false)
                                
                                );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <label>Expected Shipment Date</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 123 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
                Write(Html.Kendo().DatePickerFor(x => x.ShipmentDate)
                                .Min(DateTime.Now.ToString())
                                .HtmlAttributes(new { style = "width: 100%", title = "Shipment Date", id = "ShipmentDate", required = "required", ValidationMessage = "Please select shipment date" })
                                .DateInput(false)
                                
                                );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <br />\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-6\">\r\n                <label>Product Line</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 137 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
                Write(Html.Kendo().DropDownListFor(x=>x.ProductLine)
                           //.Name("Water")
                           .HtmlAttributes(new { @class = "w-100", id= "ProductLine" })
                           .OptionLabel("Select Product Line")
                           .DataTextField("Text")
                           .DataValueField("Value")
                           .BindTo(new List<SelectListItem>() {
                                            new SelectListItem() {
                                                Text = "Soft Line",
                                                Value = "Soft Line"
                                            },
                                            new SelectListItem() {
                                                Text = "Hard Line",
                                                Value = "Hard Line"
                                            }
                                        })
                            );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <label>Product Category</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 159 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.ProductCategory)
                                   .Placeholder("Enter Product Category")
                                   .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Product Category", id = "ProductCategory" })
                                   
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
                <label>Min % Product To Be Finish</label>
                <div class=""form-group"">
                    ");
#nullable restore
#line 172 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
                Write(Html.Kendo().NumericTextBoxFor(x => x.MinPercentProductToFinish)
                         .Min(0)
                         .Max(100)
                         .Format("##.00 \\%")
                         .HtmlAttributes(new { style = "width: 100%;", @class = "w-60", id = "MinPercentProductToFinish", required = "required", ValidationMessage = "Please enter Mininum Percent" })
                         
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <label>Min % Product To Be Finish And Packed</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 184 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
                Write(Html.Kendo().NumericTextBoxFor(x => x.MinPercentProductToFinishAndPacked)
                         .Min(0)
                         .Max(100)
                         .Format("##.00 \\%")
                         .HtmlAttributes(new { style = "width: 100%;", @class = "w-60", id = "MinPercentProductToFinishAndPacked", required = "required", ValidationMessage = "Please enter Mininum Percent" })
                         
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
                <label>Destination Country For Your Goods</label>
                <div class=""form-group"">
                    ");
#nullable restore
#line 199 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.DestinationCountry)
                                   .Placeholder("Enter Destination Country")
                                   .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Destination Country", id = "DestinationCountry" })
                                   
                            );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <label>Quantity Unit</label>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 209 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
                Write(Html.Kendo().TextBoxFor(m => m.QuantityUnit)
                                   .Placeholder("Enter Quantity Unit")
                                   .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Quantity Unit", id = "QuantityUnit" })
                                   
                            );

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
            </div>
        </div>
        <br />
        <div class=""container"">
            <h2 style=""font-weight:bold"">References</h2>
            <br />
            <div class=""row"">
                <div class=""col-lg-4"">
");
#nullable restore
#line 223 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
                     if (Model != null && Model.IsApproved == false)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <a");
                BeginWriteAttribute("href", " href=\"", 9225, "\"", 9263, 1);
#nullable restore
#line 225 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
WriteAttributeValue("", 9232, Url.Action("DownloadTemplate"), 9232, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"k-button\"><i class=\"fa fa-download\"> Download Template</i></a>\r\n");
#nullable restore
#line 226 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </div>
                <div class=""col-lg-5"" style=""float:right"">
                </div>
            </div>
            <br />
            <div class=""row"">
                <div class=""col-lg-2"">
                    <label for=""PO"" class=""k-form-label font-weight-bold"">PO#</label>
                </div>
                <div class=""col-lg-2"">
                    <label for=""SKU"" class=""k-form-label font-weight-bold"">Item Number</label>
                </div>
                <div class=""col-lg-2"">
                    <label for=""Name"" class=""k-form-label font-weight-bold"">Product Description</label>
                </div>
                <div class=""col-lg-2"">
                    <label for=""Quantity"" class=""k-form-label font-weight-bold"">Quantity</label>
                </div>
                <div class=""col-lg-2"">
                    <label for=""ProductType"" class=""k-form-label font-weight-bold"">Product Type</label>
                </div>
                <div class=""col-lg");
                WriteLiteral(@"-2"">
                    <label class=""k-form-label font-weight-bold"">Action</label>
                </div>
            </div>

            <div class=""from-group mb-0"" id=""referencesLevels"" style=""overflow-y:scroll; overflow-x:hidden"">
                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "277dba9293295689b4239a9d175eb3384010814622955", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 254 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.References;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            </div>
            <div class=""row"">
                <div class=""col-lg-2"">
                </div>
                <div class=""col-lg-2"">
                </div>
                <div class=""col-lg-2"">
                </div>
                <div class=""col-lg-2"">
                    <label class=""k-form-label font-weight-bold"">Total:  </label><label id=""total"" class=""k-form-label font-weight-bold"">0</label>
                </div>
                <div class=""col-lg-2"">
                </div>
                <div class=""col-lg-2"">
                </div>
            </div>
            <div class=""row"" style=""text-align: center;"">
");
#nullable restore
#line 272 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
                 if (Model.IsApproved == false)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <button type=\"button\" id=\"btnAddLevel\" class=\"btn-hover color-11 w-100\"");
                BeginWriteAttribute("onclick", " onclick=\"", 11562, "\"", 11591, 3);
                WriteAttributeValue("", 11572, "AddLevel(", 11572, 9, true);
#nullable restore
#line 274 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
WriteAttributeValue("", 11581, Model.Id, 11581, 9, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 11590, ")", 11590, 1, true);
                EndWriteAttribute();
                WriteLiteral(">Add Level </button>\r\n");
#nullable restore
#line 275 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n        </div>\r\n        <br />\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "277dba9293295689b4239a9d175eb3384010814626702", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 279 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.Vendor;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <br />\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "277dba9293295689b4239a9d175eb3384010814628423", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 281 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.Factory;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <br />\r\n        <div class=\"row\" style=\"float:right\">\r\n            <div class=\"col-md-12\" id=\"eventBtns\">\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Kendo_Mvc_TagHelpers_ValidatorTagHelper = CreateTagHelper<global::Kendo.Mvc.TagHelpers.ValidatorTagHelper>();
            __tagHelperExecutionContext.Add(__Kendo_Mvc_TagHelpers_ValidatorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
#nullable restore
#line 99 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
__Kendo_Mvc_TagHelpers_ValidatorTagHelper.IsEnabled = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("kendo-validator", __Kendo_Mvc_TagHelpers_ValidatorTagHelper.IsEnabled, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
#nullable restore
#line 99 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "277dba9293295689b4239a9d175eb3384010814633163", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
#nullable restore
#line 296 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\GeneralInformationInspector\_GeneralInformation.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GeneralInformationModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
