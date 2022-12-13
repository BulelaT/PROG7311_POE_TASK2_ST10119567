using System.Web;
using System.Web.Mvc;

namespace PROG7311_POE_TASK2_ST10119567
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
