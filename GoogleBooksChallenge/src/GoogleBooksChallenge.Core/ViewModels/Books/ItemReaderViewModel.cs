using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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
    public class ItemReaderViewModel : BaseViewModel<Item>
    {
        public Item SelectedItem { get; set; }

        public ItemReaderViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
        }

        public override void Prepare(Item selectedItem)
        {
            SelectedItem = selectedItem;
        }
    }
}
