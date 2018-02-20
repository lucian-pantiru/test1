using DevExpress.Web;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.Mvc;
using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace dx17test.Helpers
{
    public class SchedulerSettingsHelper
    {
        static SchedulerSettings commonSchedulerSettings;
        public static SchedulerSettings CommonSchedulerSettings
        {
            get
            {
                if (commonSchedulerSettings == null)
                    commonSchedulerSettings = CreateSchedulerSettings();
                return commonSchedulerSettings;
            }
        }
        static SchedulerSettings CreateSchedulerSettings()
        {
            SchedulerSettings settings = new SchedulerSettings();
            settings.Name = "scheduler";
            settings.CallbackRouteValues = new { Controller = "Home", Action = "SchedulerPartial" };
            settings.EditAppointmentRouteValues = new { Controller = "Home", Action = "EditAppointment" };

            settings.Storage.Appointments.Assign(SchedulerStorageProvider.DefaultAppointmentStorage);
            settings.Storage.Resources.Assign(SchedulerStorageProvider.DefaultResourceStorage);

            settings.Views.WeekView.Styles.DateCellBody.Height = 50;
            settings.Views.MonthView.CellAutoHeightOptions.Mode = AutoHeightMode.FitToContent;
            settings.Views.MonthView.AppointmentDisplayOptions.AppointmentAutoHeight = true;
            settings.Views.MonthView.AppointmentDisplayOptions.TimeDisplayType = AppointmentTimeDisplayType.Clock;
            settings.Views.DayView.ShowWorkTimeOnly = true;
            settings.Views.DayView.DayCount = 2;
            settings.ActiveViewType = SchedulerViewType.Day;

            //customized text inside description field in appointment form
            settings.OptionsForms.DialogLayoutSettings.AppointmentDialog.ViewModel.PrepareControlFor(m => m.Description, (ASPxMemo me) => {
                me.ForeColor = Color.Blue;
                me.Font.Bold = true;
                me.Font.Italic = true;
            });

            return settings;
        }
    }
}