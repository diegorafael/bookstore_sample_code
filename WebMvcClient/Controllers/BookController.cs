using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookstoreApiClient;
using BookstoreApiClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebMvcClient.Models;

namespace WebMvcClient.Controllers
{
    public class BookController : Controller
    {
        private BookstoreClient BookstoreClient { get; }
        private string BooksEndpoint { get; }
        public BookController(IConfiguration config)
        {
            BooksEndpoint = config.GetValue<string>("Endpoints:Books");
            BookstoreClient = BookstoreClient.Build(BooksEndpoint);
        }

        // GET: Book
        public async Task<ActionResult> Index()
        {
            var books = await BookstoreClient.GetBooksAsync();
            return View(books);
        }

        // GET: Book/Create
        public async Task<ActionResult> CreateOrEdit(int id = 0)
        {
            Book book = new Book();

            if (id != 0)
                book = await BookstoreClient.GetBookAsync(id) ?? book;

            return View(book);
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind()] Book book)
        {
            try
            {
                Book response;

                if (book.Id == 0)
                    response = await BookstoreClient.CreateAsync(book);
                else
                    response = await BookstoreClient.UpdateBookAsync(book);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Book/ChangePrice
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePrice(ItemPrice itemPrice)
        {
            await BookstoreClient.ChangePriceAsync(itemPrice);
            return RedirectToAction(nameof(Index));
        }

        // Get: Book/ChangePrice
        public ActionResult ChangePrice(int id)
        {
            return View(new ItemPrice() { Id = id, Price = 0 });
        }


        // POST: Book/RegisterSell
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterSell(StockMovement stockMovement)
        {
            await BookstoreClient.RegisterSellAsync(stockMovement);
            return RedirectToAction(nameof(Index));
        }

        // Get: Book/RegisterSell
        public ActionResult RegisterSell(int id)
        {
            return View(new StockMovement() { Id = id });
        }
        // POST: Book/RegisterPurchase
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterPurchase(StockMovement stockMovement)
        {
            await BookstoreClient.RegisterPurchaseAsync(stockMovement);
            return RedirectToAction(nameof(Index));
        }

        // Get: Book/RegisterPurchase
        public ActionResult RegisterPurchase(int id)
        {
            return View(new StockMovement() { Id = id });
        }

        // GET: Book/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                bool response = await BookstoreClient.DeleteBookAsync(id);

                if (response)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}