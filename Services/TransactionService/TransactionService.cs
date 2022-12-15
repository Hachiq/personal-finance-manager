using FinanceManager.Data;
using FinanceManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext _db;
        public TransactionService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<TransactionModel> GetTransactions()
        {
            return _db.Transactions.Include(c => c.Category).ToList();
        }
        public IEnumerable<CategoryModel> GetCategories()
        {
            return _db.Categories.ToList();
        }
        public TransactionModel GetTransactionById(int id)
        {
            return _db.Transactions.Find(id);
        }
        public void AddTransaction(TransactionModel transaction)
        {
            try
            {
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RemoveTransaction(TransactionModel transaction)
        {
            try
            {
                _db.Transactions.Remove(transaction);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void EditTransaction(TransactionModel transaction)
        {
            try
            {
                _db.Transactions.Update(transaction);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } 
    }
}
