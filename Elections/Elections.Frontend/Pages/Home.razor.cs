namespace Elections.Frontend.Pages
{
    public partial class Home
    {
        private List<string>? adminImages;
        private List<string>? anonymImages;
        private List<string>? userImages;
        protected override async Task OnInitializedAsync()
        {
            adminImages = ["resources/1.png", "resources/2_Admin.png", "resources/3.png"];
            userImages = ["resources/1.png", "resources/2_user.png", "resources/3.png"];
            anonymImages = ["resources/1.png", "resources/2_Anonimo.png", "resources/3_Anonimo.png"];
        }
    }
}
