using dx17test.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dx17test.Helpers
{
    public class AppointmentDataAccessor
    {
        public static void InsertAppointment(DBAppointment appt)
        {
            if (appt == null)
                return;
            DXClinicModels db = new DXClinicModels();
            db.DBAppointments.Add(appt);
            db.SaveChanges();
        }
        public static void UpdateAppointment(DBAppointment appt)
        {
            if (appt == null)
                return;
            DXClinicModels db = new DXClinicModels();
            DBAppointment query = (DBAppointment)(from carSchedule
                                                      in db.DBAppointments
                                                  where carSchedule.UniqueID == appt.UniqueID
                                                  select carSchedule).SingleOrDefault();

            //query.UniqueID = appt.UniqueID;
            query.StartDate = appt.StartDate;
            query.EndDate = appt.EndDate;
            query.AllDay = appt.AllDay;
            query.Subject = appt.Subject;
            query.Description = appt.Description;
            query.Location = appt.Location;
            query.RecurrenceInfo = appt.RecurrenceInfo;
            query.ReminderInfo = appt.ReminderInfo;
            query.Status = appt.Status;
            query.Type = appt.Type;
            query.Label = appt.Label;
            query.ResourceID = appt.ResourceID;
            db.SaveChanges();
        }
        public static void RemoveAppointment(DBAppointment appt)
        {
            DXClinicModels db = new DXClinicModels();
            DBAppointment query = (DBAppointment)(from carSchedule
                                                      in db.DBAppointments
                                                  where carSchedule.UniqueID == appt.UniqueID
                                                  select carSchedule).SingleOrDefault();
            db.DBAppointments.Remove(query);
            db.SaveChanges();
        }
    }
}