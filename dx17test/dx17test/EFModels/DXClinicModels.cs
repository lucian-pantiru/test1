namespace dx17test.EFModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DXClinicModels : DbContext
    {
        public DXClinicModels()
            : base("name=DXClinicModels1")
        {
        }

        public virtual DbSet<DBAppointment> DBAppointments { get; set; }
        public virtual DbSet<DBResource> DBResources { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Practice> Practices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
