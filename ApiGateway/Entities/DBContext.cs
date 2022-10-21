using Microsoft.EntityFrameworkCore;

namespace ApiGateway.Entities
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivityLog> ActivityLog { get; set; }
        public virtual DbSet<Announcements> Announcements { get; set; }
        public virtual DbSet<ArticleFeedback> ArticleFeedback { get; set; }
        public virtual DbSet<ArticleGroups> ArticleGroups { get; set; }
        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<ConsentPurposes> ConsentPurposes { get; set; }
        public virtual DbSet<Consents> Consents { get; set; }
        public virtual DbSet<ContactPermissions> ContactPermissions { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<ContractComments> ContractComments { get; set; }
        public virtual DbSet<ContractRenewals> ContractRenewals { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<ContractsTypes> ContractsTypes { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CreditNoteRefunds> CreditNoteRefunds { get; set; }
        public virtual DbSet<CreditNotes> CreditNotes { get; set; }
        public virtual DbSet<Credits> Credits { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<CustomFields> CustomFields { get; set; }
        public virtual DbSet<CustomFieldsValues> CustomFieldsValues { get; set; }
        public virtual DbSet<CustomerAdmins> CustomerAdmins { get; set; }
        public virtual DbSet<CustomerGroups> CustomerGroups { get; set; }
        public virtual DbSet<CustomersGroups> CustomersGroups { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<DismissedAnnouncements> DismissedAnnouncements { get; set; }
        public virtual DbSet<EmailTemplates> EmailTemplates { get; set; }
        public virtual DbSet<Estimates> Estimates { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<ExpensesCategories> ExpensesCategories { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<FormQuestionBox> FormQuestionBox { get; set; }
        public virtual DbSet<FormQuestionBoxDescription> FormQuestionBoxDescription { get; set; }
        public virtual DbSet<FormQuestions> FormQuestions { get; set; }
        public virtual DbSet<FormResults> FormResults { get; set; }
        public virtual DbSet<GdprRequests> GdprRequests { get; set; }
        public virtual DbSet<InvoicePaymentRecords> InvoicePaymentRecords { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<ItemTax> ItemTax { get; set; }
        public virtual DbSet<Itemable> Itemable { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<ItemsGroups> ItemsGroups { get; set; }
        public virtual DbSet<LeadActivityLog> LeadActivityLog { get; set; }
        public virtual DbSet<LeadIntegrationEmails> LeadIntegrationEmails { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<LeadsEmailIntegration> LeadsEmailIntegration { get; set; }
        public virtual DbSet<LeadsSources> LeadsSources { get; set; }
        public virtual DbSet<LeadsStatus> LeadsStatus { get; set; }
        public virtual DbSet<MailQueue> MailQueue { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<Milestones> Milestones { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<NewsfeedCommentLikes> NewsfeedCommentLikes { get; set; }
        public virtual DbSet<NewsfeedPostComments> NewsfeedPostComments { get; set; }
        public virtual DbSet<NewsfeedPostLikes> NewsfeedPostLikes { get; set; }
        public virtual DbSet<NewsfeedPosts> NewsfeedPosts { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Options> Options { get; set; }
        public virtual DbSet<PaymentModes> PaymentModes { get; set; }
        public virtual DbSet<PinnedProjects> PinnedProjects { get; set; }
        public virtual DbSet<ProjectActivity> ProjectActivity { get; set; }
        public virtual DbSet<ProjectDiscussionComments> ProjectDiscussionComments { get; set; }
        public virtual DbSet<ProjectDiscussions> ProjectDiscussions { get; set; }
        public virtual DbSet<ProjectFiles> ProjectFiles { get; set; }
        public virtual DbSet<ProjectMembers> ProjectMembers { get; set; }
        public virtual DbSet<ProjectNotes> ProjectNotes { get; set; }
        public virtual DbSet<ProjectSettings> ProjectSettings { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<ProposalComments> ProposalComments { get; set; }
        public virtual DbSet<Proposals> Proposals { get; set; }
        public virtual DbSet<RelatedItems> RelatedItems { get; set; }
        public virtual DbSet<Reminders> Reminders { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SalesActivity> SalesActivity { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<SharedCustomerFiles> SharedCustomerFiles { get; set; }
        public virtual DbSet<SpamFilters> SpamFilters { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }
        public virtual DbSet<Taggables> Taggables { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<TaskAssigned> TaskAssigned { get; set; }
        public virtual DbSet<TaskChecklistItems> TaskChecklistItems { get; set; }
        public virtual DbSet<TaskComments> TaskComments { get; set; }
        public virtual DbSet<TaskFollowers> TaskFollowers { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TasksChecklistTemplates> TasksChecklistTemplates { get; set; }
        public virtual DbSet<TasksTimers> TasksTimers { get; set; }
        public virtual DbSet<Taxes> Taxes { get; set; }
        public virtual DbSet<TicketAttachments> TicketAttachments { get; set; }
        public virtual DbSet<TicketReplies> TicketReplies { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<TicketsPipeLog> TicketsPipeLog { get; set; }
        public virtual DbSet<TicketsPredefinedReplies> TicketsPredefinedReplies { get; set; }
        public virtual DbSet<TicketsPriorities> TicketsPriorities { get; set; }
        public virtual DbSet<TicketsStatus> TicketsStatus { get; set; }
        public virtual DbSet<Todos> Todos { get; set; }
        public virtual DbSet<TrackedMails> TrackedMails { get; set; }
        public virtual DbSet<UserAutoLogin> UserAutoLogin { get; set; }
        public virtual DbSet<UserDepartments> UserDepartments { get; set; }
        public virtual DbSet<UserMeta> UserMeta { get; set; }
        public virtual DbSet<UserPermissions> UserPermissions { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vault> Vault { get; set; }
        public virtual DbSet<ViewsTracking> ViewsTracking { get; set; }
        public virtual DbSet<WebToLead> WebToLead { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user=root;password=password;database=jamfahcrm;convert zero datetime=True", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityLog>(entity =>
            {
                entity.ToTable("activity_log");

                entity.HasIndex(e => e.UserId)
                    .HasName("StaffId");

                entity.Property(e => e.ActivityLogId).HasColumnName("activity_log_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Announcements>(entity =>
            {
                entity.HasKey(e => e.AnnouncementId)
                    .HasName("PRIMARY");

                entity.ToTable("announcements");

                entity.Property(e => e.AnnouncementId).HasColumnName("announcement_id");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowName).HasColumnName("show_name");

                entity.Property(e => e.ShowToStaff).HasColumnName("show_to_staff");

                entity.Property(e => e.ShowToUsers).HasColumnName("show_to_users");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ArticleFeedback>(entity =>
            {
                entity.HasKey(e => e.ArticleAnswerId)
                    .HasName("PRIMARY");

                entity.ToTable("article_feedback");

                entity.Property(e => e.ArticleAnswerId).HasColumnName("article_answer_id");

                entity.Property(e => e.Answer).HasColumnName("answer");

                entity.Property(e => e.ArticleId).HasColumnName("article_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ArticleGroups>(entity =>
            {
                entity.HasKey(e => e.ArticleGroupId)
                    .HasName("PRIMARY");

                entity.ToTable("article_groups");

                entity.Property(e => e.ArticleGroupId).HasColumnName("article_group_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("varchar(10)")
                    .HasDefaultValueSql("'#28B8DA'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GroupOrder)
                    .HasColumnName("group_order")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GroupSlug)
                    .HasColumnName("group_slug")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Articles>(entity =>
            {
                entity.HasKey(e => e.ArticleId)
                    .HasName("PRIMARY");

                entity.ToTable("articles");

                entity.Property(e => e.ArticleId).HasColumnName("article_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.ArticleGroup).HasColumnName("article_group");

                entity.Property(e => e.ArticleOrder).HasColumnName("article_order");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StaffArticle).HasColumnName("staff_article");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("PRIMARY");

                entity.ToTable("clients");

                entity.HasIndex(e => e.Company)
                    .HasName("company");

                entity.HasIndex(e => e.Country)
                    .HasName("country");

                entity.HasIndex(e => e.LeadId)
                    .HasName("lead_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.AddedFrom).HasColumnName("added_from");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingCity)
                    .HasColumnName("billing_city")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingCountry)
                    .HasColumnName("billing_country")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BillingState)
                    .HasColumnName("billing_state")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingStreet)
                    .HasColumnName("billing_street")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingZip)
                    .HasColumnName("billing_zip")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DefaultCurrency).HasColumnName("default_currency");

                entity.Property(e => e.DefaultLanguage)
                    .HasColumnName("default_language")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("phonenumber")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RegistrationConfirmed)
                    .HasColumnName("registration_confirmed")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ShippingCity)
                    .HasColumnName("shipping_city")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingCountry)
                    .HasColumnName("shipping_country")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ShippingState)
                    .HasColumnName("shipping_state")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingStreet)
                    .HasColumnName("shipping_street")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingZip)
                    .HasColumnName("shipping_zip")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowPrimaryContact).HasColumnName("show_primary_contact");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StripeId)
                    .HasColumnName("stripe_id")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Vat)
                    .HasColumnName("vat")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ConsentPurposes>(entity =>
            {
                entity.ToTable("consent_purposes");

                entity.Property(e => e.ConsentPurposesId).HasColumnName("consent_purposes_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Consents>(entity =>
            {
                entity.HasKey(e => e.ConsentId)
                    .HasName("PRIMARY");

                entity.ToTable("consents");

                entity.HasIndex(e => e.ContactId)
                    .HasName("contact_id");

                entity.HasIndex(e => e.LeadId)
                    .HasName("lead_id");

                entity.HasIndex(e => e.PurposeId)
                    .HasName("purpose_id");

                entity.Property(e => e.ConsentId).HasColumnName("consent_id");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasColumnName("action")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.OptInPurposeDescription)
                    .HasColumnName("opt_in_purpose_description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PurposeId).HasColumnName("purpose_id");

                entity.Property(e => e.StaffName)
                    .HasColumnName("staff_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ContactPermissions>(entity =>
            {
                entity.ToTable("contact_permissions");

                entity.Property(e => e.ContactPermissionsId).HasColumnName("contact_permissions_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PRIMARY");

                entity.ToTable("contacts");

                entity.HasIndex(e => e.Email)
                    .HasName("email");

                entity.HasIndex(e => e.Firstname)
                    .HasName("firstname");

                entity.HasIndex(e => e.IsPrimary)
                    .HasName("is_primary");

                entity.HasIndex(e => e.Lastname)
                    .HasName("lastname");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ContractEmails)
                    .IsRequired()
                    .HasColumnName("contract_emails")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CreditNoteEmails)
                    .IsRequired()
                    .HasColumnName("credit_note_emails")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasColumnType("datetime");

                entity.Property(e => e.Direction)
                    .HasColumnName("direction")
                    .HasColumnType("varchar(3)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailVerificationKey)
                    .HasColumnName("email_verification_key")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailVerificationSentAt)
                    .HasColumnName("email_verification_sent_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailVerifiedAt)
                    .HasColumnName("email_verified_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.EstimateEmails)
                    .IsRequired()
                    .HasColumnName("estimate_emails")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InvoiceEmails)
                    .IsRequired()
                    .HasColumnName("invoice_emails")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsPrimary)
                    .HasColumnName("is_primary")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LastId)
                    .HasColumnName("last_id")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("last_login")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChange)
                    .HasColumnName("last_password_change")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NewPassKey)
                    .HasColumnName("new_pass_key")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NewPassKeyRequest)
                    .HasColumnName("new_pass_key_request")
                    .HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phone_number")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProfileImage)
                    .HasColumnName("profile_image")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectEmails)
                    .IsRequired()
                    .HasColumnName("project_emails")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TaskEmails)
                    .IsRequired()
                    .HasColumnName("task_emails")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TicketEmails)
                    .IsRequired()
                    .HasColumnName("ticket_emails")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<ContractComments>(entity =>
            {
                entity.HasKey(e => e.ContractCommentId)
                    .HasName("PRIMARY");

                entity.ToTable("contract_comments");

                entity.Property(e => e.ContractCommentId).HasColumnName("contract_comment_id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<ContractRenewals>(entity =>
            {
                entity.ToTable("contract_renewals");

                entity.Property(e => e.ContractRenewalsId).HasColumnName("contract_renewals_id");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.DateRenewed)
                    .HasColumnName("date_renewed")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsOnOldExpiryNotified)
                    .HasColumnName("is_on_old_expiry_notified")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NewEndDate)
                    .HasColumnName("new_end_date")
                    .HasColumnType("date");

                entity.Property(e => e.NewStartDate)
                    .HasColumnName("new_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.NewValue)
                    .HasColumnName("new_value")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.OldEndDate)
                    .HasColumnName("old_end_date")
                    .HasColumnType("date");

                entity.Property(e => e.OldStartDate)
                    .HasColumnName("old_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.OldValue)
                    .HasColumnName("old_value")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.RenewedBy)
                    .IsRequired()
                    .HasColumnName("renewed_by")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RenewedByStaffId).HasColumnName("renewed_by_staff_id");
            });

            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.HasKey(e => e.ContractId)
                    .HasName("PRIMARY");

                entity.ToTable("contracts");

                entity.HasIndex(e => e.Client)
                    .HasName("client");

                entity.HasIndex(e => e.ContractType)
                    .HasName("contract_type");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.AcceptanceDate)
                    .HasColumnName("acceptance_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AcceptanceEmail)
                    .HasColumnName("acceptance_email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AcceptanceFirstname)
                    .HasColumnName("acceptance_firstname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AcceptanceIp)
                    .HasColumnName("acceptance_ip")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AcceptanceLastname)
                    .HasColumnName("acceptance_lastname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AddedFrom).HasColumnName("added_from");

                entity.Property(e => e.Client).HasColumnName("client");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractType).HasColumnName("contract_type");

                entity.Property(e => e.ContractValue)
                    .HasColumnName("contract_value")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateEnd)
                    .HasColumnName("date_end")
                    .HasColumnType("date");

                entity.Property(e => e.DateStart)
                    .HasColumnName("date_start")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Hash)
                    .HasColumnName("hash")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsExpiryNotified).HasColumnName("is_expiry_notified");

                entity.Property(e => e.NotVisibleToClient).HasColumnName("not_visible_to_client");

                entity.Property(e => e.Signature)
                    .HasColumnName("signature")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Signed).HasColumnName("signed");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Trash)
                    .HasColumnName("trash")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ContractsTypes>(entity =>
            {
                entity.HasKey(e => e.ContractsTypeId)
                    .HasName("PRIMARY");

                entity.ToTable("contracts_types");

                entity.Property(e => e.ContractsTypeId).HasColumnName("contracts_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PRIMARY");

                entity.ToTable("countries");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CallingCode)
                    .HasColumnName("calling_code")
                    .HasColumnType("varchar(8)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cctld)
                    .HasColumnName("cctld")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(6)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Iso2)
                    .HasColumnName("iso2")
                    .HasColumnType("char(2)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Iso3)
                    .HasColumnName("iso3")
                    .HasColumnType("char(3)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LongName)
                    .IsRequired()
                    .HasColumnName("long_name")
                    .HasColumnType("varchar(80)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasColumnName("short_name")
                    .HasColumnType("varchar(80)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UnMember)
                    .HasColumnName("un_member")
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CreditNoteRefunds>(entity =>
            {
                entity.HasKey(e => e.CreditNoteRefundId)
                    .HasName("PRIMARY");

                entity.ToTable("credit_note_refunds");

                entity.Property(e => e.CreditNoteRefundId).HasColumnName("credit_note_refund_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreditNoteId).HasColumnName("credit_note_id");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasColumnName("payment_mode")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RefundedOn)
                    .HasColumnName("refunded_on")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CreditNotes>(entity =>
            {
                entity.HasKey(e => e.CreditNoteId)
                    .HasName("PRIMARY");

                entity.ToTable("credit_notes");

                entity.HasIndex(e => e.ClientId)
                    .HasName("client_id");

                entity.HasIndex(e => e.Currency)
                    .HasName("currency");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id");

                entity.Property(e => e.CreditNoteId).HasColumnName("credit_note_id");

                entity.Property(e => e.AddedFrom).HasColumnName("added_from");

                entity.Property(e => e.Adjustment)
                    .HasColumnName("adjustment")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.AdminNote)
                    .HasColumnName("admin_note")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingCity)
                    .HasColumnName("billing_city")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingCountry).HasColumnName("billing_country");

                entity.Property(e => e.BillingState)
                    .HasColumnName("billing_state")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingStreet)
                    .HasColumnName("billing_street")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingZip)
                    .HasColumnName("billing_zip")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ClientNote)
                    .HasColumnName("client_note")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Currency).HasColumnName("currency");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedCustomerName)
                    .HasColumnName("deleted_customer_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DiscountPercent)
                    .HasColumnName("discount_percent")
                    .HasColumnType("decimal(15,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountTotal)
                    .HasColumnName("discount_total")
                    .HasColumnType("decimal(15,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountType)
                    .IsRequired()
                    .HasColumnName("discount_type")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IncludeShipping).HasColumnName("include_shipping");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.NumberFormat)
                    .HasColumnName("number_format")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Prefix)
                    .HasColumnName("prefix")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.ReferenceNo)
                    .HasColumnName("reference_no")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingCity)
                    .HasColumnName("shipping_city")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingCountry).HasColumnName("shipping_country");

                entity.Property(e => e.ShippingState)
                    .HasColumnName("shipping_state")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingStreet)
                    .HasColumnName("shipping_street")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingZip)
                    .HasColumnName("shipping_zip")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowQuantityAs)
                    .HasColumnName("show_quantity_as")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ShowShippingOnCreditNote)
                    .IsRequired()
                    .HasColumnName("show_shipping_on_credit_note")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Terms)
                    .HasColumnName("terms")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.TotalTax)
                    .HasColumnName("total_tax")
                    .HasColumnType("decimal(15,2)");
            });

            modelBuilder.Entity<Credits>(entity =>
            {
                entity.ToTable("credits");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.CreditId).HasColumnName("credit_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DateApplied)
                    .HasColumnName("date_applied")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.HasKey(e => e.CurrencyId)
                    .HasName("PRIMARY");

                entity.ToTable("currencies");

                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");

                entity.Property(e => e.DecimalSeparator)
                    .HasColumnName("decimal_separator")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Placement)
                    .HasColumnName("placement")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasColumnName("symbol")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ThousandSeparator)
                    .HasColumnName("thousand_separator")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CustomFields>(entity =>
            {
                entity.HasKey(e => e.CustomFieldId)
                    .HasName("PRIMARY");

                entity.ToTable("custom_fields");

                entity.Property(e => e.CustomFieldId).HasColumnName("custom_field_id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.BsColumn)
                    .HasColumnName("bs_column")
                    .HasDefaultValueSql("'12'");

                entity.Property(e => e.DisalowClientToEdit).HasColumnName("disalow_client_to_edit");

                entity.Property(e => e.DisplayInline).HasColumnName("display_inline");

                entity.Property(e => e.FieldOrder)
                    .HasColumnName("field_order")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FieldTo)
                    .IsRequired()
                    .HasColumnName("field_to")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OnlyAdmin).HasColumnName("only_admin");

                entity.Property(e => e.Options)
                    .HasColumnName("options")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Required).HasColumnName("required");

                entity.Property(e => e.ShowOnClientPortal).HasColumnName("show_on_client_portal");

                entity.Property(e => e.ShowOnPdf).HasColumnName("show_on_pdf");

                entity.Property(e => e.ShowOnTable).HasColumnName("show_on_table");

                entity.Property(e => e.ShowOnTicketForm).HasColumnName("show_on_ticket_form");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CustomFieldsValues>(entity =>
            {
                entity.ToTable("custom_fields_values");

                entity.HasIndex(e => e.FieldId)
                    .HasName("field_id");

                entity.HasIndex(e => e.FieldTo)
                    .HasName("field_to");

                entity.HasIndex(e => e.RelId)
                    .HasName("rel_id");

                entity.Property(e => e.FieldId).HasColumnName("field_id");

                entity.Property(e => e.FieldTo)
                    .IsRequired()
                    .HasColumnName("field_to")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<CustomerAdmins>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("customer_admins");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("customer_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("StaffId");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DateAssigned)
                    .HasColumnName("date_assigned")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CustomerGroups>(entity =>
            {
                entity.ToTable("customer_groups");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("customer_id");

                entity.HasIndex(e => e.GroupId)
                    .HasName("group_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");
            });

            modelBuilder.Entity<CustomersGroups>(entity =>
            {
                entity.HasKey(e => e.CustomersGroupId)
                    .HasName("PRIMARY");

                entity.ToTable("customers_groups");

                entity.HasIndex(e => e.Name)
                    .HasName("Name");

                entity.Property(e => e.CustomersGroupId).HasColumnName("customers_group_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PRIMARY");

                entity.ToTable("departments");

                entity.HasIndex(e => e.Name)
                    .HasName("Name");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.CalendarId)
                    .HasColumnName("calendar_id")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeleteAfterImport).HasColumnName("delete_after_import");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailFromHeader).HasColumnName("email_from_header");

                entity.Property(e => e.Encryption)
                    .HasColumnName("encryption")
                    .HasColumnType("varchar(3)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HideFromClient).HasColumnName("hide_from_client");

                entity.Property(e => e.Host)
                    .HasColumnName("host")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImapUsername)
                    .HasColumnName("imap_username")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<DismissedAnnouncements>(entity =>
            {
                entity.HasKey(e => e.DismissedAnnouncementId)
                    .HasName("PRIMARY");

                entity.ToTable("dismissed_announcements");

                entity.HasIndex(e => e.AnnouncementId)
                    .HasName("AnnouncementId");

                entity.HasIndex(e => e.Staff)
                    .HasName("staff");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.DismissedAnnouncementId).HasColumnName("dismissed_announcement_id");

                entity.Property(e => e.AnnouncementId).HasColumnName("announcement_id");

                entity.Property(e => e.Staff).HasColumnName("staff");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<EmailTemplates>(entity =>
            {
                entity.HasKey(e => e.EmaiLtemplateId)
                    .HasName("PRIMARY");

                entity.ToTable("email_templates");

                entity.Property(e => e.EmaiLtemplateId).HasColumnName("emai_ltemplate_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.FromEmail)
                    .HasColumnName("from_email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FromName)
                    .IsRequired()
                    .HasColumnName("from_name")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Plaintext).HasColumnName("plaintext");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Estimates>(entity =>
            {
                entity.HasKey(e => e.EstimateId)
                    .HasName("PRIMARY");

                entity.ToTable("estimates");

                entity.HasIndex(e => e.ClientId)
                    .HasName("client_id");

                entity.HasIndex(e => e.Currency)
                    .HasName("currency");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id");

                entity.HasIndex(e => e.SaleAgent)
                    .HasName("sale_agent");

                entity.Property(e => e.EstimateId).HasColumnName("estimate_id");

                entity.Property(e => e.AcceptanceDate)
                    .HasColumnName("acceptance_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AcceptanceEmail)
                    .HasColumnName("acceptance_email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AcceptanceFirstname)
                    .HasColumnName("acceptance_firstname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AcceptanceIp)
                    .HasColumnName("acceptance_ip")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AcceptanceLastname)
                    .HasColumnName("acceptance_lastname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AddedFrom).HasColumnName("added_from");

                entity.Property(e => e.Adjustment)
                    .HasColumnName("adjustment")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.AdminNote)
                    .HasColumnName("admin_note")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingCity)
                    .HasColumnName("billing_city")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingCountry).HasColumnName("billing_country");

                entity.Property(e => e.BillingState)
                    .HasColumnName("billing_state")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingStreet)
                    .HasColumnName("billing_street")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingZip)
                    .HasColumnName("billing_zip")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ClientNote)
                    .HasColumnName("client_note")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Currency).HasColumnName("currency");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateSend)
                    .HasColumnName("date_send")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedCustomerName)
                    .HasColumnName("deleted_customer_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DiscountPercent)
                    .HasColumnName("discount_percent")
                    .HasColumnType("decimal(15,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountTotal)
                    .HasColumnName("discount_total")
                    .HasColumnType("decimal(15,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountType)
                    .HasColumnName("discount_type")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("expiry_date")
                    .HasColumnType("date");

                entity.Property(e => e.Hash)
                    .HasColumnName("hash")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IncludeShipping).HasColumnName("include_shipping");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.InvoicedDate)
                    .HasColumnName("invoiced_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsExpiryNotified).HasColumnName("is_expiry_notified");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.NumberFormat).HasColumnName("number_format");

                entity.Property(e => e.PipelineOrder).HasColumnName("pipeline_order");

                entity.Property(e => e.Prefix)
                    .HasColumnName("prefix")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.ReferenceNo)
                    .HasColumnName("reference_no")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SaleAgent).HasColumnName("sale_agent");

                entity.Property(e => e.Sent).HasColumnName("sent");

                entity.Property(e => e.ShippingCity)
                    .HasColumnName("shipping_city")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingCountry).HasColumnName("shipping_country");

                entity.Property(e => e.ShippingState)
                    .HasColumnName("shipping_state")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingStreet)
                    .HasColumnName("shipping_street")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingZip)
                    .HasColumnName("shipping_zip")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowQuantityAs)
                    .HasColumnName("show_quantity_as")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ShowShippingOnEstimate)
                    .IsRequired()
                    .HasColumnName("show_shipping_on_estimate")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Signature)
                    .HasColumnName("signature")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Terms)
                    .HasColumnName("terms")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.TotalTax)
                    .HasColumnName("total_tax")
                    .HasColumnType("decimal(15,2)");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PRIMARY");

                entity.ToTable("events");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.End)
                    .HasColumnName("end")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsStartNotified).HasColumnName("is_start_notified");

                entity.Property(e => e.Public).HasColumnName("public");

                entity.Property(e => e.ReminderBefore).HasColumnName("reminder_before");

                entity.Property(e => e.ReminderBeforeType)
                    .HasColumnName("reminder_before_type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Start)
                    .HasColumnName("start")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.HasKey(e => e.ExpenseId)
                    .HasName("PRIMARY");

                entity.ToTable("expenses");

                entity.HasIndex(e => e.Category)
                    .HasName("category");

                entity.HasIndex(e => e.ClientId)
                    .HasName("client_id");

                entity.HasIndex(e => e.Currency)
                    .HasName("currency");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id");

                entity.Property(e => e.ExpenseId).HasColumnName("expense_id");

                entity.Property(e => e.AddedFrom).HasColumnName("added_from");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Billable)
                    .HasColumnName("billable")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CreateInvoiceBillable).HasColumnName("create_invoice_billable");

                entity.Property(e => e.Currency).HasColumnName("currency");

                entity.Property(e => e.CustomRecurring).HasColumnName("custom_recurring");

                entity.Property(e => e.Cycles).HasColumnName("cycles");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpenseName)
                    .HasColumnName("expense_name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.LastRecurringDate)
                    .HasColumnName("last_recurring_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PaymentMode)
                    .HasColumnName("payment_mode")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Recurring).HasColumnName("recurring");

                entity.Property(e => e.RecurringFrom).HasColumnName("recurring_from");

                entity.Property(e => e.RecurringType)
                    .HasColumnName("recurring_type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReferenceNo)
                    .HasColumnName("reference_no")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RepeatEvery).HasColumnName("repeat_every");

                entity.Property(e => e.SendInvoiceToCustomer).HasColumnName("send_invoice_to_customer");

                entity.Property(e => e.Tax).HasColumnName("tax");

                entity.Property(e => e.Tax2).HasColumnName("tax2");

                entity.Property(e => e.TotalCycles).HasColumnName("total_cycles");
            });

            modelBuilder.Entity<ExpensesCategories>(entity =>
            {
                entity.ToTable("expenses_categories");

                entity.Property(e => e.ExpensesCategoriesId).HasColumnName("expenses_categories_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PRIMARY");

                entity.ToTable("files");

                entity.HasIndex(e => e.RelId)
                    .HasName("rel_id");

                entity.HasIndex(e => e.RelType)
                    .HasName("rel_type");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.AttachmentKey)
                    .HasColumnName("attachment_key")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContactId)
                    .HasColumnName("contact_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.External)
                    .HasColumnName("external")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExternalLink)
                    .HasColumnName("external_link")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Filetype)
                    .HasColumnName("filetype")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TaskCommentId).HasColumnName("task_comment_id");

                entity.Property(e => e.ThumbnailLink)
                    .HasColumnName("thumbnail_link")
                    .HasColumnType("text")
                    .HasComment("For external usage")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VisibleToCustomer).HasColumnName("visible_to_customer");
            });

            modelBuilder.Entity<FormQuestionBox>(entity =>
            {
                entity.HasKey(e => e.BoxId)
                    .HasName("PRIMARY");

                entity.ToTable("form_question_box");

                entity.Property(e => e.BoxId).HasColumnName("box_id");

                entity.Property(e => e.BoxType)
                    .IsRequired()
                    .HasColumnName("box_type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");
            });

            modelBuilder.Entity<FormQuestionBoxDescription>(entity =>
            {
                entity.HasKey(e => e.QuestionBoxDescriptionId)
                    .HasName("PRIMARY");

                entity.ToTable("form_question_box_description");

                entity.Property(e => e.QuestionBoxDescriptionId).HasColumnName("question_box_description_id");

                entity.Property(e => e.BoxId)
                    .IsRequired()
                    .HasColumnName("box_id")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");
            });

            modelBuilder.Entity<FormQuestions>(entity =>
            {
                entity.HasKey(e => e.FormQuestionId)
                    .HasName("PRIMARY");

                entity.ToTable("form_questions");

                entity.Property(e => e.FormQuestionId).HasColumnName("form_question_id");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnName("question")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QuestionOrder).HasColumnName("question_order");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Required).HasColumnName("required");
            });

            modelBuilder.Entity<FormResults>(entity =>
            {
                entity.HasKey(e => e.FormResultId)
                    .HasName("PRIMARY");

                entity.ToTable("form_results");

                entity.Property(e => e.FormResultId).HasColumnName("form_result_id");

                entity.Property(e => e.Answer)
                    .HasColumnName("answer")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BoxDescriptionId).HasColumnName("box_description_id");

                entity.Property(e => e.BoxId).HasColumnName("box_id");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Resultsetid).HasColumnName("resultsetid");
            });

            modelBuilder.Entity<GdprRequests>(entity =>
            {
                entity.HasKey(e => e.GdprRequestId)
                    .HasName("PRIMARY");

                entity.ToTable("gdpr_requests");

                entity.Property(e => e.GdprRequestId).HasColumnName("gdpr_request_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.RequestDate)
                    .HasColumnName("request_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RequestFrom)
                    .HasColumnName("request_from")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RequestType)
                    .HasColumnName("request_type")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<InvoicePaymentRecords>(entity =>
            {
                entity.ToTable("invoice_payment_records");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("invoice_id");

                entity.HasIndex(e => e.PaymentMethod)
                    .HasName("payment_method");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DateRecorded)
                    .HasColumnName("date_recorded")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PaymentMethod)
                    .HasColumnName("payment_method")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PaymentMode)
                    .HasColumnName("payment_mode")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("transaction_id")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("PRIMARY");

                entity.ToTable("invoices");

                entity.HasIndex(e => e.ClientId)
                    .HasName("client_id");

                entity.HasIndex(e => e.Currency)
                    .HasName("currency");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id");

                entity.HasIndex(e => e.SaleAgent)
                    .HasName("sale_agent");

                entity.HasIndex(e => e.Total)
                    .HasName("total");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.AddedFrom).HasColumnName("added_from");

                entity.Property(e => e.Adjustment)
                    .HasColumnName("adjustment")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.AdminNote)
                    .HasColumnName("admin_note")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AllowedPaymentModes)
                    .HasColumnName("allowed_payment_modes")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingCity)
                    .HasColumnName("billing_city")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingCountry).HasColumnName("billing_country");

                entity.Property(e => e.BillingState)
                    .HasColumnName("billing_state")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingStreet)
                    .HasColumnName("billing_street")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BillingZip)
                    .HasColumnName("billing_zip")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CancelOverdueReminders).HasColumnName("cancel_overdue_reminders");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ClientNote)
                    .HasColumnName("client_note")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Currency).HasColumnName("currency");

                entity.Property(e => e.CustomRecurring).HasColumnName("custom_recurring");

                entity.Property(e => e.Cycles).HasColumnName("cycles");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateSend)
                    .HasColumnName("date_send")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedCustomerName)
                    .HasColumnName("deleted_customer_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DiscountPercent)
                    .HasColumnName("discount_percent")
                    .HasColumnType("decimal(15,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountTotal)
                    .HasColumnName("discount_total")
                    .HasColumnType("decimal(15,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.DiscountType)
                    .IsRequired()
                    .HasColumnName("discount_type")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasColumnName("hash")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IncludeShipping).HasColumnName("include_shipping");

                entity.Property(e => e.IsRecurringFrom).HasColumnName("is_recurring_from");

                entity.Property(e => e.LastOverdueReminder)
                    .HasColumnName("last_overdue_reminder")
                    .HasColumnType("date");

                entity.Property(e => e.LastRecurringDate)
                    .HasColumnName("last_recurring_date")
                    .HasColumnType("date");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.NumberFormat).HasColumnName("number_format");

                entity.Property(e => e.Prefix)
                    .HasColumnName("prefix")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Recurring).HasColumnName("recurring");

                entity.Property(e => e.RecurringType)
                    .HasColumnName("recurring_type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SaleAgent).HasColumnName("sale_agent");

                entity.Property(e => e.Sent).HasColumnName("sent");

                entity.Property(e => e.ShippingCity)
                    .HasColumnName("shipping_city")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingCountry).HasColumnName("shipping_country");

                entity.Property(e => e.ShippingState)
                    .HasColumnName("shipping_state")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingStreet)
                    .HasColumnName("shipping_street")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingZip)
                    .HasColumnName("shipping_zip")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowQuantityAs)
                    .HasColumnName("show_quantity_as")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ShowShippingOnInvoice)
                    .IsRequired()
                    .HasColumnName("show_shipping_on_invoice")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SubscriptionId).HasColumnName("subscription_id");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Terms)
                    .HasColumnName("terms")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.TotalCycles).HasColumnName("total_cycles");

                entity.Property(e => e.TotalTax)
                    .HasColumnName("total_tax")
                    .HasColumnType("decimal(15,2)");
            });

            modelBuilder.Entity<ItemTax>(entity =>
            {
                entity.ToTable("item_tax");

                entity.HasIndex(e => e.Itemid)
                    .HasName("itemid");

                entity.Property(e => e.ItemTaxId).HasColumnName("item_tax_id");

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TaxName)
                    .IsRequired()
                    .HasColumnName("tax_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("tax_rate")
                    .HasColumnType("decimal(15,2)");
            });

            modelBuilder.Entity<Itemable>(entity =>
            {
                entity.ToTable("itemable");

                entity.HasIndex(e => e.Qty)
                    .HasName("qty");

                entity.HasIndex(e => e.Rate)
                    .HasName("rate");

                entity.HasIndex(e => e.RelId)
                    .HasName("rel_id");

                entity.HasIndex(e => e.RelType)
                    .HasName("rel_type");

                entity.Property(e => e.ItemableId).HasColumnName("itemable_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ItemOrder).HasColumnName("item_order");

                entity.Property(e => e.LongDescription)
                    .HasColumnName("long_description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.ToTable("items");

                entity.HasIndex(e => e.GroupId)
                    .HasName("group_id");

                entity.HasIndex(e => e.Tax)
                    .HasName("tax");

                entity.HasIndex(e => e.Tax2)
                    .HasName("tax2");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.LongDescription)
                    .HasColumnName("long_description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Tax).HasColumnName("tax");

                entity.Property(e => e.Tax2).HasColumnName("tax2");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ItemsGroups>(entity =>
            {
                entity.HasKey(e => e.ItemsGroupId)
                    .HasName("PRIMARY");

                entity.ToTable("items_groups");

                entity.Property(e => e.ItemsGroupId).HasColumnName("items_group_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<LeadActivityLog>(entity =>
            {
                entity.ToTable("lead_activity_log");

                entity.Property(e => e.LeadActivityLogId).HasColumnName("lead_activity_log_id");

                entity.Property(e => e.AdditionalData)
                    .HasColumnName("additional_data")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustomActivity).HasColumnName("custom_activity");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<LeadIntegrationEmails>(entity =>
            {
                entity.ToTable("lead_integration_emails");

                entity.Property(e => e.LeadIntegrationEmailsId).HasColumnName("lead_integration_emails_id");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailId).HasColumnName("email_id");

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.HasKey(e => e.LeadId)
                    .HasName("PRIMARY");

                entity.ToTable("leads");

                entity.HasIndex(e => e.Assigned)
                    .HasName("assigned");

                entity.HasIndex(e => e.Company)
                    .HasName("company");

                entity.HasIndex(e => e.DateAdded)
                    .HasName("date_added");

                entity.HasIndex(e => e.Email)
                    .HasName("email");

                entity.HasIndex(e => e.FromFormId)
                    .HasName("from_form_id");

                entity.HasIndex(e => e.LastContact)
                    .HasName("last_contact");

                entity.HasIndex(e => e.LeadOrder)
                    .HasName("lead_order");

                entity.HasIndex(e => e.Name)
                    .HasName("Name");

                entity.HasIndex(e => e.Source)
                    .HasName("source");

                entity.HasIndex(e => e.Status)
                    .HasName("status");

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.AddedFrom).HasColumnName("added_from");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Assigned).HasColumnName("assigned");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateAssigned)
                    .HasColumnName("date_assigned")
                    .HasColumnType("date");

                entity.Property(e => e.DateConverted)
                    .HasColumnName("date_converted")
                    .HasColumnType("datetime");

                entity.Property(e => e.DefaultLanguage)
                    .HasColumnName("default_language")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailIntegrationUid)
                    .HasColumnName("email_integration_uid")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FromFormId).HasColumnName("from_form_id");

                entity.Property(e => e.Hash)
                    .HasColumnName("hash")
                    .HasColumnType("varchar(65)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsImportedFromEmailIntegration).HasColumnName("is_imported_from_email_integration");

                entity.Property(e => e.IsPublic).HasColumnName("is_public");

                entity.Property(e => e.Junk).HasColumnName("junk");

                entity.Property(e => e.LastContact)
                    .HasColumnName("last_contact")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastLeadStatus).HasColumnName("last_lead_status");

                entity.Property(e => e.LastStatusChange)
                    .HasColumnName("last_status_change")
                    .HasColumnType("datetime");

                entity.Property(e => e.LeadOrder)
                    .HasColumnName("lead_order")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Lost).HasColumnName("lost");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("phonenumber")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<LeadsEmailIntegration>(entity =>
            {
                entity.ToTable("leads_email_integration");

                entity.Property(e => e.LeadsEmailIntegrationId)
                    .HasColumnName("leads_email_integration_id")
                    .HasComment("the ID always must be 1");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CheckEvery)
                    .HasColumnName("check_every")
                    .HasDefaultValueSql("'5'");

                entity.Property(e => e.CreateTaskIfCustomer).HasColumnName("create_task_if_customer");

                entity.Property(e => e.DeleteAfterImport).HasColumnName("delete_after_import");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Encryption)
                    .HasColumnName("encryption")
                    .HasColumnType("varchar(3)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Folder)
                    .IsRequired()
                    .HasColumnName("folder")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ImapServer)
                    .IsRequired()
                    .HasColumnName("imap_server")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastRun)
                    .HasColumnName("last_run")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LeadSource).HasColumnName("lead_source");

                entity.Property(e => e.LeadStatus).HasColumnName("lead_status");

                entity.Property(e => e.MarkPublic).HasColumnName("mark_public");

                entity.Property(e => e.NotifyIds)
                    .HasColumnName("notify_ids")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

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
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OnlyLoopOnUnseenEmails)
                    .IsRequired()
                    .HasColumnName("only_loop_on_unseen_emails")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Responsible).HasColumnName("responsible");
            });

            modelBuilder.Entity<LeadsSources>(entity =>
            {
                entity.HasKey(e => e.LeadsSources1)
                    .HasName("PRIMARY");

                entity.ToTable("leads_sources");

                entity.HasIndex(e => e.Name)
                    .HasName("Name");

                entity.Property(e => e.LeadsSources1).HasColumnName("leads_sources");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<LeadsStatus>(entity =>
            {
                entity.ToTable("leads_status");

                entity.HasIndex(e => e.Name)
                    .HasName("Name");

                entity.Property(e => e.LeadsStatusId).HasColumnName("leads_status_id");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("varchar(10)")
                    .HasDefaultValueSql("'#28B8DA'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StatusOrder).HasColumnName("status_order");
            });

            modelBuilder.Entity<MailQueue>(entity =>
            {
                entity.ToTable("mail_queue");

                entity.Property(e => e.MailQueueId).HasColumnName("mail_queue_id");

                entity.Property(e => e.AltMessage)
                    .HasColumnName("alt_message")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Attachments)
                    .HasColumnName("attachments")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Bcc)
                    .HasColumnName("bcc")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cc)
                    .HasColumnName("cc")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Engine)
                    .HasColumnName("engine")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Headers)
                    .HasColumnName("headers")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("enum('pending','sending','sent','failed')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("migrations");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<Milestones>(entity =>
            {
                entity.HasKey(e => e.MilestoneId)
                    .HasName("PRIMARY");

                entity.ToTable("milestones");

                entity.Property(e => e.MilestoneId).HasColumnName("milestone_id");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DescriptionVisibleToCustomer)
                    .HasColumnName("description_visible_to_customer")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("date");

                entity.Property(e => e.MilestoneOrder).HasColumnName("milestone_order");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");
            });

            modelBuilder.Entity<Modules>(entity =>
            {
                entity.HasKey(e => e.ModuleId)
                    .HasName("PRIMARY");

                entity.ToTable("modules");

                entity.Property(e => e.ModuleId).HasColumnName("module_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.InstalledVersion)
                    .IsRequired()
                    .HasColumnName("installed_version")
                    .HasColumnType("varchar(11)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasColumnName("module_name")
                    .HasColumnType("varchar(55)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<NewsfeedCommentLikes>(entity =>
            {
                entity.ToTable("newsfeed_comment_likes");

                entity.Property(e => e.NewsfeedCommentLikesId).HasColumnName("newsfeed_comment_likes_id");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.DateLiked)
                    .HasColumnName("date_liked")
                    .HasColumnType("datetime");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<NewsfeedPostComments>(entity =>
            {
                entity.HasKey(e => e.NewsfeedPostCommentId)
                    .HasName("PRIMARY");

                entity.ToTable("newsfeed_post_comments");

                entity.Property(e => e.NewsfeedPostCommentId).HasColumnName("newsfeed_post_comment_id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<NewsfeedPostLikes>(entity =>
            {
                entity.ToTable("newsfeed_post_likes");

                entity.Property(e => e.DateLiked)
                    .HasColumnName("date_liked")
                    .HasColumnType("datetime");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<NewsfeedPosts>(entity =>
            {
                entity.ToTable("newsfeed_posts");

                entity.Property(e => e.NewsfeedPostsId).HasColumnName("newsfeed_posts_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Creator).HasColumnName("creator");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatePinned)
                    .HasColumnName("date_pinned")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pinned).HasColumnName("pinned");

                entity.Property(e => e.Visibility)
                    .IsRequired()
                    .HasColumnName("visibility")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.HasKey(e => e.NoteId)
                    .HasName("PRIMARY");

                entity.ToTable("notes");

                entity.HasIndex(e => e.RelId)
                    .HasName("rel_id");

                entity.HasIndex(e => e.RelType)
                    .HasName("rel_type");

                entity.Property(e => e.NoteId).HasColumnName("note_id");

                entity.Property(e => e.AddedFrom).HasColumnName("added_from");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateContacted)
                    .HasColumnName("date_contacted")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.HasKey(e => e.NotificationId)
                    .HasName("PRIMARY");

                entity.ToTable("notifications");

                entity.Property(e => e.NotificationId).HasColumnName("notification_id");

                entity.Property(e => e.AdditionalData)
                    .HasColumnName("additional_data")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FromClientId).HasColumnName("from_client_id");

                entity.Property(e => e.FromCompany).HasColumnName("from_company");

                entity.Property(e => e.FromFullname)
                    .IsRequired()
                    .HasColumnName("from_fullname")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FromUserId).HasColumnName("from_user_id");

                entity.Property(e => e.Isread).HasColumnName("isread");

                entity.Property(e => e.IsreadInline).HasColumnName("isread_inline");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ToUserId).HasColumnName("to_user_id");
            });

            modelBuilder.Entity<Options>(entity =>
            {
                entity.HasKey(e => e.OptionId)
                    .HasName("PRIMARY");

                entity.ToTable("options");

                entity.HasIndex(e => e.Name)
                    .HasName("Name");

                entity.Property(e => e.OptionId).HasColumnName("option_id");

                entity.Property(e => e.Autoload)
                    .HasColumnName("autoload")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Section)
                    .HasColumnName("section")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<PaymentModes>(entity =>
            {
                entity.HasKey(e => e.PaymentModeId)
                    .HasName("PRIMARY");

                entity.ToTable("payment_modes");

                entity.Property(e => e.PaymentModeId).HasColumnName("payment_mode_id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExpensesOnly).HasColumnName("expenses_only");

                entity.Property(e => e.InvoicesOnly).HasColumnName("invoices_only");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SelectedByDefault)
                    .HasColumnName("selected_by_default")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ShowOnPdf).HasColumnName("show_on_pdf");
            });

            modelBuilder.Entity<PinnedProjects>(entity =>
            {
                entity.ToTable("pinned_projects");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id");

                entity.Property(e => e.PinnedProjectsId).HasColumnName("pinned_projects_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<ProjectActivity>(entity =>
            {
                entity.ToTable("project_activity");

                entity.Property(e => e.ProjectActivityId).HasColumnName("project_activity_id");

                entity.Property(e => e.AdditionalData)
                    .HasColumnName("additional_data")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.DescriptionKey)
                    .IsRequired()
                    .HasColumnName("description_key")
                    .HasColumnType("varchar(191)")
                    .HasComment("Language file key")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VisibleToCustomer).HasColumnName("visible_to_customer");
            });

            modelBuilder.Entity<ProjectDiscussionComments>(entity =>
            {
                entity.HasKey(e => e.ProjectDiscussionCommentId)
                    .HasName("PRIMARY");

                entity.ToTable("project_discussion_comments");

                entity.Property(e => e.ProjectDiscussionCommentId).HasColumnName("project_discussion_comment_id");

                entity.Property(e => e.ContactId)
                    .HasColumnName("contact_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DiscussionId).HasColumnName("discussion_id");

                entity.Property(e => e.DiscussionType)
                    .IsRequired()
                    .HasColumnName("discussion_type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FileMimeType)
                    .HasColumnName("file_mime_type")
                    .HasColumnType("varchar(70)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.Parent).HasColumnName("parent");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<ProjectDiscussions>(entity =>
            {
                entity.HasKey(e => e.ProjectDiscussionId)
                    .HasName("PRIMARY");

                entity.ToTable("project_discussions");

                entity.Property(e => e.ProjectDiscussionId).HasColumnName("project_discussion_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastActivity)
                    .HasColumnName("last_activity")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.ShowToCustomer).HasColumnName("show_to_customer");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<ProjectFiles>(entity =>
            {
                entity.HasKey(e => e.ProjectFileId)
                    .HasName("PRIMARY");

                entity.ToTable("project_files");

                entity.Property(e => e.ProjectFileId).HasColumnName("project_file_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.External)
                    .HasColumnName("external")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExternalLink)
                    .HasColumnName("external_link")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Filetype)
                    .HasColumnName("filetype")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastActivity)
                    .HasColumnName("last_activity")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ThumbnailLink)
                    .HasColumnName("thumbnail_link")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VisibleToCustomer)
                    .HasColumnName("visible_to_customer")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ProjectMembers>(entity =>
            {
                entity.ToTable("project_members");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("StaffId");

                entity.Property(e => e.ProjectMembersId).HasColumnName("project_members_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<ProjectNotes>(entity =>
            {
                entity.HasKey(e => e.ProjectNoteId)
                    .HasName("PRIMARY");

                entity.ToTable("project_notes");

                entity.Property(e => e.ProjectNoteId).HasColumnName("project_note_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<ProjectSettings>(entity =>
            {
                entity.HasKey(e => e.ProjectSettingId)
                    .HasName("PRIMARY");

                entity.ToTable("project_settings");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_id");

                entity.Property(e => e.ProjectSettingId).HasColumnName("project_setting_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PRIMARY");

                entity.ToTable("projects");

                entity.HasIndex(e => e.ClientId)
                    .HasName("client_id");

                entity.HasIndex(e => e.Name)
                    .HasName("Name");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.AddedFrom).HasColumnName("added_from");

                entity.Property(e => e.BillingType).HasColumnName("billing_type");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.DateFinished)
                    .HasColumnName("date_finished")
                    .HasColumnType("datetime");

                entity.Property(e => e.Deadline)
                    .HasColumnName("deadline")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EstimatedHours)
                    .HasColumnName("estimated_hours")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Progress)
                    .HasColumnName("progress")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ProgressFromTasks)
                    .HasColumnName("progress_from_tasks")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ProjectCost)
                    .HasColumnName("project_cost")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.ProjectCreated)
                    .HasColumnName("project_created")
                    .HasColumnType("date");

                entity.Property(e => e.ProjectRatePerHour)
                    .HasColumnName("project_rate_per_hour")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<ProposalComments>(entity =>
            {
                entity.HasKey(e => e.ProposalCommentId)
                    .HasName("PRIMARY");

                entity.ToTable("proposal_comments");

                entity.Property(e => e.ProposalCommentId).HasColumnName("proposal_comment_id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProposalId).HasColumnName("proposal_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Proposals>(entity =>
            {
                entity.HasKey(e => e.ProposalId)
                    .HasName("PRIMARY");

                entity.ToTable("proposals");

                entity.Property(e => e.ProposalId).HasColumnName("proposal_id");

                entity.Property(e => e.AcceptanceDate)
                    .HasColumnName("acceptance_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AcceptanceEmail)
                    .HasColumnName("acceptance_email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AcceptanceFirstname)
                    .HasColumnName("acceptance_firstname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AcceptanceIp)
                    .HasColumnName("acceptance_ip")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AcceptanceLastname)
                    .HasColumnName("acceptance_lastname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AddedFrom).HasColumnName("added_from");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Adjustment)
                    .HasColumnName("adjustment")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.AllowComments)
                    .IsRequired()
                    .HasColumnName("allow_comments")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Assigned).HasColumnName("assigned");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.Currency).HasColumnName("currency");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DateConverted)
                    .HasColumnName("date_converted")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DiscountPercent)
                    .HasColumnName("discount_percent")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.DiscountTotal)
                    .HasColumnName("discount_total")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.DiscountType)
                    .HasColumnName("discount_type")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EstimateId).HasColumnName("estimate_id");

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasColumnName("hash")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.IsExpiryNotified).HasColumnName("is_expiry_notified");

                entity.Property(e => e.OpenTill)
                    .HasColumnName("open_till")
                    .HasColumnType("date");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PipelineOrder).HasColumnName("pipeline_order");

                entity.Property(e => e.ProposalTo)
                    .HasColumnName("proposal_to")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowQuantityAs)
                    .HasColumnName("show_quantity_as")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Signature)
                    .HasColumnName("signature")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.TotalTax)
                    .HasColumnName("total_tax")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<RelatedItems>(entity =>
            {
                entity.ToTable("related_items");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Reminders>(entity =>
            {
                entity.HasKey(e => e.ReminderId)
                    .HasName("PRIMARY");

                entity.ToTable("reminders");

                entity.HasIndex(e => e.RelId)
                    .HasName("rel_id");

                entity.HasIndex(e => e.RelType)
                    .HasName("rel_type");

                entity.HasIndex(e => e.Staff)
                    .HasName("staff");

                entity.Property(e => e.ReminderId).HasColumnName("reminder_id");

                entity.Property(e => e.Creator).HasColumnName("creator");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsNotified).HasColumnName("is_notified");

                entity.Property(e => e.NotifyByEmail)
                    .HasColumnName("notify_by_email")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Staff).HasColumnName("staff");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Permissions)
                    .HasColumnName("permissions")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<SalesActivity>(entity =>
            {
                entity.ToTable("sales_activity");

                entity.Property(e => e.SalesActivityId).HasColumnName("sales_activity_id");

                entity.Property(e => e.AdditionalData)
                    .HasColumnName("additional_data")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(11)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("PRIMARY");

                entity.ToTable("services");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .HasName("PRIMARY");

                entity.ToTable("sessions");

                entity.HasIndex(e => e.CreateDate)
                    .HasName("sessions_timestamp");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasColumnName("ip_address")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<SharedCustomerFiles>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("shared_customer_files");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.FileId).HasColumnName("file_id");
            });

            modelBuilder.Entity<SpamFilters>(entity =>
            {
                entity.ToTable("spam_filters");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Subscriptions>(entity =>
            {
                entity.HasKey(e => e.SubscriptionId)
                    .HasName("PRIMARY");

                entity.ToTable("subscriptions");

                entity.HasIndex(e => e.ClientId)
                    .HasName("client_id");

                entity.HasIndex(e => e.Currency)
                    .HasName("currency");

                entity.HasIndex(e => e.TaxId)
                    .HasName("tax_id");

                entity.Property(e => e.SubscriptionId).HasColumnName("subscription_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedFrom).HasColumnName("created_from");

                entity.Property(e => e.Currency).HasColumnName("currency");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DateSubscribed)
                    .HasColumnName("date_subscribed")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DescriptionInItem).HasColumnName("description_in_item");

                entity.Property(e => e.EndsAt)
                    .HasColumnName("ends_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasColumnName("hash")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NextBillingCycle).HasColumnName("next_billing_cycle");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StripePlanId)
                    .HasColumnName("stripe_plan_id")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StripeSubscriptionId)
                    .IsRequired()
                    .HasColumnName("stripe_subscription_id")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TaxId).HasColumnName("tax_id");
            });

            modelBuilder.Entity<Taggables>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("taggables");

                entity.HasIndex(e => e.RelId)
                    .HasName("rel_id");

                entity.HasIndex(e => e.RelType)
                    .HasName("rel_type");

                entity.HasIndex(e => e.TagId)
                    .HasName("tag_id");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.Property(e => e.TagOrder).HasColumnName("tag_order");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.ToTable("tags");

                entity.HasIndex(e => e.Name)
                    .HasName("Name");

                entity.Property(e => e.TagsId).HasColumnName("tags_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TaskAssigned>(entity =>
            {
                entity.ToTable("task_assigned");

                entity.HasIndex(e => e.TaskId)
                    .HasName("task_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("StaffId");

                entity.Property(e => e.TaskAssignedId).HasColumnName("task_assigned_id");

                entity.Property(e => e.AssignedFrom).HasColumnName("assigned_from");

                entity.Property(e => e.IsAssignedFromContact).HasColumnName("is_assigned_from_contact");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<TaskChecklistItems>(entity =>
            {
                entity.HasKey(e => e.TaskChecklistItemId)
                    .HasName("PRIMARY");

                entity.ToTable("task_checklist_items");

                entity.HasIndex(e => e.TaskId)
                    .HasName("task_id");

                entity.Property(e => e.TaskChecklistItemId).HasColumnName("task_checklist_item_id");

                entity.Property(e => e.AddedFrom).HasColumnName("added_from");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Finished).HasColumnName("finished");

                entity.Property(e => e.FinishedFrom)
                    .HasColumnName("finished_from")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ListOrder).HasColumnName("list_order");

                entity.Property(e => e.TaskId).HasColumnName("task_id");
            });

            modelBuilder.Entity<TaskComments>(entity =>
            {
                entity.HasKey(e => e.TaskCommentId)
                    .HasName("PRIMARY");

                entity.ToTable("task_comments");

                entity.HasIndex(e => e.FileId)
                    .HasName("file_id");

                entity.HasIndex(e => e.TaskId)
                    .HasName("task_id");

                entity.Property(e => e.TaskCommentId).HasColumnName("task_comment_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.TaskId).HasColumnName("task_id");
            });

            modelBuilder.Entity<TaskFollowers>(entity =>
            {
                entity.HasKey(e => e.TaskFollowerId)
                    .HasName("PRIMARY");

                entity.ToTable("task_followers");

                entity.Property(e => e.TaskFollowerId).HasColumnName("task_follower_id");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PRIMARY");

                entity.ToTable("tasks");

                entity.HasIndex(e => e.KanbanOrder)
                    .HasName("kanban_order");

                entity.HasIndex(e => e.Milestone)
                    .HasName("milestone");

                entity.HasIndex(e => e.RelId)
                    .HasName("rel_id");

                entity.HasIndex(e => e.RelType)
                    .HasName("rel_type");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.AddedFrom).HasColumnName("added_from");

                entity.Property(e => e.Billable).HasColumnName("billable");

                entity.Property(e => e.Billed).HasColumnName("billed");

                entity.Property(e => e.CustomRecurring).HasColumnName("custom_recurring");

                entity.Property(e => e.Cycles).HasColumnName("cycles");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeadlineNotified).HasColumnName("deadline_notified");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("date");

                entity.Property(e => e.FinishDate)
                    .HasColumnName("finish_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.HourlyRate)
                    .HasColumnName("hourly_rate")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.IsAddedFromContact).HasColumnName("is_added_from_contact");

                entity.Property(e => e.IsPublic).HasColumnName("is_public");

                entity.Property(e => e.IsRecurringFrom).HasColumnName("is_recurring_from");

                entity.Property(e => e.KanbanOrder).HasColumnName("kanban_order");

                entity.Property(e => e.LastRecurringDate)
                    .HasColumnName("last_recurring_date")
                    .HasColumnType("date");

                entity.Property(e => e.Milestone)
                    .HasColumnName("milestone")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MilestoneOrder).HasColumnName("milestone_order");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.Recurring).HasColumnName("recurring");

                entity.Property(e => e.RecurringType)
                    .HasColumnName("recurring_type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Repeat)
                    .HasColumnName("repeat")
                    .HasComment("repeat schedule");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalCycles).HasColumnName("total_cycles");

                entity.Property(e => e.VisibleToClient).HasColumnName("visible_to_client");
            });

            modelBuilder.Entity<TasksChecklistTemplates>(entity =>
            {
                entity.HasKey(e => e.TasksChecklistTemplateId)
                    .HasName("PRIMARY");

                entity.ToTable("tasks_checklist_templates");

                entity.Property(e => e.TasksChecklistTemplateId).HasColumnName("tasks_checklist_template_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TasksTimers>(entity =>
            {
                entity.HasKey(e => e.TasksTimerId)
                    .HasName("PRIMARY");

                entity.ToTable("tasks_timers");

                entity.HasIndex(e => e.StaffId)
                    .HasName("StaffId");

                entity.HasIndex(e => e.TaskId)
                    .HasName("task_id");

                entity.Property(e => e.TasksTimerId).HasColumnName("tasks_timer_id");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HourlyRate)
                    .HasColumnName("hourly_rate")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasColumnName("start_time")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TaskId).HasColumnName("task_id");
            });

            modelBuilder.Entity<Taxes>(entity =>
            {
                entity.ToTable("taxes");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TaxRate).HasColumnType("decimal(15,2)");
            });

            modelBuilder.Entity<TicketAttachments>(entity =>
            {
                entity.HasKey(e => e.TicketAttachmentId)
                    .HasName("PRIMARY");

                entity.ToTable("ticket_attachments");

                entity.Property(e => e.TicketAttachmentId).HasColumnName("ticket_attachment_id");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Filetype)
                    .HasColumnName("filetype")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReplyId).HasColumnName("reply_id");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            });

            modelBuilder.Entity<TicketReplies>(entity =>
            {
                entity.HasKey(e => e.TicketReplyId)
                    .HasName("PRIMARY");

                entity.ToTable("ticket_replies");

                entity.Property(e => e.TicketReplyId).HasColumnName("ticket_reply_id");

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.Attachment).HasColumnName("attachment");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Tickets>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PRIMARY");

                entity.ToTable("tickets");

                entity.HasIndex(e => e.ContactId)
                    .HasName("contact_id");

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

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.AdminRead).HasColumnName("admin_read");

                entity.Property(e => e.AdminReplying).HasColumnName("admin_replying");

                entity.Property(e => e.Assigned).HasColumnName("assigned");

                entity.Property(e => e.ClientRead).HasColumnName("client_read");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Department).HasColumnName("department");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastReply)
                    .HasColumnName("last_reply")
                    .HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Service).HasColumnName("service");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TicketKey)
                    .IsRequired()
                    .HasColumnName("ticket_key")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<TicketsPipeLog>(entity =>
            {
                entity.ToTable("tickets_pipe_log");

                entity.Property(e => e.TicketsPipeLogId).HasColumnName("tickets_pipe_log_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailTo)
                    .IsRequired()
                    .HasColumnName("email_to")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TicketsPredefinedReplies>(entity =>
            {
                entity.ToTable("tickets_predefined_replies");

                entity.Property(e => e.TicketsPredefinedRepliesId).HasColumnName("tickets_predefined_replies_id");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TicketsPriorities>(entity =>
            {
                entity.HasKey(e => e.TicketsPriorityId)
                    .HasName("PRIMARY");

                entity.ToTable("tickets_priorities");

                entity.Property(e => e.TicketsPriorityId).HasColumnName("tickets_priority_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TicketsStatus>(entity =>
            {
                entity.HasKey(e => e.TicketStatusId)
                    .HasName("PRIMARY");

                entity.ToTable("tickets_status");

                entity.Property(e => e.TicketStatusId).HasColumnName("ticket_status_id");

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StatusOrder).HasColumnName("status_order");

                entity.Property(e => e.Statuscolor)
                    .HasColumnName("statuscolor")
                    .HasColumnType("varchar(7)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Todos>(entity =>
            {
                entity.HasKey(e => e.TodoId)
                    .HasName("PRIMARY");

                entity.ToTable("todos");

                entity.Property(e => e.TodoId).HasColumnName("todo_id");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateFinished)
                    .HasColumnName("date_finished")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Finished).HasColumnName("finished");

                entity.Property(e => e.ItemOrder).HasColumnName("item_order");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<TrackedMails>(entity =>
            {
                entity.HasKey(e => e.TrackedMailId)
                    .HasName("PRIMARY");

                entity.ToTable("tracked_mails");

                entity.Property(e => e.TrackedMailId).HasColumnName("tracked_mail_id");

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
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Opened).HasColumnName("opened");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasColumnName("uid")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UserAutoLogin>(entity =>
            {
                entity.ToTable("user_auto_login");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastIp)
                    .IsRequired()
                    .HasColumnName("last_ip")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("last_login")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Staff).HasColumnName("staff");

                entity.Property(e => e.UserAgent)
                    .IsRequired()
                    .HasColumnName("user_agent")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<UserDepartments>(entity =>
            {
                entity.HasKey(e => e.UserDepartmentId)
                    .HasName("PRIMARY");

                entity.ToTable("user_departments");

                entity.Property(e => e.UserDepartmentId).HasColumnName("user_department_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<UserMeta>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PRIMARY");

                entity.ToTable("user_meta");

                entity.Property(e => e.MetaId).HasColumnName("meta_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<UserPermissions>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_permissions");

                entity.Property(e => e.Capability)
                    .IsRequired()
                    .HasColumnName("capability")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Feature)
                    .IsRequired()
                    .HasColumnName("feature")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.Firstname)
                    .HasName("firstname");

                entity.HasIndex(e => e.Lastname)
                    .HasName("lastname");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DefaultLanguage)
                    .HasColumnName("default_language")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Direction)
                    .HasColumnName("direction")
                    .HasColumnType("varchar(3)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailSignature)
                    .HasColumnName("email_signature")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Facebook)
                    .HasColumnName("facebook")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HourlyRate)
                    .HasColumnName("hourly_rate")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.IsNotStaff).HasColumnName("is_not_staff");

                entity.Property(e => e.LastActivity)
                    .HasColumnName("last_activity")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastIp)
                    .HasColumnName("last_ip")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("last_login")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChange)
                    .HasColumnName("last_password_change")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Linkedin)
                    .HasColumnName("linkedin")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MediaPathSlug)
                    .HasColumnName("media_path_slug")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NewPassKey)
                    .HasColumnName("new_pass_key")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NewPassKeyRequested)
                    .HasColumnName("new_pass_key_requested")
                    .HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("phonenumber")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProfileImage)
                    .HasColumnName("profile_image")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Skype)
                    .HasColumnName("skype")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TwoFactorAuthCode)
                    .HasColumnName("two_factor_auth_code")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TwoFactorAuthCodeRequested)
                    .HasColumnName("two_factor_auth_code_requested")
                    .HasColumnType("datetime");

                entity.Property(e => e.TwoFactorAuthEnabled)
                    .HasColumnName("two_factor_auth_enabled")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Vault>(entity =>
            {
                entity.ToTable("vault");

                entity.Property(e => e.VaultId).HasColumnName("vault_id");

                entity.Property(e => e.Creator).HasColumnName("creator");

                entity.Property(e => e.CreatorName)
                    .HasColumnName("creator_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("last_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedFrom)
                    .HasColumnName("last_updated_from")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Port).HasColumnName("port");

                entity.Property(e => e.ServerAddress)
                    .IsRequired()
                    .HasColumnName("server_address")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShareInProjects).HasColumnName("share_in_projects");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Visibility)
                    .IsRequired()
                    .HasColumnName("visibility")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<ViewsTracking>(entity =>
            {
                entity.ToTable("views_tracking");

                entity.Property(e => e.ViewsTrackingId).HasColumnName("views_tracking_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ViewIp)
                    .IsRequired()
                    .HasColumnName("view_ip")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<WebToLead>(entity =>
            {
                entity.ToTable("web_to_lead");

                entity.Property(e => e.WebToLeadId).HasColumnName("web_to_lead_id");

                entity.Property(e => e.AllowDuplicate)
                    .HasColumnName("allow_duplicate")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CreateTaskOnDuplicate).HasColumnName("create_task_on_duplicate");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.FormData)
                    .HasColumnName("form_data")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FormKey)
                    .IsRequired()
                    .HasColumnName("form_key")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LeadSource).HasColumnName("lead_source");

                entity.Property(e => e.LeadStatus).HasColumnName("lead_status");

                entity.Property(e => e.MarkPublic).HasColumnName("mark_public");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NotifyIds)
                    .HasColumnName("notify_ids")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NotifyLeadImported)
                    .HasColumnName("notify_lead_imported")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NotifyType)
                    .HasColumnName("notify_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Recaptcha).HasColumnName("recaptcha");

                entity.Property(e => e.Responsible).HasColumnName("responsible");

                entity.Property(e => e.SubmitBtnName)
                    .HasColumnName("submit_btn_name")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SuccessSubmitMsg)
                    .HasColumnName("success_submit_msg")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TrackDuplicateField)
                    .HasColumnName("track_duplicate_field")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TrackDuplicateFieldAnd)
                    .HasColumnName("track_duplicate_field_and")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
