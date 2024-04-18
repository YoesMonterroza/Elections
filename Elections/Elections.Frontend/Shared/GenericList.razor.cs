using Microsoft.AspNetCore.Components;

namespace Elections.Frontend.Shared
{
    public partial class GenericList<Titem>
    {
        [EditorRequired]
        [Parameter]
        public RenderFragment Body { get; set; } = null!;

        [Parameter]
        public RenderFragment? Loading { get; set; }

        [EditorRequired, Parameter] public List<Titem> MyList { get; set; } = null!;
        [Parameter]
        public RenderFragment? NoRecords { get; set; }
    }
}
