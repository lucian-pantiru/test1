﻿using DevExpress.Web;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.Mvc;
using DevExpress.XtraScheduler;
using dx17test.EFModels;
using dx17test.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;

namespace dx17test.Helpers
{
    public static class SchedulerSettingsHelper
    {
        //static SchedulerSettings commonSchedulerSettings;
        //public static SchedulerSettings CommonSchedulerSettings
        //{
        //    get
        //    {
        //        if (commonSchedulerSettings == null)
        //            commonSchedulerSettings = CreateSchedulerSettings();
        //        return commonSchedulerSettings;
        //    }
        //}

        //public static SchedulerSettings GetSchedulerSettings()
        //{
        //    return GetSchedulerSettings(null);
        //}

        public static AppointmentRecurrenceFormSettings CreateAppointmentRecurrenceFormSettings(DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer container) {
            return new AppointmentRecurrenceFormSettings()
            {
                Name = "appointmentRecurrenceForm",
                Width = System.Web.UI.WebControls.Unit.Percentage(100),
                IsRecurring = container.Appointment.IsRecurring,
                DayNumber = container.RecurrenceDayNumber,
                End = container.RecurrenceEnd,
                Month = container.RecurrenceMonth,
                OccurrenceCount = container.RecurrenceOccurrenceCount,
                Periodicity = container.RecurrencePeriodicity,
                RecurrenceRange = container.RecurrenceRange,
                Start = container.Start,
                WeekDays = container.RecurrenceWeekDays,
                WeekOfMonth = container.RecurrenceWeekOfMonth,
                RecurrenceType = container.RecurrenceType,
                IsFormRecreated = container.IsFormRecreated
            };
        }

        public static SchedulerSettings GetSchedulerSettings(this System.Web.Mvc.HtmlHelper customHtml, IEnumerable<DBAppointment> appts, IEnumerable<DBResource> resources, IEnumerable<Patient> patients)
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

            settings.AppointmentFormShowing = PrepareAppointmentPopup;

            settings.OptionsForms.RecurrenceFormName = "appointmentRecurrenceForm";

            settings.OptionsForms.SetAppointmentFormTemplateContent(c => {
                var container = (CustomAppointmentTemplateContainer)c;
                AppointmentDialogViewModel modelAppointment = new AppointmentDialogViewModel()
                {
                    UniqueId = container.Appointment.Id == null ? -1 : (int)container.Appointment.Id,
                    Subjject = container.Appointment.Subject,
                    Location = container.Appointment.Location,
                    StartDate = container.Appointment.Start,
                    EndDate = container.Appointment.End,
                    AllDay = container.Appointment.AllDay,
                    Description = container.Appointment.Description,
                    Type = (int)container.Appointment.Type,
                    Status = container.Appointment.StatusId,
                    Label = container.Appointment.LabelId,
                    Patients = patients,
                    Resources = resources,
                    Appointments = appts
                    //OwnerId = Convert.ToInt32(container.Appointment.ResourceId)
                    //RecurrenceInfo = container.Appointment.RecurrenceInfo.ToXml(),
                    //RecurrenceXmlInfo = container.Appointment.RecurrenceInfo.ToXml()
                };

                customHtml.ViewBag.DeleteButtonEnabled = container.CanDeleteAppointment;

                (container.ResourceDataSource as ListEditItemCollection).RemoveAt(0);
                customHtml.ViewBag.ResourceDataSource = container.ResourceDataSource;
                customHtml.ViewBag.StatusDataSource = container.StatusDataSource;
                customHtml.ViewBag.LabelDataSource = container.LabelDataSource;
                customHtml.ViewBag.ReminderDataSource = container.ReminderDataSource;
                customHtml.ViewBag.AppointmentRecurrenceFormSettings = CreateAppointmentRecurrenceFormSettings(container);
                System.Web.Mvc.Html.RenderPartialExtensions.RenderPartial(customHtml, "CustomAppointmentFormPartial", modelAppointment);
            });

            //customized text inside description field in appointment form
            settings.OptionsForms.DialogLayoutSettings.AppointmentDialog.ViewModel.PrepareControlFor(m => m.Description, (ASPxMemo me) =>
            {
                me.ForeColor = Color.Blue;
                me.Font.Bold = true;
                me.Font.Italic = true;
            });

            return settings;
        }

        private static void PrepareAppointmentPopup(object sender, AppointmentFormEventArgs e)
        {
            if (sender != null)
                e.Container = (new CustomAppointmentTemplateContainer(sender as MVCxScheduler));
        }
    }
}