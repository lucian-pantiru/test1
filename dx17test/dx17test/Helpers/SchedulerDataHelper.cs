using dx17test.EFModels;
using dx17test.OtherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dx17test.Helpers
{
    public class SchedulerDataHelper
    {
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
        public static SchedulerDataObject DataObject
        {
            get
            {
                return new SchedulerDataObject()
                {
                    Appointments = GetAppointments(),
                    Resources = GetResources()
                };
            }
        }
    }
}