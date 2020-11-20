using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using GoogleBooksChallenge.Core.Contracts;
using GoogleBooksChallenge.Core.Resources;
using Xamarin.Forms;

namespace GoogleBooksChallenge.Core.Services
{
    /// <summary>
    /// User dialog service
    /// </summary>
    public class DialogService : IDialogService
    {
        /// <summary>
        /// App is loading
        /// </summary>
        private bool _loading;

        /// <summary>
        /// show loading
        /// </summary>
        /// <param name="show">Show</param>
        public void ShowLoading(bool show)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (show)
                {
                    UserDialogs.Instance.ShowLoading(AppResources.Loading,
                                                     MaskType.Black);
                    _loading = true;
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    _loading = false;
                }
            });
        }

        /// <summary>
        /// Show alert
        /// </summary>
        /// <param name="message">Alert message</param>        
        /// <returns>Awaitable</returns>
        public Task ShowAlertAsync(string message)
        {
            return InternalShowAlertAsync(message,
                                          AppResources.ApplicationName,
                                          AppResources.Accept);
        }

        /// <summary>
        /// Show alert
        /// </summary>
        /// <param name="message">Alert message</param>
        /// <param name="title">Title</param>       
        /// <returns>Awaitable</returns>
        public Task ShowAlertAsync(string message, string title)
        {
            return InternalShowAlertAsync(message,
                                          title,
                                          AppResources.Accept);
        }

        /// <summary>
        /// Show alert
        /// </summary>
        /// <param name="message">Alert message</param>
        /// <param name="title">Title</param>
        /// <param name="buttonText">Button text</param>
        /// <returns>Awaitable</returns>
        public Task ShowAlertAsync(string message, string title, string buttonText)
        {
            return InternalShowAlertAsync(message,
                                          title,
                                          buttonText);
        }               

        /// <summary>
        /// Show alert
        /// </summary>
        /// <param name="message">Alert message</param>
        /// <param name="title">Title</param>
        /// <param name="buttonText">Button text</param>
        /// <returns>Awaitable</returns>
        private async Task InternalShowAlertAsync(string message, string title, string buttonText)
        {
            if (_loading)
            {
                ShowLoading(false);

                await UserDialogs.Instance.AlertAsync(message,
                                                      title,
                                                      buttonText);

                ShowLoading(true);
            }
            else
            {
                await UserDialogs.Instance.AlertAsync(message,
                                                      title,
                                                      buttonText);
            }
        }
    }
}
