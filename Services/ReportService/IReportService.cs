using FinanceManager.Models;

namespace FinanceManager.Services.ReportService
{
    public interface IReportService
    {
        IEnumerable<TransactionModel> GetTransactions();
        IEnumerable<CategoryModel> GetCategories();
        double GenerateReport(IEnumerable<TransactionModel> transactions);
        double GenerateReport(IEnumerable<TransactionModel> transactions, DateTime startDate, DateTime endDate);
    }
}
