using GalleryView.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalleryView.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeLanguagePage : ContentPage
    {
        public ChangeLanguagePage()
        {
            InitializeComponent();

            if (HandelLanguage.Currnetlanguage() == "ar")
            {
                labelAR.TextColor = Color.Crimson;
            }
            else
            {
                labelEN.TextColor = Color.Crimson;
            }
        }


        private void TapChangeLangauge(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label.Text == "عربي")
            {
                labelAR.TextColor = Color.Crimson;
                labelEN.TextColor = Color.Black;
                
                HandelLanguage.ChangeLanguage("ar");
            }
            else
            {
                labelEN.TextColor = Color.Crimson;
                labelAR.TextColor = Color.Black;

                HandelLanguage.ChangeLanguage("en");
            }
        }

    }
}