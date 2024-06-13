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
                    uid = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("lesson_state_type__pk", x => x.uid);
                });

            migrationBuilder.InsertData(
                table: "lesson_state_type",
                columns: ["uid", "name"],
                values: new object[,]
                {
                    { Guid.Parse("4fa18d19-9810-4ff7-9e8e-9bbd4a652de0"), "appointed" },
                    { Guid.Parse("5cb127de-f207-4532-98b8-bc58ef9dcd69"), "completed" },
                    { Guid.Parse("fd5b9d5f-2dc7-41a0-8a8b-7e158b8c44b5"), "rescheduled" },
                    { Guid.Parse("a0e1a49e-531f-469a-a14b-f0c605c056d5"), "dismissed" }
                });

            migrationBuilder.CreateTable(
                name: "lesson_type",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("lesson_type__pk", x => x.uid);
                });

            migrationBuilder.InsertData(
                table: "lesson_type",
                columns: ["uid", "name"],
                values: new object[,]
                {
                    { Guid.Parse("de305d54-75b4-431b-adb2-eb6b9e546013"), "individual" },
                    { Guid.Parse("a5debb58-12ab-489b-9633-d0a1e4e3f54b"), "group" }
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    uid = table.Column<Guid>(type: "TEXT", nullable: false),
                    starting_time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    duration = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Price = table.Column<ushort>(type: "INTEGER", nullable: false),
                    lesson_state_type_uid = table.Column<Guid>(type: "TEXT", nullable: false),
                    lesson_type_uid = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    lesson_uid = table.Column<Guid>(type: "TEXT", nullable: false),
                    student_uid = table.Column<Guid>(type: "TEXT", nullable: false)
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
