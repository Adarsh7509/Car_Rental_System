using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Car_Rental_System.Models
{
    public partial class Car_Rental_SystemContext : DbContext
    {
        public Car_Rental_SystemContext()
        {
        }

        public Car_Rental_SystemContext(DbContextOptions<Car_Rental_SystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<CarImage> CarImages { get; set; } = null!;
        public virtual DbSet<CarSpecification> CarSpecifications { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ZEFYRUS\\SQLEXPRESS;Database=Car_Rental_System;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Admins__536C85E4686A2FC8")
                    .IsUnique();

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.PasswordHash).HasMaxLength(255);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Admin')");

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.AvailabilityStatus)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('Available')");

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Make).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.PricePerDay).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<CarImage>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__CarImage__7516F4EC5D5A0D14");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.ImageUrl).HasMaxLength(255);

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.CarImages)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__CarImages__CarID__5070F446");
            });

            modelBuilder.Entity<CarSpecification>(entity =>
            {
                entity.HasKey(e => e.SpecificationId)
                    .HasName("PK__CarSpeci__A384CC1D9E5BADD9");

                entity.Property(e => e.SpecificationId).HasColumnName("SpecificationID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.Specification).HasMaxLength(255);

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.CarSpecifications)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__CarSpecif__CarID__534D60F1");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('Completed')");

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ReservationId)
                    .HasConstraintName("FK__Payments__Reserv__5AEE82B9");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.DropoffDate).HasColumnType("datetime");

                entity.Property(e => e.PickupDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('Active')");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Reservati__CarID__571DF1D5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Reservati__UserI__5629CD9C");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.ReviewDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReviewText).HasMaxLength(1000);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Reviews__CarID__60A75C0F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Reviews__UserID__5FB337D6");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D105347B2424E4")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(255);

                entity.Property(e => e.PaymentDetails).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
