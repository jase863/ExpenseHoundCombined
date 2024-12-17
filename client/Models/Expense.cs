using System.ComponentModel.DataAnnotations;

namespace ExpenseHound.Models
{
    public class Expense
    {
        public string? Id { get; set; }
        // Simple name of expense?
        [Required(ErrorMessage = "Please enter a name of the expense.")]
        public string Description { get; set; }
        //Amount of expense.
        [Required(ErrorMessage = "Please enter an amount.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.00.")]
        public decimal Amount { get; set; }
        //Category (Rent, Groceries, etc..)
        [Required(ErrorMessage = "Please select an expense category.")]
        public string Category { get; set; }
        //Type of Expense (Fixed, Variable, etc..)
        [Required(ErrorMessage = "Please select an expense type.")]
        public string ExpenseType { get; set; }
        //Date of Expense
        [Required(ErrorMessage = "Please select a date.")]
        public DateTime Date { get; set; }
    }
}
