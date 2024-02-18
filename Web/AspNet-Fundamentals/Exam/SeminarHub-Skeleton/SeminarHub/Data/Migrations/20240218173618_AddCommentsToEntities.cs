using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeminarHub.Data.Migrations
{
    public partial class AddCommentsToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "SeminarsParticipants",
                comment: "The participants in the seminars");

            migrationBuilder.AlterTable(
                name: "Seminars",
                comment: "Seminars for the SeminarHub");

            migrationBuilder.AlterTable(
                name: "Categories",
                comment: "Categories of seminars");

            migrationBuilder.AlterColumn<string>(
                name: "ParticipantId",
                table: "SeminarsParticipants",
                type: "nvarchar(450)",
                nullable: false,
                comment: "The seminar's participant id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "SeminarId",
                table: "SeminarsParticipants",
                type: "int",
                nullable: false,
                comment: "The participant's seminar id",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "Seminars",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "The topic of the seminar",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "Seminars",
                type: "nvarchar(450)",
                nullable: false,
                comment: "The seminar's organizer id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Lecturer",
                table: "Seminars",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                comment: "The lecturer of the seminar",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Seminars",
                type: "int",
                nullable: true,
                comment: "The seminar's duration in minutes",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Seminars",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Details for the seminar",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTime",
                table: "Seminars",
                type: "datetime2",
                nullable: false,
                comment: "The seminar's start date and time",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Seminars",
                type: "int",
                nullable: false,
                comment: "The seminar's category id",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Seminars",
                type: "int",
                nullable: false,
                comment: "The Primary Key of the Seminar",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The name of the Category",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                comment: "The Primary Key of the Category",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "SeminarsParticipants",
                oldComment: "The participants in the seminars");

            migrationBuilder.AlterTable(
                name: "Seminars",
                oldComment: "Seminars for the SeminarHub");

            migrationBuilder.AlterTable(
                name: "Categories",
                oldComment: "Categories of seminars");

            migrationBuilder.AlterColumn<string>(
                name: "ParticipantId",
                table: "SeminarsParticipants",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "The seminar's participant id");

            migrationBuilder.AlterColumn<int>(
                name: "SeminarId",
                table: "SeminarsParticipants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The participant's seminar id");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "Seminars",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "The topic of the seminar");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "Seminars",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "The seminar's organizer id");

            migrationBuilder.AlterColumn<string>(
                name: "Lecturer",
                table: "Seminars",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldComment: "The lecturer of the seminar");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Seminars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "The seminar's duration in minutes");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Seminars",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Details for the seminar");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTime",
                table: "Seminars",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The seminar's start date and time");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Seminars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The seminar's category id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Seminars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The Primary Key of the Seminar")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The name of the Category");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The Primary Key of the Category")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
