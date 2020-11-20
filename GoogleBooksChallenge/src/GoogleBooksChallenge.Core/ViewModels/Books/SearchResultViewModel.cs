using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleBooksChallenge.Core.Contracts;
using GoogleBooksChallenge.Core.Helpers;
using GoogleBooksChallenge.Core.Models;
using GoogleBooksChallenge.Core.Resources;
using GoogleBooksChallenge.Core.ViewModels.Home;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using Refit;

namespace GoogleBooksChallenge.Core.ViewModels.Books
{
    public class SearchResultViewModel : BaseViewModel<string>
    {
        public string Title { get; set; }

        public string TextQuery { get; set; }

        private int _itemTreshold;
        public int ItemTreshold
        {
            get => _itemTreshold;
            set => SetProperty(ref _itemTreshold, value);
        }

        public ObservableCollection<Item> QueryItems
        {
            get => _queryItems;
            set => SetProperty(ref _queryItems, value);
        }

        private ObservableCollection<Item> _queryItems;

        public IMvxCommand BookDetailCommand { get; set; }

        public IMvxCommand RemainingItemsThresholdReachedCommand { get; set; }

        private IDialogService _dialogService { get; set; }

        public SearchResultViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            BookDetailCommand = new MvxCommand<Item>(async (i) => await BookDetailAsync(i));
            RemainingItemsThresholdReachedCommand = new MvxCommand(async () => await RemainingItemsThresholdReachedAsync());            
            ItemTreshold = 3;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            if (IsNotBusy)
            {
                IsBusy = true;

                var queryResponse = await ApiService.GetBooksAsync(TextQuery);

                if (queryResponse.Success)
                {
                    if (queryResponse.Result.TotalItems > 0)
                    {
                        QueryItems = new ObservableCollection<Item>(queryResponse.Result.Items);
                    }
                    else
                    {
                        await _dialogService.ShowAlertAsync(AppResources.QueryEmptyResult);
                        await NavigationService.Close(this);
                    }
                }
                else
                {
                    await _dialogService.ShowAlertAsync(AppResources.ServiceError);
                    await NavigationService.Close(this);
                }

                IsBusy = false;
            }
            
        }
        private async Task RemainingItemsThresholdReachedAsync()
        {
            if (IsNotBusy)
            {
                IsBusy = true;                

                var newItemsResponse = await ApiService.GetNextBooksAsync(TextQuery, QueryItems.Count());

                if (newItemsResponse.Success)
                {
                    if (newItemsResponse.Result.Items != null)
                    {
                        foreach (var item in newItemsResponse.Result.Items)
                        {
                            QueryItems.Add(item);
                        }
                    }
                    else
                    {
                        ItemTreshold = -1;
                    }                 
                }
                else
                {

                }
                IsBusy = false;
            }
        }

        private async Task BookDetailAsync(Item selectedItem)
        {
            if (IsNotBusy)
            {
                IsBusy = true;

                await NavigationService.Navigate<ItemDetailViewModel, Item>(selectedItem);

                IsBusy = false;
            }
        }

        public override void Prepare(string textQuery)
        {
            Title = AppResources.SearchResultTitle + textQuery;
            TextQuery = textQuery;
        }
    }
}
