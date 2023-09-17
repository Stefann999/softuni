using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class AddTasksAndBoardsAndSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("3668f239-88b1-4a41-99ee-6b494e1a2a9b"), 3, new DateTime(2022, 9, 17, 12, 59, 39, 561, DateTimeKind.Utc).AddTicks(4134), "Implement [Create Task] page for adding tasks", "5fa3b317-d421-4f05-b6f5-be1bfff33573", "Create Tasks" },
                    { new Guid("9bcba4a6-b050-44e6-a8f1-1706d99eeb83"), 1, new DateTime(2023, 4, 17, 12, 59, 39, 561, DateTimeKind.Utc).AddTicks(4118), "Create Android client App for the RESTful TaskBoard service", "9b3cbdbe-8ca7-4732-8107-3c2ce800cbd3", "Android Client App" },
                    { new Guid("a19b9877-754e-4481-a317-03a18d0cb87b"), 1, new DateTime(2023, 3, 1, 12, 59, 39, 561, DateTimeKind.Utc).AddTicks(4096), "Implement better styling for all public pages", "9b3cbdbe-8ca7-4732-8107-3c2ce800cbd3", "Improve CSS styles" },
                    { new Guid("c77ec508-d08d-488f-aa74-5bcb4b63a6f4"), 2, new DateTime(2023, 8, 17, 12, 59, 39, 561, DateTimeKind.Utc).AddTicks(4122), "Create Desktop client App for the RESTful TaskBoard service", "5fa3b317-d421-4f05-b6f5-be1bfff33573", "Desktop Client App" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
