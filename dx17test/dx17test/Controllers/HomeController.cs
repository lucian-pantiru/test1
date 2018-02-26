using DevExpress.Web.Mvc;
using dx17test.EFModels;
using dx17test.Helpers;
using dx17test.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace dx17test.Controllers
{
    public class HomeController : Controller
    {
        #region reading
        public ActionResult Index()
        {
            AppointmentDialogViewModel vm = new AppointmentDialogViewModel();
            vm.Appointments = SchedulerDataHelper.GetAppointments();
            vm.Resources = SchedulerDataHelper.GetResources();
            vm.Patients = SchedulerDataHelper.GetPatients();
            return View(vm);
        }

        public ActionResult SchedulerPartial()
        {
            AppointmentDialogViewModel vm = new AppointmentDialogViewModel();
            vm.Appointments = SchedulerDataHelper.GetAppointments();
            vm.Resources = SchedulerDataHelper.GetResources();
            vm.Patients = SchedulerDataHelper.GetPatients();
            return PartialView("SchedulerPartial", vm);
        }

        public ActionResult GridViewPart()
        {
            AppointmentDialogViewModel vm = new AppointmentDialogViewModel();
            vm.Appointments = SchedulerDataHelper.GetAppointments();
            vm.Resources = SchedulerDataHelper.GetResources();
            vm.Patients = SchedulerDataHelper.GetPatients();
            return PartialView("GridViewPartial", vm);
        }


        #endregion

        #region editing

        public ActionResult EditAppointment()
        {
            UpdateAppointment();
            AppointmentDialogViewModel vm = new AppointmentDialogViewModel();
            vm.Appointments = SchedulerDataHelper.GetAppointments();
            vm.Resources = SchedulerDataHelper.GetResources();
            vm.Patients = SchedulerDataHelper.GetPatients();
            return PartialView("SchedulerPartial", vm);
        }

        static void UpdateAppointment()
        {
            AppointmentDialogViewModel[] insertedAppts = SchedulerExtension.GetAppointmentsToInsert<AppointmentDialogViewModel>(SchedulerSettingsHelper.GetSchedulerSettings(null, SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources(), SchedulerDataHelper.GetPatients()),
                SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources());
            foreach (var appt in insertedAppts)
            {
                SchedulerDataHelper.InsertAppointment(appt);
            }

            AppointmentDialogViewModel[] updatedAppt = SchedulerExtension.GetAppointmentsToUpdate<AppointmentDialogViewModel>(SchedulerSettingsHelper.GetSchedulerSettings(null, SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources(), SchedulerDataHelper.GetPatients()),
                SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources());
            foreach (var appt in updatedAppt)
            {
                SchedulerDataHelper.UpdateAppointment(appt);
            }

            AppointmentDialogViewModel[] removedAppt = SchedulerExtension.GetAppointmentsToRemove<AppointmentDialogViewModel>(SchedulerSettingsHelper.GetSchedulerSettings(null, SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources(), SchedulerDataHelper.GetPatients()),
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