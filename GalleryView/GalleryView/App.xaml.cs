using GalleryView.Resources;
using System;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalleryView
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LocalizationResourceManager.Current.PropertyChanged += (r, s) => AppResources.Culture = LocalizationResourceManager.Current.CurrentCulture;
            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);
            MainPage = new MainPage();
            //MainPage.FlowDirection = FlowDirection.RightToLeft;
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
