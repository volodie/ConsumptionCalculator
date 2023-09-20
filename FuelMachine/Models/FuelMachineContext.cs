using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FuelMachine.Models;

public partial class FuelMachineContext : DbContext
{
    public FuelMachineContext()
    {
    }

    public FuelMachineContext(DbContextOptions<FuelMachineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AirConditioner> AirConditioners { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarModel> CarModels { get; set; }

    public virtual DbSet<Fuel> Fuels { get; set; }

    public virtual DbSet<ModelConsumption> ModelConsumptions { get; set; }

    public virtual DbSet<Town> Towns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=;Database=fuel_machine;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AirConditioner>(entity =>
        {
            entity.ToTable("AirConditioner");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CarName).HasMaxLength(50);
        });

        modelBuilder.Entity<CarModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Model");

            entity.ToTable("CarModel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ModelName).HasMaxLength(50);
            entity.Property(e => e.PowerInKw).HasColumnName("PowerInKW");

            entity.HasOne(d => d.Car).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarModel_Cars");
        });

        modelBuilder.Entity<Fuel>(entity =>
        {
            entity.ToTable("Fuel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FuelType).HasMaxLength(10);
        });

        modelBuilder.Entity<ModelConsumption>(entity =>
        {
            entity.ToTable("ModelConsumption");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ModelId).HasColumnName("ModelID");
            entity.Property(e => e.VechicleConsumption).HasColumnType("decimal(3, 1)");

            entity.HasOne(d => d.Model).WithMany(p => p.ModelConsumptions)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ModelConsumption_CarModel");
        });

        modelBuilder.Entity<Town>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TownName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
