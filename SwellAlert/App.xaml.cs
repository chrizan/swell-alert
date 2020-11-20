using SwellAlert.Data;
using SwellAlert.Models;
using SwellAlert.Views;
using Xamarin.Forms;

namespace SwellAlert
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            IDataProvider dataProvider = new MswDataProvider();
            MainPage = new MainPage(dataProvider);
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
