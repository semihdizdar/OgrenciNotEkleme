using System.Web;
using System.Web.Mvc;
using Elmah;

namespace OgrenciNotMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public class ElmahHandledErrorLoggerFilter : System.Web.Mvc.IExceptionFilter
        {
            public void OnException(ExceptionContext context)
            {
                if (context.ExceptionHandled)
                    ErrorSignal.FromCurrentContext().Raise(context.Exception);
            }
        }
    }
}
