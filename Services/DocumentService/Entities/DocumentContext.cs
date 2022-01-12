using Microsoft.EntityFrameworkCore;

namespace DocumentService.Entities
{
    public partial class DocumentContext : DbContext
    {
        public DocumentContext()
        {
        }

        public DocumentContext(DbContextOptions<DocumentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmailTemplates> EmailTemplates { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<FormQuestionBox> FormQuestionBox { get; set; }
        public virtual DbSet<FormQuestionBoxDescription> FormQuestionBoxDescription { get; set; }
        public virtual DbSet<FormQuestions> FormQuestions { get; set; }
        public virtual DbSet<FormResults> FormResults { get; set; }
        public virtual DbSet<Todos> Todos { get; set; }

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
            modelBuilder.Entity<EmailTemplates>(entity =>
            {
                entity.HasKey(e => e.Emailtemplateid)
                    .HasName("PRIMARY");

                entity.ToTable("email_templates");

                entity.Property(e => e.Emailtemplateid)
                    .HasColumnName("emailtemplateid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Fromemail)
                    .HasColumnName("fromemail")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Fromname)
                    .IsRequired()
                    .HasColumnName("fromname")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Plaintext)
                    .HasColumnName("plaintext")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.ToTable("files");

                entity.HasIndex(e => e.RelId)
                    .HasName("rel_id");

                entity.HasIndex(e => e.RelType)
                    .HasName("rel_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AttachmentKey)
                    .HasColumnName("attachment_key")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.ContactId)
                    .HasColumnName("contact_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Dateadded)
                    .HasColumnName("dateadded")
                    .HasColumnType("datetime");

                entity.Property(e => e.External)
                    .HasColumnName("external")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.ExternalLink)
                    .HasColumnName("external_link")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Filetype)
                    .HasColumnName("filetype")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.RelId)
                    .HasColumnName("rel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Staffid)
                    .HasColumnName("staffid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TaskCommentId)
                    .HasColumnName("task_comment_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ThumbnailLink)
                    .HasColumnName("thumbnail_link")
                    .HasColumnType("text")
                    .HasComment("For external usage")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.VisibleToCustomer)
                    .HasColumnName("visible_to_customer")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<FormQuestionBox>(entity =>
            {
                entity.HasKey(e => e.Boxid)
                    .HasName("PRIMARY");

                entity.ToTable("form_question_box");

                entity.Property(e => e.Boxid)
                    .HasColumnName("boxid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Boxtype)
                    .IsRequired()
                    .HasColumnName("boxtype")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Questionid)
                    .HasColumnName("questionid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<FormQuestionBoxDescription>(entity =>
            {
                entity.HasKey(e => e.Questionboxdescriptionid)
                    .HasName("PRIMARY");

                entity.ToTable("form_question_box_description");

                entity.Property(e => e.Questionboxdescriptionid)
                    .HasColumnName("questionboxdescriptionid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Boxid)
                    .IsRequired()
                    .HasColumnName("boxid")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Questionid)
                    .HasColumnName("questionid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<FormQuestions>(entity =>
            {
                entity.HasKey(e => e.Questionid)
                    .HasName("PRIMARY");

                entity.ToTable("form_questions");

                entity.Property(e => e.Questionid)
                    .HasColumnName("questionid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnName("question")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.QuestionOrder)
                    .HasColumnName("question_order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelId)
                    .HasColumnName("rel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelType)
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Required).HasColumnName("required");
            });

            modelBuilder.Entity<FormResults>(entity =>
            {
                entity.HasKey(e => e.Resultid)
                    .HasName("PRIMARY");

                entity.ToTable("form_results");

                entity.Property(e => e.Resultid)
                    .HasColumnName("resultid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Answer)
                    .HasColumnName("answer")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Boxdescriptionid)
                    .HasColumnName("boxdescriptionid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Boxid)
                    .HasColumnName("boxid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Questionid)
                    .HasColumnName("questionid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelId)
                    .HasColumnName("rel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelType)
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Resultsetid)
                    .HasColumnName("resultsetid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Todos>(entity =>
            {
                entity.HasKey(e => e.Todoid)
                    .HasName("PRIMARY");

                entity.ToTable("todos");

                entity.Property(e => e.Todoid)
                    .HasColumnName("todoid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dateadded)
                    .HasColumnName("dateadded")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datefinished)
                    .HasColumnName("datefinished")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Finished).HasColumnName("finished");

                entity.Property(e => e.ItemOrder)
                    .HasColumnName("item_order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Staffid)
                    .HasColumnName("staffid")
                    .HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
