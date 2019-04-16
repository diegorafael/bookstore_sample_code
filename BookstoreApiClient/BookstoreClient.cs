using BookstoreApiClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApiClient
{
    public class BookstoreClient
    {
        private BookRouteProvider routeProvider = new BookRouteProvider();
        public string BaseUrl { get; private set; }
        public TimeSpan Timeout { get; private set; }
        private JsonSerializer serializer = new JsonSerializer
        {
            Culture = CultureInfo.GetCultureInfo("en-US"),
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            Formatting = Formatting.None,
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            FloatParseHandling = FloatParseHandling.Decimal,
        };
        private BookstoreClient()
        { }

        public static BookstoreClient Build(string baseUrl, TimeSpan? timeout = null)
        {
            var response = new BookstoreClient()
            {
                BaseUrl = baseUrl,
                Timeout = timeout ?? new TimeSpan(0, 0, 30)
            };

            return response;
        }

        //Get Books
        public async Task<List<Book>> GetBooksAsync()
        {
            using (var client = BuildClient())
            {
                var route = routeProvider.BuildRoute(BaseUrl);

                using (Stream s = await client.GetStreamAsync(route))
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    var retorno = serializer.Deserialize<List<Book>>(reader);
                    return retorno;
                }
            }
        }
        public async Task<Book> GetBookAsync(int id)
        {
            using (var client = BuildClient())
            {
                var route = routeProvider.BuildGetRoute(BaseUrl, id);

                using (Stream s = await client.GetStreamAsync(route))
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    var retorno = serializer.Deserialize<Book>(reader);
                    return retorno;
                }
            }
        }

        public async Task RegisterSellAsync(StockMovement stockMovement)
        {
            using (var client = BuildClient())
            {
                var route = routeProvider.BuildSellRoute(BaseUrl, stockMovement.Id);

                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync(route, stockMovement);

                    if (response.IsSuccessStatusCode == false)
                    {
                        var teste = response.ReasonPhrase;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task RegisterPurchaseAsync(StockMovement stockMovement)
        {
            using (var client = BuildClient())
            {
                var route = routeProvider.BuildPurchaseRoute(BaseUrl, stockMovement.Id);

                HttpResponseMessage response = await client.PostAsJsonAsync(route, stockMovement);
            }
        }

        public async Task ChangePriceAsync(ItemPrice itemPrice)
        {
            using (var client = BuildClient())
            {
                var route = routeProvider.BuildChangePriceRoute(BaseUrl, itemPrice.Id);

                HttpResponseMessage response = await client.PostAsJsonAsync(route, itemPrice);
            }
        }

        //Create Book
        public async Task<Book> CreateAsync(Book book)
        {
            using (var client = BuildClient())
            {
                var route = routeProvider.BuildRoute(BaseUrl);

                using (HttpResponseMessage response = await client.PostAsJsonAsync(route, book))
                {
                    return book;
                }
            }
        }

        //Update Book
        public async Task<Book> UpdateBookAsync(Book book)
        {
            using (var client = BuildClient())
            {
                var route = routeProvider.BuildGetRoute(BaseUrl, book.Id);

                using (HttpResponseMessage response = await client.PutAsJsonAsync(route, book))
                {
                    if (response.IsSuccessStatusCode)
                        return book;
                    else
                        return null;
                }
            }
        }

        //Delete Book
        public async Task<bool> DeleteBookAsync(int id)
        {
            using (var client = BuildClient())
            {
                var route = routeProvider.BuildGetRoute(BaseUrl, id);

                using (HttpResponseMessage response = await client.DeleteAsync(route))
                {
                    if (response.IsSuccessStatusCode)
                        return true;
                    else
                        return false;
                }
            }
        }

        private HttpClient BuildClient()
        {
            var client = new HttpClient();
            client.Timeout = Timeout;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
