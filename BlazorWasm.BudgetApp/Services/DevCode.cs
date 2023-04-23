namespace BlazorWasm.BudgetApp
{
    public static class DevCode
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return str == null || string.IsNullOrEmpty(str.Trim());
        }

        public static List<T> ToPage<T>(this List<T> lst, int pageNo, int pageSize)
        {
            int skipRowCount = (pageNo - 1) * pageSize;
            return lst.Skip(skipRowCount).Take(pageSize).ToList();
        }
    }
}
