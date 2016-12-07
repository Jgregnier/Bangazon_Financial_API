using Microsoft.AspNetCore.Mvc;
using Bangazon_Financial_API.Repositories;

namespace BangazonWeb.Controllers
{
    [Produces("application/json")]
    [Route("CustomerRevenueReport")]
    public class QuarterlyReportController : Controller
    {
        //Bringing in the context from our DB and storing it in a local variable named BangazonWebContext.
        private ReportRepository reportRepository;

        public QuarterlyReportController(ReportRepository repository)
        {
            reportRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(reportRepository.QuarterlyReports());
        }
    }
}