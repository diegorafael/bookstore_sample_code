using System;

namespace BookstoreApiClient
{
    public class BookRouteProvider
    {
        private const string urlSeparator = "/";
        private const string prefix = "api";
        private const string controllerName = "Books";

        public string BuildRoute(string baseUrl)
            => string.Join(urlSeparator, baseUrl, prefix, controllerName);

        public string BuildGetRoute(string baseUrl, int id)
            => string.Join(urlSeparator, BuildRoute(baseUrl), id);

        public string BuildChangePriceRoute(string baseUrl, int id)
            => string.Join(urlSeparator, BuildRoute(baseUrl), id, "changeprice");

        public string BuildPurchaseRoute(string baseUrl, int id)
            => string.Join(urlSeparator, BuildRoute(baseUrl), id, "purchase");

        public string BuildSellRoute(string baseUrl, int id)
            => string.Join(urlSeparator, BuildRoute(baseUrl), id,"sell");
    }
}
