using Microsoft.EntityFrameworkCore;

namespace ContractService.Entities
{
    public partial class ContractContext : DbContext
    {
        public ContractContext()
        {
        }

        public ContractContext(DbContextOptions<ContractContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContractComments> ContractComments { get; set; }
        public virtual DbSet<ContractRenewals> ContractRenewals { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<ContractsTypes> ContractsTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http: //go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql(
                    "server=localhost;user=root;password=password;database=perfex;convert zero datetime=True",
                    x => x.ServerVersion("10.6.5-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractComments>(entity =>
            {
                entity.ToTable("contract_comments");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.ContractId)
                    .HasColumnName("contract_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dateadded)
                    .HasColumnName("dateadded")
                    .HasColumnType("datetime");

                entity.Property(e => e.Staffid)
                    .HasColumnName("staffid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<ContractRenewals>(entity =>
            {
                entity.ToTable("contract_renewals");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contractid)
                    .HasColumnName("contractid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateRenewed)
                    .HasColumnName("date_renewed")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsOnOldExpiryNotified)
                    .HasColumnName("is_on_old_expiry_notified")
                    .HasColumnType("int(11)")
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
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.RenewedByStaffId)
                    .HasColumnName("renewed_by_staff_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.ToTable("contracts");

                entity.HasIndex(e => e.Client)
                    .HasName("client");

                entity.HasIndex(e => e.ContractType)
                    .HasName("contract_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcceptanceDate)
                    .HasColumnName("acceptance_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AcceptanceEmail)
                    .HasColumnName("acceptance_email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.AcceptanceFirstname)
                    .HasColumnName("acceptance_firstname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.AcceptanceIp)
                    .HasColumnName("acceptance_ip")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.AcceptanceLastname)
                    .HasColumnName("acceptance_lastname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Addedfrom)
                    .HasColumnName("addedfrom")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Client)
                    .HasColumnName("client")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.ContractType)
                    .HasColumnName("contract_type")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContractValue)
                    .HasColumnName("contract_value")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Dateadded)
                    .HasColumnName("dateadded")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dateend)
                    .HasColumnName("dateend")
                    .HasColumnType("date");

                entity.Property(e => e.Datestart)
                    .HasColumnName("datestart")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Hash)
                    .HasColumnName("hash")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Isexpirynotified)
                    .HasColumnName("isexpirynotified")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NotVisibleToClient).HasColumnName("not_visible_to_client");

                entity.Property(e => e.Signature)
                    .HasColumnName("signature")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Signed).HasColumnName("signed");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Trash)
                    .HasColumnName("trash")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<ContractsTypes>(entity =>
            {
                entity.ToTable("contracts_types");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}