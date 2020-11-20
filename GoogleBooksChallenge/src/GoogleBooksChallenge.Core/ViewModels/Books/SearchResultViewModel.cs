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
        /// <summary>
        /// Dynamic title for Navigation Bar
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Object parameter generated in Home search
        /// </summary>
        public string TextQuery { get; set; }

        /// <summary>
        /// Treshold for CollectionView inifinite scrolling
        /// </summary>
        private int _itemTreshold;
        public int ItemTreshold
        {
            get => _itemTreshold;
            set => SetProperty(ref _itemTreshold, value);
        }

        /// <summary>
        /// Collection of Query result Items
        /// </summary>
        private ObservableCollection<Item> _queryItems;
        public ObservableCollection<Item> QueryItems
        {
            get => _queryItems;
            set => SetProperty(ref _queryItems, value);
        }

        /// <summary>
        /// Command for Book Detail Page
        /// </summary>
        public IMvxCommand BookDetailCommand { get; set; }

        /// <summary>
        /// Command for infinite scrolling logic
        /// </summary>
        public IMvxCommand RemainingItemsThresholdReachedCommand { get; set; }

        /// <summary>
        /// Service dependency for Display Alerts
        /// </summary>
        private IDialogService _dialogService { get; set; }

        public SearchResultViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService)
        {
            _dialogService = dialogService;
            BookDetailCommand = new MvxCommand<Item>(async (i) => await BookDetailAsync(i));
            RemainingItemsThresholdReachedCommand = new MvxCommand(async () => await RemainingItemsThresholdReachedAsync());            
            ItemTreshold = 3;
        }

        /// <summary>
        /// ViewModel Init method for API Search response
        /// </summary>
        /// <returns></returns>
        public override async Task Initialize()
        {
            await base.Initialize();

            if (IsNotBusy)
            {
                IsBusy = true;

                //API Google Books Search initial response for 20 items
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

        /// <summary>
        /// Method for infinite scrolling logic
        /// </summary>
        /// <returns></returns>
        private async Task RemainingItemsThresholdReachedAsync()
        {
            if (IsNotBusy)
            {
                IsBusy = true;                

                //API Google Books Search response for new books
                var newItemsResponse = await ApiService.GetNextBooksAsync(TextQuery, QueryItems.Count());

                if (newItemsResponse.Success)
                {
                    if (newItemsResponse.Result.Items != null)
                    {
                        foreach (var item in newItemsResponse.Result.Items)
                        {
                            //New book added to Collection
                            QueryItems.Add(item);
                        }
                    }
                    else
                    {
                        //Negative value indicating to CollectionView that there are no new items
                        ItemTreshold = -1;
                    }                 
                }
                else
                {
                    await _dialogService.ShowAlertAsync(AppResources.ServiceError);
                }
                IsBusy = false;
            }
        }

        /// <summary>
        /// Method for navigation service Book Detail
        /// </summary>
        /// <param name="selectedItem"></param>
        /// <returns></returns>
        private async Task BookDetailAsync(Item selectedItem)
        {
            if (IsNotBusy)
            {
                IsBusy = true;

                await NavigationService.Navigate<ItemDetailViewModel, Item>(selectedItem);

                IsBusy = false;
            }
        }

        /// <summary>
        /// Method init for ViewModel parameters
        /// </summary>
        /// <param name="textQuery"></param>
        public override void Prepare(string textQuery)
        {
            Title = AppResources.SearchResultTitle + textQuery;
            TextQuery = textQuery;
        }
    }
}
