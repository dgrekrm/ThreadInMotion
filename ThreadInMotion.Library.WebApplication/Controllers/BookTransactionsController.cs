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

        public BookTransactionsController(IBookService bookService, IMemberService memberService)
        {
            _bookService = bookService;
            _memberService = memberService;
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

    }
}
