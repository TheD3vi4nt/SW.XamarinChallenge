using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using GoogleBooksChallenge.Core.Contracts;
using GoogleBooksChallenge.Core.Helpers;
using GoogleBooksChallenge.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using Refit;

namespace GoogleBooksChallenge.Core.ViewModels.Books
{
    public class SearchResultViewModel : BaseViewModel<BooksQueryResponse>
    {
        public string TextQuery { get; set; }

        public ObservableCollection<Item> QueryItems
        {
            get => _queryItems;
            set => SetProperty(ref _queryItems, value);
        }

        private ObservableCollection<Item> _queryItems;

        public IMvxCommand BookDetailCommand { get; set; }

        public SearchResultViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            BookDetailCommand = new MvxCommand(async () => await BookDetailAsync());
        }

        private Task BookDetailAsync()
        {
            throw new NotImplementedException();
        }

        public override void Prepare(BooksQueryResponse parameter)
        {
            QueryItems = new ObservableCollection<Item>(parameter.Items);
        }
    }
}
