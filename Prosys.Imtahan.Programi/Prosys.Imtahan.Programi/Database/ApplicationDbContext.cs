using Microsoft.EntityFrameworkCore;
using Prosys.Imtahan.Programi.Entities;

namespace Prosys.Imtahan.Programi.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ProsysLesson> ProsysLesson { get; set; }
        public DbSet<ProsysStudents> ProsysStudents { get; set; }
        public DbSet<ProsysExam> ProsysExam { get; set; }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProsysLesson>(entity =>
            {
                entity.Property(e => e.Classroom)
                    .IsRequired()
                    .HasColumnType("int");

                entity.HasCheckConstraint("CK_ClassroomRange", "[Classroom] BETWEEN 10 AND 99");
            });

            modelBuilder.Entity<ProsysStudents>(entity =>
            {
                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnType("int");

                entity.HasCheckConstraint("CK_StudentNumberRange", "[Number] BETWEEN 10000 AND 99999");
            });
            modelBuilder.Entity<ProsysStudents>(entity =>
            {
                entity.Property(e => e.ClassRoom)
                    .IsRequired()
                    .HasColumnType("int");

                entity.HasCheckConstraint("CK_StudentClassRoomRange", "[ClassRoom] BETWEEN 10 AND 99");
            });
            modelBuilder.Entity<ProsysExam>(entity =>
            {
                entity.Property(e => e.Score)
                    .IsRequired()
                    .HasColumnType("int");

                entity.HasCheckConstraint("CK_StudentClassRoomRange", "[Score] BETWEEN 1 AND 9");
            });
            modelBuilder.Entity<ProsysExam>(entity =>
            {
                entity.Property(e => e.StudentNumber)
                    .IsRequired()
                    .HasColumnType("int");

                entity.HasCheckConstraint("CK_StudentExamNumberRange", "[StudentNumber] BETWEEN 10000 AND 99999");
            });
        }
    }
}
