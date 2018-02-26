using dx17test.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dx17test.Helpers
{
    public class SchedulerDataHelper
    {
        #region read
        public static System.Collections.IEnumerable GetResources()
        {
            DXClinicModels db = new DXClinicModels();
            return (from res in db.DBResources select res).ToList();
        }
        public static System.Collections.IEnumerable GetAppointments()
        {
            DXClinicModels db = new DXClinicModels();
            return (from apt in db.DBAppointments select apt).ToList();
        }
        public static System.Collections.IEnumerable GetPatients()
        {
            DXClinicModels db = new DXClinicModels();
            return (from patient in db.Patients select patient).ToList();
        }
        public static SchedulerDataObject DataObject
        {
            get
            {
                return new SchedulerDataObject()
                {
                    Appointments = GetAppointments(),
                    Resources = GetResources(),
                    Patients = GetPatients()
                };
            }
        }
        #endregion

        #region edit
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
        #endregion
    }
}