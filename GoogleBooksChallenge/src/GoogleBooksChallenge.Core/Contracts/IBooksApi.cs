using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GoogleBooksChallenge.Core.Models;
using Refit;

namespace GoogleBooksChallenge.Core.Contracts
{
    public interface IBooksApi
    {
        [Get("/books/v1/volumes?q={query}")]
        Task<BooksQueryResponse> GetBooks(string query);
    }
}
