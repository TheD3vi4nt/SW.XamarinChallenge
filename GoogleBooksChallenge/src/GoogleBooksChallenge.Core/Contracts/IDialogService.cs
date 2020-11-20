using System;
using System.Threading.Tasks;

namespace GoogleBooksChallenge.Core.Contracts
{
    /// <summary>
    /// User dialog service
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// show loading
        /// </summary>
        /// <param name="show">Show</param>
        void ShowLoading(bool show);

        /// <summary>
        /// Show alert
        /// </summary>
        /// <param name="message">Alert message</param>        
        /// <returns>Awaitable</returns>
        Task ShowAlertAsync(string message);

        /// <summary>
        /// Show alert
        /// </summary>
        /// <param name="message">Alert message</param>
        /// <param name="title">Title</param>       
        /// <returns>Awaitable</returns>
        Task ShowAlertAsync(string message, string title);

        /// <summary>
        /// Show alert
        /// </summary>
        /// <param name="message">Alert message</param>
        /// <param name="title">Title</param>
        /// <param name="buttonText">Button text</param>
        /// <returns>Awaitable</returns>
        Task ShowAlertAsync(string message, string title, string buttonText);
    }
}
