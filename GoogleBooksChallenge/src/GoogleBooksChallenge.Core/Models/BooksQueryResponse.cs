using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GoogleBooksChallenge.Core.Models
{
    public class BooksQueryResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }

        public string TextQuery { get; set; }
    }
}
