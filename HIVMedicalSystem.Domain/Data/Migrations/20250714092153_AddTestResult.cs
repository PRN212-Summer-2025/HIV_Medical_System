using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HIVMedicalSystem.Domain.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTestResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ARVProtocol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARVProtocol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnosisDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TreatmentNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TestResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CD4Count = table.Column<int>(type: "int", nullable: false),
                    ViralLoad = table.Column<int>(type: "int", nullable: false),
                    ALT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AST = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Creatine = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResult_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ARVMedicalRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    ARVProtocolId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARVMedicalRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ARVMedicalRecord_ARVProtocol_ARVProtocolId",
                        column: x => x.ARVProtocolId,
                        principalTable: "ARVProtocol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ARVMedicalRecord_MedicalRecord_RecordId",
                        column: x => x.RecordId,
                        principalTable: "MedicalRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ARVMedicalRecord_ARVProtocolId",
                table: "ARVMedicalRecord",
                column: "ARVProtocolId");

            migrationBuilder.CreateIndex(
                name: "IX_ARVMedicalRecord_RecordId",
                table: "ARVMedicalRecord",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_CustomerId",
                table: "MedicalRecord",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_DoctorId",
                table: "MedicalRecord",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_UserId",
                table: "TestResult",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ARVMedicalRecord");

            migrationBuilder.DropTable(
                name: "TestResult");

            migrationBuilder.DropTable(
                name: "ARVProtocol");

            migrationBuilder.DropTable(
                name: "MedicalRecord");
        }
    }
}
