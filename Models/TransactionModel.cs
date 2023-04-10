using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        [DisplayName("Type")]
        public bool IsExpense { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        [StringLength(100)]
        public string? Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public virtual CategoryModel? Category { get; set; }
    }
}
