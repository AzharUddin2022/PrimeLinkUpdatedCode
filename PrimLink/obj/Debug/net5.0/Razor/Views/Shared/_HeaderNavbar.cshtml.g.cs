#pragma checksum "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Shared\_HeaderNavbar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d28a4f82d0dde430fbbfe662770f7abebfb5c328"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PrimLink.Pages.Shared.Views_Shared__HeaderNavbar), @"mvc.1.0.view", @"/Views/Shared/_HeaderNavbar.cshtml")]
namespace PrimLink.Pages.Shared
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
#line 1 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Shared\_HeaderNavbar.cshtml"
using Model.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d28a4f82d0dde430fbbfe662770f7abebfb5c328", @"/Views/Shared/_HeaderNavbar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18e57a331d4e28b5ccd17f1aef09b2ee05452014", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__HeaderNavbar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/user2-160x160.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("user-image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("User Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav class=""navbar navbar-static-top"">
    <!-- Sidebar toggle button-->
    <a href=""#"" class=""sidebar-toggle"" data-toggle=""push-menu"" role=""button"">
        <span class=""sr-only"">Toggle navigation</span>
        <span class=""icon-bar""></span>
        <span class=""icon-bar""></span>
        <span class=""icon-bar""></span>
    </a>

    <div class=""navbar-custom-menu"">
        <ul class=""nav navbar-nav"">
            <!-- User Account: style can be found in dropdown.less -->
            <li class=""dropdown user user-menu"">
                <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d28a4f82d0dde430fbbfe662770f7abebfb5c3285495", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <span class=\"hidden-xs\">");
#nullable restore
#line 18 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Shared\_HeaderNavbar.cshtml"
                                       Write(ViewBag.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 18 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Shared\_HeaderNavbar.cshtml"
                                                          Write(ViewBag.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </a>\r\n                <ul class=\"dropdown-menu\">\r\n                    <!-- User image -->\r\n                    <li class=\"user-header\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d28a4f82d0dde430fbbfe662770f7abebfb5c3287529", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                        <p>\r\n                            ");
#nullable restore
#line 26 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Shared\_HeaderNavbar.cshtml"
                       Write(ViewBag.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 26 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Shared\_HeaderNavbar.cshtml"
                                          Write(ViewBag.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <small>");
#nullable restore
#line 27 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Shared\_HeaderNavbar.cshtml"
                              Write(ViewBag.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</small>
                        </p>
                    </li>
                    <!-- Menu Footer-->
                    <li class=""user-footer"" style=""background-color: #222d32"">
                        <div class=""pull-right"">
                            <a");
            BeginWriteAttribute("href", " href=\"", 1501, "\"", 1538, 1);
#nullable restore
#line 33 "C:\Users\sd118\Downloads\PrimLink_20_01_2024\PrimLink_20_01_2024\PrimLink\Views\Shared\_HeaderNavbar.cshtml"
WriteAttributeValue("", 1508, Url.Action("Logout", "Login"), 1508, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-default btn-flat"">Sign out</a>
                        </div>
                    </li>
                </ul>
            </li>
            <!-- Control Sidebar Toggle Button -->
            <li>
                <a href=""#"" data-toggle=""control-sidebar""><i class=""fa fa-gears""></i></a>
            </li>
        </ul>
    </div>
</nav>");
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
