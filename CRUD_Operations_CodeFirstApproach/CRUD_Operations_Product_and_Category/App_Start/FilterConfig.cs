using System.Web;
using System.Web.Mvc;

namespace CRUD_Operations_Product_and_Category
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
