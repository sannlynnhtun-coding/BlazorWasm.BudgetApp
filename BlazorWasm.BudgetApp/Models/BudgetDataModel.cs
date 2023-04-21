namespace BlazorWasm.BudgetApp.Models
{
    public class BudgetDataModel
    {
        public Guid BudgetId { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public string BudgetName { get; set; }
        public int Budget { get; set; }
        public DateTime BudgetCreationDate { get; set; }
    }
}
