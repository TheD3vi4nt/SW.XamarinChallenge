using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GoogleBooksChallenge.Core.Contracts;
using GoogleBooksChallenge.Core.Helpers;
using MvvmCross.Navigation;
using Refit;

namespace GoogleBooksChallenge.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {

        }
    }
}
