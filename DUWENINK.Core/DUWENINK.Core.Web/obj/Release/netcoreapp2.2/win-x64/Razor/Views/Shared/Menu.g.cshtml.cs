#pragma checksum "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9283517fe419976825c425bce99cb64133719b04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Menu), @"mvc.1.0.view", @"/Views/Shared/Menu.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Menu.cshtml", typeof(AspNetCore.Views_Shared_Menu))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\_ViewImports.cshtml"
using DUWENINK.Core.Web;

#line default
#line hidden
#line 2 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 1 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#line 2 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
using DUWENINK.Core.Models;

#line default
#line hidden
#line 3 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
using DUWENINK.Core.Models.Enum;

#line default
#line hidden
#line 4 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
using DUWENINK.Core.Infrastructure.Extentions;

#line default
#line hidden
#line 5 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
using DUWENINK.Core.Models.System;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9283517fe419976825c425bce99cb64133719b04", @"/Views/Shared/Menu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d43f3410db118ba1c7d22a00f589f4c1533de1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Menu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hidden-small"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 6 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
  
    List<MenuDto> menus = ViewBag.Menus;

#line default
#line hidden
            BeginContext(231, 554, true);
            WriteLiteral(@"
<nav class=""navbar-default navbar-static-side"" role=""navigation"">
    <div class=""nav-close"">
        <i class=""fa fa-times-circle""></i>
    </div>
    <div class=""sidebar-collapse"">
        <ul class=""nav"" id=""side-menu"">
            <li class=""nav-header"">
                <div class=""dropdown profile-element"">
                    <h1 style=""font-size: 2em; color: white; text-align: center"">DUWENINK</h1>
                </div>
                <div class=""logo-element"">
                    文
                </div>
            </li>
");
            EndContext();
#line 24 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
             if (menus != null)
            {
                foreach (var module in menus.OrderBy(x => x.Order).Where(item => item.Type == MenuType.Module))
                {

#line default
#line hidden
            BeginContext(965, 94, true);
            WriteLiteral("                    <li>\r\n                        <a href=\"#\">\r\n                            <i");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1059, "\"", 1118, 1);
#line 30 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
WriteAttributeValue("", 1067, module.Icon.IsBlank() ? "fa fa-tv" : module.Icon, 1067, 51, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1119, 59, true);
            WriteLiteral("></i>\r\n                            <span class=\"nav-label\">");
            EndContext();
            BeginContext(1179, 11, false);
#line 31 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
                                               Write(module.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1190, 158, true);
            WriteLiteral("</span>\r\n                            <span class=\"fa arrow\"></span>\r\n                        </a>\r\n                        <ul class=\"nav nav-second-level\">\r\n");
            EndContext();
#line 35 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
                             foreach (var menu in menus.OrderBy(x => x.Order).Where(item => item.ParentId == module.Id))
                            {

#line default
#line hidden
            BeginContext(1501, 131, true);
            WriteLiteral("                                <li>                                    \r\n                                    <a class=\"J_menuItem\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1632, "\"", 1648, 1);
#line 38 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
WriteAttributeValue("", 1639, menu.Url, 1639, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1649, 13, true);
            WriteLiteral(" data-index=\"");
            EndContext();
            BeginContext(1663, 9, false);
#line 38 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
                                                                                  Write(module.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1672, 46, true);
            WriteLiteral("\">\r\n                                        <i");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1718, "\"", 1782, 1);
#line 39 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
WriteAttributeValue("", 1726, menu.Icon.IsBlank() ? "fa fa-angle-right" : menu.Icon, 1726, 56, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1783, 47, true);
            WriteLiteral("></i>\r\n                                        ");
            EndContext();
            BeginContext(1831, 9, false);
#line 40 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
                                   Write(menu.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1840, 83, true);
            WriteLiteral("\r\n                                    </a>\r\n                                </li>\r\n");
            EndContext();
#line 43 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
                            }

#line default
#line hidden
            BeginContext(1954, 60, true);
            WriteLiteral("                        </ul>\r\n\r\n                    </li>\r\n");
            EndContext();
#line 47 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Shared\Menu.cshtml"
                }
            }

#line default
#line hidden
            BeginContext(2048, 283, true);
            WriteLiteral(@"        </ul>
    </div>
    <div class=""sidebar-footer"">
        <a id=""btnChangeMenu""><span class=""fa fa-reorder""></span></a>
        <a class=""hidden-small""><span class=""fa fa-desktop""></span></a>
        <a class=""hidden-small""><span class=""fa fa-lock""></span></a>
        ");
            EndContext();
            BeginContext(2331, 104, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9283517fe419976825c425bce99cb64133719b0410917", async() => {
                BeginContext(2394, 37, true);
                WriteLiteral("<span class=\"fa fa-power-off\"></span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2435, 22, true);
            WriteLiteral("\r\n    </div>\r\n</nav>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
