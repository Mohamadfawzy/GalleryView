using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace GalleryView.Helper
{
    public static class HandelLanguage
    {
        public static void ChangeLanguage(string language)
        {
            LocalizationResourceManager.Current.CurrentCulture = new CultureInfo(language);
            if(language == "ar")
            {
                App.Current.MainPage.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                App.Current.MainPage.FlowDirection = FlowDirection.RightToLeft;
            }
        }
        public static string Currnetlanguage()
        {
            return LocalizationResourceManager.Current.CurrentCulture.ToString();
        }


    }
}
