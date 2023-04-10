using FinanceManager.Models;
using FinanceManager.Services.StatsService;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers
{
    public class StatsController : Controller
    {
        private readonly IStatsService _statsService;
        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }
        public ActionResult Index()
        {
            var stats = new List<StatsViewModel>();
            var transactions = _statsService.GetTransactions();
            var categories = _statsService.GetCategories();
            foreach (var category in categories)
            {
                var transactionsInCategory = transactions.Where(t => t.CategoryId == category.Id).ToList();
                var income = transactionsInCategory.Where(t => t.IsExpense == false).Sum(t => t.Value);
                var expenses = transactionsInCategory.Where(t => t.IsExpense == true).Sum(t => t.Value);
                var balance = transactionsInCategory.Sum(t => t.IsExpense ? -t.Value : t.Value);
                stats.Add(new StatsViewModel
                {
                    CategoryName = category.Name,
                    Income = income,
                    Expenses = expenses,
                    Balance = balance
                });
            }
            return View(stats);
        }
    }
}
