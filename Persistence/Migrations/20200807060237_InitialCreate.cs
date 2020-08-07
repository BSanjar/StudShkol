using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    login = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GroupTest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    TimeToTest = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTest", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(nullable: true),
                    MyPropertyid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.id);
                    table.ForeignKey(
                        name: "FK_Test_GroupTest_MyPropertyid",
                        column: x => x.MyPropertyid,
                        principalTable: "GroupTest",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentTest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studentid = table.Column<int>(nullable: true),
                    groupTestid = table.Column<int>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    RegDate = table.Column<DateTime>(nullable: false),
                    DateStartTest = table.Column<DateTime>(nullable: false),
                    DateFinishTest = table.Column<DateTime>(nullable: false),
                    CountTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTest", x => x.id);
                    table.ForeignKey(
                        name: "FK_StudentTest_GroupTest_groupTestid",
                        column: x => x.groupTestid,
                        principalTable: "GroupTest",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentTest_Student_studentid",
                        column: x => x.studentid,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    answer = table.Column<int>(nullable: false),
                    testsid = table.Column<int>(nullable: true),
                    score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.id);
                    table.ForeignKey(
                        name: "FK_Answer_Test_testsid",
                        column: x => x.testsid,
                        principalTable: "Test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageTest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    testid = table.Column<int>(nullable: true),
                    file = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTest", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImageTest_Test_testid",
                        column: x => x.testid,
                        principalTable: "Test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageAnswer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    answerid = table.Column<int>(nullable: true),
                    file = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageAnswer", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImageAnswer_Answer_answerid",
                        column: x => x.answerid,
                        principalTable: "Answer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestResult",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studentTestid = table.Column<int>(nullable: true),
                    testid = table.Column<int>(nullable: true),
                    answerid = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResult", x => x.id);
                    table.ForeignKey(
                        name: "FK_TestResult_Answer_answerid",
                        column: x => x.answerid,
                        principalTable: "Answer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestResult_StudentTest_studentTestid",
                        column: x => x.studentTestid,
                        principalTable: "StudentTest",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestResult_Test_testid",
                        column: x => x.testid,
                        principalTable: "Test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_testsid",
                table: "Answer",
                column: "testsid");

            migrationBuilder.CreateIndex(
                name: "IX_ImageAnswer_answerid",
                table: "ImageAnswer",
                column: "answerid");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTest_testid",
                table: "ImageTest",
                column: "testid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTest_groupTestid",
                table: "StudentTest",
                column: "groupTestid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTest_studentid",
                table: "StudentTest",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_Test_MyPropertyid",
                table: "Test",
                column: "MyPropertyid");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_answerid",
                table: "TestResult",
                column: "answerid");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_studentTestid",
                table: "TestResult",
                column: "studentTestid");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_testid",
                table: "TestResult",
                column: "testid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "ImageAnswer");

            migrationBuilder.DropTable(
                name: "ImageTest");

            migrationBuilder.DropTable(
                name: "TestResult");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "StudentTest");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "GroupTest");
        }
    }
}
