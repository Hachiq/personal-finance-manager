using FinanceManager.Models;

namespace FinanceManager.Services.TransactionService
{
    public interface ITransactionService
    {
        IEnumerable<TransactionModel> GetTransactions();
        IEnumerable<CategoryModel> GetCategories();
        TransactionModel GetTransactionById(int id);
        public void AddTransaction(TransactionModel transaction);
        public void RemoveTransaction(TransactionModel transaction);
        public void EditTransaction(TransactionModel transaction);
    }
}
