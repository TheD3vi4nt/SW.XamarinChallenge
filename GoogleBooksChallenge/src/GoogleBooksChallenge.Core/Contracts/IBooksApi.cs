using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GoogleBooksChallenge.Core.Models;
using Refit;

namespace GoogleBooksChallenge.Core.Contracts
{
    /// <summary>
    /// Google Books API Service for Refit
    /// </summary>
    public interface IBooksApi
    {
        /// <summary>
        /// Initial 20 items response
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Get("/books/v1/volumes?q={query}&startIndex=0&maxResults=20")]
        Task<BooksQueryResponse> GetBooks(string query);

        /// <summary>
        /// Service for infinite scrolling logic
        /// </summary>
        /// <param name="query"></param>
        /// <param name="lastBook"></param>
        /// <returns></returns>
        [Get("/books/v1/volumes?q={query}&startIndex={lastBook}&maxResults=20")]
        Task<BooksQueryResponse> GetNextBooks(string query, int lastBook);
    }
}
