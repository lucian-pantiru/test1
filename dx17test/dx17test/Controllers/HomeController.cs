using DevExpress.Web.Mvc;
using dx17test.EFModels;
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
        #region reading
        public ActionResult Index()
        {
            return View(SchedulerDataHelper.DataObject);
        }

        public ActionResult SchedulerPartial()
        {
            return PartialView("SchedulerPartial", SchedulerDataHelper.DataObject);
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
            DBAppointment[] insertedAppointments = SchedulerExtension.GetAppointmentsToInsert<DBAppointment>("scheduler", SchedulerDataHelper.GetAppointments(),
                SchedulerDataHelper.GetResources(), SchedulerStorageProvider.DefaultAppointmentStorage, SchedulerStorageProvider.DefaultResourceStorage);
            foreach (var appt in insertedAppointments)
            {
                AppointmentDataAccessor.InsertAppointment(appt);
            }

            DBAppointment[] updatedAppointments = SchedulerExtension.GetAppointmentsToUpdate<DBAppointment>("scheduler", SchedulerDataHelper.GetAppointments(),
                SchedulerDataHelper.GetResources(), SchedulerStorageProvider.DefaultAppointmentStorage, SchedulerStorageProvider.DefaultResourceStorage);
            foreach (var appt in updatedAppointments)
            {
                AppointmentDataAccessor.UpdateAppointment(appt);
            }

            DBAppointment[] removedAppointments = SchedulerExtension.GetAppointmentsToRemove<DBAppointment>("scheduler", SchedulerDataHelper.GetAppointments(),
                SchedulerDataHelper.GetResources(), SchedulerStorageProvider.DefaultAppointmentStorage, SchedulerStorageProvider.DefaultResourceStorage);
            foreach (var appt in removedAppointments)
            {
                AppointmentDataAccessor.RemoveAppointment(appt);
            }
        }

        #endregion
    }
}

public enum HeaderViewRenderMode { Full, Title }