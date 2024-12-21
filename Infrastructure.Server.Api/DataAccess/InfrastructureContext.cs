using System;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public partial class InfrastructureContext : DbContext
{
    public InfrastructureContext()
    {
    }

    public InfrastructureContext(DbContextOptions<InfrastructureContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BuildLog> BuildLogs { get; set; }

    public virtual DbSet<Entrance> Entrances { get; set; }

    public virtual DbSet<Flat> Flats { get; set; }

    public virtual DbSet<House> Houses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__addresse__3213E83F192450A8");

            entity.ToTable("addresses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .HasColumnName("street");
        });

        modelBuilder.Entity<BuildLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__build_lo__3213E83F4183BBF1");

            entity.ToTable("build_logs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.HouseId).HasColumnName("house_id");

            entity.HasOne(d => d.House).WithMany(p => p.BuildLogs)
                .HasForeignKey(d => d.HouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__build_log__house__787EE5A0");
        });

        modelBuilder.Entity<Entrance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__entrance__3213E83FDEB8DF31");

            entity.ToTable("entrances");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.HasAccessControl).HasColumnName("has_access_control");
            entity.Property(e => e.HasElevator).HasColumnName("has_elevator");
            entity.Property(e => e.HouseId).HasColumnName("house_id");
            entity.Property(e => e.Position)
                .HasMaxLength(30)
                .HasColumnName("position");

            entity.HasOne(d => d.House).WithMany(p => p.Entrances)
                .HasForeignKey(d => d.HouseId)
                .HasConstraintName("FK__entrances__house__6A30C649");
        });

        modelBuilder.Entity<Flat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__flats__3213E83F4D629DC7");

            entity.ToTable("flats", tb => tb.HasTrigger("tr_flats_logging"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EntranceId).HasColumnName("entrance_id");
            entity.Property(e => e.HasBalcony).HasColumnName("has_balcony");
            entity.Property(e => e.HasParkingSpace).HasColumnName("has_parking_space");
            entity.Property(e => e.IsRented).HasColumnName("is_rented");
            entity.Property(e => e.Size).HasColumnName("size");

            entity.HasOne(d => d.Entrance).WithMany(p => p.Flats)
                .HasForeignKey(d => d.EntranceId)
                .HasConstraintName("FK__flats__entrance___6D0D32F4");
        });

        modelBuilder.Entity<House>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__houses__3213E83F1E27DB19");

            entity.ToTable("houses", tb =>
                {
                    tb.HasTrigger("create_houses_trigger");
                    tb.HasTrigger("tr_builds_logging");
                });

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.BuildingYear).HasColumnName("building_year");
            entity.Property(e => e.IsHistoric).HasColumnName("is_historic");
            entity.Property(e => e.Material).HasColumnName("material");
            entity.Property(e => e.OrdinalNumber)
                .HasMaxLength(30)
                .HasColumnName("ordinal_number");
            entity.Property(e => e.RenovationYear).HasColumnName("renovation_year");

            entity.HasOne(d => d.Address).WithMany(p => p.Houses)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__houses__address___6754599E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
