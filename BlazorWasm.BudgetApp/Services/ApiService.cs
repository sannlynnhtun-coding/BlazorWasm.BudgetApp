using BlazorWasm.BudgetApp.Models;
using Blazored.LocalStorage;

namespace BlazorWasm.BudgetApp.Services
{
    public class ApiService : IDbService
    {
        private readonly ILocalStorageService _localStorageService;

        public ApiService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public Task AddBudget(BudgetDataModel budget)
        {
            throw new NotImplementedException();
        }

        public Task<BudgetExpenseResponseDataModel> BudgetExpensePagination(int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<BudgetResponseDataModel> BudgetPagination(int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<BudgetDataModel> GetBudget(string guid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BudgetCategoryDataModel>> GetBudgetCategory()
        {
            var result = await _localStorageService.GetItemAsync<List<BudgetDataModel>>("Tbl_Budget");
            List<BudgetCategoryDataModel> lst = result.Select(x => new BudgetCategoryDataModel
            {
                BudgetId = x.BudgetId,
                BudgetName = x.BudgetName
            }).ToList();
            return lst;
        }

        public async Task<List<BudgetDataModel>> GetBudgetList()
        {
            return await _localStorageService.GetItemAsync<List<BudgetDataModel>>("Tbl_Budget");
        }

        public Task<List<BudgetExpenseDataModel>> GetExpenseList(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetUserName()
        {
            var userName = await _localStorageService.GetItemAsync<string>("UserName");
            return userName;
        }

        public async Task SetUserName(string userName)
        {
            await _localStorageService.SetItemAsStringAsync("UserName", userName);
        }
    }
}
