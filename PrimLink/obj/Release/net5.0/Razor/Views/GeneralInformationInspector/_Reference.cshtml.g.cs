#pragma checksum "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "92eb655f3bc93b721a0b5861c59431653fcdc8e4dd0bfd356db003505022b892"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PrimLink.Pages.GeneralInformationInspector.Views_GeneralInformationInspector__Reference), @"mvc.1.0.view", @"/Views/GeneralInformationInspector/_Reference.cshtml")]
namespace PrimLink.Pages.GeneralInformationInspector
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
#line 1 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
using Model.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"92eb655f3bc93b721a0b5861c59431653fcdc8e4dd0bfd356db003505022b892", @"/Views/GeneralInformationInspector/_Reference.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"e53d7b0bf4f7f7aeabde534ef584e632607b98e9a137c086afa7c4f4687f8998", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_GeneralInformationInspector__Reference : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ReferenceModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
 for (int i = 0; i < Model.Count; i++)
{
    int iteration = Model[i].i;
    if (i != 0)
    {
        iteration = i;
    }
    var sno = iteration + 1;
    var id = "Title-" + iteration;
    var lcounter = "lcounter_" + id;
    var lchr_error = "lchr_error_" + id;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row divReferenceLevel\"");
            BeginWriteAttribute("id", " id=\"", 366, "\"", 375, 1);
#nullable restore
#line 14 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
WriteAttributeValue("", 371, sno, 371, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"col-lg-12\">\r\n            ");
#nullable restore
#line 16 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
       Write(Html.HiddenFor(m => Model[i].GeneralInformationId, new { @id = "GeneralInformationId-" + iteration }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 17 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
       Write(Html.HiddenFor(x => Model[i].Id, new { @id = "Rowid-" + iteration }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 18 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
       Write(Html.HiddenFor(x => Model[i].i, new { @id = "iterator" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 19 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
       Write(Html.HiddenFor(x => Model[i].LevelNo, new { @id = "LevelNo-" + iteration }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n        <div class=\"col-lg-2\"");
            BeginWriteAttribute("id", " id=\"", 820, "\"", 838, 2);
            WriteAttributeValue("", 825, "PO_", 825, 3, true);
#nullable restore
#line 22 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
WriteAttributeValue("", 828, iteration, 828, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 24 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
            Write(Html.Kendo().TextBoxFor(m => m[i].PO)
                    .Placeholder("Enter PO#")
                    .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter PO#", id = "PO" + iteration })
                    
                    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"col-lg-2\"");
            BeginWriteAttribute("id", " id=\"", 1245, "\"", 1264, 2);
            WriteAttributeValue("", 1250, "SKU_", 1250, 4, true);
#nullable restore
#line 32 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
WriteAttributeValue("", 1254, iteration, 1254, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 34 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
            Write(Html.Kendo().TextBoxFor(m => m[i].SKU)
                    .Placeholder("Enter SKU#")
                    .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter SKU#", id = "SKU" + iteration })
                    
                    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"col-lg-2\"");
            BeginWriteAttribute("id", " id=\"", 1675, "\"", 1695, 2);
            WriteAttributeValue("", 1680, "Name_", 1680, 5, true);
#nullable restore
#line 42 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
WriteAttributeValue("", 1685, iteration, 1685, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 44 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
            Write(Html.Kendo().TextBoxFor(m => m[i].Name)
                    .Placeholder("Enter Name")
                    .HtmlAttributes(new { @class = "w-100", id = "Name" + iteration })
                    
                    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"col-lg-2\"");
            BeginWriteAttribute("id", " id=\"", 2044, "\"", 2068, 2);
            WriteAttributeValue("", 2049, "Quantity_", 2049, 9, true);
#nullable restore
#line 52 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
WriteAttributeValue("", 2058, iteration, 2058, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 54 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
            Write(Html.Kendo().NumericTextBoxFor(m => m[i].Quantity)
                    .Min(0)
                    .Events(ev => ev.Change("OnChangeQuantity"))
                    .HtmlAttributes(new { style = "width: 100%;", @class = "w-60", id = "Quantity" + iteration, required = "required", ValidationMessage = "Please Enter Quantity" })
                    
                    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-lg-2\"");
            BeginWriteAttribute("id", " id=\"", 2568, "\"", 2595, 2);
            WriteAttributeValue("", 2573, "ProductType_", 2573, 12, true);
#nullable restore
#line 62 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
WriteAttributeValue("", 2585, iteration, 2585, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 64 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
            Write(Html.Kendo().TextBoxFor(m => m[i].Name)
                    .Placeholder("Enter Product Type")
                    .HtmlAttributes(new { @class = "w-100", required = "required", ValidationMessage = "Please Enter Product Type", id = "ProductType" + iteration })
                    
                    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-lg-2\"");
            BeginWriteAttribute("id", " id=\"", 3029, "\"", 3054, 2);
            WriteAttributeValue("", 3034, "deleteBtn_", 3034, 10, true);
#nullable restore
#line 71 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
WriteAttributeValue("", 3044, iteration, 3044, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        </div>\r\n\r\n\r\n        <hr />\r\n    </div>\r\n");
#nullable restore
#line 77 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\GeneralInformationInspector\_Reference.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ReferenceModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
