using FinanceManager.Models;
using FinanceManager.Services.TransactionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinanceManager.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {
            return View(_transactionService.GetTransactions());
        }
        public IActionResult Add()
        {
            PopulateCategoryDropDownList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(TransactionModel transaction)
        {
            if (ModelState.IsValid)
            {
                _transactionService.AddTransaction(transaction);
                return RedirectToAction("Index");
            }
            PopulateCategoryDropDownList();
            return View(transaction);
        }
        public void PopulateCategoryDropDownList()
        {
            var categories = from c in _transactionService.GetCategories()
                             orderby c.Id
                             select c;
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
        }
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var transactionFromDb = _transactionService.GetTransactionById(id);

            if (transactionFromDb == null)
            {
                return NotFound();
            }
            PopulateCategoryDropDownList();
            return View(transactionFromDb);
        }
        [HttpPost]
        public IActionResult Edit(TransactionModel transaction)
        {
            if (ModelState.IsValid)
            {
                _transactionService.EditTransaction(transaction);
                return RedirectToAction("Index");
            }
            PopulateCategoryDropDownList();
            return View(transaction);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var transactionFromDb = _transactionService.GetTransactionById(id);

            if (transactionFromDb == null)
            {
                return NotFound();
            }
            _transactionService.GetCategories();
            return View(transactionFromDb);
        }
        [HttpPost]
        public IActionResult Delete(TransactionModel transaction)
        {
            if (ModelState.IsValid)
            {
                _transactionService.RemoveTransaction(transaction);
                return RedirectToAction("Index");
            }
            return View(transaction);
        }
    }
}
