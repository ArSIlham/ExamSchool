﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prosys.Imtahan.Programi.Database;

#nullable disable

namespace Prosys.Imtahan.Programi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Prosys.Imtahan.Programi.Entities.ProsysExam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LessonCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("char(3)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProsysExam", t =>
                        {
                            t.HasCheckConstraint("CK_StudentClassRoomRange", "[Score] BETWEEN 1 AND 9");

                            t.HasCheckConstraint("CK_StudentExamNumberRange", "[StudentNumber] BETWEEN 10000 AND 99999");
                        });
                });

            modelBuilder.Entity("Prosys.Imtahan.Programi.Entities.ProsysLesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Classroom")
                        .HasColumnType("int");

                    b.Property<string>("LessonCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("char(3)");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("char(30)");

                    b.Property<string>("TeacherFirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("char(20)");

                    b.Property<string>("TeacherLastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("char(20)");

                    b.HasKey("Id");

                    b.ToTable("ProsysLesson", t =>
                        {
                            t.HasCheckConstraint("CK_ClassroomRange", "[Classroom] BETWEEN 10 AND 99");
                        });
                });

            modelBuilder.Entity("Prosys.Imtahan.Programi.Entities.ProsysStudents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassRoom")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("char(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("char(30)");

                    b.Property<int>("Number")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProsysStudents", t =>
                        {
                            t.HasCheckConstraint("CK_StudentClassRoomRange", "[ClassRoom] BETWEEN 10 AND 99")
                                .HasName("CK_StudentClassRoomRange1");

                            t.HasCheckConstraint("CK_StudentNumberRange", "[Number] BETWEEN 10000 AND 99999");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}