using BlazorWasm.BudgetApp.Models;

namespace BlazorWasm.BudgetApp.Services
{
    public interface IDbService
    {
        Task SetUserName(string userName);
        Task<string> GetUserName();
        Task<List<BudgetDataModel>> GetBudgetList();
        Task<List<BudgetCategoryDataModel>> GetBudgetCategory();
        Task AddBudget(BudgetDataModel budget);
        Task<List<BudgetExpenseDataModel>> GetExpenseList(Guid guid);
        Task<BudgetExpenseResponseDataModel> BudgetExpensePagination(int pageNo, int pageSize);
        Task<BudgetResponseDataModel> BudgetPagination(int pageNo, int pageSize);
    }
}