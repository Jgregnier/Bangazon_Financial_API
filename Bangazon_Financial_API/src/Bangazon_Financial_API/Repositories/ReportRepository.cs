using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon_Financial_API.Interfaces;
using Bangazon_Financial_API.Models;
using Bangazon_Financial_API.Data;

namespace Bangazon_Financial_API.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private BangazonWebContext context;

        public ReportRepository(BangazonWebContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Report> WeeklyReports()
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

            return GroupedReports;
        }

        public IEnumerable<Report> MonthlyReports()
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

            return GroupedReports;
        }
        public IEnumerable<Report> QuarterlyReports()
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

            return GroupedReports;
        }

        public IEnumerable<Report> CustomerRevenueReports()
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

            return GroupedReports;
        }

        public IEnumerable<Report> ProductRevenueReports()
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

            return GroupedReports;
        }
    }
}
