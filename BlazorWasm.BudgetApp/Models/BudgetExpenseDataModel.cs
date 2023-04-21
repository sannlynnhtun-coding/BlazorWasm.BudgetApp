namespace BlazorWasm.BudgetApp.Models
{
    public class BudgetExpenseDataModel
    {
        public Guid ExpenseId { get; set; } = Guid.NewGuid();
        public Guid BudgetId { get; set; }
        public string ExpenseName { get; set; }
        public int Amount { get; set; }
        public DateTime ExpenseDateTime { get; set; } = DateTime.Now;
    }
}
