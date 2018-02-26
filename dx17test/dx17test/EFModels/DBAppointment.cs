namespace dx17test.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DBAppointment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DBAppointment()
        {
            Patients = new HashSet<Patient>();
        }

        [Key]
        public int UniqueID { get; set; }

        public int? Type { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? EndDate { get; set; }

        public bool? AllDay { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public int? Status { get; set; }

        public int? Label { get; set; }

        public int? ResourceID { get; set; }

        [Column(TypeName = "ntext")]
        public string ReminderInfo { get; set; }

        [Column(TypeName = "ntext")]
        public string RecurrenceInfo { get; set; }

        [Column(TypeName = "ntext")]
        public string CustomField1 { get; set; }

        public string RecurrenceXmlInfo { get; set; }

        [StringLength(50)]
        public string SelectedPatientsIDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
