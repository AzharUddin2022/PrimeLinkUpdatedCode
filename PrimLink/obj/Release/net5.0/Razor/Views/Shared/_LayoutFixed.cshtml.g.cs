#pragma checksum "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6d337591ca404f4ea6ccb052cdca451a22835a0ea0dbe11f874c5e787ab972fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PrimLink.Pages.Shared.Views_Shared__LayoutFixed), @"mvc.1.0.view", @"/Views/Shared/_LayoutFixed.cshtml")]
namespace PrimLink.Pages.Shared
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
#line 2 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\_ViewImports.cshtml"
using Model.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"6d337591ca404f4ea6ccb052cdca451a22835a0ea0dbe11f874c5e787ab972fb", @"/Views/Shared/_LayoutFixed.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"e53d7b0bf4f7f7aeabde534ef584e632607b98e9a137c086afa7c4f4687f8998", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__LayoutFixed : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hold-transition fixed skin-red sidebar-mini"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d337591ca404f4ea6ccb052cdca451a22835a0ea0dbe11f874c5e787ab972fb4004", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <title>");
#nullable restore
#line 6 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\r\n    <!-- Tell the browser to be responsive to screen width -->\r\n    <meta content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\" name=\"viewport\">\r\n\r\n\r\n");
#nullable restore
#line 11 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
      
        await Html.RenderPartialAsync("_CSS");
    

#line default
#line hidden
#nullable disable
                WriteLiteral("    ");
#nullable restore
#line 14 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
Write(RenderSection("Styles", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d337591ca404f4ea6ccb052cdca451a22835a0ea0dbe11f874c5e787ab972fb6040", async() => {
                WriteLiteral("\r\n    <!-- Site wrapper -->\r\n    <div class=\"wrapper\">\r\n\r\n        <header class=\"main-header\">\r\n");
#nullable restore
#line 21 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
             if (Model.Role == 10001)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <!-- Logo -->\r\n                <a");
                BeginWriteAttribute("href", " href=\"", 712, "\"", 767, 1);
#nullable restore
#line 24 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
WriteAttributeValue("", 719, Url.Action("Index", "Admin", new { area = "" }), 719, 48, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""logo"">
                    <!-- mini logo for sidebar mini 50x50 pixels -->
                    <span class=""logo-mini""><b>C</b>ore2</span>
                    <!-- logo for regular state and mobile devices -->
                    <span class=""logo-lg""><b>ASP.NET</b>Core2</span>
                </a>
");
#nullable restore
#line 30 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <!-- Logo -->\r\n                <a");
                BeginWriteAttribute("href", " href=\"", 1180, "\"", 1234, 1);
#nullable restore
#line 34 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
WriteAttributeValue("", 1187, Url.Action("Index", "Home", new { area = "" }), 1187, 47, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""logo"">
                    <!-- mini logo for sidebar mini 50x50 pixels -->
                    <span class=""logo-mini""><b>C</b>ore2</span>
                    <!-- logo for regular state and mobile devices -->
                    <span class=""logo-lg""><b>ASP.NET</b>Core2</span>
                </a>
");
#nullable restore
#line 40 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("            <!-- Header Navbar: style can be found in header.less -->\r\n            ");
#nullable restore
#line 42 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
       Write(Html.Partial("_HeaderNavbar"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </header>\r\n\r\n        <!-- =============================================== -->\r\n        <!-- Left side column. contains the sidebar -->\r\n        ");
#nullable restore
#line 47 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
   Write(Html.Partial("_LeftNavigation"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        <!-- =============================================== -->\r\n        <!-- Content Wrapper. Contains page content -->\r\n        ");
#nullable restore
#line 51 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <!-- /.content-wrapper -->\r\n        ");
#nullable restore
#line 53 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
   Write(Html.Partial("_Footer"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        <!-- Control Sidebar -->\r\n        ");
#nullable restore
#line 56 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
   Write(Html.Partial("_ControlSidebar"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </div>\r\n\r\n\r\n");
#nullable restore
#line 60 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
      
        await Html.RenderPartialAsync("_JS");
    

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n    ");
#nullable restore
#line 65 "C:\Users\areeb\source\repos\PrimLink\PrimLink\Views\Shared\_LayoutFixed.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
