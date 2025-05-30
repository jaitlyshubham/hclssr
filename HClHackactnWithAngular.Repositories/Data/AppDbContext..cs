using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using HClHackactnWithAngular.Repositories.Entities;

namespace HClHackactnWithAngular.Repositories.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<StaffAssignment> StaffAssignments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ExportLog> ExportLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships and constraints

            // User to UserData (one-to-one)
            modelBuilder.Entity<UserData>()
                .HasOne(ud => ud.User)
                .WithMany(u => u.UserData)
                .HasForeignKey(ud => ud.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many: User to StaffAssignment
            modelBuilder.Entity<StaffAssignment>()
                .HasOne(sa => sa.Staff)
                .WithMany(u => u.StaffAssignments)
                .HasForeignKey(sa => sa.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-many: Shift to StaffAssignment
            modelBuilder.Entity<StaffAssignment>()
                .HasOne(sa => sa.Shift)
                .WithMany(s => s.StaffAssignments)
                .HasForeignKey(sa => sa.ShiftId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-one: StaffAssignment to Attendance
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.StaffAssignment)
                .WithOne(sa => sa.Attendance)
                .HasForeignKey<Attendance>(a => a.StaffAssignmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Add unique constraint to prevent multiple shifts for same staff on same day
            modelBuilder.Entity<StaffAssignment>()
                .HasIndex(sa => new { sa.StaffId, sa.ShiftDate })
                .IsUnique();

            // Configure ShiftDate property to match the Shift's date for consistency
            modelBuilder.Entity<Shift>()
                .HasMany(s => s.StaffAssignments)
                .WithOne(sa => sa.Shift)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure properties with MaxLength for string fields
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .HasMaxLength(256);

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasMaxLength(50);

            modelBuilder.Entity<UserData>()
                .Property(ud => ud.FirstName)
                .HasMaxLength(100);

            modelBuilder.Entity<UserData>()
                .Property(ud => ud.LastName)
                .HasMaxLength(100);

            modelBuilder.Entity<UserData>()
                .Property(ud => ud.StaffRole)
                .HasMaxLength(100);

            modelBuilder.Entity<UserData>()
                .Property(ud => ud.Department)
                .HasMaxLength(100);

            modelBuilder.Entity<UserData>()
                .Property(ud => ud.Email)
                .HasMaxLength(256);

            modelBuilder.Entity<UserData>()
                .Property(ud => ud.PhoneNumber)
                .HasMaxLength(20);

            modelBuilder.Entity<StaffAssignment>()
                .Property(sa => sa.QRCodeIdentifier)
                .HasMaxLength(100);

            modelBuilder.Entity<Attendance>()
                .Property(a => a.Notes)
                .HasMaxLength(500);

            modelBuilder.Entity<ExportLog>()
                .Property(e => e.FileName)
                .HasMaxLength(256);

            modelBuilder.Entity<ExportLog>()
                .Property(e => e.ExportType)
                .HasMaxLength(50);

            modelBuilder.Entity<ExportLog>()
                .Property(e => e.ExportedBy)
                .HasMaxLength(100);

            modelBuilder.Entity<ExportLog>()
                .Property(e => e.FilePath)
                .HasMaxLength(500);
        }
    }
}