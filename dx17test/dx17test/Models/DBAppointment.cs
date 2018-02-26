using dx17test.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dx17test.EFModels
{
    public partial class DBAppointment
    {
        public DBAppointment(AppointmentDialogViewModel vm) : this()
        {
            AllDay = vm.AllDay;
            CustomField1 = null;
            Description = vm.Description;
            EndDate = vm.EndDate;
            Label = vm.Label;
            Location = vm.Location;
            Patients = vm.Patients.ToList<Patient>();
            RecurrenceInfo = vm.RecurrenceInfo;
            RecurrenceXmlInfo = vm.RecurrenceXmlInfo;
            ReminderInfo = vm.ReminderInfo;
            ResourceID = vm.OwnerId;
            //SelectedPatientsIDs=null;
            StartDate = vm.StartDate;
            Status = vm.Status;
            Subject = vm.Subjject;
            Type = vm.Type;
            UniqueID = vm.UniqueId;
        }
    }
}