namespace BlazorWasm.BudgetApp.Models
{
    public class BudgetResponseDataModel
    {
        public List<BudgetDataModel> lstBudget { get; set; }
        public int TotalRowCount { get; set; }
        public int RowCount { get; set; }
        public int TotalPageNo { get; set; }
        public int CurrentPageNo { get; set; }
    }
}
