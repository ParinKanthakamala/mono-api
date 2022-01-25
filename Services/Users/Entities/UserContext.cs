using Microsoft.EntityFrameworkCore;

namespace Users.Entities
{
    public partial class UserContext : DbContext
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<ContactPermissions> ContactPermissions { get; set; }
        public virtual DbSet<CustomerAdmins> CustomerAdmins { get; set; }
        public virtual DbSet<CustomerGroups> CustomerGroups { get; set; }
        public virtual DbSet<CustomersGroups> CustomersGroups { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<StaffDepartments> StaffDepartments { get; set; }
        public virtual DbSet<StaffPermissions> StaffPermissions { get; set; }
        public virtual DbSet<UserAutoLogin> UserAutoLogin { get; set; }
        public virtual DbSet<UserMeta> UserMeta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http: //go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql(
                    "server=localhost;user=root;password=password;database=perfex;convert zero datetime=True",
                    x => x.ServerVersion("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PRIMARY");

                entity.ToTable("clients");

                entity.HasIndex(e => e.Company)
                    .HasName("company");

                entity.HasIndex(e => e.Country)
                    .HasName("country");

                entity.HasIndex(e => e.Leadid)
                    .HasName("leadid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Addedfrom).HasColumnName("addedfrom");

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

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
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

                entity.Property(e => e.Leadid).HasColumnName("leadid");

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

            modelBuilder.Entity<ContactPermissions>(entity =>
            {
                entity.ToTable("contact_permissions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<CustomerAdmins>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("customer_admins");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("customer_id");

                entity.HasIndex(e => e.StaffId)
                    .HasName("staff_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DateAssigned)
                    .IsRequired()
                    .HasColumnName("date_assigned")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");
            });

            modelBuilder.Entity<CustomerGroups>(entity =>
            {
                entity.ToTable("customer_groups");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("customer_id");

                entity.HasIndex(e => e.Groupid)
                    .HasName("groupid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Groupid).HasColumnName("groupid");
            });

            modelBuilder.Entity<CustomersGroups>(entity =>
            {
                entity.ToTable("customers_groups");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.Departmentid)
                    .HasName("PRIMARY");

                entity.ToTable("departments");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.Property(e => e.Departmentid).HasColumnName("departmentid");

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

                entity.Property(e => e.Hidefromclient).HasColumnName("hidefromclient");

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

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("staff");

                entity.HasIndex(e => e.Firstname)
                    .HasName("firstname");

                entity.HasIndex(e => e.Lastname)
                    .HasName("lastname");

                entity.Property(e => e.Staffid).HasColumnName("staffid");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
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

            modelBuilder.Entity<StaffDepartments>(entity =>
            {
                entity.HasKey(e => e.Staffdepartmentid)
                    .HasName("PRIMARY");

                entity.ToTable("staff_departments");

                entity.Property(e => e.Staffdepartmentid).HasColumnName("staffdepartmentid");

                entity.Property(e => e.Departmentid).HasColumnName("departmentid");

                entity.Property(e => e.Staffid).HasColumnName("staffid");
            });

            modelBuilder.Entity<StaffPermissions>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("staff_permissions");

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

                entity.Property(e => e.StaffId).HasColumnName("staff_id");
            });

            modelBuilder.Entity<UserAutoLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_auto_login");

                entity.Property(e => e.KeyId)
                    .IsRequired()
                    .HasColumnName("key_id")
                    .HasColumnType("char(32)")
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

            modelBuilder.Entity<UserMeta>(entity =>
            {
                entity.HasKey(e => e.UmetaId)
                    .HasName("PRIMARY");

                entity.ToTable("user_meta");

                entity.Property(e => e.UmetaId).HasColumnName("umeta_id");

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

                entity.Property(e => e.StaffId).HasColumnName("staff_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}