#pragma checksum "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\Account\SendConfirmationEmailAgain.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b267ce705fb6dd9e0387b17168e85405f78049a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_SendConfirmationEmailAgain), @"mvc.1.0.view", @"/Views/Account/SendConfirmationEmailAgain.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b267ce705fb6dd9e0387b17168e85405f78049a", @"/Views/Account/SendConfirmationEmailAgain.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b2e31d84876ab28b57832e5e9010d92088670fb", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_SendConfirmationEmailAgain : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<string>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\Account\SendConfirmationEmailAgain.cshtml"
 if (Model != null && Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>Mail ponownie został wysłany na twoją skrzynkę ");
#nullable restore
#line 5 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\Account\SendConfirmationEmailAgain.cshtml"
                                                  Write(Model[0]);

#line default
#line hidden
#nullable disable
            WriteLiteral(", kliknij w znajdujący się tam link, aby aktywować konto</h3>\r\n");
#nullable restore
#line 6 "F:\C# Projects\2019\ASP .NET Core\Mvc\WebApplication73 - Sklep, Clean architecture, UnityOfWork 2\WebApplication\Views\Account\SendConfirmationEmailAgain.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<string>> Html { get; private set; }
    }
}
#pragma warning restore 1591