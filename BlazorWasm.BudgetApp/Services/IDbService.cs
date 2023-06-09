﻿using BlazorWasm.BudgetApp.Models;

namespace BlazorWasm.BudgetApp.Services
{
    public interface IDbService
    {
        Task SetUserName(string userName);
        Task<string> GetUserName();
        Task<List<BudgetDataModel>> GetBudgetList();
        Task<List<BudgetCategoryDataModel>> GetBudgetCategory();
        Task AddBudget(BudgetDataModel budget);
        Task<BudgetExpenseResponseDataModel> BudgetExpensePagination(int pageNo, int pageSize);
        Task<BudgetResponseDataModel> BudgetPagination(int pageNo, int pageSize);
        Task<BudgetDataModel> GetBudget(string guid);
        Task DeleteExpense(Guid expenseId);
        Task DeleteBudget(Guid budgetId);
        Task<List<BudgetExpenseDataModel>> GetExpenseList(Guid? budgetId = null);
        Task<BudgetExpenseResponseDataModel> GetRecentExpenses();
    }
}