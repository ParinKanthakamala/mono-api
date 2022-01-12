using Microsoft.EntityFrameworkCore;

namespace TicketService.Entities
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

        public virtual DbSet<Customfields> Customfields { get; set; }
        public virtual DbSet<TicketAttachments> TicketAttachments { get; set; }
        public virtual DbSet<TicketReplies> TicketReplies { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<TicketsPipeLog> TicketsPipeLog { get; set; }
        public virtual DbSet<TicketsPredefinedReplies> TicketsPredefinedReplies { get; set; }
        public virtual DbSet<TicketsPriorities> TicketsPriorities { get; set; }
        public virtual DbSet<TicketsStatus> TicketsStatus { get; set; }

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
            modelBuilder.Entity<Customfields>(entity =>
            {
                entity.ToTable("customfields");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.BsColumn)
                    .HasColumnName("bs_column")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'12'");

                entity.Property(e => e.DisalowClientToEdit)
                    .HasColumnName("disalow_client_to_edit")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DisplayInline).HasColumnName("display_inline");

                entity.Property(e => e.FieldOrder)
                    .HasColumnName("field_order")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Fieldto)
                    .IsRequired()
                    .HasColumnName("fieldto")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.OnlyAdmin).HasColumnName("only_admin");

                entity.Property(e => e.Options)
                    .HasColumnName("options")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Required).HasColumnName("required");

                entity.Property(e => e.ShowOnClientPortal)
                    .HasColumnName("show_on_client_portal")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShowOnPdf)
                    .HasColumnName("show_on_pdf")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShowOnTable).HasColumnName("show_on_table");

                entity.Property(e => e.ShowOnTicketForm).HasColumnName("show_on_ticket_form");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<TicketAttachments>(entity =>
            {
                entity.ToTable("ticket_attachments");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dateadded)
                    .HasColumnName("dateadded")
                    .HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Filetype)
                    .HasColumnName("filetype")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Replyid)
                    .HasColumnName("replyid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ticketid)
                    .HasColumnName("ticketid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TicketReplies>(entity =>
            {
                entity.ToTable("ticket_replies");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Admin)
                    .HasColumnName("admin")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Attachment)
                    .HasColumnName("attachment")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contactid)
                    .HasColumnName("contactid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Ticketid)
                    .HasColumnName("ticketid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Tickets>(entity =>
            {
                entity.HasKey(e => e.Ticketid)
                    .HasName("PRIMARY");

                entity.ToTable("tickets");

                entity.HasIndex(e => e.Contactid)
                    .HasName("contactid");

                entity.HasIndex(e => e.Department)
                    .HasName("department");

                entity.HasIndex(e => e.Priority)
                    .HasName("priority");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id");

                entity.HasIndex(e => e.Service)
                    .HasName("service");

                entity.HasIndex(e => e.Status)
                    .HasName("status");

                entity.HasIndex(e => e.Userid)
                    .HasName("userid");

                entity.Property(e => e.Ticketid)
                    .HasColumnName("ticketid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Admin)
                    .HasColumnName("admin")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Adminread)
                    .HasColumnName("adminread")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Adminreplying)
                    .HasColumnName("adminreplying")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Assigned)
                    .HasColumnName("assigned")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Clientread)
                    .HasColumnName("clientread")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contactid)
                    .HasColumnName("contactid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Lastreply)
                    .HasColumnName("lastreply")
                    .HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Service)
                    .HasColumnName("service")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Ticketkey)
                    .IsRequired()
                    .HasColumnName("ticketkey")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TicketsPipeLog>(entity =>
            {
                entity.ToTable("tickets_pipe_log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.EmailTo)
                    .IsRequired()
                    .HasColumnName("email_to")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<TicketsPredefinedReplies>(entity =>
            {
                entity.ToTable("tickets_predefined_replies");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Message)
                    .IsRequired()
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
            });

            modelBuilder.Entity<TicketsPriorities>(entity =>
            {
                entity.HasKey(e => e.Priorityid)
                    .HasName("PRIMARY");

                entity.ToTable("tickets_priorities");

                entity.Property(e => e.Priorityid)
                    .HasColumnName("priorityid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<TicketsStatus>(entity =>
            {
                entity.HasKey(e => e.Ticketstatusid)
                    .HasName("PRIMARY");

                entity.ToTable("tickets_status");

                entity.Property(e => e.Ticketstatusid)
                    .HasColumnName("ticketstatusid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Isdefault)
                    .HasColumnName("isdefault")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Statuscolor)
                    .HasColumnName("statuscolor")
                    .HasColumnType("varchar(7)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Statusorder)
                    .HasColumnName("statusorder")
                    .HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
