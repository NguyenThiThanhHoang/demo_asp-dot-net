#pragma checksum "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51f72926d76220939a5b8cf7ee2ee5d02602c735"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminSanPhams_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminSanPhams/Details.cshtml")]
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
#line 1 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\_ViewImports.cshtml"
using APCGaming;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\_ViewImports.cshtml"
using APCGaming.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51f72926d76220939a5b8cf7ee2ee5d02602c735", @"/Areas/Admin/Views/AdminSanPhams/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"941f1f4dfc0e0b06a02532da41ab9c72ee5925b7", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_AdminSanPhams_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<APCGaming.Models.SanPham>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("breadcrumb-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("200"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("200"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
  
    ViewData["Title"] = "Thông tin sản phảm" +   Model.TenSp;
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page-header\">\r\n    <div class=\"header-sub-title\">\r\n        <nav class=\"breadcrumb breadcrumb-dash\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51f72926d76220939a5b8cf7ee2ee5d02602c7356155", async() => {
                WriteLiteral("<i class=\"anticon anticon-home m-r-5\"></i>Thông tin sản phẩm");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <span class=\"breadcrumb-item active\">Thông tin sản phẩm : ");
#nullable restore
#line 12 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
                                                                 Write(Model.TenSp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </nav>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"card-body\">\r\n    <h4 class=\"card-title\">Thông tin sản phẩm : ");
#nullable restore
#line 18 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
                                           Write(Model.TenSp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <div class=\"table-responsive\">\r\n        <table class=\"product-info-table m-t-20\">\r\n            <tbody>\r\n                <tr>\r\n                    <td>ID:</td>\r\n                    <td class=\"text-dark font-weight-semibold\">");
#nullable restore
#line 24 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
                                                          Write(Model.SanPhamId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Tên sản phẩm:</td>\r\n                    <td>");
#nullable restore
#line 28 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
                   Write(Model.TenSp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Thẻ:</td>\r\n                    <td>");
#nullable restore
#line 32 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
                   Write(Model.The);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Giá:</td>\r\n                    <td>");
#nullable restore
#line 36 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
                   Write(Model.GiaTien);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Discount:</td>\r\n                    <td>");
#nullable restore
#line 40 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
                   Write(Model.GiamGia);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Trạng thái:</td>\r\n                    <td>\r\n");
#nullable restore
#line 45 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
                         if (Model.TrangThai)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"switch m-r-10\">\r\n                                <input type=\"checkbox\" id=\"switch-1\"");
            BeginWriteAttribute("checked", " checked=\"", 1738, "\"", 1748, 0);
            EndWriteAttribute();
            WriteLiteral(" disabled />\r\n                                <label for=\"switch-1\"></label>\r\n                            </div>\r\n");
#nullable restore
#line 51 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"switch m-r-10\">\r\n                                <input type=\"checkbox\" id=\"switch-1\" disabled />\r\n                                <label for=\"switch-1\"></label>\r\n                            </div>\r\n");
#nullable restore
#line 58 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                </tr>\r\n            <tr>\r\n                <td>Danh mục:</td>\r\n                <td>");
#nullable restore
#line 63 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
               Write(Model.DanhMuc.TenDanhMuc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Ngày tạo:</td>\r\n                <td>");
#nullable restore
#line 67 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
               Write(Model.NgayTao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Ngày chỉnh sửa\r\n                <td>\r\n                <td>");
#nullable restore
#line 72 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
               Write(Model.NgayCapNhat);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Ảnh đại diện:</td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "51f72926d76220939a5b8cf7ee2ee5d02602c73513720", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2777, "~/images/sanPhams/", 2777, 18, true);
#nullable restore
#line 77 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
AddHtmlAttributeValue("", 2795, Model.Avatar, 2795, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 77 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
AddHtmlAttributeValue("", 2815, Model.TenSp, 2815, 12, false);

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
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td>Mô tả sản phẩm:</td>\r\n                <td>");
#nullable restore
#line 82 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
               Write(Html.Raw(Model.MoTa));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n\r\n        </tbody>\r\n    </table>\r\n</div>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51f72926d76220939a5b8cf7ee2ee5d02602c73516403", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 90 "C:\Users\ASUS\Documents\Study\Lập trình csdl\APCGaming\APCGaming\Areas\Admin\Views\AdminSanPhams\Details.cshtml"
                           WriteLiteral(Model.SanPhamId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<APCGaming.Models.SanPham> Html { get; private set; }
    }
}
#pragma warning restore 1591
