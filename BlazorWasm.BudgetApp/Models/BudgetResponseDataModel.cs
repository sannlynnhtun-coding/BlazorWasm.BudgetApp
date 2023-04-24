namespace BlazorWasm.BudgetApp.Models
{
    public class BudgetResponseDataModel : PaginationResponseDataModel
    {
        public List<BudgetDataModel> lstBudget { get; set; }
    }

    public class PaginationResponseDataModel
    {
        public int TotalRowCount { get; set; }
        public int RowCount { get; set; }
        public int TotalPageNo { get; set; }
        public int CurrentPageNo { get; set; }
    }
}
