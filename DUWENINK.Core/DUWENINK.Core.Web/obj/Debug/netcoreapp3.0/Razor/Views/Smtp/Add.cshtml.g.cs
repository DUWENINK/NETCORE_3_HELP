#pragma checksum "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aac0059b6964ad8349e132ab53415bd73df10d7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Smtp_Add), @"mvc.1.0.view", @"/Views/Smtp/Add.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
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
#nullable restore
#line 1 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
using Microsoft.AspNetCore.Mvc.Rendering;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aac0059b6964ad8349e132ab53415bd73df10d7f", @"/Views/Smtp/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d43f3410db118ba1c7d22a00f589f4c1533de1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Smtp_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DUWENINK.Core.Models.Business.SmtpDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.validate.unobtrusive.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/plugins/suggest/bootstrap-suggest.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/base.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/page/menu.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("names", "Development", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/menu.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("names", "Staging,Production", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
  
    ViewBag.Title = "添加邮件客户端";
    Layout = "~/Views/Shared/_Layout_Content.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""wrapper wrapper-content"">
    <div class=""ibox float-e-margins"">
        <div class=""ibox-title"">
            <h5>添加菜单</h5>
            <div class=""ibox-tools"">
                <a class=""collapse-link"">
                    <i class=""fa fa-chevron-up""></i>
                </a>
            </div>
        </div>
        <div class=""ibox-content"">
");
#nullable restore
#line 18 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
             using (Html.BeginForm("Add", "Smtp", FormMethod.Post, new { @class = "form-horizontal" }))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group\">\r\n                    <label class=\"col-sm-3 control-label\">");
#nullable restore
#line 21 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                                                     Write(Html.LabelFor(m => m.Host));

#line default
#line hidden
#nullable disable
            WriteLiteral("：</label>\r\n                    <div class=\"col-sm-8\">\r\n                            ");
#nullable restore
#line 23 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                       Write(Html.TextBoxFor(m => m.Host, new { @class = "form-control", placeholder = "邮件服务器" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"col-sm-3 control-label\">");
#nullable restore
#line 27 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                                                     Write(Html.LabelFor(m => m.FromUserMail));

#line default
#line hidden
#nullable disable
            WriteLiteral("：</label>\r\n                    <div class=\"col-sm-8\">\r\n                        ");
#nullable restore
#line 29 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                   Write(Html.TextBoxFor(m => m.FromUserMail, new { @class = "form-control", placeholder = "发件邮箱地址" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 30 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                   Write(Html.ValidationMessageFor(m => m.FromUserMail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"col-sm-3 control-label\">");
#nullable restore
#line 34 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                                                     Write(Html.LabelFor(m => m.FromUserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("：</label>\r\n                    <div class=\"col-sm-8\">\r\n                        ");
#nullable restore
#line 36 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                   Write(Html.TextBoxFor(m => m.FromUserName, new { @class = "form-control", placeholder = "发送端昵称" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 37 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                   Write(Html.ValidationMessageFor(m => m.FromUserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"col-sm-3 control-label\">");
#nullable restore
#line 41 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                                                     Write(Html.LabelFor(m => m.PassWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("：</label>\r\n                    <div class=\"col-sm-8\">\r\n                        ");
#nullable restore
#line 43 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                   Write(Html.TextBoxFor(m => m.PassWord, new { @class = "form-control", placeholder = "邮件密码" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"col-sm-3 control-label\">");
#nullable restore
#line 47 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                                                     Write(Html.LabelFor(m => m.UseDefaultCredentials));

#line default
#line hidden
#nullable disable
            WriteLiteral("：</label>\r\n                    <div class=\"col-sm-8\">\r\n                        ");
#nullable restore
#line 49 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                   Write(Html.CheckBoxFor(m => m.UseDefaultCredentials, new { @class = "form-control",aligin="left" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
            WriteLiteral("                <div class=\"form-group\">\r\n                    <label class=\"col-sm-3 control-label\">");
#nullable restore
#line 54 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                                                     Write(Html.LabelFor(m => m.Remark));

#line default
#line hidden
#nullable disable
            WriteLiteral("：</label>\r\n                    <div class=\"col-sm-8\">\r\n                        ");
#nullable restore
#line 56 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                   Write(Html.TextBoxFor(m => m.Remark, new { @class = "form-control", placeholder = "备注信息", rows=3 }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
                <div class=""form-group"">
                    <div class=""col-sm-offset-3 col-sm-8"">
                        <button class=""btn btn-info"" type=""submit"">保存</button>
                        <button class=""btn btn-white"" type=""button"" id=""btnBack"">返回</button>
                    </div>
                </div>
");
#nullable restore
#line 65 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aac0059b6964ad8349e132ab53415bd73df10d7f14116", async() => {
                    WriteLiteral("\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aac0059b6964ad8349e132ab53415bd73df10d7f14398", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aac0059b6964ad8349e132ab53415bd73df10d7f15558", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aac0059b6964ad8349e132ab53415bd73df10d7f16718", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aac0059b6964ad8349e132ab53415bd73df10d7f17878", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aac0059b6964ad8349e132ab53415bd73df10d7f19038", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Names = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aac0059b6964ad8349e132ab53415bd73df10d7f21171", async() => {
                    WriteLiteral("\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aac0059b6964ad8349e132ab53415bd73df10d7f21453", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_6.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
#nullable restore
#line 78 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
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
                    WriteLiteral("\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Names = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    <script>\r\n        $(\"#btnBack\").bind(\"click\", function(e) {\r\n            XPage.GoTo(e.target, \"");
#nullable restore
#line 83 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Smtp\Add.cshtml"
                             Write(Url.Action("Index"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n        });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DUWENINK.Core.Models.Business.SmtpDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
