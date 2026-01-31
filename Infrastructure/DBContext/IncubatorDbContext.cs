using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Infrastructure.DBContext;

public partial class IncubatorDbContext : DbContext
{
    public IncubatorDbContext()
    {
    }

    public IncubatorDbContext(DbContextOptions<IncubatorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<alert> alerts { get; set; }

    public virtual DbSet<anomaly_rule> anomaly_rules { get; set; }

    public virtual DbSet<audit_log> audit_logs { get; set; }

    public virtual DbSet<config> configs { get; set; }

    public virtual DbSet<control_board_type> control_board_types { get; set; }

    public virtual DbSet<control_device> control_devices { get; set; }

    public virtual DbSet<customer> customers { get; set; }

    public virtual DbSet<incubator> incubators { get; set; }

    public virtual DbSet<incubator_camera> incubator_cameras { get; set; }

    public virtual DbSet<incubator_config_instance> incubator_config_instances { get; set; }

    public virtual DbSet<incubator_model> incubator_models { get; set; }

    public virtual DbSet<incubator_model_config> incubator_model_configs { get; set; }

    public virtual DbSet<maintenance_log> maintenance_logs { get; set; }

    public virtual DbSet<maintenance_ticket> maintenance_tickets { get; set; }

    public virtual DbSet<masterboard> masterboards { get; set; }

    public virtual DbSet<ml_model> ml_models { get; set; }

    public virtual DbSet<mqtt_config> mqtt_configs { get; set; }

    public virtual DbSet<operation_history> operation_histories { get; set; }

    public virtual DbSet<operation_mode> operation_modes { get; set; }

    public virtual DbSet<role> roles { get; set; }

    public virtual DbSet<sales_order> sales_orders { get; set; }

    public virtual DbSet<sales_order_item> sales_order_items { get; set; }

    public virtual DbSet<sensor> sensors { get; set; }

    public virtual DbSet<sensor_reading> sensor_readings { get; set; }

    public virtual DbSet<user> users { get; set; }

    public virtual DbSet<warranty> warranties { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Database=EggCompany;Username=postgres;Password=12345");
    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<alert>(entity =>
        {
            entity.HasKey(e => e.id).HasName("alerts_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.config).WithMany(p => p.alerts).HasConstraintName("alerts_config_id_fkey");

            entity.HasOne(d => d.incubator).WithMany(p => p.alerts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alerts_incubator_id_fkey");

            entity.HasOne(d => d.model).WithMany(p => p.alerts).HasConstraintName("alerts_model_id_fkey");
        });

        modelBuilder.Entity<anomaly_rule>(entity =>
        {
            entity.HasKey(e => e.id).HasName("anomaly_rules_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");

            entity.HasOne(d => d.config).WithMany(p => p.anomaly_rules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("anomaly_rules_config_id_fkey");

            entity.HasOne(d => d.model).WithMany(p => p.anomaly_rules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("anomaly_rules_model_id_fkey");
        });

        modelBuilder.Entity<audit_log>(entity =>
        {
            entity.HasKey(e => e.id).HasName("audit_logs_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.user).WithMany(p => p.audit_logs).HasConstraintName("audit_logs_user_id_fkey");
        });

        modelBuilder.Entity<config>(entity =>
        {
            entity.HasKey(e => e.id).HasName("configs_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
        });

        modelBuilder.Entity<control_board_type>(entity =>
        {
            entity.HasKey(e => e.id).HasName("control_board_types_pkey");
        });

        modelBuilder.Entity<control_device>(entity =>
        {
            entity.HasKey(e => e.id).HasName("control_devices_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");

            entity.HasOne(d => d.config).WithMany(p => p.control_devices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("control_devices_config_id_fkey");

            entity.HasOne(d => d.control_board_types).WithMany(p => p.control_devices).HasConstraintName("control_devices_control_board_types_id_fkey");

            entity.HasOne(d => d.masterboard).WithMany(p => p.control_devices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("control_devices_masterboard_id_fkey");
        });

        modelBuilder.Entity<customer>(entity =>
        {
            entity.HasKey(e => e.id).HasName("customers_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<incubator>(entity =>
        {
            entity.HasKey(e => e.id).HasName("incubators_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");

            entity.HasOne(d => d.customer).WithMany(p => p.incubators).HasConstraintName("incubators_customer_id_fkey");

            entity.HasOne(d => d.model).WithMany(p => p.incubators)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("incubators_model_id_fkey");
        });

        modelBuilder.Entity<incubator_camera>(entity =>
        {
            entity.HasKey(e => e.id).HasName("incubator_cameras_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.incubator).WithMany(p => p.incubator_cameras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("incubator_cameras_incubator_id_fkey");
        });

        modelBuilder.Entity<incubator_config_instance>(entity =>
        {
            entity.HasKey(e => e.id).HasName("incubator_config_instances_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");

            entity.HasOne(d => d.config).WithMany(p => p.incubator_config_instances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("incubator_config_instances_config_id_fkey");

            entity.HasOne(d => d.incubator).WithMany(p => p.incubator_config_instances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("incubator_config_instances_incubator_id_fkey");
        });

        modelBuilder.Entity<incubator_model>(entity =>
        {
            entity.HasKey(e => e.id).HasName("incubator_models_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<incubator_model_config>(entity =>
        {
            entity.HasKey(e => e.id).HasName("incubator_model_configs_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.quantity).HasDefaultValue(1);
            entity.Property(e => e.required).HasDefaultValue(false);

            entity.HasOne(d => d.config).WithMany(p => p.incubator_model_configs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("incubator_model_configs_config_id_fkey");

            entity.HasOne(d => d.model).WithMany(p => p.incubator_model_configs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("incubator_model_configs_model_id_fkey");
        });

        modelBuilder.Entity<maintenance_log>(entity =>
        {
            entity.HasKey(e => e.id).HasName("maintenance_logs_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.ticket).WithMany(p => p.maintenance_logs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("maintenance_logs_ticket_id_fkey");
        });

        modelBuilder.Entity<maintenance_ticket>(entity =>
        {
            entity.HasKey(e => e.id).HasName("maintenance_tickets_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.incubator).WithMany(p => p.maintenance_tickets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("maintenance_tickets_incubator_id_fkey");

            entity.HasOne(d => d.technician).WithMany(p => p.maintenance_tickets).HasConstraintName("maintenance_tickets_technician_id_fkey");
        });

        modelBuilder.Entity<masterboard>(entity =>
        {
            entity.HasKey(e => e.id).HasName("masterboards_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.incubator).WithOne(p => p.masterboard)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("masterboards_incubator_id_fkey");
        });

        modelBuilder.Entity<ml_model>(entity =>
        {
            entity.HasKey(e => e.id).HasName("ml_models_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.active).HasDefaultValue(true);
        });

        modelBuilder.Entity<mqtt_config>(entity =>
        {
            entity.HasKey(e => e.id).HasName("mqtt_configs_pkey");
        });

        modelBuilder.Entity<operation_history>(entity =>
        {
            entity.HasKey(e => e.id).HasName("operation_history_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");

            entity.HasOne(d => d.incubator).WithMany(p => p.operation_histories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("operation_history_incubator_id_fkey");

            entity.HasOne(d => d.mode).WithMany(p => p.operation_histories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("operation_history_mode_id_fkey");
        });

        modelBuilder.Entity<operation_mode>(entity =>
        {
            entity.HasKey(e => e.id).HasName("operation_modes_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.id).HasName("roles_pkey");

            entity.Property(e => e.id).ValueGeneratedNever();
        });

        modelBuilder.Entity<sales_order>(entity =>
        {
            entity.HasKey(e => e.id).HasName("sales_orders_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");

            entity.HasOne(d => d.customer).WithMany(p => p.sales_orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sales_orders_customer_id_fkey");
        });

        modelBuilder.Entity<sales_order_item>(entity =>
        {
            entity.HasKey(e => e.id).HasName("sales_order_items_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");

            entity.HasOne(d => d.incubator).WithMany(p => p.sales_order_items)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sales_order_items_incubator_id_fkey");

            entity.HasOne(d => d.order).WithMany(p => p.sales_order_items)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sales_order_items_order_id_fkey");
        });

        modelBuilder.Entity<sensor>(entity =>
        {
            entity.HasKey(e => e.id).HasName("sensors_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.config_instance).WithMany(p => p.sensors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sensors_config_instance_id_fkey");

            entity.HasOne(d => d.masterboard).WithMany(p => p.sensors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sensors_masterboard_id_fkey");
        });

        modelBuilder.Entity<sensor_reading>(entity =>
        {
            entity.HasKey(e => e.id).HasName("sensor_readings_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.recorded_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.sensor).WithMany(p => p.sensor_readings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sensor_readings_sensor_id_fkey");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.id).HasName("users_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");
            entity.Property(e => e.created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasMany(d => d.roles).WithMany(p => p.users)
                .UsingEntity<Dictionary<string, object>>(
                    "user_role",
                    r => r.HasOne<role>().WithMany()
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("user_roles_role_id_fkey"),
                    l => l.HasOne<user>().WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("user_roles_user_id_fkey"),
                    j =>
                    {
                        j.HasKey("user_id", "role_id").HasName("user_roles_pkey");
                        j.ToTable("user_roles");
                    });
        });

        modelBuilder.Entity<warranty>(entity =>
        {
            entity.HasKey(e => e.id).HasName("warranties_pkey");

            entity.Property(e => e.id).HasDefaultValueSql("uuid_generate_v4()");

            entity.HasOne(d => d.incubator).WithOne(p => p.warranty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("warranties_incubator_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
