using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prosys.Imtahan.Programi.Migrations
{
    /// <inheritdoc />
    public partial class CreateFirstDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProsysExam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    StudentNumber = table.Column<int>(type: "int", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProsysExam", x => x.Id);
                    table.CheckConstraint("CK_StudentClassRoomRange", "[Score] BETWEEN 1 AND 9");
                    table.CheckConstraint("CK_StudentExamNumberRange", "[StudentNumber] BETWEEN 10000 AND 99999");
                });

            migrationBuilder.CreateTable(
                name: "ProsysLesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    LessonName = table.Column<string>(type: "char(30)", maxLength: 30, nullable: false),
                    Classroom = table.Column<int>(type: "int", nullable: false),
                    TeacherFirstName = table.Column<string>(type: "char(20)", maxLength: 20, nullable: false),
                    TeacherLastName = table.Column<string>(type: "char(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProsysLesson", x => x.Id);
                    table.CheckConstraint("CK_ClassroomRange", "[Classroom] BETWEEN 10 AND 99");
                });

            migrationBuilder.CreateTable(
                name: "ProsysStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    FirstName = table.Column<string>(type: "char(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "char(30)", maxLength: 30, nullable: false),
                    ClassRoom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProsysStudents", x => x.Id);
                    table.CheckConstraint("CK_StudentClassRoomRange1", "[ClassRoom] BETWEEN 10 AND 99");
                    table.CheckConstraint("CK_StudentNumberRange", "[Number] BETWEEN 10000 AND 99999");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProsysExam");

            migrationBuilder.DropTable(
                name: "ProsysLesson");

            migrationBuilder.DropTable(
                name: "ProsysStudents");
        }
    }
}
