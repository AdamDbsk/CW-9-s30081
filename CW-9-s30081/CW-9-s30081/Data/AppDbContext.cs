using CW_9_s30081.Model;
using Microsoft.EntityFrameworkCore;

namespace CW_9_s30081.Data {
    public class AppDbContext : DbContext{
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) {
        }

    }
}
