using AsyncCRUD.Models;
using AsyncCRUD.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.Xml;

namespace AsyncCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IbookService ibs;

        public BookController(IbookService ibs)
        { 
            this.ibs = ibs;
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var bk= await ibs.GetAllAsync();
            return Ok(bk);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id) {
        var bh1 = await ibs.GetByIdAsync(id);
            return Ok(bh1);
        
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book book) {
            var ubk = await ibs.UpdateAsync(id,book);
            if(id != book.BookId)
            {
                return BadRequest();
            }
            if(ubk == null)
            {
                return NotFound();
            }
            return Ok(ubk);
           
        
        }
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {    var bk = await ibs.AddAsync(book);
            return CreatedAtAction(nameof(GetBook),new {id = bk.BookId},book);
             
        
        }

        [HttpDelete("{id}")]
      //  [Authorize]   unbale to use it this method 
        public async Task<ActionResult<Book>> Delete(int id)
        { 
                 var del = await ibs.DeleteBook(id);
                 if(del== null)
            {
                return NotFound();
            }
                 return Ok(del);
          
        
        }

        [HttpGet("bookwithauthor")]
        public async Task<ActionResult<IEnumerable>> GetAllbookwithAuthor()
        {
            var bwd= await ibs.GetAllBooksWithAuthor();
            return Ok(bwd);
        }
        [HttpGet("Authors")]
        public async Task<ActionResult<IEnumerable>> GetAuthors()
        {
            var a = await ibs.GetAllAuthor();
            return Ok(a);
        }
       
    }
}
