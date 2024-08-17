namespace MicroTech.Data.AppMetaData
{
    public static class Router
    {
        public const string Root = "Api";
        public const string Version = "V1";
        public const string Rule = $"{Root}/{Version}/";

        //example
        //public static class StudentRouting
        //{
        //    public const string Prefix = $"{Rule}Student/";


        //    public const string List = $"{Prefix}List";
        //    public const string AddStudentToDepartment = $"{Prefix}Add-Student-To-Department";
        //    public const string GetById = $"{Prefix}" + "{id}";
        //    public const string Create = $"{Prefix}" + "Create";
        //    public const string Edit = $"{Prefix}" + "Edit";
        //    public const string Delete = $"{Prefix}" + "Delete/{id}";
        //    public const string Pagination = $"{Prefix}" + "Pagination";
        //}
        
        public static class AccountRouting
        {
            public const string Prefix = $"{Rule}Accounts/";
            public const string GetAllAccounts = $"{Prefix}GetAllAccounts";
            public const string GetAccuontDetalies = $"{Prefix}GetAccuontDetalies";
        }
    }
}
