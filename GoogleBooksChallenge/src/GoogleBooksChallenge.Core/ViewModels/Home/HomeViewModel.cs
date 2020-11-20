using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GoogleBooksChallenge.Core.Contracts;
using GoogleBooksChallenge.Core.Helpers;
using GoogleBooksChallenge.Core.Models;
using GoogleBooksChallenge.Core.Resources;
using GoogleBooksChallenge.Core.ViewModels.Books;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using Refit;

namespace GoogleBooksChallenge.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        /// <summary>
        /// Query text entered in Home entry
        /// </summary>
        public string TextQuery { get; set; }

        /// <summary>
        /// Command for Home search button
        /// </summary>
        public IMvxCommand SearchBooksCommand { get; set; }

        /// <summary>
        /// Service dependency for Display Alerts
        /// </summary>
        private IDialogService _dialogService { get; set; }

        public HomeViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            SearchBooksCommand = new MvxCommand(async () => await SearchBooksAsync());
        }

        /// <summary>
        /// Initialize search method
        /// </summary>
        /// <returns></returns>
        private async Task SearchBooksAsync()
        {
            if (IsNotBusy)
            {
                IsBusy = true;

                if (string.IsNullOrEmpty(TextQuery))
                {
                    await _dialogService.ShowAlertAsync(AppResources.QueryEmptyError);
                }
                else
                {
                    await NavigationService.Navigate<SearchResultViewModel, string>(TextQuery);
                }

                IsBusy = false;
            }           
        }
    }
}
