using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Car_izma.data.Models;

public partial class CarizmaContext : DbContext
{
    public CarizmaContext()
    {
    }

    public CarizmaContext(DbContextOptions<CarizmaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarImage> CarImages { get; set; }

    public virtual DbSet<Satislar> Satislars { get; set; }

    public virtual DbSet<Showroom> Showrooms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=CARizma;User Id=SA;Password=reallyStrongPwd123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.CarAciklama).HasMaxLength(500);
            entity.Property(e => e.CarEklenmeTarihi).HasColumnType("datetime");
            entity.Property(e => e.Fiyat).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.KasaTipi).HasMaxLength(30);
            entity.Property(e => e.Km).HasColumnName("KM");
            entity.Property(e => e.Marka).HasMaxLength(50);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.MotorNo).HasMaxLength(50);
            entity.Property(e => e.Plaka).HasMaxLength(20);
            entity.Property(e => e.Renk).HasMaxLength(30);
            entity.Property(e => e.SaseNo).HasMaxLength(50);
            entity.Property(e => e.ShowroomId).HasColumnName("ShowroomID");
            entity.Property(e => e.VitesTipi).HasMaxLength(20);
            entity.Property(e => e.YakıtTipi).HasMaxLength(20);

            entity.HasOne(d => d.Showroom).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ShowroomId)
                .HasConstraintName("FK_Cars_Showrooms");
        });

        modelBuilder.Entity<CarImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__CarImage__7516F70CB94C9FF5");

            entity.Property(e => e.ImagePath).HasMaxLength(200);

            entity.HasOne(d => d.Car).WithMany(p => p.CarImages)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarImages_Cars");
        });

        modelBuilder.Entity<Satislar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Satislar__3214EC07292C1B3D");

            entity.ToTable("Satislar");

            entity.Property(e => e.MusteriAdSoyad).HasMaxLength(100);
            entity.Property(e => e.MusteriTelefon).HasMaxLength(20);
            entity.Property(e => e.SatisFiyati).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SatisTarihi).HasColumnType("datetime");

            entity.HasOne(d => d.Car).WithMany(p => p.Satislars)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Satislar_Cars");

            entity.HasOne(d => d.User).WithMany(p => p.Satislars)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Satislar_Users");
        });

        modelBuilder.Entity<Showroom>(entity =>
        {
            entity.Property(e => e.ShowroomId).HasColumnName("showroomID");
            entity.Property(e => e.ShowroomAciklama)
                .HasMaxLength(500)
                .HasColumnName("showroomAciklama");
            entity.Property(e => e.ShowroomAd)
                .HasMaxLength(50)
                .HasColumnName("showroomAd");
            entity.Property(e => e.ShowroomAdres)
                .HasMaxLength(200)
                .HasColumnName("showroomAdres");
            entity.Property(e => e.ShowroomMail)
                .HasMaxLength(50)
                .HasColumnName("showroomMail");
            entity.Property(e => e.ShowroomTel)
                .HasMaxLength(20)
                .HasColumnName("showroomTel");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__3214EC0793F17A1E");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AdSoyad).HasMaxLength(100);
            entity.Property(e => e.UserEmail).HasMaxLength(100);
            entity.Property(e => e.UserRol).HasMaxLength(20);
            entity.Property(e => e.UserSifre).HasMaxLength(100);
            entity.Property(e => e.UserTelefon).HasMaxLength(20);

            entity.HasOne(d => d.Showroom).WithMany(p => p.Users)
                .HasForeignKey(d => d.ShowroomId)
                .HasConstraintName("FK_Users_Showrooms");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
