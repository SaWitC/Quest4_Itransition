#pragma checksum "D:\FileCopy\Quest4\Quest4\Views\Shared\Partial\_UpdateDataPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d43e2fefd9a2f1b499a06b02c2f6da80d3806117"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Partial__UpdateDataPartial), @"mvc.1.0.view", @"/Views/Shared/Partial/_UpdateDataPartial.cshtml")]
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
#line 1 "D:\FileCopy\Quest4\Quest4\Views\_ViewImports.cshtml"
using Quest4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FileCopy\Quest4\Quest4\Views\_ViewImports.cshtml"
using Quest4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d43e2fefd9a2f1b499a06b02c2f6da80d3806117", @"/Views/Shared/Partial/_UpdateDataPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"281a7a525620dc38193c20879272f153708bd36f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Partial__UpdateDataPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<script>\r\n        $(document).ready(function () {\r\n            $.ajax({\r\n                type: \"POST\",\r\n                url: \"");
#nullable restore
#line 5 "D:\FileCopy\Quest4\Quest4\Views\Shared\Partial\_UpdateDataPartial.cshtml"
                 Write(Url.Action("CheckUserStatus", "Account"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                data: {  },\r\n                dataType: \"text\",\r\n                success: function () {\r\n                },\r\n                error: function () {\r\n                }\r\n            })\r\n        })\r\n</script>\r\n\r\n");
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
