using Microsoft.EntityFrameworkCore;

namespace LeadService.Entities
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

        public virtual DbSet<LeadIntegrationEmails> LeadIntegrationEmails { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<LeadsEmailIntegration> LeadsEmailIntegration { get; set; }
        public virtual DbSet<LeadsSources> LeadsSources { get; set; }
        public virtual DbSet<LeadsStatus> LeadsStatus { get; set; }
        public virtual DbSet<WebToLead> WebToLead { get; set; }

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
            modelBuilder.Entity<LeadIntegrationEmails>(entity =>
            {
                entity.ToTable("lead_integration_emails");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Dateadded)
                    .HasColumnName("dateadded")
                    .HasColumnType("datetime");

                entity.Property(e => e.Emailid)
                    .HasColumnName("emailid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Leadid)
                    .HasColumnName("leadid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.ToTable("leads");

                entity.HasIndex(e => e.Assigned)
                    .HasName("assigned");

                entity.HasIndex(e => e.Company)
                    .HasName("company");

                entity.HasIndex(e => e.Dateadded)
                    .HasName("dateadded");

                entity.HasIndex(e => e.Email)
                    .HasName("email");

                entity.HasIndex(e => e.FromFormId)
                    .HasName("from_form_id");

                entity.HasIndex(e => e.Lastcontact)
                    .HasName("lastcontact");

                entity.HasIndex(e => e.Leadorder)
                    .HasName("leadorder");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.HasIndex(e => e.Source)
                    .HasName("source");

                entity.HasIndex(e => e.Status)
                    .HasName("status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addedfrom)
                    .HasColumnName("addedfrom")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Assigned)
                    .HasColumnName("assigned")
                    .HasColumnType("int(11)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateConverted)
                    .HasColumnName("date_converted")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dateadded)
                    .HasColumnName("dateadded")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dateassigned)
                    .HasColumnName("dateassigned")
                    .HasColumnType("date");

                entity.Property(e => e.DefaultLanguage)
                    .HasColumnName("default_language")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.EmailIntegrationUid)
                    .HasColumnName("email_integration_uid")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.FromFormId)
                    .HasColumnName("from_form_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Hash)
                    .HasColumnName("hash")
                    .HasColumnType("varchar(65)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.IsImportedFromEmailIntegration).HasColumnName("is_imported_from_email_integration");

                entity.Property(e => e.IsPublic).HasColumnName("is_public");

                entity.Property(e => e.Junk)
                    .HasColumnName("junk")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastLeadStatus)
                    .HasColumnName("last_lead_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastStatusChange)
                    .HasColumnName("last_status_change")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lastcontact)
                    .HasColumnName("lastcontact")
                    .HasColumnType("datetime");

                entity.Property(e => e.Leadorder)
                    .HasColumnName("leadorder")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Lost).HasColumnName("lost");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("phonenumber")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("int(11)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<LeadsEmailIntegration>(entity =>
            {
                entity.ToTable("leads_email_integration");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("the ID always must be 1");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CheckEvery)
                    .HasColumnName("check_every")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'5'");

                entity.Property(e => e.CreateTaskIfCustomer)
                    .HasColumnName("create_task_if_customer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeleteAfterImport)
                    .HasColumnName("delete_after_import")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Encryption)
                    .HasColumnName("encryption")
                    .HasColumnType("varchar(3)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Folder)
                    .IsRequired()
                    .HasColumnName("folder")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.ImapServer)
                    .IsRequired()
                    .HasColumnName("imap_server")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.LastRun)
                    .HasColumnName("last_run")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.LeadSource)
                    .HasColumnName("lead_source")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LeadStatus)
                    .HasColumnName("lead_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MarkPublic)
                    .HasColumnName("mark_public")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NotifyIds)
                    .HasColumnName("notify_ids")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.NotifyLeadContactMoreTimes)
                    .IsRequired()
                    .HasColumnName("notify_lead_contact_more_times")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NotifyLeadImported)
                    .IsRequired()
                    .HasColumnName("notify_lead_imported")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NotifyType)
                    .HasColumnName("notify_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.OnlyLoopOnUnseenEmails)
                    .IsRequired()
                    .HasColumnName("only_loop_on_unseen_emails")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Responsible)
                    .HasColumnName("responsible")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<LeadsSources>(entity =>
            {
                entity.ToTable("leads_sources");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<LeadsStatus>(entity =>
            {
                entity.ToTable("leads_status");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("varchar(10)")
                    .HasDefaultValueSql("'#28B8DA'")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Isdefault)
                    .HasColumnName("isdefault")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Statusorder)
                    .HasColumnName("statusorder")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<WebToLead>(entity =>
            {
                entity.ToTable("web_to_lead");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AllowDuplicate)
                    .HasColumnName("allow_duplicate")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CreateTaskOnDuplicate)
                    .HasColumnName("create_task_on_duplicate")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dateadded)
                    .HasColumnName("dateadded")
                    .HasColumnType("datetime");

                entity.Property(e => e.FormData)
                    .HasColumnName("form_data")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.FormKey)
                    .IsRequired()
                    .HasColumnName("form_key")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.LeadSource)
                    .HasColumnName("lead_source")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LeadStatus)
                    .HasColumnName("lead_status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MarkPublic)
                    .HasColumnName("mark_public")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.NotifyIds)
                    .HasColumnName("notify_ids")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.NotifyLeadImported)
                    .HasColumnName("notify_lead_imported")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NotifyType)
                    .HasColumnName("notify_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Recaptcha)
                    .HasColumnName("recaptcha")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Responsible)
                    .HasColumnName("responsible")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SubmitBtnName)
                    .HasColumnName("submit_btn_name")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.SuccessSubmitMsg)
                    .HasColumnName("success_submit_msg")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.TrackDuplicateField)
                    .HasColumnName("track_duplicate_field")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.TrackDuplicateFieldAnd)
                    .HasColumnName("track_duplicate_field_and")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
