using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Hospital.Infrastructure.EfCore;

/// <summary>
/// EF Core database context for domain
/// </summary>
public class HospitalDbContext(DbContextOptions options) : DbContext(options)
{
    /// <summary>
    /// Appointments in the database
    /// </summary>
    public DbSet<Appointment> Appointments { get; set; }

    /// <summary>
    /// Doctors in the database
    /// </summary>
    public DbSet<Doctor> Doctors { get; set; }

    /// <summary>
    /// Patients in the database
    /// </summary>
    public DbSet<Patient> Patients { get; set; }

    /// <summary>
    /// Specializations in the database
    /// </summary>
    public DbSet<Specialization> Specializations { get; set; }

    /// <summary>
    /// Configures entity relationships, keys
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure entities</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

        modelBuilder.Entity<Appointment>(builder =>
        {
            builder.ToCollection("appointments");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasElementName("_id");

            builder.Property(b => b.DateAndTime)
                .IsRequired()
                .HasElementName("date_and_time");

            builder.Property(b => b.NumberOfOffice)
                .IsRequired()
                .HasElementName("number_of_office");

            builder.Property(b => b.IsRepeated)
                .IsRequired()
                .HasElementName("is_repeated");

            builder.Property(b => b.PatientId)
                .IsRequired()
                .HasElementName("patient_id");

            builder.Property(b => b.DoctorId)
                .IsRequired()
                .HasElementName("doctor_id");
        });

        modelBuilder.Entity<Doctor>(builder =>
        {
            builder.ToCollection("doctors");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasElementName("_id");

            builder.Property(b => b.PassportId)
                .IsRequired()
                .HasMaxLength(32)
                .HasElementName("passport_id");

            builder.Property(b => b.FullName)
                .IsRequired()
                .HasMaxLength(200)
                .HasElementName("full_name");

            builder.Property(b => b.DateOfBirth)
                .IsRequired()
                .HasElementName("date_of_birth");

            builder.Property(b => b.WorkExperience)
                .IsRequired()
                .HasElementName("work_experience");

            builder.Property(b => b.SpecializationId)
                .IsRequired()
                .HasElementName("specialization_id");
        });

        modelBuilder.Entity<Patient>(builder =>
        {
            builder.ToCollection("patients");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasElementName("_id");

            builder.Property(b => b.PassportId)
                .IsRequired()
                .HasMaxLength(32)
                .HasElementName("passport_id");

            builder.Property(b => b.FullName)
                .IsRequired()
                .HasMaxLength(200)
                .HasElementName("full_name");

            builder.Property(b => b.DateOfBirth)
                .IsRequired()
                .HasElementName("date_of_birth");

            builder.Property(b => b.Gender)
                .HasConversion<string>()
                .HasElementName("gender");

            builder.Property(b => b.Address)
                .HasMaxLength(300)
                .HasElementName("address");

            builder.Property(b => b.BloodGroup)
                .IsRequired()
                .HasConversion<string>()
                .HasElementName("blood_group");

            builder.Property(b => b.RhesusFactor)
                .IsRequired()
                .HasConversion<string>()
                .HasElementName("rhesus_factor");

            builder.Property(b => b.PhoneNumber)
                .HasMaxLength(32)
                .HasElementName("phone_number");
        });

        modelBuilder.Entity<Specialization>(builder =>
        {
            builder.ToCollection("specializations");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasElementName("_id");

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasElementName("name");
        });
    }
}