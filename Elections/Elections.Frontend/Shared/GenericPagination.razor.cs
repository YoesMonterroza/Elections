using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace Elections.Frontend.Shared
{
    public partial class GenericPagination
    {
        private List<OptionModel> options = new();

        private int selectedOptionValue = 10;
        private const string PREVIOUS = "previous";
        private const string NEXT = "next";
        [Parameter] public int CurrentPage { get; set; } = 1;
        [Parameter] public string PreviousPage { get; set; } = string.Empty;
        [Parameter] public string NextPage { get; set; } = string.Empty;
        [Parameter] public EventCallback<int> RecordsNumber { get; set; }
        [Parameter] public EventCallback<int> SelectedPage { get; set; }
        [Parameter] public int TotalPages { get; set; }
        protected override void OnParametersSet()
        {
            buildNextAndPrevious();
            buildOptions();            
        }

        private void buildNextAndPrevious()
        {
            PreviousPage = (CurrentPage - 1).ToString();
            NextPage = (CurrentPage + 1).ToString();
        }

        private void buildOptions()
        {
            options = new List<OptionModel>();
            options.Add(new OptionModel { Value = 10, Name = "10" });
            options.Add(new OptionModel { Value = 25, Name = "25" });
            options.Add(new OptionModel { Value = 50, Name = "50" });
            options.Add(new OptionModel { Value = -1, Name = "Todos" });
        }

        private async void InternalSelectedPage(string pageAsString)
        {
            int page = int.Parse(pageAsString);
            if (page == CurrentPage || page == 0)
            {
                return;
            }
            CurrentPage = page;
            await SelectedPage.InvokeAsync(page);
        }

        private async Task InternalRecordsNumberSelected(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                selectedOptionValue = Convert.ToInt32(e.Value.ToString());
            }
            await RecordsNumber.InvokeAsync(selectedOptionValue);
        }

        private bool IsActive(string page)
        => CurrentPage == int.Parse(page);

        private bool IsPageNavigationDisabled(string navigation)
        {
            if (navigation.Equals(PREVIOUS))
            {
                return CurrentPage.Equals(1);
            }
            else if (navigation.Equals(NEXT))
            {
                return CurrentPage.Equals(TotalPages);
            }
            return false;
        }

        private class OptionModel
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
    }
}
