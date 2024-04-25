using Microsoft.AspNetCore.Components;

namespace Elections.Frontend.Shared
{
    public partial class GenericFilter
    {
        [Parameter] public string PlaceHolder { get; set; } = string.Empty;
        [Parameter, SupplyParameterFromQuery] public string Filter { get; set; } = string.Empty;
        [Parameter] public EventCallback<string> SelectedFilter { get; set; }
        private async Task CleanFilterAsync()
        {
            Filter = string.Empty;
            await ApplyFilterAsync();
        }

        private async Task ApplyFilterAsync()
        {
            await SelectedFilter.InvokeAsync(Filter);
        }
    }
}
