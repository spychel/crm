using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lesson_state_type",
                columns: table => new
                {
                    uid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("lesson_state_type__pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "lesson_type",
                columns: table => new
                {
                    uid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("lesson_type__pk", x => x.uid);
                });

            migrationBuilder.InsertData(
                table: "lesson_state_type",
                columns: ["uid", "name"],
                values: new object[,]
                {
                         { 1, "appointed" },
                         { 2, "completed" },
                         { 3, "rescheduled" },
                         { 4, "dismissed" }
                });

            migrationBuilder.InsertData(
                table: "lesson_type",
                columns: ["uid", "name"],
                values: new object[,]
                {
                    { 1, "individual" },
                    { 2, "group" }
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    uid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    last_name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("student__pk", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "lesson",
                columns: table => new
                {
                    uid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    starting_time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    duration = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Price = table.Column<ushort>(type: "INTEGER", nullable: false),
                    lesson_state_type_uid = table.Column<int>(type: "INTEGER", nullable: false),
                    lesson_type_uid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("lesson__pk", x => x.uid);
                    table.ForeignKey(
                        name: "FK_lesson_lesson_state_type_lesson_state_type_uid",
                        column: x => x.lesson_state_type_uid,
                        principalTable: "lesson_state_type",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lesson_lesson_type_lesson_type_uid",
                        column: x => x.lesson_type_uid,
                        principalTable: "lesson_type",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lesson_student",
                columns: table => new
                {
                    lesson_uid = table.Column<int>(type: "INTEGER", nullable: false),
                    student_uid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("lesson_student__pk", x => new { x.lesson_uid, x.student_uid });
                    table.ForeignKey(
                        name: "FK_lesson_student_lesson_lesson_uid",
                        column: x => x.lesson_uid,
                        principalTable: "lesson",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lesson_student_student_student_uid",
                        column: x => x.student_uid,
                        principalTable: "student",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lesson_lesson_state_type_uid",
                table: "lesson",
                column: "lesson_state_type_uid");

            migrationBuilder.CreateIndex(
                name: "IX_lesson_lesson_type_uid",
                table: "lesson",
                column: "lesson_type_uid");

            migrationBuilder.CreateIndex(
                name: "IX_lesson_student_student_uid",
                table: "lesson_student",
                column: "student_uid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lesson_student");

            migrationBuilder.DropTable(
                name: "lesson");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "lesson_state_type");

            migrationBuilder.DropTable(
                name: "lesson_type");
        }
    }
}
