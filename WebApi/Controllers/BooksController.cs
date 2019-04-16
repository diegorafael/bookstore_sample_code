using System.Collections.Generic;
using Domain.DTO;
using Domain.Entities;
using Domain.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using WebApi.Views;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BasicController<IBookService>
    {
        public BooksController([FromServices] IBookService service) : base(service)
        {
        }

        // GET api/books
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Service.GetAllBooksOnDefaultSorting());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(Service.Get(id));
        }

        // POST api/books
        [HttpPost]
        public ActionResult Post([FromBody] Book value)
        {
            var added = Service.Add(value);
            return CreatedAtAction(nameof(Get),new { id = added.Id } , added);
        }

        // POST api/books/1/purchase
        [Route("{id:int}/purchase")]
        [HttpPost]
        public ActionResult Purchase([FromRoute] int id, [FromBody] StockMovement stockMovement)
        {
            Service.Purchase(stockMovement.ToBookStockMovement(id));
            return Ok();
        }
        
        // POST api/books/1/sell
        [Route("{id:int}/sell")]
        [HttpPost]
        public ActionResult Sell([FromRoute] int id, [FromBody] StockMovement stockMovement)
        {
            Service.Sell(stockMovement.ToBookStockMovement(id));
            return Ok();
        }

        // POST api/books/2/changeprice
        [Route("{id:int}/changeprice")]
        [HttpPost]
        public ActionResult Post([FromRoute] int id, [FromBody]ItemPrice itemPrice)
        {
            itemPrice.Id = id;
            Service.ChangePrice(itemPrice);
            return Ok();
        }

        // PUT api/Books/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book newValue)
        {
            newValue.Id = id;
            return Accepted(Service.Update(newValue));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Accepted(Service.Remove(id));
        }
    }
}
