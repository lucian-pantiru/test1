using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dx17test.Helpers
{
    public class CustomAppointmentTemplateContainer : AppointmentFormTemplateContainer
    {
        public CustomAppointmentTemplateContainer(MVCxScheduler sc):base(sc){

        }
        
    }
}