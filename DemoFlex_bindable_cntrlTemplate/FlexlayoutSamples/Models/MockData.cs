using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DemoFlex_bindable_cntrlTemplate.FlexlayoutSamples.Models
{
    public class NewsData
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }

        [JsonProperty("articles")]
        public Article[] Articles { get; set; }
    }
    public class Article
    {
        [JsonProperty("source")]
        public Source Source { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urlToImage")]
        public string UrlToImage { get; set; }

        [JsonProperty("publishedAt")]
        public DateTimeOffset PublishedAt { get; set; }

        [JsonProperty("content")]
        public object Content { get; set; }
        
    }
    public class Source
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class BottomUIElements
    {
        public string GifImageSource { get; set; }

        public string Title { get; set; }

    }
}
