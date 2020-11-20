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
        public Item SelectedItem { get; set; }

        public IMvxCommand BookReaderCommand { get; set; }

        public IMvxCommand RemainingItemsThresholdReachedCommand { get; set; }

        public ItemDetailViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            BookReaderCommand = new MvxCommand<Item>(async (i) => await BookReaderAsync(i));
        }

        private async Task BookReaderAsync(Item selectedItem)
        {
            if (IsNotBusy)
            {
                IsBusy = true;

                await NavigationService.Navigate<ItemReaderViewModel,Item>(selectedItem);

                IsBusy = false;
            }
        }

        public override void Prepare(Item selectedItem)
        {
            SelectedItem = selectedItem;
        }
    }
}
