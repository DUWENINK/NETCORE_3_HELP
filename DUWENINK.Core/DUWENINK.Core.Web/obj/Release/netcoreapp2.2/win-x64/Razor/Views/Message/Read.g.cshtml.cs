#pragma checksum "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Message\Read.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39e1351a08bd5d101bc20de41f943bae01a000a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Message_Read), @"mvc.1.0.view", @"/Views/Message/Read.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Message/Read.cshtml", typeof(AspNetCore.Views_Message_Read))]
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
#line 1 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\_ViewImports.cshtml"
using DUWENINK.Core.Web;

#line default
#line hidden
#line 2 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39e1351a08bd5d101bc20de41f943bae01a000a4", @"/Views/Message/Read.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d43f3410db118ba1c7d22a00f589f4c1533de1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Message_Read : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DUWENINK.Core.Models.MessageQueryDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Message\Read.cshtml"
  
    ViewBag.Title = "站内信详情";
    Layout = "~/Views/Shared/_Layout_Content.cshtml";

#line default
#line hidden
            BeginContext(139, 236, true);
            WriteLiteral("\r\n<div class=\"wrapper wrapper-content\">\r\n\r\n    <div class=\"ibox float-e-margins\">\r\n            <div class=\"ibox-title\">\r\n                <h5>站内信内容 </h5>\r\n            </div>\r\n            <div class=\"ibox-content\">\r\n                <p>标题：");
            EndContext();
            BeginContext(376, 11, false);
#line 15 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Message\Read.cshtml"
                 Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(387, 28, true);
            WriteLiteral("</p>\r\n                <p>内容：");
            EndContext();
            BeginContext(416, 14, false);
#line 16 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Message\Read.cshtml"
                 Write(Model.Contents);

#line default
#line hidden
            EndContext();
            BeginContext(430, 30, true);
            WriteLiteral("</p>\r\n                <p>发送时间：");
            EndContext();
            BeginContext(461, 20, false);
#line 17 "C:\Users\DUWENINK\source\repos\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Message\Read.cshtml"
                   Write(Model.CreateDateTime);

#line default
#line hidden
            EndContext();
            BeginContext(481, 48, true);
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DUWENINK.Core.Models.MessageQueryDto> Html { get; private set; }
    }
}
#pragma warning restore 1591