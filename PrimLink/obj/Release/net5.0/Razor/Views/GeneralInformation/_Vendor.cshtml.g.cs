#pragma checksum "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "bd2b7680becaa616db86ba55cc0d5fd5a4b5c63405f99c7ba869b0f1f43b77db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PrimLink.Pages.GeneralInformation.Views_GeneralInformation__Vendor), @"mvc.1.0.view", @"/Views/GeneralInformation/_Vendor.cshtml")]
namespace PrimLink.Pages.GeneralInformation
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
#line 1 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
using Model.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"bd2b7680becaa616db86ba55cc0d5fd5a4b5c63405f99c7ba869b0f1f43b77db", @"/Views/GeneralInformation/_Vendor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"e53d7b0bf4f7f7aeabde534ef584e632607b98e9a137c086afa7c4f4687f8998", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_GeneralInformation__Vendor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VendorModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
Write(Html.HiddenFor(x => x.Id, new { id = "vendorId" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
Write(Html.HiddenFor(x => x.GeneralInformationId, new { id = "generalInformationId" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
Write(Html.HiddenFor(x => x.IsVendorEmailIncluded, new { id = "isEmailIncluded" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-lg-3\">\r\n        <h1 style=\"font-weight:bold\">Vendor Detail</h1>\r\n\r\n    </div>\r\n    <div class=\"col-lg-3 align-self-end\">\r\n");
#nullable restore
#line 13 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
         if (Model.Id > 0)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().SwitchFor(m => m.IsVendor)
                .Checked(true)
                .Events(ev => ev.Change("onChangeVendor"))
                .HtmlAttributes(new { style = "width:100px;" })
                .Messages(c => c.Checked("Yes").Unchecked("No"))
                .Enabled(Model != null && Model.IsApproved == true ? false : true)
                );

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
                 
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().SwitchFor(m => m.IsVendor)
                .Checked(Model != null ? Model.IsVendor == true ? true : false : false)
                .Events(ev => ev.Change("onChangeVendor"))
                .HtmlAttributes(new { style = "width:100px;" })
                .Messages(c => c.Checked("Yes").Unchecked("No"))
                .Enabled(Model != null && Model.IsApproved == true ? false : true)
                );

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
                 
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n<br />\r\n<div class=\"row\">\r\n    <div class=\"col-lg-6\">\r\n        <label>Vendor Preset</label>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 40 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().TextBoxFor(m => m.VendorPreset)
                .Placeholder("Enter Vendor Preset")
                .HtmlAttributes(new { @class = "w-100", id = "VendorPreset" })
                .Enable(Model != null && Model.IsApproved == true ? false : true)
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"col-lg-6\">\r\n        <label>Vendor Company Name</label>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 50 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().TextBoxFor(m => m.VendorCompanyName)
                .Placeholder("Enter Vendor Company Name")
                .HtmlAttributes(new { @class = "w-100", id = "VendorCompanyName" })
                .Enable(Model != null && Model.IsApproved == true ? false : true)
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<br />\r\n<div class=\"row\">\r\n    <div class=\"col-lg-6\">\r\n        <label>Company Phone Number</label>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 63 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().TextBoxFor(x => x.CompanyPhoneNumber)
                .HtmlAttributes(new { @class = "w-100", @id = "CompanyPhoneNumber", @required = "required", ValidationMessage = "Please Enter Vendor Company Phone Number" })
                .Placeholder("Enter Company Phone Number")
                .Enable(Model != null && Model.IsApproved == true ? false : true)
                .Events(e => e.Change("validateNumericInput"))
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"col-lg-6\">\r\n        <label>Company Address</label>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 74 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().TextBoxFor(m => m.CompanyAddress)
                .Placeholder("Enter Company Address")
                .HtmlAttributes(new { @class = "w-100", id = "CompanyAddress" })
                .Enable(Model != null && Model.IsApproved == true ? false : true)
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<br />\r\n<div class=\"row\">\r\n    <div class=\"col-lg-6\">\r\n        <label>Country</label>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 87 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().TextBoxFor(m => m.Country)
                .Placeholder("Enter Country")
                .HtmlAttributes(new { @class = "w-100", id = "Country" })
                .Enable(Model != null && Model.IsApproved == true ? false : true)
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"col-lg-6\">\r\n        <label>Province</label>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 97 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().TextBoxFor(m => m.Province)
                .Placeholder("Enter Province")
                .HtmlAttributes(new { @class = "w-100", id = "Province" })
                .Enable(Model != null && Model.IsApproved == true ? false : true)
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<br />\r\n<div class=\"row\">\r\n    <div class=\"col-lg-6\">\r\n        <label>City</label>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 110 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().TextBoxFor(m => m.City)
                .Placeholder("Enter City")
                .HtmlAttributes(new { @class = "w-100", id = "City" })
                .Enable(Model != null && Model.IsApproved == true ? false : true)
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"col-lg-6\">\r\n        <label>Nature Of Your Vendor</label>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 120 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().TextBoxFor(m => m.NatureOfVendor)
                .Placeholder("Enter Nature Of Vendor")
                .HtmlAttributes(new { @class = "w-100", id = "NatureOfVendor" })
                .Enable(Model != null && Model.IsApproved == true ? false : true)
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<br />\r\n<h3 style=\"font-weight:bold\">Vendor Contact</h3>\r\n<br />\r\n<div class=\"row\">\r\n    <div class=\"col-lg-6\">\r\n        <label>First Name</label>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 135 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().TextBoxFor(m => m.FirstName)
                .Placeholder("Enter First Name")
                .HtmlAttributes(new { @class = "w-100", id = "FirstName" })
                .Enable(Model != null && Model.IsApproved == true ? false : true)
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"col-lg-6\">\r\n        <label>Last Name</label>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 145 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().TextBoxFor(m => m.LastName)
                .Placeholder("Enter Last Name")
                .HtmlAttributes(new { @class = "w-100", id = "LastName" })
                .Enable(Model != null && Model.IsApproved == true ? false : true)
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<br />\r\n<div class=\"row\">\r\n    <div class=\"col-lg-6\">\r\n        <label>Email Address</label>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 158 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().TextBoxFor(m => m.Email)
                .Placeholder("Enter Email Address")
                .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Email Address", id = "Email" })
                .Enable(Model != null && Model.IsApproved == true ? false : true)
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"col-lg-6\">\r\n        <label>Phone Number</label>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 168 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
        Write(Html.Kendo().TextBoxFor(x => x.PhoneNumber)
                .HtmlAttributes(new { @class = "w-100", @id = "PhoneNumber", @required = "required", ValidationMessage = "Please Enter Phone Number" })
                .Placeholder("Enter Phone Number")
                .Enable(Model != null && Model.IsApproved == true ? false : true)
                .Events(e => e.Change("validateNumericInput"))
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<br />\r\n<div class=\"row\">\r\n    <div class=\"col-lg-6\">\r\n        <label>Do you want to be in copy of all emails to your vendor ?</label>\r\n\r\n        ");
#nullable restore
#line 182 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformation\_Vendor.cshtml"
    Write(Html.Kendo().SwitchFor(m => m.IsVendorEmailIncluded)
            .Checked(Model != null ? Model.IsVendorEmailIncluded == true ? true : false : false)
            .Events(ev => ev.Change("onChangeStatus"))
            .HtmlAttributes(new { style = "width:100px;" })
            .Messages(c => c.Checked("Yes").Unchecked("No"))
            .Enabled(Model != null && Model.IsApproved == true ? false : true)
            );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VendorModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591