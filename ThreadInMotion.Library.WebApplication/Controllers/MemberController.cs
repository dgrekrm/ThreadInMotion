using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using ThreadInMotion.Library.DataAccessLayer.Interfaces;
using ThreadInMotion.Library.SharedModels.Models;

namespace ThreadInMotion.Library.WebApplication.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public IActionResult Create() {
            return View(new Member { });
        }

        [HttpPost]
        public IActionResult Create(Member member)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = string.Join(Environment.NewLine, ModelState.Values.SelectMany(v => v.Errors).Select(s => s.ErrorMessage)) });
                }
                var result = _memberService.Create(member);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                //TODO:Log here..
                return StatusCode(500);
            }
        }

    }
}
