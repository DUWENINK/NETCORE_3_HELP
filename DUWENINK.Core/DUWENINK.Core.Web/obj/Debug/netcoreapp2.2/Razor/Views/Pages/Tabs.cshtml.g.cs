#pragma checksum "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Pages\Tabs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e84da3d99ead2e29263d732a074a5ab87d47b131"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pages_Tabs), @"mvc.1.0.view", @"/Views/Pages/Tabs.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pages/Tabs.cshtml", typeof(AspNetCore.Views_Pages_Tabs))]
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
#line 1 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\_ViewImports.cshtml"
using DUWENINK.Core.Web;

#line default
#line hidden
#line 2 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e84da3d99ead2e29263d732a074a5ab87d47b131", @"/Views/Pages/Tabs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d43f3410db118ba1c7d22a00f589f4c1533de1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Pages_Tabs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\DUWENINK\Desktop\DUWENINK\DUWENINK_WEB\DUWENINK.Core\DUWENINK.Core.Web\Views\Pages\Tabs.cshtml"
  
    ViewBag.Title = "Form";
    Layout = "~/Views/Shared/_Layout_Content.cshtml";

#line default
#line hidden
            DefineSection("styles", async() => {
                BeginContext(111, 8, true);
                WriteLiteral("\r\n    \r\n");
                EndContext();
            }
            );
            BeginContext(122, 4323, true);
            WriteLiteral(@"<div class=""wrapper wrapper-content animated fadeIn"">
    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""ibox float-e-margins"">
                <div class=""ibox-title"">
                    <h5>基本面板 <small class=""m-l-sm"">这是一个自定义面板</small></h5>
                    <div class=""ibox-tools"">
                        <a class=""collapse-link"">
                            <i class=""fa fa-chevron-up""></i>
                        </a>
                        <a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""#"">
                            <i class=""fa fa-wrench""></i>
                        </a>
                        <ul class=""dropdown-menu dropdown-user"">
                            <li>
                                <a href=""#"">选项1</a>
                            </li>
                            <li>
                                <a href=""#"">选项2</a>
                            </li>
                        </ul>
                        <a class=""close-link""");
            WriteLiteral(@">
                            <i class=""fa fa-times""></i>
                        </a>
                    </div>
                </div>
                <div class=""ibox-content"">
                    <h2>
                        Bootstrap<br />
                    </h2>
                    <p>
                        简洁、直观、强悍的前端开发框架，让web开发更迅速、简单。
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-sm-6"">
            <div class=""tabs-container"">
                <ul class=""nav nav-tabs"">
                    <li class=""active"">
                        <a data-toggle=""tab"" href=""#tab-1"" aria-expanded=""true""> 第一个选项卡</a>
                    </li>
                    <li class="""">
                        <a data-toggle=""tab"" href=""#tab-2"" aria-expanded=""false"">第二个选项卡</a>
                    </li>
                </ul>
                <div class=""tab-content"">
                    <div id=""tab-1"" class=""t");
            WriteLiteral(@"ab-pane active"">
                        <div class=""panel-body"">
                            <strong>HTML5 文档类型</strong>
                            <p>Bootstrap 使用到的某些 HTML 元素和 CSS 属性需要将页面设置为 HTML5 文档类型。在你项目中的每个页面都要参照下面的格式进行设置。</p>
                        </div>
                    </div>
                    <div id=""tab-2"" class=""tab-pane"">
                        <div class=""panel-body"">
                            <strong>移动设备优先</strong>
                            <p>在 Bootstrap 2 中，我们对框架中的某些关键部分增加了对移动设备友好的样式。而在 Bootstrap 3 中，我们重写了整个框架，使其一开始就是对移动设备友好的。这次不是简单的增加一些可选的针对移动设备的样式，而是直接融合进了框架的内核中。也就是说，Bootstrap 是移动设备优先的。针对移动设备的样式融合进了框架的每个角落，而不是增加一个额外的文件。</p>
                        </div>
                    </div>
                </div>


            </div>
        </div>

        <div class=""col-sm-6"">
            <div class=""panel blank-panel"">

                <div class=""panel-heading"">
                    <div class=""panel-title m-b-md"">
                        <h4>图标选项卡</h4>
    ");
            WriteLiteral(@"                </div>
                    <div class=""panel-options"">

                        <ul class=""nav nav-tabs"">
                            <li class=""active"">
                                <a data-toggle=""tab"" href=""#tab-4""><i class=""fa fa-laptop""></i></a>
                            </li>
                            <li class="""">
                                <a data-toggle=""tab"" href=""#tab-5""><i class=""fa fa-desktop""></i></a>
                            </li>
                            <li class="""">
                                <a data-toggle=""tab"" href=""#tab-6""><i class=""fa fa-signal""></i></a>
                            </li>
                            <li class="""">
                                <a data-toggle=""tab"" href=""#tab-7""><i class=""fa fa-bar-chart-o""></i></a>
                            </li>
                        </ul>
                    </div>
                </div>

                <div class=""panel-body"">
                    <div class=""tab-content");
            WriteLiteral("\">\r\n                        <div id=\"tab-4\" class=\"tab-pane active\">\r\n                            <strong>排版与链接</strong>\r\n\r\n                            <p>Bootstrap 排版、链接样式设置了基本的全局样式。分别是： 为 body 元素设置 background-color: #fff; 使用 ");
            EndContext();
            BeginContext(4446, 18, true);
            WriteLiteral("@font-family-base、");
            EndContext();
            BeginContext(4465, 18, true);
            WriteLiteral("@font-size-base 和 ");
            EndContext();
            BeginContext(4484, 44, true);
            WriteLiteral("@line-height-base a变量作为排版的基本参数 为所有链接设置了基本颜色 ");
            EndContext();
            BeginContext(4529, 1906, true);
            WriteLiteral(@"@link-color ，并且当链接处于 :hover 状态时才添加下划线 这些样式都能在 scaffolding.less 文件中找到对应的源码。</p>
                        </div>

                        <div id=""tab-5"" class=""tab-pane"">
                            <strong>Normalize.css</strong>

                            <p>为了增强跨浏览器表现的一致性，我们使用了 Normalize.css，这是由 Nicolas Gallagher 和 Jonathan Neal 维护的一个CSS 重置样式库。</p>
                        </div>
                        <div id=""tab-6"" class=""tab-pane"">
                            <strong>布局容器</strong>

                            <p>Bootstrap 需要为页面内容和栅格系统包裹一个 .container 容器。我们提供了两个作此用处的类。注意，由于 padding 等属性的原因，这两种 容器类不能互相嵌套。</p>
                        </div>
                        <div id=""tab-7"" class=""tab-pane"">
                            <strong>栅格系统</strong>

                            <p>Bootstrap 提供了一套响应式、移动设备优先的流式栅格系统，随着屏幕或视口（viewport）尺寸的增加，系统会自动分为最多12列。它包含了易于使用的预定义类，还有强大的mixin 用于生成更具语义的布局。</p>
                        </div>
                    </div>

                </div>

            </div>");
            WriteLiteral(@"
        </div>
    </div>
    <div class=""row m-b-lg"">
        <div class=""col-sm-6"">
            <div class=""tabs-container"">

                <div class=""tabs-left"">
                    <ul class=""nav nav-tabs"">
                        <li class=""active"">
                            <a data-toggle=""tab"" href=""#tab-8""> 第一个选项卡</a>
                        </li>
                        <li class="""">
                            <a data-toggle=""tab"" href=""#tab-9""> 第二个选项卡</a>
                        </li>
                    </ul>
                    <div class=""tab-content "">
                        <div id=""tab-8"" class=""tab-pane active"">
                            <div class=""panel-body"">
                                <strong>排版与链接</strong>

                                <p>Bootstrap 排版、链接样式设置了基本的全局样式。分别是： 为 body 元素设置 background-color: #fff; 使用 ");
            EndContext();
            BeginContext(6436, 18, true);
            WriteLiteral("@font-family-base、");
            EndContext();
            BeginContext(6455, 18, true);
            WriteLiteral("@font-size-base 和 ");
            EndContext();
            BeginContext(6474, 44, true);
            WriteLiteral("@line-height-base a变量作为排版的基本参数 为所有链接设置了基本颜色 ");
            EndContext();
            BeginContext(6519, 1448, true);
            WriteLiteral(@"@link-color ，并且当链接处于 :hover 状态时才添加下划线 这些样式都能在 scaffolding.less 文件中找到对应的源码。</p>
                            </div>
                        </div>
                        <div id=""tab-9"" class=""tab-pane"">
                            <div class=""panel-body"">
                                <strong>栅格系统</strong>

                                <p>Bootstrap 提供了一套响应式、移动设备优先的流式栅格系统，随着屏幕或视口（viewport）尺寸的增加，系统会自动分为最多12列。它包含了易于使用的预定义类，还有强大的mixin 用于生成更具语义的布局。</p>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>
        <div class=""col-sm-6"">
            <div class=""tabs-container"">
                <div class=""tabs-right"">
                    <ul class=""nav nav-tabs"">
                        <li class=""active"">
                            <a data-toggle=""tab"" href=""#tab-10"">第一个选项卡</a>
                        </li>
                        <li class="""">
                            <a data-toggle=""t");
            WriteLiteral(@"ab"" href=""#tab-11""> 第二个选项卡</a>
                        </li>
                    </ul>
                    <div class=""tab-content "">
                        <div id=""tab-10"" class=""tab-pane active"">
                            <div class=""panel-body"">
                                <strong>排版与链接</strong>

                                <p>Bootstrap 排版、链接样式设置了基本的全局样式。分别是： 为 body 元素设置 background-color: #fff; 使用 ");
            EndContext();
            BeginContext(7968, 18, true);
            WriteLiteral("@font-family-base、");
            EndContext();
            BeginContext(7987, 18, true);
            WriteLiteral("@font-size-base 和 ");
            EndContext();
            BeginContext(8006, 44, true);
            WriteLiteral("@line-height-base a变量作为排版的基本参数 为所有链接设置了基本颜色 ");
            EndContext();
            BeginContext(8051, 9168, true);
            WriteLiteral(@"@link-color ，并且当链接处于 :hover 状态时才添加下划线 这些样式都能在 scaffolding.less 文件中找到对应的源码。</p>
                            </div>
                        </div>
                        <div id=""tab-11"" class=""tab-pane"">
                            <div class=""panel-body"">
                                <strong>栅格系统</strong>

                                <p>Bootstrap 提供了一套响应式、移动设备优先的流式栅格系统，随着屏幕或视口（viewport）尺寸的增加，系统会自动分为最多12列。它包含了易于使用的预定义类，还有强大的mixin 用于生成更具语义的布局。</p>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""ibox"">
                <div class=""ibox-title"">
                    <h5>Bootstrap面板 <small>自定义背景</small></h5>
                </div>
                <div class=""ibox-content"">

                    <div class=""row"">
                        <div class=""col-sm-4"">
                            <div cla");
            WriteLiteral(@"ss=""panel panel-default"">
                                <div class=""panel-heading"">
                                    默认面板
                                </div>
                                <div class=""panel-body"">
                                    <p>通过 .panel-heading 可以很简单地为面板加入一个标题容器。你也可以通过添加设置了 .panel-title 类的标签，添加一个预定义样式的标题。 为了给链接设置合适的颜色，务必将链接放到带有 .panel-title 类的标题标签内。</p>
                                </div>

                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""panel panel-primary"">
                                <div class=""panel-heading"">
                                    主要
                                </div>
                                <div class=""panel-body"">
                                    <p>通过 .panel-heading 可以很简单地为面板加入一个标题容器。你也可以通过添加设置了 .panel-title 类的标签，添加一个预定义样式的标题。 为了给链接设置合适的颜色，务必将链接放到带有 .panel-title 类的标题标签内。</p>
                                </div>");
            WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""panel panel-success"">
                                <div class=""panel-heading"">
                                    成功
                                </div>
                                <div class=""panel-body"">
                                    <p>通过 .panel-heading 可以很简单地为面板加入一个标题容器。你也可以通过添加设置了 .panel-title 类的标签，添加一个预定义样式的标题。 为了给链接设置合适的颜色，务必将链接放到带有 .panel-title 类的标题标签内。</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-sm-4"">
                            <div class=""panel panel-info"">
                                <div class=""panel-heading"">
                                    <i class=""fa fa-info-circle""></i> 信息
                                </div>
                 ");
            WriteLiteral(@"               <div class=""panel-body"">
                                    <p>通过 .panel-heading 可以很简单地为面板加入一个标题容器。你也可以通过添加设置了 .panel-title 类的标签，添加一个预定义样式的标题。 为了给链接设置合适的颜色，务必将链接放到带有 .panel-title 类的标题标签内。</p>
                                </div>

                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=""panel panel-warning"">
                                <div class=""panel-heading"">
                                    <i class=""fa fa-warning""></i> 警告
                                </div>
                                <div class=""panel-body"">
                                    <p>通过 .panel-heading 可以很简单地为面板加入一个标题容器。你也可以通过添加设置了 .panel-title 类的标签，添加一个预定义样式的标题。 为了给链接设置合适的颜色，务必将链接放到带有 .panel-title 类的标题标签内。</p>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-4"">
                            <div class=");
            WriteLiteral(@"""panel panel-danger"">
                                <div class=""panel-heading"">
                                    危险
                                </div>
                                <div class=""panel-body"">
                                    <p>通过 .panel-heading 可以很简单地为面板加入一个标题容器。你也可以通过添加设置了 .panel-title 类的标签，添加一个预定义样式的标题。 为了给链接设置合适的颜色，务必将链接放到带有 .panel-title 类的标题标签内。</p>
                                </div>
                                <div class=""panel-footer"">
                                    面板Footer
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <div class=""row"">
        <div class=""col-sm-6"">
            <div class=""ibox float-e-margins"">
                <div class=""ibox-title"">
                    <h5>折叠面板</h5>
                    <div class=""ibox-tools"">
                        <a class=""collapse-link"">");
            WriteLiteral(@"
                            <i class=""fa fa-chevron-up""></i>
                        </a>
                        <a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""#"">
                            <i class=""fa fa-wrench""></i>
                        </a>
                        <ul class=""dropdown-menu dropdown-user"">
                            <li>
                                <a href=""#"">选项1</a>
                            </li>
                            <li>
                                <a href=""#"">选项2</a>
                            </li>
                        </ul>
                        <a class=""close-link"">
                            <i class=""fa fa-times""></i>
                        </a>
                    </div>
                </div>
                <div class=""ibox-content"">
                    <div class=""panel-body"">
                        <div class=""panel-group"" id=""accordion"">
                            <div class=""panel panel-default"">
          ");
            WriteLiteral(@"                      <div class=""panel-heading"">
                                    <h5 class=""panel-title"">
                                        <a data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseOne"">标题 #1</a>
                                    </h5>
                                </div>
                                <div id=""collapseOne"" class=""panel-collapse collapse in"">
                                    <div class=""panel-body"">
                                        Bootstrap相关优质项目推荐 这些项目或者是对Bootstrap进行了有益的补充，或者是基于Bootstrap开发的
                                    </div>
                                </div>
                            </div>
                            <div class=""panel panel-default"">
                                <div class=""panel-heading"">
                                    <h4 class=""panel-title"">
                                        <a data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseTwo"">标题 #2</a>
                      ");
            WriteLiteral(@"              </h4>
                                </div>
                                <div id=""collapseTwo"" class=""panel-collapse collapse"">
                                    <div class=""panel-body"">
                                        Bootstrap相关优质项目推荐 这些项目或者是对Bootstrap进行了有益的补充，或者是基于Bootstrap开发的
                                    </div>
                                </div>
                            </div>
                            <div class=""panel panel-default"">
                                <div class=""panel-heading"">
                                    <h4 class=""panel-title"">
                                        <a data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseThree"">标题 #3</a>
                                    </h4>
                                </div>
                                <div id=""collapseThree"" class=""panel-collapse collapse"">
                                    <div class=""panel-body"">
                                        Boots");
            WriteLiteral(@"trap相关优质项目推荐 这些项目或者是对Bootstrap进行了有益的补充，或者是基于Bootstrap开发的
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-sm-6"">
            <div class=""jumbotron"">
                <h1>超大屏幕</h1>
                <p>Bootstrap 支持的另一个特性，超大屏幕（Jumbotron）。顾名思义该组件可以增加标题的大小，并为登陆页面内容添加更多的外边距（margin）。使用超大屏幕（Jumbotron）的步骤如下：</p>
                <div class=""alert alert-warning"">
                    <ol>
                        <li>创建一个带有 class .jumbotron. 的容器</li>
                        <li>除了更大的 &lt;h1&gt;，字体粗细 font-weight 被减为 200px。</li>
                    </ol>
                </div>


                <p>
                    <a role=""button"" class=""btn btn-primary btn-lg"">了解更多</a>
                </p>
            </div>
        </div>
    </div>
</div>

");
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
