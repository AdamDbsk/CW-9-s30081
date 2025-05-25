using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CW_9_s30081.Migrations
{
    /// <inheritdoc />
    public partial class Trulymen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_DoctorID_IdDoctor",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_PatientID_IdPatient",
                table: "Prescription");

            migrationBuilder.DropTable(
                name: "DoctorID");

            migrationBuilder.DropTable(
                name: "PatientID");

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.IdPatient);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Doctor_IdDoctor",
                table: "Prescription",
                column: "IdDoctor",
                principalTable: "Doctor",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Patient_IdPatient",
                table: "Prescription",
                column: "IdPatient",
                principalTable: "Patient",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Doctor_IdDoctor",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Patient_IdPatient",
                table: "Prescription");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.CreateTable(
                name: "DoctorID",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorID", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "PatientID",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientID", x => x.IdPatient);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_DoctorID_IdDoctor",
                table: "Prescription",
                column: "IdDoctor",
                principalTable: "DoctorID",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_PatientID_IdPatient",
                table: "Prescription",
                column: "IdPatient",
                principalTable: "PatientID",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
