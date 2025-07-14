using HIVMedicalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories;

public class AppDbContext: DbContext
{
    public AppDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
    }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        return configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Degree> Degrees { get; set; }
    public DbSet<DegreeType> DegreeTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Users table
        modelBuilder.Entity<User>()
            .HasOne(entity => entity.Role)
            .WithMany(role => role.Users)
            .HasForeignKey(entity => entity.RoleId);
        //Degree Table
        modelBuilder.Entity<Degree>() 
            .HasOne(entity => entity.User)
            .WithMany(user => user.Degrees)
            .HasForeignKey(entity => entity.UserId);
        modelBuilder.Entity<Degree>() 
            .HasOne(entity => entity.DegreeType)
            .WithMany(entity =>  entity.Degrees)
            .HasForeignKey(entity => entity.DegreeTypeId);
        //Test Result
        modelBuilder.Entity<TestResult>()
            .HasOne(entity => entity.User)
            .WithMany(user => user.TestResults)
            .HasForeignKey(entity => entity.UserId);
        //ARVMedicalRecords
        modelBuilder.Entity<ARVMedicalRecord>()
            .HasOne(entity => entity.MedicalRecord)
            .WithMany(entity => entity.ARVMedicalRecords)
            .HasForeignKey(entity => entity.RecordId);
        modelBuilder.Entity<ARVMedicalRecord>()
            .HasOne(entity => entity.ARVProtocol)
            .WithMany(entity => entity.ArvMedicalRecords)
            .HasForeignKey(entity => entity.ARVProtocolId);
        //Medical record
        modelBuilder.Entity<MedicalRecord>()
            .HasOne(entity => entity.Doctor)
            .WithMany(entity => entity.MedicalRecordsHandled)
            .HasForeignKey(entity => entity.DoctorId);
        modelBuilder.Entity<MedicalRecord>()
            .HasOne(entity => entity.Customer)
            .WithMany(entity => entity.MedicalRecordHistory)
            .HasForeignKey(entity => entity.CustomerId);
        
    }
}