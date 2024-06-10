#pragma checksum "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7372dcde05f29947722c000ee55684617eba4a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PrimLink.Pages.ReportInspector.Views_ReportInspector_Index), @"mvc.1.0.view", @"/Views/ReportInspector/Index.cshtml")]
namespace PrimLink.Pages.ReportInspector
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
#line 1 "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml"
using Model.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7372dcde05f29947722c000ee55684617eba4a6", @"/Views/ReportInspector/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18e57a331d4e28b5ccd17f1aef09b2ee05452014", @"/Views/_ViewImports.cshtml")]
    public class Views_ReportInspector_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GeneralInformationModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml"
  
    ViewData["Title"] = "Report";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml"
Write(Html.HiddenFor(x => x.IsAdmin, new { id = "isAdmin" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml"
Write(Html.HiddenFor(x => x.Id, new { id = "userId" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<table class=""table table-bordered"">
    <thead>
        <tr>
            <th>Products</th>
            <th>Protocol Status</th>
            <th>Report Status</th>
            <th>Inspected By</th>
            <th>Reviewed By</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 22 "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml"
         foreach (var item in Model.References)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 25 "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml"
               Write(item.PO);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 25 "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml"
                          Write(item.SKU);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td style=\"background-color: #4FA35F; color: white;\">Validated</td>\r\n                <td style=\"background-color: #4FA35F; color: white;\"v>Validated</td>\r\n                <td>");
#nullable restore
#line 28 "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml"
               Write(Model.AllocatedTo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>Admin</td>\r\n                <td style =\"color: darkred;\">\r\n                    <ul>\r\n                        <li>\r\n                            <a style=\"color: darkred;\" data-value=\"");
#nullable restore
#line 33 "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml"
                                                              Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("href", " href=\"", 1060, "\"", 1127, 1);
#nullable restore
#line 33 "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml"
WriteAttributeValue("", 1067, Url.Action("GetFillReport", "Report", new { id = item.Id }), 1067, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btnEdit\">Fill the report</a>\r\n                        </li>\r\n                        <li>\r\n                            <a style=\"color: darkred;\" data-value=\"");
#nullable restore
#line 36 "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml"
                                                              Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("href", " href=\"", 1303, "\"", 1370, 1);
#nullable restore
#line 36 "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml"
WriteAttributeValue("", 1310, Url.Action("GetViewReport", "Report", new { id = item.Id }), 1310, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btnDelete\">View the report</a>\r\n                        </li>\r\n                    </ul>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 41 "D:\Prime\PrimLink\Views\ReportInspector\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
