using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace GalleryView
{
    public partial class MainPage : ContentPage
    {
        private int positionCurrentView;
        private uint lengthAnimation = 300;
        private double widthDevice;
        private VisualElement CurrnentVisualElement;
        private VisualElement PreviousVisualElement;
        private char CurrnetDirection = 'r';
        public MainPage()
        {
            InitializeComponent();
            CurrnentVisualElement = this;
            PreviousVisualElement = new StackLayout();
            this.SizeChanged += MainPage_SizeChanged;
        }

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            widthDevice = this.Width;
            CurrnentVisualElement.TranslationX = 0;
            PreviousVisualElement.TranslationX = widthDevice;
            Console.WriteLine(widthDevice);
        }

        // Taps Events
        private void TapChangeLangauge(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label.Text == "عربي")
            {
                labelAR.TextColor = Color.Crimson;
                labelEN.TextColor = Color.Black;
                CurrnetDirection = 'r';
                CurrnentVisualElement.TranslationX = 0;
                PreviousVisualElement.TranslationX = -widthDevice;
                LocalizationResourceManager.Current.CurrentCulture = new CultureInfo("ar");
                this.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                labelEN.TextColor = Color.Crimson;
                labelAR.TextColor = Color.Black;
                CurrnetDirection = 'l';
                CurrnentVisualElement.TranslationX = 0;
                PreviousVisualElement.TranslationX = widthDevice;
                LocalizationResourceManager.Current.CurrentCulture = new CultureInfo("en");
                this.FlowDirection = FlowDirection.LeftToRight;
            }
        }

        // Buttons Events
        private void ButtonNext(object sender, EventArgs e)
        {
            NextVisibleGallery();
        }
        private void ButtonPrevious(object sender, EventArgs e)
        {
            PreviousVisibleGallery();
        }

        // Methods

        // this method set position and show next view with animation
        async void NextVisibleGallery()
        {
            switch (positionCurrentView)
            {
                case 0:
                    await NextAnimation(gallery1, gallery2, CurrnetDirection);
                    positionCurrentView = 1;
                    break;
                case 1:
                    await NextAnimation(gallery2, gallery3, CurrnetDirection);
                    positionCurrentView = 2;
                    break;
                case 2:
                    break;
            }
        }

        // this method set position and show Previous view with animation
        async void PreviousVisibleGallery()
        {
            switch (positionCurrentView)
            {
                case 2:
                    await PreviousAnimation(gallery3, gallery2, CurrnetDirection);
                    positionCurrentView = 1;
                    break;
                case 1:
                    await PreviousAnimation(gallery2, gallery1, CurrnetDirection);
                    positionCurrentView = 0;
                    break;
                case 0:
                    break;
            }
        }

        #region Animation

        // Next ANIMATION
        private async Task<bool> NextAnimation(VisualElement view1, VisualElement view2, char direction)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            var an = new Animation();
            var endView1 = direction == 'l' ? -widthDevice : widthDevice;
            var startView2 = direction == 'l' ? widthDevice : -widthDevice;
            view1.TranslationX = 0;
            an.Add(0, 1, new Animation(v => view1.TranslationX = v, 0, endView1, Easing.SinIn));
            an.Add(0, 1, new Animation(v => view2.TranslationX = v, startView2, 0, Easing.SinIn));

            an.Commit(owner: this, "name", length: lengthAnimation,
                 finished: (x, c) =>
                 {
                     //taskCompletionSource.SetResult(c);
                 });
            CurrnentVisualElement = view2;
            PreviousVisualElement = view1;
            taskCompletionSource.SetResult(true);
            return await taskCompletionSource.Task;
        }

        // Previous ANIMATION
        private async Task<bool> PreviousAnimation(VisualElement view1, VisualElement view2, char direction)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            var an = new Animation();

            var endView1 = direction == 'l' ? widthDevice : -widthDevice;
            var startView2 = direction == 'l' ? -widthDevice : widthDevice;

            an.Add(0, 1, new Animation(v => view1.TranslationX = v, 0, endView1, Easing.SinIn));
            an.Add(0, 1, new Animation(v => view2.TranslationX = v, startView2, 0, Easing.SinIn));

            an.Commit(owner: this, "name", length: lengthAnimation,
                 finished: (x, c) =>
                 {
                     //taskCompletionSource.SetResult(c);
                 });
            CurrnentVisualElement = view2;
            PreviousVisualElement = view1;
            taskCompletionSource.SetResult(true);
            return await taskCompletionSource.Task;
        }
        #endregion


    } // end MainPage Class
}
