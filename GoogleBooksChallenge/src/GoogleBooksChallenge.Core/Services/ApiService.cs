using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GoogleBooksChallenge.Core.Contracts;
using GoogleBooksChallenge.Core.Helpers;
using GoogleBooksChallenge.Core.Models;
using Refit;

namespace GoogleBooksChallenge.Core.Services
{
    /// <summary>
    /// Api service
    /// </summary>
    public class ApiService
    {
        private readonly IBooksApi _booksApi;

        /// <summary>
        /// Class constructor
        /// </summary>
        public ApiService()
        {
            _booksApi = RestService.For<IBooksApi>(new HttpClient()
            {
                BaseAddress = new Uri(Constants.GoogleBooksEndpoint)
            });
        }

        /// <summary>
        /// Get books async
        /// </summary>
        /// <param name="login">Login data</param>
        /// <returns>Token</returns>
        public async Task<ApiServiceResult<BooksQueryResponse>> GetBooksAsync(string query)
        {
            return await ExecuteAsync(_booksApi.GetBooks(query));
        }

        /// <summary>
        /// Get next books async
        /// </summary>
        /// <param name="login">Login data</param>
        /// <returns>Token</returns>
        public async Task<ApiServiceResult<BooksQueryResponse>> GetNextBooksAsync(string query, int lastBook)
        {
            return await ExecuteAsync(_booksApi.GetNextBooks(query, lastBook));
        }

        /// <summary>
        /// Excecute api operation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="task"></param>
        /// <returns></returns>
        private async Task<ApiServiceResult<T>> ExecuteAsync<T>(Task<T> task)
        {
            var result = new ApiServiceResult<T>();

            try
            {
                result.Result = await task;
                result.Code = HttpStatusCode.OK;
                result.Success = true;
            }
            catch (Refit.ApiException ex)
            {
                if (ex != null)
                {
                    Trace.TraceError(ex.Message);

                    result.Code = ex.StatusCode;                    
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                result.Code = HttpStatusCode.InternalServerError;
                result.Error = ex.Message;
            }

            return result;
        }       
    }
}
