using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SteamBoilerApp.Models;

public partial class ProductionDbContext : DbContext
{
    public ProductionDbContext()
    {
    }

    public ProductionDbContext(DbContextOptions<ProductionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<FluteType> FluteTypes { get; set; }

    public virtual DbSet<FuelFeedLog> FuelFeedLogs { get; set; }

    public virtual DbSet<FuelType> FuelTypes { get; set; }

    public virtual DbSet<Layer> Layers { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<Measurement> Measurements { get; set; }

    public virtual DbSet<MeasurementType> MeasurementTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<PaperGrammage> PaperGrammages { get; set; }

    public virtual DbSet<PaperType> PaperTypes { get; set; }

    public virtual DbSet<PidControllerConfig> PidControllerConfigs { get; set; }

    public virtual DbSet<PidRuntimeLog> PidRuntimeLogs { get; set; }

    public virtual DbSet<Sensor> Sensors { get; set; }

    public virtual DbSet<SensorDatum> SensorData { get; set; }

    public virtual DbSet<SteamLatentHeat> SteamLatentHeats { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-AP9S4SF, 1433;Initial Catalog=ProductionDB;User ID=huyle;Password=huyle;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__AppUser__1788CC4C53F30DBB");

            entity.ToTable("AppUser");

            entity.HasIndex(e => e.Username, "UQ__AppUser__536C85E472C84A2B").IsUnique();

            entity.Property(e => e.HashedPassword).HasMaxLength(200);
            entity.Property(e => e.LastLogin).HasPrecision(0);
            entity.Property(e => e.PasswordSalt).HasMaxLength(200);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValue("Operator");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D83D987F10");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerName).HasMaxLength(100);
        });

        modelBuilder.Entity<FluteType>(entity =>
        {
            entity.HasKey(e => e.FluteTypeId).HasName("PK__FluteTyp__FF229FD02A97A3D3");

            entity.ToTable("FluteType");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.FluteCode).HasMaxLength(50);
            entity.Property(e => e.FluteRatio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<FuelFeedLog>(entity =>
        {
            entity.HasKey(e => e.FuelFeedLogId).HasName("PK__FuelFeed__3D9C938F185AA0B1");

            entity.ToTable("FuelFeedLog");

            entity.Property(e => e.Timestamp).HasPrecision(0);

            entity.HasOne(d => d.FuelType).WithMany(p => p.FuelFeedLogs)
                .HasForeignKey(d => d.FuelTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FuelFeedL__FuelT__797309D9");

            entity.HasOne(d => d.Unit).WithMany(p => p.FuelFeedLogs)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FuelFeedL__UnitI__7A672E12");
        });

        modelBuilder.Entity<FuelType>(entity =>
        {
            entity.HasKey(e => e.FuelTypeId).HasName("PK__FuelType__048BEE379601C6CF");

            entity.ToTable("FuelType");

            entity.Property(e => e.FuelLhv)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("FuelLHV");
            entity.Property(e => e.FuelName).HasMaxLength(50);

            entity.HasOne(d => d.Unit).WithMany(p => p.FuelTypes)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FuelType__UnitId__76969D2E");
        });

        modelBuilder.Entity<Layer>(entity =>
        {
            entity.HasKey(e => e.LayerId).HasName("PK__Layer__83790D82BAD1EA86");

            entity.ToTable("Layer");

            entity.HasOne(d => d.Order).WithMany(p => p.Layers)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Layer__OrderId__5CD6CB2B");

            entity.HasOne(d => d.PaperGrammage).WithMany(p => p.Layers)
                .HasForeignKey(d => d.PaperGrammageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Layer__PaperGram__5EBF139D");

            entity.HasOne(d => d.PaperType).WithMany(p => p.Layers)
                .HasForeignKey(d => d.PaperTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Layer__PaperType__5DCAEF64");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.MachineId).HasName("PK__Machine__44EE5B38617A64C3");

            entity.ToTable("Machine");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.MachineName).HasMaxLength(100);
        });

        modelBuilder.Entity<Measurement>(entity =>
        {
            entity.HasKey(e => e.MeasurementId).HasName("PK__Measurem__85599FB8F629DECC");

            entity.ToTable("Measurement");

            entity.Property(e => e.MeasuredValue).HasColumnType("decimal(12, 3)");

            entity.HasOne(d => d.Machine).WithMany(p => p.Measurements)
                .HasForeignKey(d => d.MachineId)
                .HasConstraintName("FK__Measureme__Machi__628FA481");

            entity.HasOne(d => d.MeasurementType).WithMany(p => p.Measurements)
                .HasForeignKey(d => d.MeasurementTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Measureme__Measu__6383C8BA");

            entity.HasOne(d => d.Order).WithMany(p => p.Measurements)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Measureme__Order__619B8048");

            entity.HasOne(d => d.Unit).WithMany(p => p.Measurements)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Measureme__UnitI__6477ECF3");
        });

        modelBuilder.Entity<MeasurementType>(entity =>
        {
            entity.HasKey(e => e.MeasurementTypeId).HasName("PK__Measurem__167933E76825FAD5");

            entity.ToTable("MeasurementType");

            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCF2C3E1DB5");

            entity.ToTable("Order");

            entity.Property(e => e.RunDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__CustomerI__59063A47");

            entity.HasOne(d => d.FluteType).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FluteTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__FluteType__59FA5E80");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("PK__OrderSta__BC674CA1571472DC");

            entity.ToTable("OrderStatus");

            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Timestamp)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderStatuses)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderStat__Order__71D1E811");
        });

        modelBuilder.Entity<PaperGrammage>(entity =>
        {
            entity.HasKey(e => e.PaperGrammageId).HasName("PK__PaperGra__6254D45771F89FF0");

            entity.ToTable("PaperGrammage");

            entity.Property(e => e.GrammageValue).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Unit).WithMany(p => p.PaperGrammages)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PaperGram__UnitI__5165187F");
        });

        modelBuilder.Entity<PaperType>(entity =>
        {
            entity.HasKey(e => e.PaperTypeId).HasName("PK__PaperTyp__F95F66DAD0D001D4");

            entity.ToTable("PaperType");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.PaperCode).HasMaxLength(50);
        });

        modelBuilder.Entity<PidControllerConfig>(entity =>
        {
            entity.HasKey(e => e.PidConfigId).HasName("PK__PidContr__8B1B10C9F1A2BC9A");

            entity.ToTable("PidControllerConfig");

            entity.Property(e => e.ConfigName).HasMaxLength(50);
            entity.Property(e => e.ControlMode)
                .HasMaxLength(10)
                .HasDefaultValue("Auto");
            entity.Property(e => e.ControllerName).HasMaxLength(50);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LastUpdated).HasPrecision(0);

            entity.HasOne(d => d.Sensor).WithMany(p => p.PidControllerConfigs)
                .HasForeignKey(d => d.SensorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PidContro__Senso__30C33EC3");
        });

        modelBuilder.Entity<PidRuntimeLog>(entity =>
        {
            entity.HasKey(e => e.PidLogId).HasName("PK__PidRunti__6A3E3181D4471B3B");

            entity.ToTable("PidRuntimeLog");

            entity.Property(e => e.Timestamp).HasPrecision(0);

            entity.HasOne(d => d.PidConfig).WithMany(p => p.PidRuntimeLogs)
                .HasForeignKey(d => d.PidConfigId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PidRuntim__PidCo__339FAB6E");
        });

        modelBuilder.Entity<Sensor>(entity =>
        {
            entity.HasKey(e => e.SensorId).HasName("PK__Sensor__D8099BFADA3444B3");

            entity.ToTable("Sensor");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.SensorName).HasMaxLength(50);

            entity.HasOne(d => d.MeasurementType).WithMany(p => p.Sensors)
                .HasForeignKey(d => d.MeasurementTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sensor__Measurem__06CD04F7");

            entity.HasOne(d => d.Unit).WithMany(p => p.Sensors)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sensor__UnitId__07C12930");
        });

        modelBuilder.Entity<SensorDatum>(entity =>
        {
            entity.HasKey(e => e.SensorDataId).HasName("PK__SensorDa__14C88410BD7527D9");

            entity.Property(e => e.EngineeringValue).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.QualityStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Good");
            entity.Property(e => e.Timestamp).HasPrecision(0);

            entity.HasOne(d => d.Sensor).WithMany(p => p.SensorData)
                .HasForeignKey(d => d.SensorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SensorDat__Senso__0B91BA14");
        });

        modelBuilder.Entity<SteamLatentHeat>(entity =>
        {
            entity.HasKey(e => e.SteamLatentHeatId).HasName("PK__SteamLat__52F31FC9E160BBD3");

            entity.ToTable("SteamLatentHeat");

            entity.Property(e => e.LatentHeatKJkg)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("LatentHeat_kJkg");
            entity.Property(e => e.PressureBarg)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("Pressure_barg");
            entity.Property(e => e.TemperatureC)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("Temperature_C");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__Unit__44F5ECB5AA8447CA");

            entity.ToTable("Unit");

            entity.Property(e => e.Symbol).HasMaxLength(20);
            entity.Property(e => e.UnitName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
