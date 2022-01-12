using Microsoft.EntityFrameworkCore;

namespace NotificationService.Entities
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcements> Announcements { get; set; }
        public virtual DbSet<DismissedAnnouncements> DismissedAnnouncements { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<MailQueue> MailQueue { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Reminders> Reminders { get; set; }
        public virtual DbSet<TrackedMails> TrackedMails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user=root;password=password;database=perfex;convert zero datetime=True", x => x.ServerVersion("10.6.5-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcements>(entity =>
            {
                entity.HasKey(e => e.Announcementid)
                    .HasName("PRIMARY");

                entity.ToTable("announcements");

                entity.Property(e => e.Announcementid)
                    .HasColumnName("announcementid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dateadded)
                    .HasColumnName("dateadded")
                    .HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Showname)
                    .HasColumnName("showname")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Showtostaff)
                    .HasColumnName("showtostaff")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Showtousers)
                    .HasColumnName("showtousers")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasColumnName("userid")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<DismissedAnnouncements>(entity =>
            {
                entity.HasKey(e => e.Dismissedannouncementid)
                    .HasName("PRIMARY");

                entity.ToTable("dismissed_announcements");

                entity.HasIndex(e => e.Announcementid)
                    .HasName("announcementid");

                entity.HasIndex(e => e.Staff)
                    .HasName("staff");

                entity.HasIndex(e => e.Userid)
                    .HasName("userid");

                entity.Property(e => e.Dismissedannouncementid)
                    .HasColumnName("dismissedannouncementid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Announcementid)
                    .HasColumnName("announcementid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Staff)
                    .HasColumnName("staff")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.Eventid)
                    .HasName("PRIMARY");

                entity.ToTable("events");

                entity.Property(e => e.Eventid)
                    .HasColumnName("eventid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.End)
                    .HasColumnName("end")
                    .HasColumnType("datetime");

                entity.Property(e => e.Isstartnotified).HasColumnName("isstartnotified");

                entity.Property(e => e.Public)
                    .HasColumnName("public")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReminderBefore)
                    .HasColumnName("reminder_before")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReminderBeforeType)
                    .HasColumnName("reminder_before_type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Start)
                    .HasColumnName("start")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<MailQueue>(entity =>
            {
                entity.ToTable("mail_queue");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AltMessage)
                    .HasColumnName("alt_message")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Attachments)
                    .HasColumnName("attachments")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Bcc)
                    .HasColumnName("bcc")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Cc)
                    .HasColumnName("cc")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Engine)
                    .HasColumnName("engine")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Headers)
                    .HasColumnName("headers")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("enum('pending','sending','sent','failed')")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.ToTable("notifications");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdditionalData)
                    .HasColumnName("additional_data")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.FromFullname)
                    .IsRequired()
                    .HasColumnName("from_fullname")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Fromclientid)
                    .HasColumnName("fromclientid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fromcompany)
                    .HasColumnName("fromcompany")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fromuserid)
                    .HasColumnName("fromuserid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Isread)
                    .HasColumnName("isread")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsreadInline).HasColumnName("isread_inline");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Touserid)
                    .HasColumnName("touserid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Reminders>(entity =>
            {
                entity.ToTable("reminders");

                entity.HasIndex(e => e.RelId)
                    .HasName("rel_id");

                entity.HasIndex(e => e.RelType)
                    .HasName("rel_type");

                entity.HasIndex(e => e.Staff)
                    .HasName("staff");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Creator)
                    .HasColumnName("creator")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Isnotified)
                    .HasColumnName("isnotified")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NotifyByEmail)
                    .HasColumnName("notify_by_email")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.RelId)
                    .HasColumnName("rel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Staff)
                    .HasColumnName("staff")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TrackedMails>(entity =>
            {
                entity.ToTable("tracked_mails");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOpened)
                    .HasColumnName("date_opened")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Opened).HasColumnName("opened");

                entity.Property(e => e.RelId)
                    .HasColumnName("rel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasColumnName("uid")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
