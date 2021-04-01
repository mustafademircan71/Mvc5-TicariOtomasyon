using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicari_Otomasyon
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
