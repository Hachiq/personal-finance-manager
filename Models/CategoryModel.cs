using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [StringLength(25)]
        public string Name { get; set; } = string.Empty;
        [StringLength(100)]
        public string Description { get; set; } = string.Empty;
        public List<TransactionModel>? Transactions { get; set; }
    }
}
