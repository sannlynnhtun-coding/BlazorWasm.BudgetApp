using Blazored.LocalStorage;
using BlazorWasm.BudgetApp.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Transactions;

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

        public async Task<BudgetDataModel> GetBudget(string guid)
        {
            var lst = await localStorage.GetItemAsync<List<BudgetDataModel>>("Tbl_Budget");
            lst ??= new();
            return lst.FirstOrDefault(x=> x.BudgetId == new Guid(guid));
        }

        public async Task<List<BudgetExpenseDataModel>> GetExpenseList(Guid guid)
        {
            var result = await localStorage.GetItemAsync<List<BudgetExpenseDataModel>>("Tbl_Expense");
            result ??= new();
            var lst = result.Where(x => x.BudgetId == guid).ToList();
            lst ??= new();
            return lst;
        }

        public async Task<List<BudgetCategoryDataModel>> GetBudgetCategory()
        {
            var lst = await GetBudgetList();
            lst ??= new List<BudgetDataModel>();
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

        public async Task AddBudget(BudgetDataModel budget)
        {
            List<BudgetDataModel> lst = await localStorage.GetItemAsync<List<BudgetDataModel>>("Tbl_Budget");
            lst ??= new();
            budget.UserId = await GetUserName();
            budget.BudgetCreationDate = DateTime.Now;
            lst.Add(budget);
            await localStorage.SetItemAsync("Tbl_Budget", lst);
        }

        public async Task<BudgetExpenseResponseDataModel> BudgetExpensePagination(int pageNo, int pageSize)
        {
            var lst = await localStorage.GetItemAsync<List<BudgetExpenseDataModel>>("Tbl_Expense");
            var count = lst.Count;
            int totalPageNo = count / pageSize;
            int result = count % pageSize;
            if (result > 0)
                totalPageNo++;
            return new BudgetExpenseResponseDataModel
            {
                CurrentPageNo = pageNo,
                lstExpense = lst.ToPage(pageNo, pageSize),
                RowCount = pageSize,
                TotalPageNo = totalPageNo,
                TotalRowCount = count
            };
        }

        public async Task<BudgetResponseDataModel> BudgetPagination(int pageNo, int pageSize)
        {
            var lst = await localStorage.GetItemAsync<List<BudgetDataModel>>("Tbl_Budget");
            var count = lst.Count;
            int totalPageNo = count / pageSize;
            int result = count % pageSize;
            if (result > 0)
                totalPageNo++;
            return new BudgetResponseDataModel
            {
                CurrentPageNo = pageNo,
                lstBudget = lst.ToPage(pageNo, pageSize),
                RowCount = pageSize,
                TotalPageNo = totalPageNo,
                TotalRowCount = count
            };
        }
    }
}
