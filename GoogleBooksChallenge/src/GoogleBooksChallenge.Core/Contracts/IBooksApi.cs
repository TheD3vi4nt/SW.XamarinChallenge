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
        [Get("/books/v1/volumes?q={query}&startIndex=0&maxResults=20")]
        Task<BooksQueryResponse> GetBooks(string query);

        [Get("/books/v1/volumes?q={query}&startIndex={lastBook}&maxResults=20")]
        Task<BooksQueryResponse> GetNextBooks(string query, int lastBook);
    }
}
