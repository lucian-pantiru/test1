using DevExpress.Web.Mvc;
using dx17test.EFModels;
using dx17test.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dx17test.Controllers
{
    public class HomeController : Controller
    {
        #region reading
        public ActionResult Index()
        {
            return View(SchedulerDataHelper.DataObject);
        }

        public ActionResult SchedulerPartial()
        {
            return PartialView("SchedulerPartial", SchedulerDataHelper.DataObject);
        }

        public ActionResult GridViewPart()
        {
            return PartialView("GridViewPartial", SchedulerDataHelper.DataObject);
        }


        #endregion

        #region editing

        public ActionResult EditAppointment()
        {
            UpdateAppointment();
            return PartialView("SchedulerPartial", SchedulerDataHelper.DataObject);
        }

        static void UpdateAppointment()
        {
            DBAppointment[] insertedAppts = SchedulerExtension.GetAppointmentsToInsert<DBAppointment>(SchedulerSettingsHelper.GetSchedulerSettings(null, SchedulerDataHelper.DataObject),
                SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources());
            foreach (var appt in insertedAppts)
            {
                SchedulerDataHelper.InsertAppointment(appt);
            }

            DBAppointment[] updatedAppt = SchedulerExtension.GetAppointmentsToUpdate<DBAppointment>(SchedulerSettingsHelper.GetSchedulerSettings(null, SchedulerDataHelper.DataObject),
                SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources());
            foreach (var appt in updatedAppt)
            {
                SchedulerDataHelper.UpdateAppointment(appt);
            }

            DBAppointment[] removedAppt = SchedulerExtension.GetAppointmentsToRemove<DBAppointment>(SchedulerSettingsHelper.GetSchedulerSettings(null, SchedulerDataHelper.DataObject),
                SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources());
            foreach (var appt in removedAppt)
            {
                SchedulerDataHelper.RemoveAppointment(appt);
            }
        }

        #endregion
    }
}

public enum HeaderViewRenderMode { Full, Title }