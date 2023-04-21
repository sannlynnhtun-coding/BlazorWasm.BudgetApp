using Blazored.LocalStorage;
using BlazorWasm.BudgetApp.Models;
using System.Collections.Generic;

namespace BlazorWasm.BudgetApp.Services
{
    public class LocalStorageService : IDbService
    {
        private readonly ILocalStorageService localStorage;

        public LocalStorageService(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public async Task SetUserName(string userName)
        {
            await localStorage.SetItemAsync<string>("UserName", userName);
        }

        public async Task<string> GetUserName()
        {
            return await localStorage.GetItemAsync<string>("UserName");
        }

        public async Task<List<BudgetDataModel>> GetBudgetList()
        {
            var lst = await localStorage.GetItemAsync<List<BudgetDataModel>>("Tbl_Budget");
            lst ??= new();
            return lst;
        }
        public async Task<List<BudgetCategoryDataModel>> GetBudgetCategory()
        {
            var lst = await GetBudgetList();
            var lstBudgetCategory = lst.Select(x => new BudgetCategoryDataModel
            {
                BudgetId = x.BudgetId,
                BudgetName = x.BudgetName
            }).ToList();
            lstBudgetCategory.Insert(0, new BudgetCategoryDataModel
            {
                BudgetId = null,
                BudgetName = "--Select One--"
            });
            return lstBudgetCategory;
        }
    }
}
