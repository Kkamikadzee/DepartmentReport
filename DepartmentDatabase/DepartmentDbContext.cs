using System;
using System.Configuration;
using DepartmentDatabase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DepartmentDatabase
{
    public partial class DepartmentDbContext : DbContext
    {
        public DepartmentDbContext()
        {
        }

        public DepartmentDbContext(DbContextOptions<DepartmentDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupStudent> GroupStudent { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["PostgreSQL"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.HeadmasterId).HasColumnName("headmaster_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.Headmaster)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.HeadmasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("department_headmaster_id_fkey");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("group");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Course).HasColumnName("course");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.EducationType)
                    .IsRequired()
                    .HasColumnName("education_type");

                entity.Property(e => e.EducationalProgram)
                    .IsRequired()
                    .HasColumnName("educational_program");

                entity.Property(e => e.FormOfEducation)
                    .IsRequired()
                    .HasColumnName("form_of_education");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasColumnName("short_name");

                entity.Property(e => e.SpecialityCode)
                    .IsRequired()
                    .HasColumnName("speciality_code");

                entity.Property(e => e.SpecialityName)
                    .IsRequired()
                    .HasColumnName("speciality_name");

                entity.Property(e => e.YearOfIssue).HasColumnName("year_of_issue");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("group_department_id_fkey");
            });

            modelBuilder.Entity<GroupStudent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("group_student");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Group)
                    .WithMany()
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("group_student_group_id_fkey");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("group_student_student_id_fkey");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name");

                entity.Property(e => e.Partonymic).HasColumnName("partonymic");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BasicOfEducation).HasColumnName("basic_of_education");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.TopicOfFinalQualificationWork).HasColumnName("topic_of_final_qualification_work");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student_person_id_fkey");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student_teacher_id_fkey");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teacher");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.JobVacancy).HasColumnName("job_vacancy");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.ScienceDegree).HasColumnName("science_degree");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teacher_person_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
