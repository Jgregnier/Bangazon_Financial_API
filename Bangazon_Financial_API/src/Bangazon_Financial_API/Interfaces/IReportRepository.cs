using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon_Financial_API.Models;

namespace Bangazon_Financial_API.Interfaces
{
    public interface IReportRepository
    {
        IEnumerable<Report> WeeklyReports();
        IEnumerable<Report> MonthlyReports();
        IEnumerable<Report> QuarterlyReports();
        IEnumerable<Report> CustomerRevenueReports();
        IEnumerable<Report> ProductRevenueReports();
    }
}
