using Microsoft.AspNetCore.Mvc;
using ThreadInMotion.Library.DataAccessLayer.Interfaces;
using ThreadInMotion.Library.SharedModels.Models;

namespace ThreadInMotion.Library.WebApplication.Controllers
{
    public class DailyReportController : Controller
    {
        private readonly IDailyReportService _dailyReportService;

        public DailyReportController(IDailyReportService dailyReportService)
        {
            _dailyReportService = dailyReportService;
        }

        public IActionResult Index()
        {
            return View(_dailyReportService.Read(new DailyReport { }));
        }
    }
}
