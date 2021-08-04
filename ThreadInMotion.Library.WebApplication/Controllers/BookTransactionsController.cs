using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreadInMotion.Library.DataAccessLayer.Interfaces;
using ThreadInMotion.Library.SharedModels.Models;

namespace ThreadInMotion.Library.WebApplication.Controllers
{
    public class BookTransactionsController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMemberService _memberService;
        private readonly IBookTransactionsService _bookTransactionsService;


        public BookTransactionsController(IBookService bookService, IMemberService memberService, IBookTransactionsService bookTransactionsService)
        {
            _bookService = bookService;
            _memberService = memberService;
            _bookTransactionsService = bookTransactionsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AssignBookToMember(int bookId)
        {
            var book = _bookService.GetEntities($"Id = {bookId}").FirstOrDefault();
            ViewBag.BookId = book.Id;
            ViewBag.BookName = book.Name;
            var members = _memberService.Read(new Member { });
            ViewBag.Members = members.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AssignBookToMember(BookTransaction bookTransaction)
        {
            try
            {
                bookTransaction.ExitDate = DateTime.Now;
                _bookTransactionsService.Create(bookTransaction);

                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
        [HttpPost]
        public IActionResult UnassignBook(int bookId)
        {
            try
            {
                _bookTransactionsService.Update(new BookTransaction { BookId = bookId });

                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }


    }
}
