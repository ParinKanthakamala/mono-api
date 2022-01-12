using Microsoft.EntityFrameworkCore;

namespace ForumService.Entities
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

        public virtual DbSet<CustomfieldsValues> CustomfieldsValues { get; set; }
        public virtual DbSet<KnowedgeBaseArticleFeedback> KnowedgeBaseArticleFeedback { get; set; }
        public virtual DbSet<KnowledgeBase> KnowledgeBase { get; set; }
        public virtual DbSet<KnowledgeBaseGroups> KnowledgeBaseGroups { get; set; }
        public virtual DbSet<NewsfeedCommentLikes> NewsfeedCommentLikes { get; set; }
        public virtual DbSet<NewsfeedPostComments> NewsfeedPostComments { get; set; }
        public virtual DbSet<NewsfeedPostLikes> NewsfeedPostLikes { get; set; }
        public virtual DbSet<NewsfeedPosts> NewsfeedPosts { get; set; }
        public virtual DbSet<SpamFilters> SpamFilters { get; set; }
        public virtual DbSet<Taggables> Taggables { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }

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
            modelBuilder.Entity<CustomfieldsValues>(entity =>
            {
                entity.ToTable("customfields_values");

                entity.HasIndex(e => e.Fieldid)
                    .HasName("fieldid");

                entity.HasIndex(e => e.Fieldto)
                    .HasName("fieldto");

                entity.HasIndex(e => e.Relid)
                    .HasName("relid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fieldid)
                    .HasColumnName("fieldid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fieldto)
                    .IsRequired()
                    .HasColumnName("fieldto")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Relid)
                    .HasColumnName("relid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<KnowedgeBaseArticleFeedback>(entity =>
            {
                entity.HasKey(e => e.Articleanswerid)
                    .HasName("PRIMARY");

                entity.ToTable("knowedge_base_article_feedback");

                entity.Property(e => e.Articleanswerid)
                    .HasColumnName("articleanswerid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Answer)
                    .HasColumnName("answer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Articleid)
                    .HasColumnName("articleid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<KnowledgeBase>(entity =>
            {
                entity.HasKey(e => e.Articleid)
                    .HasName("PRIMARY");

                entity.ToTable("knowledge_base");

                entity.Property(e => e.Articleid)
                    .HasColumnName("articleid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.ArticleOrder)
                    .HasColumnName("article_order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Articlegroup)
                    .HasColumnName("articlegroup")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.StaffArticle)
                    .HasColumnName("staff_article")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<KnowledgeBaseGroups>(entity =>
            {
                entity.HasKey(e => e.Groupid)
                    .HasName("PRIMARY");

                entity.ToTable("knowledge_base_groups");

                entity.Property(e => e.Groupid)
                    .HasColumnName("groupid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("varchar(10)")
                    .HasDefaultValueSql("'#28B8DA'")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.GroupOrder)
                    .HasColumnName("group_order")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GroupSlug)
                    .HasColumnName("group_slug")
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

            modelBuilder.Entity<NewsfeedCommentLikes>(entity =>
            {
                entity.ToTable("newsfeed_comment_likes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Commentid)
                    .HasColumnName("commentid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dateliked)
                    .HasColumnName("dateliked")
                    .HasColumnType("datetime");

                entity.Property(e => e.Postid)
                    .HasColumnName("postid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<NewsfeedPostComments>(entity =>
            {
                entity.ToTable("newsfeed_post_comments");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Dateadded)
                    .HasColumnName("dateadded")
                    .HasColumnType("datetime");

                entity.Property(e => e.Postid)
                    .HasColumnName("postid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<NewsfeedPostLikes>(entity =>
            {
                entity.ToTable("newsfeed_post_likes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dateliked)
                    .HasColumnName("dateliked")
                    .HasColumnType("datetime");

                entity.Property(e => e.Postid)
                    .HasColumnName("postid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<NewsfeedPosts>(entity =>
            {
                entity.HasKey(e => e.Postid)
                    .HasName("PRIMARY");

                entity.ToTable("newsfeed_posts");

                entity.Property(e => e.Postid)
                    .HasColumnName("postid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Creator)
                    .HasColumnName("creator")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datepinned)
                    .HasColumnName("datepinned")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pinned)
                    .HasColumnName("pinned")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Visibility)
                    .IsRequired()
                    .HasColumnName("visibility")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<SpamFilters>(entity =>
            {
                entity.ToTable("spam_filters");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
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

                entity.Property(e => e.RelId)
                    .HasColumnName("rel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelType)
                    .IsRequired()
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.TagId)
                    .HasColumnName("tag_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TagOrder)
                    .HasColumnName("tag_order")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.ToTable("tags");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
