using FinanceManager.Data;
using FinanceManager.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _db;
        public ReportService(ApplicationDbContext db)
        {
            _db = db;
        }

        public double GenerateReport(IEnumerable<TransactionModel> transactions)
        {
            double value = 0d;
            foreach (var transaction in transactions)
            {
                if (transaction.IsExpense)
                {
                    value += transaction.Value;
                }
            }
            return value;
        }
        public double GenerateReport(IEnumerable<TransactionModel> transactions, DateTime startDate, DateTime endDate)
        {
            double value = 0d;
            foreach (var transaction in transactions)
            {
                if (transaction.Date >= startDate && transaction.Date <= endDate)
                {
                    if (transaction.IsExpense)
                    {
                        value += transaction.Value;
                    }
                }  
            }
            return value;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public IEnumerable<TransactionModel> GetTransactions()
        {
            return _db.Transactions.Include(c => c.Category).ToList();
        }
    }
}
