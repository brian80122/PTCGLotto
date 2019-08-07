using AngleSharp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;

namespace PTCGLottoCrawler
{
    class Program
    {
        static IHttpClientFactory  _httpClientFactory { get; set; }
        static void Main(string[] args)
        {
            SetUp();
            GetImage();
        }


        private static void SetUp()
        {
            var servicesProvider = new ServiceCollection()
                                       .AddHttpClient()
                                       .BuildServiceProvider();
            _httpClientFactory = servicesProvider.GetRequiredService<IHttpClientFactory>();
        }

        private static void GetImage()
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://www.tcgcollector.com/cards?expansion-142=on");
            
            //該站藉由 cookie 決定呈現方式
            request.Headers.Add("Cookie", "display=images");

            var result = client.SendAsync(request)
                               .Result;
            var content = result.Content
                                .ReadAsStringAsync()
                                .Result;

            #region AngleSharp
            //Use the default configuration for AngleSharp
            var config = Configuration.Default;

            //Create a new context for evaluating webpages with the given config
            var context = BrowsingContext.New(config);

            //Just get the DOM representation
            var document = context.OpenAsync(req => req.Content(content))
                                  .Result;
            var found = document.All
                                .Where(c => c.LocalName == "article" && c.ClassName.Contains("card-image-container"))
                                .ToList();
            var imageUrls = found.Select(c => c.QuerySelector("img")
                                               .GetAttribute("src"))
                                 .Select(u => new
                                 {
                                     Key = $"unbroken-bonds-{u.Split("/").Last().Split("-")[0]}.jpg",
                                     Url = u
                                 })
                                 .ToList();
            #endregion
        }
    }
}
