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
        /// The app is not busy
        /// </summary>
        public bool IsNotBusy => !_isBusy;

        /// <summary>
        /// The app is busy
        /// </summary>
        private bool _isBusy;

        /// <summary>
        /// The app is busy
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;

            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

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
