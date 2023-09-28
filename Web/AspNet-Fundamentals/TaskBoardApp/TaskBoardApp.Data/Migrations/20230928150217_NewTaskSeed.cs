using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class NewTaskSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("3668f239-88b1-4a41-99ee-6b494e1a2a9b"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("9bcba4a6-b050-44e6-a8f1-1706d99eeb83"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a19b9877-754e-4481-a317-03a18d0cb87b"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c77ec508-d08d-488f-aa74-5bcb4b63a6f4"));

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("0aaa14bb-6f73-4010-8447-937c790cbb35"), 3, new DateTime(2022, 9, 28, 15, 2, 17, 305, DateTimeKind.Utc).AddTicks(4733), "Implement [Create Task] page for adding tasks", "5fa3b317-d421-4f05-b6f5-be1bfff33573", "Create Tasks" },
                    { new Guid("0d5c1843-c807-4650-9c4e-ea1b1b2e6552"), 1, new DateTime(2023, 4, 28, 15, 2, 17, 305, DateTimeKind.Utc).AddTicks(4726), "Create Android client App for the RESTful TaskBoard service", "9b3cbdbe-8ca7-4732-8107-3c2ce800cbd3", "Android Client App" },
                    { new Guid("77ce819c-f75e-4f6f-86de-92e2ec93599a"), 1, new DateTime(2023, 3, 12, 15, 2, 17, 305, DateTimeKind.Utc).AddTicks(4700), "Implement better styling for all public pages", "9b3cbdbe-8ca7-4732-8107-3c2ce800cbd3", "Improve CSS styles" },
                    { new Guid("f1f6ba08-a3ee-4d54-ab43-4f9e04765e4d"), 2, new DateTime(2023, 8, 28, 15, 2, 17, 305, DateTimeKind.Utc).AddTicks(4731), "Create Desktop client App for the RESTful TaskBoard service", "5fa3b317-d421-4f05-b6f5-be1bfff33573", "Desktop Client App" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("0aaa14bb-6f73-4010-8447-937c790cbb35"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("0d5c1843-c807-4650-9c4e-ea1b1b2e6552"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("77ce819c-f75e-4f6f-86de-92e2ec93599a"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("f1f6ba08-a3ee-4d54-ab43-4f9e04765e4d"));

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
        }
    }
}
