namespace BlazorWasm.BudgetApp.Models
{
    public class BudgetExpenseResponseDataModel
    {
        public List<BudgetExpenseDataModel> lstExpense { get; set; }
        public int TotalRowCount { get; set; }
        public int RowCount { get; set; }
        public int TotalPageNo { get; set; }
        public int CurrentPageNo { get; set; }
    }
}
