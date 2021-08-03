using Microsoft.AspNetCore.Mvc;
using System;
using ThreadInMotion.Library.DataAccessLayer.Interfaces;
using ThreadInMotion.Library.DataAccessLayer.Services;
using ThreadInMotion.Library.SharedModels.Models;
using System.Linq;

namespace ThreadInMotion.Library.WebApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Book { });
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = string.Join(Environment.NewLine, ModelState.Values.SelectMany(v => v.Errors).Select(s => s.ErrorMessage)) });
                }
                var result = _bookService.Create(book);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                //TODO:Log here..
                return StatusCode(500);
            }

        }

        [HttpGet]
        public IActionResult Search()
        {
            return View(new Book { });
        }

        [HttpPost]
        public IActionResult GetBooks(Book book)
        {
            try
            {
                var result = _bookService.Read(book);
                return Ok(new
                {
                    result = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }
}
