using LMS.Web.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Web.API.Data
{
    public class LMSDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public LMSDbContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=LMSDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Courses");

                entity.Property(i => i.Id).UseIdentityColumn();
                entity.Property(i => i.Name).HasMaxLength(20);
                entity.Property(i => i.ShortName).HasMaxLength(4);
                entity.HasOne(q => q.Teacher).WithMany(q => q.Courses).HasForeignKey(q => q.TeacherId);
                entity.Property(q => q.TeacherId).IsRequired(false);
            });

        }
    }
}
