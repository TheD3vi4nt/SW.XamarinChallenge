using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GoogleBooksChallenge.Core.Models
{
    /// <summary>
    /// Api service result data
    /// </summary>
    /// <typeparam name="T">Result object</typeparam>
    public class ApiServiceResult<T>
    {
        /// <summary>
        /// Successful operation
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Response code
        /// </summary>
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// Result object
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Error { get; set; }
    }
}
