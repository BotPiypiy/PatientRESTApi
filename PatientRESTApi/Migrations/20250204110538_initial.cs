using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientRESTApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Use = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Given_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Given_Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
