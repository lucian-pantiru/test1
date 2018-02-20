using DevExpress.Web;
using DevExpress.Web.ASPxScheduler.Dialogs;
using DevExpress.Web.ASPxScheduler.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevExpressMvcApplication1.Models
{
    public class CustomAppointmentEditDialogViewModel : AppointmentEditDialogViewModel
    {
        [DialogFieldViewSettings(Caption = "Company", EditorType = DialogFieldEditorType.ComboBox)]
        public int AppointmentCompany { get; set; }

        [DialogFieldViewSettings(Caption = "Contact", EditorType = DialogFieldEditorType.ComboBox)]
        public int AppointmentContact { get; set; }

        public override void Load(AppointmentFormController appointmentController)
        {
            base.Load(appointmentController);

            // subject will be a combobox instead of plain textbox
            SetEditorTypeFor(m => m.Subject, DialogFieldEditorType.ComboBox);
            // add the 3 selectitems
            SetDataItemsFor(m => m.Subject, (addItemDelegate) => {
                addItemDelegate("meeting", "meeting");
                addItemDelegate("travel", "travel");
                addItemDelegate("phone call", "phonecall");
            });

            // retrieve the companies
            List<Company> companies = Company.GenerateCompanyDataSource();
            // add the selectitems for AppointmentCompany combobox
            SetDataItemsFor((CustomAppointmentEditDialogViewModel m) => m.AppointmentCompany, (addItemDelegate) => {
                foreach (Company comp in companies)
                {
                    addItemDelegate(comp.CompanyName, comp.CompanyID);
                }
            });

            // retrieve the contacts
            SetDataItemsFor((CustomAppointmentEditDialogViewModel m) => m.AppointmentContact, (addItemDelegate) => {
                // retrieve contacts for the selected AppointmentCompany
                List<CompanyContact> contacts = CompanyContact.GenerateContactDataSource().Where(c => c.CompanyID == AppointmentCompany).ToList();
                // add the empty selectitem
                addItemDelegate("", 0);
                // populate with contacts for selected company
                foreach (CompanyContact cont in contacts)
                {
                    addItemDelegate(cont.ContactName, cont.ContactID);
                }
            });

            // i think that when another AppointmentCompany is selected, the AppointmentContact will become 0 (some further logic will make the contact hidden when it's 0)
            TrackPropertyChangeFor((CustomAppointmentEditDialogViewModel m) => m.AppointmentCompany, () => {
                AppointmentContact = 0;
            });

            // when subject is changed, what is happening? i don't understand why this is needed
            TrackPropertyChangeFor(m => m.Subject, () => { });
        }

        public override void SetDialogElementStateConditions()
        {
            base.SetDialogElementStateConditions();
            SetItemVisibilityCondition("Location", false);
            SetItemVisibilityCondition(vm => vm.IsAllDay, false);
            SetItemVisibilityCondition(vm => vm.Reminder, false);
            SetEditorEnabledCondition((CustomAppointmentEditDialogViewModel vm) => vm.AppointmentContact, AppointmentCompany > 0);
            SetItemVisibilityCondition((CustomAppointmentEditDialogViewModel vm) => vm.AppointmentContact, Subject == "phonecall");
            SetItemVisibilityCondition((CustomAppointmentEditDialogViewModel vm) => vm.AppointmentCompany, Subject == "phonecall");
        }
    }
}