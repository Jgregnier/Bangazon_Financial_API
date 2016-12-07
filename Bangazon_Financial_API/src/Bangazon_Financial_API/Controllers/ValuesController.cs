using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon_Financial_API.Models;
using Bangazon_Financial_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bangazon_Financial_API.Repositories;
using Bangazon_Financial_API.Interfaces;

namespace BangazonWeb.Controllers
{
    [Produces("application/json")]
    [Route("Values")]
    public class ValuesController : Controller
    {
        //Bringing in the context from our DB and storing it in a local variable named BangazonWebContext.
        private ReportRepository reportRepository;

        public ValuesController(ReportRepository repository)
        {
            reportRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(reportRepository.WeeklyReports());
        }

        [HttpGet]
        public IActionResult GetMonthlyReport()
        {
            return Json(reportRepository.MonthlyReports());
        }

        [HttpGet]
        public IActionResult GetQuarterlyReport()
        {
            return Json(reportRepository.QuarterlyReports());
        }

        [HttpGet]
        public IActionResult CustomerRevenueReport()
        {
            return Json(reportRepository.CustomerRevenueReports());
        }

        [HttpGet]
        public IActionResult ProductRevenueReport()
        {
            return Json(reportRepository.ProductRevenueReports());
        }
    }
}
