#pragma checksum "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0393ebfe7b2fb38d1f960652ba6542d1ac84422"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\_ViewImports.cshtml"
using DUWENINK.Core.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0393ebfe7b2fb38d1f960652ba6542d1ac84422", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d43f3410db118ba1c7d22a00f589f4c1533de1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<DUWENINK.Core.Models.MessageQueryDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div id=\"page-wrapper\" class=\"gray-bg dashbard-1\">\r\n    <div class=\"row border-bottom\">\r\n        <nav class=\"navbar navbar-static-top\" role=\"navigation\" style=\"margin-bottom: 0\">\r\n");
            WriteLiteral("\r\n            <ul class=\"nav navbar-top-links navbar-right\">\r\n                <li class=\"hidden-xs\">\r\n                    ");
#nullable restore
#line 13 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
               Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </li>\r\n");
            WriteLiteral("                <li class=\"dropdown\">\r\n                    <a class=\"dropdown-toggle count-info\" data-toggle=\"dropdown\" href=\"#\" aria-expanded=\"false\">\r\n                        <i class=\"fa fa-envelope\"></i>  <span class=\"label label-warning\">");
#nullable restore
#line 18 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
                                                                                     Write(ViewBag.MyUnReadMessageNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </a>\r\n                    <ul class=\"dropdown-menu dropdown-messages\">\r\n");
#nullable restore
#line 21 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
                         if (Model.Any())
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
                             foreach(var message in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <li>
                                    <div class=""dropdown-messages-box"">
                                        <div class=""media-body"">
                                            <strong><i class=""fa fa-volume-down""></i><a href=""javascript:;""");
            BeginWriteAttribute("onclick", " onclick=\"", 1433, "\"", 1469, 3);
            WriteAttributeValue("", 1443, "readMessage(\'", 1443, 13, true);
#nullable restore
#line 28 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1456, message.Id, 1456, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1467, "\')", 1467, 2, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 28 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
                                                                                                                                            Write(message.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></strong><br>\r\n                                            <small class=\"text-muted\">");
#nullable restore
#line 29 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
                                                                 Write(message.CreateDateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                                        </div>\r\n                                    </div>\r\n                                </li>\r\n                                <li class=\"divider\"></li>\r\n");
#nullable restore
#line 34 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
                             
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                             <li>
                                <div class=""dropdown-messages-box"">
                                        <div class=""media-body"">
                                            没有未读的信息
                                        </div>
                                    </div>
                            </li>
");
#nullable restore
#line 45 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </li>\r\n                <li class=\"hidden-xs\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 2742, "\"", 2770, 1);
#nullable restore
#line 57 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 2749, Url.Action("Logout"), 2749, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><i class=""fa fa fa-sign-out""></i> 退出</a>
                </li>
            </ul>
        </nav>
    </div>
    <div class=""row content-tabs"">
        <button class=""roll-nav roll-left J_tabLeft"">
            <i class=""fa fa-backward""></i>
        </button>
        <nav class=""page-tabs J_menuTabs"">
            <div class=""page-tabs-content"">
                <a href=""javascript:;"" class=""active J_menuTab"" data-id=""");
#nullable restore
#line 68 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
                                                                    Write(Url.Action("Welcome"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">首页</a>
            </div>
        </nav>
        <button class=""roll-nav roll-right J_tabRight"">
            <i class=""fa fa-forward""></i>
        </button>
        <div class=""btn-group roll-nav roll-right"">
            <button class=""dropdown J_tabClose"" data-toggle=""dropdown"">
                关闭操作<span class=""caret""></span>
            </button>
            <ul role=""menu"" class=""dropdown-menu dropdown-menu-right"">
                <li class=""J_tabShowActive"">
                    <a>定位当前选项卡</a>
                </li>
                <li class=""divider""></li>
                <li class=""J_tabCloseAll"">
                    <a>关闭全部选项卡</a>
                </li>
                <li class=""J_tabCloseOther"">
                    <a>关闭其他选项卡</a>
                </li>
            </ul>
        </div>
    </div>
    <div class=""row J_mainContent"" id=""content-main"">
        <iframe class=""J_iframe"" name=""iframe0"" width=""100%"" height=""100%""");
            BeginWriteAttribute("src", " src=\"", 4189, "\"", 4217, 1);
#nullable restore
#line 93 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 4195, Url.Action("Welcome"), 4195, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" frameborder=\"0\" data-id=\"");
#nullable restore
#line 93 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
                                                                                                                            Write(Url.Action("Welcome"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" seamless></iframe>\r\n    </div>\r\n    <div class=\"footer\">\r\n        <div class=\"pull-right\">\r\n            &copy; 2012 - ");
#nullable restore
#line 97 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Home\Index.cshtml"
                     Write(DateTime.Now.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" <a href=""http://www.duwen.ink/"" target=""_blank"">&copy;DUWENINK</a>
        </div>
    </div>
</div>

<script>
    function readMessage(messageId) {
        parent.layer.open({
            title: '站内信',
            type: 2,
            content: '/message/read/' + messageId,
            area: ['80%', '60%']
        });
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<DUWENINK.Core.Models.MessageQueryDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
