﻿using System.Web;
using System.Web.Mvc;

namespace BlackSwan.Accounting.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
