using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBContext;

public partial class EggDbContext : DbContext
{
    public EggDbContext()
    {
    }

    public EggDbContext(DbContextOptions<EggDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AiConversationalMessage> AiConversationalMessages { get; set; }

    public virtual DbSet<AiConversationalSession> AiConversationalSessions { get; set; }

    public virtual DbSet<AiModel> AiModels { get; set; }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<AnomalyEvent> AnomalyEvents { get; set; }

    public virtual DbSet<AnomalyRule> AnomalyRules { get; set; }

    public virtual DbSet<AnomalyType> AnomalyTypes { get; set; }

    public virtual DbSet<BioSensingDatum> BioSensingData { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<DeviceOwnership> DeviceOwnerships { get; set; }

    public virtual DbSet<DeviceWarranty> DeviceWarranties { get; set; }

    public virtual DbSet<EggSession> EggSessions { get; set; }

    public virtual DbSet<EggType> EggTypes { get; set; }

    public virtual DbSet<ImageMatch> ImageMatches { get; set; }

    public virtual DbSet<ImageTemplate> ImageTemplates { get; set; }

    public virtual DbSet<IncubationBatch> IncubationBatches { get; set; }

    public virtual DbSet<IncubatorDevice> IncubatorDevices { get; set; }

    public virtual DbSet<IncubatorModel> IncubatorModels { get; set; }

    public virtual DbSet<MaintenanceAction> MaintenanceActions { get; set; }

    public virtual DbSet<MaintenanceTicket> MaintenanceTickets { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=EggCompany;Username=postgres;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AiConversationalMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("ai_conversational_messages_pkey");

            entity.ToTable("ai_conversational_messages");

            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.MessageText).HasColumnName("message_text");
            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.Timestamp)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Session).WithMany(p => p.AiConversationalMessages)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("fk_ai_messages_sessions");
        });

        modelBuilder.Entity<AiConversationalSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("ai_conversational_sessions_pkey");

            entity.ToTable("ai_conversational_sessions");

            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.EndTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_time");
            entity.Property(e => e.StartTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_time");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.AiConversationalSessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_ai_sessions_users");
        });

        modelBuilder.Entity<AiModel>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("ai_models_pkey");

            entity.ToTable("ai_models");

            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.DataInputType)
                .HasMaxLength(50)
                .HasColumnName("data_input_type");
            entity.Property(e => e.ModelName)
                .HasMaxLength(50)
                .HasColumnName("model_name");
            entity.Property(e => e.Version)
                .HasMaxLength(20)
                .HasColumnName("version");
        });

        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.AlertId).HasName("alerts_pkey");

            entity.ToTable("alerts");

            entity.Property(e => e.AlertId).HasColumnName("alert_id");
            entity.Property(e => e.AlertMessage).HasColumnName("alert_message");
            entity.Property(e => e.AlertType)
                .HasMaxLength(50)
                .HasColumnName("alert_type");
        });

        modelBuilder.Entity<AnomalyEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("anomaly_events_pkey");

            entity.ToTable("anomaly_events");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.AnomalyTypeId).HasColumnName("anomaly_type_id");
            entity.Property(e => e.OccurredAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("occurred_at");

            entity.HasOne(d => d.AnomalyType).WithMany(p => p.AnomalyEvents)
                .HasForeignKey(d => d.AnomalyTypeId)
                .HasConstraintName("fk_anomaly_events_types");
        });

        modelBuilder.Entity<AnomalyRule>(entity =>
        {
            entity.HasKey(e => e.RuleId).HasName("anomaly_rules_pkey");

            entity.ToTable("anomaly_rules");

            entity.Property(e => e.RuleId).HasColumnName("rule_id");
            entity.Property(e => e.AnomalyTypeId).HasColumnName("anomaly_type_id");
            entity.Property(e => e.RuleName)
                .HasMaxLength(50)
                .HasColumnName("rule_name");
            entity.Property(e => e.Threshold).HasColumnName("threshold");

            entity.HasOne(d => d.AnomalyType).WithMany(p => p.AnomalyRules)
                .HasForeignKey(d => d.AnomalyTypeId)
                .HasConstraintName("fk_anomaly_rules_types");
        });

        modelBuilder.Entity<AnomalyType>(entity =>
        {
            entity.HasKey(e => e.AnomalyTypeId).HasName("anomaly_types_pkey");

            entity.ToTable("anomaly_types");

            entity.Property(e => e.AnomalyTypeId).HasColumnName("anomaly_type_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<BioSensingDatum>(entity =>
        {
            entity.HasKey(e => e.DataId).HasName("bio_sensing_data_pkey");

            entity.ToTable("bio_sensing_data");

            entity.Property(e => e.DataId).HasColumnName("data_id");
            entity.Property(e => e.CapturedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("captured_at");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Device).WithMany(p => p.BioSensingData)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("fk_bio_sensing_devices");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("category_name");
            entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.DeviceId).HasName("devices_pkey");

            entity.ToTable("devices");

            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(50)
                .HasColumnName("serial_number");
        });

        modelBuilder.Entity<DeviceOwnership>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("device_ownership_pkey");

            entity.ToTable("device_ownership");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.OwnershipType)
                .HasMaxLength(20)
                .HasColumnName("ownership_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Device).WithMany(p => p.DeviceOwnerships)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("fk_device_ownership_devices");

            entity.HasOne(d => d.User).WithMany(p => p.DeviceOwnerships)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_device_ownership_users");
        });

        modelBuilder.Entity<DeviceWarranty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("device_warranty_pkey");

            entity.ToTable("device_warranty");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.WarrantyStatus)
                .HasMaxLength(20)
                .HasColumnName("warranty_status");

            entity.HasOne(d => d.Device).WithMany(p => p.DeviceWarranties)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("fk_device_warranty_devices");
        });

        modelBuilder.Entity<EggSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("egg_sessions_pkey");

            entity.ToTable("egg_sessions");

            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.EggTypeId).HasColumnName("egg_type_id");
            entity.Property(e => e.EndTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_time");
            entity.Property(e => e.StartTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_time");

            entity.HasOne(d => d.EggType).WithMany(p => p.EggSessions)
                .HasForeignKey(d => d.EggTypeId)
                .HasConstraintName("fk_egg_sessions_types");
        });

        modelBuilder.Entity<EggType>(entity =>
        {
            entity.HasKey(e => e.EggTypeId).HasName("egg_types_pkey");

            entity.ToTable("egg_types");

            entity.Property(e => e.EggTypeId).HasColumnName("egg_type_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EggName)
                .HasMaxLength(50)
                .HasColumnName("egg_name");
        });

        modelBuilder.Entity<ImageMatch>(entity =>
        {
            entity.HasKey(e => e.MatchId).HasName("image_matches_pkey");

            entity.ToTable("image_matches");

            entity.Property(e => e.MatchId).HasColumnName("match_id");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.MatchScore).HasColumnName("match_score");
            entity.Property(e => e.TemplateId).HasColumnName("template_id");

            entity.HasOne(d => d.Template).WithMany(p => p.ImageMatches)
                .HasForeignKey(d => d.TemplateId)
                .HasConstraintName("fk_image_matches_templates");
        });

        modelBuilder.Entity<ImageTemplate>(entity =>
        {
            entity.HasKey(e => e.TemplateId).HasName("image_templates_pkey");

            entity.ToTable("image_templates");

            entity.Property(e => e.TemplateId).HasColumnName("template_id");
            entity.Property(e => e.MatchingThreshold).HasColumnName("matching_threshold");
            entity.Property(e => e.TemplateData).HasColumnName("template_data");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(50)
                .HasColumnName("template_name");
        });

        modelBuilder.Entity<IncubationBatch>(entity =>
        {
            entity.HasKey(e => e.BatchId).HasName("incubation_batches_pkey");

            entity.ToTable("incubation_batches");

            entity.Property(e => e.BatchId).HasColumnName("batch_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            entity.Property(e => e.IncubatorDeviceId).HasColumnName("incubator_device_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");

            entity.HasOne(d => d.IncubatorDevice).WithMany(p => p.IncubationBatches)
                .HasForeignKey(d => d.IncubatorDeviceId)
                .HasConstraintName("fk_incubation_batches_devices");
        });

        modelBuilder.Entity<IncubatorDevice>(entity =>
        {
            entity.HasKey(e => e.DeviceId).HasName("incubator_devices_pkey");

            entity.ToTable("incubator_devices");

            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.ModelId).HasColumnName("model_id");

            entity.HasOne(d => d.Model).WithMany(p => p.IncubatorDevices)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("fk_incubator_devices_models");
        });

        modelBuilder.Entity<IncubatorModel>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("incubator_models_pkey");

            entity.ToTable("incubator_models");

            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .HasColumnName("manufacturer");
            entity.Property(e => e.ModelNumber)
                .HasMaxLength(50)
                .HasColumnName("model_number");
        });

        modelBuilder.Entity<MaintenanceAction>(entity =>
        {
            entity.HasKey(e => e.ActionId).HasName("maintenance_actions_pkey");

            entity.ToTable("maintenance_actions");

            entity.Property(e => e.ActionId).HasColumnName("action_id");
            entity.Property(e => e.ActionDesc).HasColumnName("action_desc");
            entity.Property(e => e.PerformedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("performed_at");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");

            entity.HasOne(d => d.Ticket).WithMany(p => p.MaintenanceActions)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("fk_maintenance_actions_tickets");
        });

        modelBuilder.Entity<MaintenanceTicket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("maintenance_tickets_pkey");

            entity.ToTable("maintenance_tickets");

            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.ClosedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("closed_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.OpenedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("opened_at");

            entity.HasOne(d => d.Device).WithMany(p => p.MaintenanceTickets)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("fk_maintenance_tickets_devices");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderTotal).HasColumnName("order_total");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_orders_users");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("order_items_pkey");

            entity.ToTable("order_items");

            entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("fk_order_items_orders");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("fk_users_roles");
        });

        modelBuilder.Entity<UserActivityLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("user_activity_logs_pkey");

            entity.ToTable("user_activity_logs");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(50)
                .HasColumnName("activity_type");
            entity.Property(e => e.Timestamp)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserActivityLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_user_activity_logs_users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
