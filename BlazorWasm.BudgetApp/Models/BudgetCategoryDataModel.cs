namespace BlazorWasm.BudgetApp.Models
{
    public class BudgetCategoryDataModel
    {
        public Guid? BudgetId { get; set; } = Guid.NewGuid();
        public string BudgetName { get; set; }
    }
}
