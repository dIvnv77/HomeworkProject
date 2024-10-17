using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasMany(u => u.CreatedClasses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(u => u.EnrolledClasses)
                .WithOne(uc => uc.Student)
                .HasForeignKey(uc => uc.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasMany(u => u.CreatedReports)
               .WithOne(r => r.Teacher)
               .HasForeignKey(r => r.TeacherId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(u => u.EnrolledReports)
                .WithOne(ur => ur.Student)
                .HasForeignKey(ur => ur.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
