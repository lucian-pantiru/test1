using dx17test.EFModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dx17test.ViewModels
{
    public class AppointmentDialogViewModel
    {
        public AppointmentDialogViewModel() { }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Subjject { get; set; }

        public int Status { get; set; }
        public string Description { get; set; }
        public int Label { get; set; }
        public string Location { get; set; }
        public bool AllDay { get; set; }
        public int Type { get; set; }
        public string RecurrenceInfo { get; set; }
        public string ReminderInfo { get; set; }
        public string RecurrenceXmlInfo { get; set; }

        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<DBAppointment> Appointments { get; set; }
        public IEnumerable<DBResource> Resources { get; set; }
        public string SelectedPatientsIDs { get; set; }

        [Required]
        [Display(Name = "Resource")]
        public int OwnerId { get; set; }
        public string CustomInfo { get; set; }
        public int UniqueId { get; set; }
    }
}