using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dx17test.Helpers
{
    public class SchedulerDataObject
    {
        public System.Collections.IEnumerable Appointments { get; set; }
        public System.Collections.IEnumerable Resources { get; set; }
        public System.Collections.IEnumerable Patients { get; set; }
    }
}