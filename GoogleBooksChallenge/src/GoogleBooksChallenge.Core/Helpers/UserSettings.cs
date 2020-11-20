using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using GoogleBooksChallenge.Core.Contracts;

namespace GoogleBooksChallenge.Core.Helpers
{
    /// <summary>
    /// User local settings data
    /// </summary>
    public class UserSettings
    {
        public static CookieContainer CookieContainer = new CookieContainer();
    }
}
