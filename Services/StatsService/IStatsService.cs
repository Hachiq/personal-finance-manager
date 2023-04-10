using FinanceManager.Models;

namespace FinanceManager.Services.StatsService
{
    public interface IStatsService
    {
        IEnumerable<TransactionModel> GetTransactions();
        IEnumerable<CategoryModel> GetCategories();
    }
}
