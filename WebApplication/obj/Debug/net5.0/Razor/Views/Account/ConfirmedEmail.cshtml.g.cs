#pragma checksum "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\Account\ConfirmedEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1819f53fb8e331a95c71480933f5fedbc92ecd7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ConfirmedEmail), @"mvc.1.0.view", @"/Views/Account/ConfirmedEmail.cshtml")]
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
#line 1 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Application.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Domain.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Domain.Models.Enum;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Domain.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Domain.ViewModels.ReceiveMessages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Domain.ViewModels.Roles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Domain.ViewModels.SendMessages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Domain.ViewModels.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Domain.ViewModels.Products;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Domain.ViewModels.Orders;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Domain.ViewModels.Payments;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\_ViewImports.cshtml"
using Domain.ViewModels.Koszyk;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1819f53fb8e331a95c71480933f5fedbc92ecd7", @"/Views/Account/ConfirmedEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b2e31d84876ab28b57832e5e9010d92088670fb", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ConfirmedEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ConfirmEmailViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("button7"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\Account\ConfirmedEmail.cshtml"
  
    ViewData["Title"] = "ConfirmedEmail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Email potwierdzony, możesz się teraz zalogować na własne kontro</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1819f53fb8e331a95c71480933f5fedbc92ecd78677", async() => {
                WriteLiteral("Tutaj");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 9 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\Account\ConfirmedEmail.cshtml"
Write(Model.Result);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n");
#nullable restore
#line 11 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\Account\ConfirmedEmail.cshtml"
Write(Model.Success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n");
#nullable restore
#line 13 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\Account\ConfirmedEmail.cshtml"
Write(Model.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n");
#nullable restore
#line 15 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\Account\ConfirmedEmail.cshtml"
Write(Model.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ConfirmEmailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591