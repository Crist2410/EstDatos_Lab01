#pragma checksum "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2eaa45a5a6061c327f2c0171d97249faf43b9c71"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Jugadores_BuscarJugadoresCS), @"mvc.1.0.view", @"/Views/Jugadores/BuscarJugadoresCS.cshtml")]
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
#line 1 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\_ViewImports.cshtml"
using EstDatos_Lab01;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\_ViewImports.cshtml"
using EstDatos_Lab01.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2eaa45a5a6061c327f2c0171d97249faf43b9c71", @"/Views/Jugadores/BuscarJugadoresCS.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"156ee664cc865a46213e08e22892faa7407c4edc", @"/Views/_ViewImports.cshtml")]
    public class Views_Jugadores_BuscarJugadoresCS : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EstDatos_Lab01.Models.JugadoresModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline my-2 my-lg-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Jugadores", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BuscarJugador", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
  
    ViewData["Title"] = "BuscarJugadoresCS";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>BuscarJugadoresCS</h1>\r\n\r\n<nav class=\"navbar navbar-dark bg-dark\">\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2eaa45a5a6061c327f2c0171d97249faf43b9c714610", async() => {
                WriteLiteral(@"
        <div class=""btn-group btn-group-toggle"" data-toggle=""buttons"">
            <label class=""btn btn-secondary active"">
                <input type=""radio"" name=""Buscar"" id=""Buscar"" value=""N"" autocomplete=""off"" checked> Nombre
            </label>
            <label class=""btn btn-secondary"">
                <input type=""radio"" name=""Buscar"" id=""Buscar"" value=""P"" autocomplete=""off""> Posicion
            </label>
            <label class=""btn btn-secondary"">
                <input type=""radio"" name=""Buscar"" id=""Buscar"" value=""SMayores"" autocomplete=""off""> Salarios Mayores
            </label>
            <label class=""btn btn-secondary"">
                <input type=""radio"" name=""Buscar"" id=""Buscar"" value=""SMenores"" autocomplete=""off""> Salarios Menores
            </label>
            <label class=""btn btn-secondary"">
                <input type=""radio"" name=""Buscar"" id=""Buscar"" value=""SIgual"" autocomplete=""off""> Salario Igual
            </label>
        </div>
        <input class=""form");
                WriteLiteral(@"-control mr-sm-2"" type=""search"" placeholder=""Search"" aria-label=""Search"" name=""Texto"" style=""position:absolute; left: 750px;"">
        <button class=""btn btn-outline-info my-2 my-sm-0"" style=""position:absolute; left: 1000px;"" type=""submit"">Buscar</button>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</nav>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 37 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
               Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 40 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
               Write(Html.DisplayNameFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 43 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
               Write(Html.DisplayNameFor(model => model.Salario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 46 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
               Write(Html.DisplayNameFor(model => model.Club));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 49 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
               Write(Html.DisplayNameFor(model => model.Posicion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 55 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
             foreach (JugadoresModel item in ViewBag.Jugadores)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 65 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Salario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 68 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Club));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 71 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Posicion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 74 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
                   Write(Html.ActionLink("Editar", "Editar", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 75 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
                   Write(Html.ActionLink("Borrar", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 78 "C:\Users\Crist\Desktop\EstDatos_Lab01\Views\Jugadores\BuscarJugadoresCS.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EstDatos_Lab01.Models.JugadoresModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
