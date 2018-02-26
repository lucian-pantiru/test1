namespace dx17test.EFModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DXClinicModels : DbContext
    {
        public DXClinicModels()
            : base("name=DXClinicModels2")
        {
        }

        public virtual DbSet<DBAppointment> DBAppointments { get; set; }
        public virtual DbSet<DBResource> DBResources { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Practice> Practices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DBAppointment>()
                .Property(e => e.SelectedPatientsIDs)
                .IsUnicode(false);

            modelBuilder.Entity<DBAppointment>()
                .HasMany(e => e.Patients)
                .WithMany(e => e.DBAppointments)
                .Map(m => m.ToTable("DBAppointments_Patients").MapLeftKey("DBAppointmentId").MapRightKey("PatientId"));
        }
    }
}
