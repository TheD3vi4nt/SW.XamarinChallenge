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
        public string TextQuery { get; set; }

        public IMvxCommand SearchBooksCommand { get; set; }

        private IDialogService _dialogService { get; set; }

        public HomeViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            SearchBooksCommand = new MvxCommand(async () => await SearchBooksAsync());
        }

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
