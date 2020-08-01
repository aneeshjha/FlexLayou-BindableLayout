using DemoFlex_bindable_cntrlTemplate.FlexlayoutSamples.Views;
using Xamarin.Forms;

namespace DemoFlex_bindable_cntrlTemplate
{
    public partial class App : Application
    {
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CatalogView());

            //Theme Setting
            //Current.Resources["MajorColor"] = (Color)Current.Resources["Amber"];
            //Current.Resources["MajorColor"] = (Color)Current.Resources["LightGrey"];
            //Current.Resources["MajorColor"] = (Color)Current.Resources["#C0D68D"];
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
