using AssignmentExcelbd.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssignmentExcelbd.Backend.Data
{
    public class ApplicationDbContext:  DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<PatientInfo> PatientInfos { get; set; }
        public DbSet<DiseasesInfo> Diseases { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<NCD> NCDs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PatientInfo>()
                .HasMany(p => p.NCD_Details)
                .WithOne(nd => nd.Patient)
                .HasForeignKey(nd => nd.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PatientInfo>()
                .HasMany(p => p.Allergies_Details)
                .WithOne(ad => ad.Patient)
                .HasForeignKey(ad => ad.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
