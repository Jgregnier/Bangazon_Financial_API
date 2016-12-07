using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon_Financial_API.Models;
using Bangazon_Financial_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BangazonWeb.Controllers
{
    [Produces("application/json")]
    [Route("Values")]
    public class ValuesController : Controller
    {
        //Bringing in the context from our DB and storing it in a local variable named BangazonWebContext.
        private BangazonWebContext context;
        public ValuesController(BangazonWebContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult GetWeeklyReport()
        {
            IEnumerable<Report> WeeklyReport =
                from product in context.Product
                join lineitem in context.LineItem on product.ProductId equals lineitem.ProductId
                join order in context.Order on lineitem.OrderId equals order.OrderId
                where order.DateCompleted >= DateTime.Today.AddDays(-6)
                select new Report { Name = product.Name, Number = product.Price };

            List<Report> GroupedReports = WeeklyReport
            .GroupBy(r => r.Name)
            .Select(r => new Report
            {
                Name = r.First().Name,
                Number = r.Sum(p => p.Number)
            })
            .ToList();

            return Ok(GroupedReports);
        }

        [HttpGet]
        public IActionResult GetMonthlyReport()
        {
            IEnumerable<Report> MonthlyReport =
                from product in context.Product
                join lineitem in context.LineItem on product.ProductId equals lineitem.ProductId
                join order in context.Order on lineitem.OrderId equals order.OrderId
                where order.DateCompleted >= DateTime.Today.AddDays(-30)
                select new Report { Name = product.Name, Number = product.Price };

            List<Report> GroupedReports = MonthlyReport
            .GroupBy(r => r.Name)
            .Select(r => new Report
            {
                Name = r.First().Name,
                Number = r.Sum(p => p.Number)
            }).ToList();

            return Ok(GroupedReports);
        }

        [HttpGet]
        public IActionResult GetQuarterlyReport()
        {
            IEnumerable<Report> QuarterlyReport =
                 from product in context.Product
                 join lineitem in context.LineItem on product.ProductId equals lineitem.ProductId
                 join order in context.Order on lineitem.OrderId equals order.OrderId
                 where order.DateCompleted >= DateTime.Today.AddDays(-90)
                 select new Report { Name = product.Name, Number = product.Price };

            List<Report> GroupedReports = QuarterlyReport
            .GroupBy(r => r.Name)
            .Select(r => new Report
            {
                Name = r.First().Name,
                Number = r.Sum(p => p.Number)
            }).ToList();

            return Ok(GroupedReports);
        }

        [HttpGet]
        public IActionResult CustomerRevenueReport()
        {
            IEnumerable<Report> CustomerRevenueReports =
                from customer in context.Customer
                join order in context.Order on customer.CustomerId equals order.CustomerId
                join lineItem in context.LineItem on order.OrderId equals lineItem.OrderId
                join product in context.Product on lineItem.ProductId equals product.ProductId
                select new Report { Name = customer.FirstName + customer.LastName, Number = product.Price };

            List<Report> GroupedReports = CustomerRevenueReports
            .GroupBy(r => r.Name)
            .Select(r => new Report
            {
                Name = r.First().Name,
                Number = r.Sum(p => p.Number)
            }).ToList();

            return Ok(GroupedReports);
        }

        [HttpGet]
        public IActionResult ProductRevenueReport()
        {
            IEnumerable<Report> ProductRevenueReports =
                from product in context.Product 
                join lineItem in context.LineItem on product.ProductId equals lineItem.ProductId
                select new Report { Name = product.Name, Number = product.Price };

            List<Report> GroupedReports = ProductRevenueReports
            .GroupBy(r => r.Name)
            .Select(r => new Report
            {
                Name = r.First().Name,
                Number = r.Sum(p => p.Number)
            }).ToList();

            return Ok(GroupedReports);
        }
    }
}
