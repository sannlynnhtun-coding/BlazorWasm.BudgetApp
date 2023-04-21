using BlazorWasm.BudgetApp.Models;

namespace BlazorWasm.BudgetApp.Services
{
    public interface IDbService
    {
        Task SetUserName(string userName);
        Task<string> GetUserName();
        Task<List<BudgetDataModel>> GetBudgetList();
        Task<List<BudgetCategoryDataModel>> GetBudgetCategory();
    }
}