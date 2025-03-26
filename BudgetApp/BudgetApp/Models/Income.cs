using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Income
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public decimal ForecastedAmount { get; set; }
        public decimal ActualAmount { get; set; }

        public DateTime Date { get; set; }

        public int PartitionCount { get; set; }
    }
}
