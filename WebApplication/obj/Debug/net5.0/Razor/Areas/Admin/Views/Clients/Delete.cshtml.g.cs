#pragma checksum "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork\WebApplication\Areas\Admin\Views\Clients\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eaa49b969aabb9ea8941bc28979bf9233d5adc01"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Clients_Delete), @"mvc.1.0.view", @"/Areas/Admin/Views/Clients/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaa49b969aabb9ea8941bc28979bf9233d5adc01", @"/Areas/Admin/Views/Clients/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d221959382d002e9a675138168ad5beae88e33b", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Clients_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Client>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Clients", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-button-a"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div class=\"headerCe\">Czy na pewno chcesz usunąć wskazaną pozycję?</div>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eaa49b969aabb9ea8941bc28979bf9233d5adc0112202", async() => {
                WriteLiteral("\r\n        <div class=\"bottom-bar-options\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eaa49b969aabb9ea8941bc28979bf9233d5adc0112519", async() => {
                    WriteLiteral("Nie");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <input type=\"submit\" value=\"Tak\" class=\"form-button\" />\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Client> Html { get; private set; }
    }
}
#pragma warning restore 1591
