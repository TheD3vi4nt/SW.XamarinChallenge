using System;
using System.Collections.Generic;
using System.Text;
using GoogleBooksChallenge.Core.Services;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace GoogleBooksChallenge.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        /// <summary>
        /// Api service
        /// </summary>
        protected readonly ApiService ApiService;

        public readonly IMvxNavigationService NavigationService;

        public BaseViewModel(IMvxNavigationService navigationService)
        {
            NavigationService = navigationService;
            ApiService = new ApiService();
        }
    }
}
