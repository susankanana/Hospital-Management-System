using Hospital_Management_System.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OK5OBQR;Database=HospMgt_System;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many-to-many
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.patients)
                .WithMany(p => p.doctors)
                .UsingEntity(b => b.ToTable("Appointment"));

            ////one-to-many
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Room>()
            //    .HasMany(r => r.patients)
            //    .WithOne(p => p.room)
            //    .HasForeignKey(p => p.RoomID);

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
