using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using GoogleBooksChallenge.Core.ViewModels.Home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GoogleBooksChallenge.Core.ViewModels.Books;
using GoogleBooksChallenge.Core.Helpers;

namespace GoogleBooksChallenge.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class ItemReaderPage : MvxContentPage<ItemReaderViewModel>
    {
        public ItemReaderPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                navigationPage.BarTextColor = Color.White;
                navigationPage.BarBackgroundColor = Color.FromHex("#f74b50");
            }
        }
    }
}
