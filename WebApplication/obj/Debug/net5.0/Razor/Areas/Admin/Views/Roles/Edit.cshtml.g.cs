#pragma checksum "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\Roles\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9cbffae1639e7295c09aab6ec41cf4c43ebb928f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Roles_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/Roles/Edit.cshtml")]
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
#line 1 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.Models.Enum;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Categories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Clients;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Colors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.ColorsProduct;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Favourites;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Likes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Marki;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Newsletters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Orders;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Products;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.ReceiveMessages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Roles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.SendMessages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Sizes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.SizesProduct;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Subcategories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Subsubcategories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using Domain.ViewModels.Users;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cbffae1639e7295c09aab6ec41cf4c43ebb928f", @"/Areas/Admin/Views/Roles/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d221959382d002e9a675138168ad5beae88e33b", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Roles_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EditRoleViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("c-red"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Roles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-button-a"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"headerCe\">Tworzenie nowej roli</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cbffae1639e7295c09aab6ec41cf4c43ebb928f12787", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9cbffae1639e7295c09aab6ec41cf4c43ebb928f13050", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 7 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\Roles\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.RoleId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 7 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\Roles\Edit.cshtml"
                                     WriteLiteral(Model.RoleId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n    <div class=\"db\">\r\n        <div class=\"row\">\r\n            <div class=\"fieldName\">\r\n                <span>Nazwa roli</span>\r\n            </div>\r\n            <div class=\"fieldEdit\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9cbffae1639e7295c09aab6ec41cf4c43ebb928f15795", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 16 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\Roles\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cbffae1639e7295c09aab6ec41cf4c43ebb928f17362", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 17 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\Roles\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                <span class=\"c-red\">");
#nullable restore
#line 18 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\Roles\Edit.cshtml"
                               Write(Model.Result);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"bottom-bar-options\">\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cbffae1639e7295c09aab6ec41cf4c43ebb928f19549", async() => {
                    WriteLiteral("Anuluj");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Zapisz\" class=\"form-button\" />\r\n    </div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ApplicationDbContext Context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EditRoleViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
