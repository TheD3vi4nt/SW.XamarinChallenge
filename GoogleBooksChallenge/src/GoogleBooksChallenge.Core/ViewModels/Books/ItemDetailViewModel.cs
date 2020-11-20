using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleBooksChallenge.Core.Contracts;
using GoogleBooksChallenge.Core.Helpers;
using GoogleBooksChallenge.Core.Models;
using GoogleBooksChallenge.Core.ViewModels.Home;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using Refit;

namespace GoogleBooksChallenge.Core.ViewModels.Books
{
    public class ItemDetailViewModel : BaseViewModel<Item>
    {
        /// <summary>
        /// Current selected book
        /// </summary>
        public Item SelectedItem { get; set; }

        /// <summary>
        /// Command for Book Reader Page
        /// </summary>
        public IMvxCommand BookReaderCommand { get; set; }

        public ItemDetailViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            BookReaderCommand = new MvxCommand<Item>(async (i) => await BookReaderAsync(i));
        }

        /// <summary>
        /// Method for navigation service Book Reader
        /// </summary>
        /// <param name="selectedItem"></param>
        /// <returns></returns>
        private async Task BookReaderAsync(Item selectedItem)
        {
            if (IsNotBusy)
            {
                IsBusy = true;

                await NavigationService.Navigate<ItemReaderViewModel,Item>(selectedItem);

                IsBusy = false;
            }
        }

        /// <summary>
        /// Method init for ViewModel parameters
        /// </summary>
        /// <param name="selectedItem"></param>
        public override void Prepare(Item selectedItem)
        {
            SelectedItem = selectedItem;
        }
    }
}
