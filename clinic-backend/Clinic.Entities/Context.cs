using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Clinic.Entities.Models;

namespace Clinic.Entities;
public class Context : IdentityDbContext<User, UserRole, Guid>
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);

        builder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        builder.Entity<UserRole>().ToTable("user_roles");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");

        #endregion

        #region Doctors

        builder.Entity<Doctor>().ToTable("doctors");
        builder.Entity<Doctor>().HasKey(x => x.Id);

        #endregion

        #region Patient

        builder.Entity<Patient>().ToTable("patients");
        builder.Entity<Patient>().HasKey(x => x.Id);

        #endregion

        #region Specialities

        builder.Entity<Speciality>().ToTable("specialities");
        builder.Entity<Speciality>().HasKey(x => x.Id);
        builder.Entity<Speciality>().Property(x => x.ParentSpecialityId).IsRequired(false);
        builder.Entity<Speciality>().HasOne(x => x.ParentSpeciality)
                                    .WithMany(x => x.ChildrenSpecialities)
                                    .HasForeignKey(x => x.ParentSpecialityId)
                                    .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region DoctorSpeciality

        builder.Entity<DoctorSpeciality>().ToTable("doctors_specialities");
        builder.Entity<DoctorSpeciality>().HasKey(x => x.Id);
        builder.Entity<DoctorSpeciality>().HasOne(x => x.Doctor)
                                    .WithMany(x => x.Specialities)
                                    .HasForeignKey(x => x.DoctorId)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<DoctorSpeciality>().HasOne(x => x.Speciality)
                                    .WithMany(x => x.Doctors)
                                    .HasForeignKey(x => x.SpecialityId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Schedules

        builder.Entity<Schedule>().ToTable("schedules");
        builder.Entity<Schedule>().HasKey(x => x.Id);
        builder.Entity<Schedule>().HasOne(x => x.Doctor)
                                    .WithMany(x => x.Schedules)
                                    .HasForeignKey(x => x.DoctorId)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Schedule>().HasOne(x => x.Speciality)
                                    .WithMany(x => x.Schedules)
                                    .HasForeignKey(x => x.SpecialityId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Receptions

        builder.Entity<Reception>().ToTable("receptions");
        builder.Entity<Reception>().HasKey(x => x.Id);
        builder.Entity<Reception>().HasOne(x => x.Patient)
                                    .WithMany(x => x.Receptions)
                                    .HasForeignKey(x => x.PatientId)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Reception>().HasOne(x => x.Schedule)
                                    .WithMany(x => x.Receptions)
                                    .HasForeignKey(x => x.ScheduleId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}


