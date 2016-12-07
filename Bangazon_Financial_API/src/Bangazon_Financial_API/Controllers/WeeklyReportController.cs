using Microsoft.AspNetCore.Mvc;
using Bangazon_Financial_API.Data;
using Bangazon_Financial_API.Repositories;

namespace BangazonWeb.Controllers
{
    [Produces("application/json")]
    [Route("WeeklyReport")]
    public class WeeklyReportController : Controller
    {
        //Bringing in the context from our DB and storing it in a local variable named BangazonWebContext.
        private ReportRepository reportRepository;

        public WeeklyReportController(ReportRepository repository)
        {
            reportRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(reportRepository.WeeklyReports());
        }
    }
}
