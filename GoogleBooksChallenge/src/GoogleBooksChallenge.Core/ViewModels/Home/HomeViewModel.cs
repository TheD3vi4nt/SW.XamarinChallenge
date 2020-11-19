using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GoogleBooksChallenge.Core.Contracts;
using GoogleBooksChallenge.Core.Helpers;
using GoogleBooksChallenge.Core.Models;
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

        public HomeViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            SearchBooksCommand = new MvxCommand(async () => await SearchBooksAsync());
        }

        private async Task SearchBooksAsync()
        {
            var queryResponse = await ApiService.GetBooksAsync(TextQuery);

            if (queryResponse.Success)
            {
                await NavigationService.Navigate<SearchResultViewModel, BooksQueryResponse>(queryResponse.Result);
            }
            else
            {

            }
        }
    }
}
