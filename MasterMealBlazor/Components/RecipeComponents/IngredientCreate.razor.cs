using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMealBlazor.Components.RecipeComponents
{
    public partial class IngredientCreate : ComponentBase
    {
        [Inject] private ILogger<IngredientCreate> _logger { get; set; }

        [Parameter] public string Title { get; set; }

        // Basic Lifecycle Functions
        //      There are Async versions of these        
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Title = "IngredientCreate";
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }
    }
}
