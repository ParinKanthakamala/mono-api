using Microsoft.EntityFrameworkCore;

namespace TaskService.Entities
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

        public virtual DbSet<Milestones> Milestones { get; set; }
        public virtual DbSet<TaskAssigned> TaskAssigned { get; set; }
        public virtual DbSet<TaskChecklistItems> TaskChecklistItems { get; set; }
        public virtual DbSet<TaskComments> TaskComments { get; set; }
        public virtual DbSet<TaskFollowers> TaskFollowers { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TasksChecklistTemplates> TasksChecklistTemplates { get; set; }
        public virtual DbSet<Taskstimers> Taskstimers { get; set; }

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
            modelBuilder.Entity<Milestones>(entity =>
            {
                entity.ToTable("milestones");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.DescriptionVisibleToCustomer)
                    .HasColumnName("description_visible_to_customer")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("date");

                entity.Property(e => e.MilestoneOrder)
                    .HasColumnName("milestone_order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(191)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TaskAssigned>(entity =>
            {
                entity.ToTable("task_assigned");

                entity.HasIndex(e => e.Staffid)
                    .HasName("staffid");

                entity.HasIndex(e => e.Taskid)
                    .HasName("taskid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AssignedFrom)
                    .HasColumnName("assigned_from")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsAssignedFromContact).HasColumnName("is_assigned_from_contact");

                entity.Property(e => e.Staffid)
                    .HasColumnName("staffid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Taskid)
                    .HasColumnName("taskid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TaskChecklistItems>(entity =>
            {
                entity.ToTable("task_checklist_items");

                entity.HasIndex(e => e.Taskid)
                    .HasName("taskid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addedfrom)
                    .HasColumnName("addedfrom")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dateadded)
                    .HasColumnName("dateadded")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Finished)
                    .HasColumnName("finished")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FinishedFrom)
                    .HasColumnName("finished_from")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ListOrder)
                    .HasColumnName("list_order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Taskid)
                    .HasColumnName("taskid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TaskComments>(entity =>
            {
                entity.ToTable("task_comments");

                entity.HasIndex(e => e.FileId)
                    .HasName("file_id");

                entity.HasIndex(e => e.Taskid)
                    .HasName("taskid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContactId)
                    .HasColumnName("contact_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Dateadded)
                    .HasColumnName("dateadded")
                    .HasColumnType("datetime");

                entity.Property(e => e.FileId)
                    .HasColumnName("file_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Staffid)
                    .HasColumnName("staffid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Taskid)
                    .HasColumnName("taskid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TaskFollowers>(entity =>
            {
                entity.ToTable("task_followers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Staffid)
                    .HasColumnName("staffid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Taskid)
                    .HasColumnName("taskid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.ToTable("tasks");

                entity.HasIndex(e => e.KanbanOrder)
                    .HasName("kanban_order");

                entity.HasIndex(e => e.Milestone)
                    .HasName("milestone");

                entity.HasIndex(e => e.RelId)
                    .HasName("rel_id");

                entity.HasIndex(e => e.RelType)
                    .HasName("rel_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Addedfrom)
                    .HasColumnName("addedfrom")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Billable).HasColumnName("billable");

                entity.Property(e => e.Billed).HasColumnName("billed");

                entity.Property(e => e.CustomRecurring).HasColumnName("custom_recurring");

                entity.Property(e => e.Cycles)
                    .HasColumnName("cycles")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dateadded)
                    .HasColumnName("dateadded")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datefinished)
                    .HasColumnName("datefinished")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeadlineNotified)
                    .HasColumnName("deadline_notified")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Duedate)
                    .HasColumnName("duedate")
                    .HasColumnType("date");

                entity.Property(e => e.HourlyRate)
                    .HasColumnName("hourly_rate")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsAddedFromContact).HasColumnName("is_added_from_contact");

                entity.Property(e => e.IsPublic).HasColumnName("is_public");

                entity.Property(e => e.IsRecurringFrom)
                    .HasColumnName("is_recurring_from")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KanbanOrder)
                    .HasColumnName("kanban_order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastRecurringDate)
                    .HasColumnName("last_recurring_date")
                    .HasColumnType("date");

                entity.Property(e => e.Milestone)
                    .HasColumnName("milestone")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MilestoneOrder)
                    .HasColumnName("milestone_order")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Recurring)
                    .HasColumnName("recurring")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RecurringType)
                    .HasColumnName("recurring_type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.RelId)
                    .HasColumnName("rel_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelType)
                    .HasColumnName("rel_type")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.RepeatEvery)
                    .HasColumnName("repeat_every")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalCycles)
                    .HasColumnName("total_cycles")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VisibleToClient).HasColumnName("visible_to_client");
            });

            modelBuilder.Entity<TasksChecklistTemplates>(entity =>
            {
                entity.ToTable("tasks_checklist_templates");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<Taskstimers>(entity =>
            {
                entity.ToTable("taskstimers");

                entity.HasIndex(e => e.StaffId)
                    .HasName("staff_id");

                entity.HasIndex(e => e.TaskId)
                    .HasName("task_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.HourlyRate)
                    .HasColumnName("hourly_rate")
                    .HasColumnType("decimal(15,2)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasColumnName("start_time")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
