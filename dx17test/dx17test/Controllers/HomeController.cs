using dx17test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dx17test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(SchedulerDataHelper.DataObject);
        }

        public ActionResult SchedulerPartial()
        {
            return PartialView("SchedulerPartial", SchedulerDataHelper.DataObject);
        }
    }
}

public enum HeaderViewRenderMode { Full, Title }