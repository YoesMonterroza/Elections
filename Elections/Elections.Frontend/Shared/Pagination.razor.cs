using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace Elections.Frontend.Shared
{
    public partial class Pagination
    {
        private List<PageModel> links = new();

        private List<OptionModel> options = new();

        private int selectedOptionValue = 10;
        [Parameter] public int CurrentPage { get; set; } = 1;
        [Parameter] public int Radio { get; set; } = 10;
        [Parameter] public EventCallback<int> RecordsNumber { get; set; }
        [Parameter] public EventCallback<int> SelectedPage { get; set; }
        [Parameter] public int TotalPages { get; set; }
        protected override void OnParametersSet()
        {
            buildPages();
            buildOptions();            
        }

        private void buildPages()
        {
            links = new List<PageModel>();
            var previousLinkEnable = CurrentPage != 1;
            var previousLinkPage = CurrentPage - 1;

            links.Add(new PageModel
            {
                Text = "Anterior",
                Page = previousLinkPage,
                Enable = previousLinkEnable
            });

            for (int i = 1; i <= TotalPages; i++)
            {
                if (TotalPages <= Radio)
                {
                    links.Add(new PageModel
                    {
                        Page = i,
                        Enable = CurrentPage == i,
                        Text = $"{i}"
                    });
                }

                if (TotalPages > Radio && i <= Radio && CurrentPage <= Radio)
                {
                    links.Add(new PageModel
                    {
                        Page = i,
                        Enable = CurrentPage == i,
                        Text = $"{i}"
                    });
                }

                if (CurrentPage > Radio && i > CurrentPage - Radio && i <= CurrentPage)
                {
                    links.Add(new PageModel
                    {
                        Page = i,
                        Enable = CurrentPage == i,
                        Text = $"{i}"
                    });
                }
            }

            var linkNextEnable = CurrentPage != TotalPages;
            var linkNextPage = CurrentPage != TotalPages ? CurrentPage + 1 : CurrentPage;
            links.Add(new PageModel
            {
                Text = "Siguiente",
                Page = linkNextPage,
                Enable = linkNextEnable
            });
        }

        private void buildOptions()
        {
            options = new List<OptionModel>();
            options.Add(new OptionModel { Value = 10, Name = "10" });
            options.Add(new OptionModel { Value = 25, Name = "25" });
            options.Add(new OptionModel { Value = 50, Name = "50" });
            options.Add(new OptionModel { Value = -1, Name = "Todos" });
        }

        private async Task InternalRecordsNumberSelected(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                selectedOptionValue = Convert.ToInt32(e.Value.ToString());
            }
            await RecordsNumber.InvokeAsync(selectedOptionValue);
        }

        private async Task InternalSelectedPage(PageModel pageModel)
        {
            if (pageModel.Page == CurrentPage || pageModel.Page == 0)
            {
                return;
            }

            await SelectedPage.InvokeAsync(pageModel.Page);
        }
        private class OptionModel
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }

        private class PageModel
        {
            public bool Active { get; set; } = false;
            public bool Enable { get; set; } = true;
            public int Page { get; set; }
            public string Text { get; set; } = null!;
        }
    }
}
