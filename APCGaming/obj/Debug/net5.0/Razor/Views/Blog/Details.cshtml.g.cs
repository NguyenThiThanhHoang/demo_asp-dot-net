#pragma checksum "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92171173905f44c96797789d7cbbaa9ae7eb5135"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Details), @"mvc.1.0.view", @"/Views/Blog/Details.cshtml")]
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
#line 1 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\_ViewImports.cshtml"
using APCGaming;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\_ViewImports.cshtml"
using APCGaming.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92171173905f44c96797789d7cbbaa9ae7eb5135", @"/Views/Blog/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58390494f1a115158f43cfe66f4b4861e06bf0dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<APCGaming.Models.TinTuc>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-full"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
  
    ViewData["Title"] = Model.TieuDe;
    Layout = "~/Views/Shared/_Layout.cshtml";
    string url = $"/tin-tuc/{Model.TinTucId}";
    List<TinTuc> BaiVietLienQuan = ViewBag.BaiVietLienQuan;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main class=""main-content"">
    <div class=""breadcrumb-area breadcrumb-height"" data-bg-image=""assets/images/breadcrumb/bg/1-1-1920x373.jpg"">
        <div class=""container h-100"">
            <div class=""row h-100"">
                <div class=""col-lg-12"">
                    <div class=""breadcrumb-item"">
                        <h1 class=""breadcrumb-heading"">");
#nullable restore
#line 16 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
                                                  Write(Model.TieuDe);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                        <ul>\r\n                            <li>\r\n                                <a href=\"/\">Trang chủ<i class=\"pe-7s-angle-right\"></i></a>\r\n                            </li>\r\n                            <li>");
#nullable restore
#line 21 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
                           Write(Model.TieuDe);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""blog-area section-space-y-axis-100"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""blog-detail-item"">
                        <div class=""blog-img"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "92171173905f44c96797789d7cbbaa9ae7eb51355487", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1312, "~/images/tinTucs/", 1312, 17, true);
#nullable restore
#line 34 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
AddHtmlAttributeValue("", 1329, Model.HinhAnh, 1329, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 34 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
AddHtmlAttributeValue("", 1350, Model.TieuDe, 1350, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                        <div class=""blog-content text-start pb-0"">
                            <div class=""blog-meta text-dim-gray pb-3"">
                                <ul>
                                    <li class=""date""><i class=""fa fa-calendar-o me-2""></i>");
#nullable restore
#line 39 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
                                                                                     Write(Model.NgayTao);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                                    <li>
                                        <span class=""comments me-3"">
                                            <a href=""javascript:void(0)"">2 Comments</a>
                                        </span>
                                        <span class=""link-share"">
                                            <a href=""javascript:void(0)"">Share</a>
                                        </span>
                                    </li>
                                </ul>
                            </div>
                            <h5 class=""title mb-4"">
                                <a");
            BeginWriteAttribute("href", " href=\"", 2343, "\"", 2354, 1);
#nullable restore
#line 51 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
WriteAttributeValue("", 2350, url, 2350, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 51 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
                                          Write(Model.TieuDe);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            </h5>\r\n                            <p class=\"short-desc mb-4 mb-7\">");
#nullable restore
#line 53 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
                                                       Write(Model.MoTaNgan);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            ");
#nullable restore
#line 54 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
                       Write(Html.Raw(Model.MoTaDai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <div class=\"feedback-area section-space-top-55\">\r\n                                <h4 class=\"heading mb-1\">Bài viết liên quan</h4>\r\n");
#nullable restore
#line 57 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
                                 if (BaiVietLienQuan != null && BaiVietLienQuan.Count() > 0)
                                {
                                    foreach (var item in BaiVietLienQuan)
                                    {
                                        string _url = $"/tin-tuc/{item.TinTucId}.html";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <div class=""swiper-slide"" role=""group"" aria-label=""3 / 3"" style=""margin-top: 25px; width: 263px; margin-right: 25px;"">
                                            <div class=""product-list-item"">
                                                <div class=""product-img img-zoom-effect"">
                                                    <a");
            BeginWriteAttribute("href", " href=\"", 3419, "\"", 3431, 1);
#nullable restore
#line 65 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
WriteAttributeValue("", 3426, _url, 3426, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "92171173905f44c96797789d7cbbaa9ae7eb513511681", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3518, "~/images/tinTucs/", 3518, 17, true);
#nullable restore
#line 66 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
AddHtmlAttributeValue("", 3535, Model.HinhAnh, 3535, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 66 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
AddHtmlAttributeValue("", 3556, item.TieuDe, 3556, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                    </a>
                                                </div>
                                                <div class=""product-content"">
                                                    <h5 class=""title mb-3"">
                                                        <a");
            BeginWriteAttribute("href", " href=\"", 3900, "\"", 3912, 1);
#nullable restore
#line 71 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
WriteAttributeValue("", 3907, _url, 3907, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 71 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
                                                                   Write(item.TieuDe);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                                    </h5>
                                                    <div class=""blog-meta text-manatee pb-1"">
                                                        <ul>
                                                            <li class=""date"">");
#nullable restore
#line 75 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"
                                                                        Write(item.NgayTao);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
");
#nullable restore
#line 81 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Views\Blog\Details.cshtml"

                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</main>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<APCGaming.Models.TinTuc> Html { get; private set; }
    }
}
#pragma warning restore 1591
