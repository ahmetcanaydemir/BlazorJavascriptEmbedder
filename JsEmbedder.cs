using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorJsEmbedder
{
    public class JsEmbedder : ComponentBase
    {
        #region Constants
        const string JS_FUNC_PREFIX = "window.embedderFunctions.";
        const string JS_EVALUATE_FUNC = "evaluate";
        #endregion

        #region Parameters and Injects
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Parameter] public string JavaScript { get; set; }
        #endregion

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                await JSRuntime.InvokeVoidAsync(FullFuncName(JS_EVALUATE_FUNC), JavaScript);
            }
        }

        public async Task<T> RunJsFunction<T>(string code)
        {
           return await JSRuntime.InvokeAsync<T>(FullFuncName(JS_EVALUATE_FUNC), code);
        }

        private static string FullFuncName(string funcName) =>JS_FUNC_PREFIX + funcName;
    }
}
