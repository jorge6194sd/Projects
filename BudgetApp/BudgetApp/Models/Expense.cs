using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public decimal ForecastedAmount { get; set; }
        public decimal ActualAmount { get; set; }

        public bool IsPaid { get; set; }

        public DateTime Date { get; set; }

        public int PartitionCount { get; set; }
    }
}
