using FinanceManager.Data;
using FinanceManager.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Services.StatsService
{
    public class StatsService : IStatsService
    {
        private readonly ApplicationDbContext _db;
        public StatsService(ApplicationDbContext db)
        {
            _db = db;
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
