using Microsoft.AspNetCore.Mvc;
using ThreadInMotion.Library.DataAccessLayer.Services;
using ThreadInMotion.Library.SharedModels.Models;

namespace ThreadInMotion.Library.WebApplication.Controllers
{
    public class BookController
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Create(Book book)
        {
            try
            {
                var result = _bookService.Create(book);
                return new JsonResult(new
                {
                    message = "Book registration is successfully",
                    id = result
                });
            }
            catch (System.Exception)
            {
                return new JsonResult(new {
                    message = "an error occurred"
                });
            }

        }
    }
}
