namespace BlazorWasm.BudgetApp.Services
{
    public class UserInfoState
    {
        public string UserName { get; set; }
        public bool IsExist { get { return !UserName.IsNullOrEmpty(); } }
    }
}
