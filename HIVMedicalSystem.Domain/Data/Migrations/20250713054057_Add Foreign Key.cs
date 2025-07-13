using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HIVMedicalSystem.Domain.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DegreeTypeId",
                table: "Degrees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Degrees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Degrees_DegreeTypeId",
                table: "Degrees",
                column: "DegreeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Degrees_UserId",
                table: "Degrees",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Degrees_DegreeTypes_DegreeTypeId",
                table: "Degrees",
                column: "DegreeTypeId",
                principalTable: "DegreeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Degrees_Users_UserId",
                table: "Degrees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degrees_DegreeTypes_DegreeTypeId",
                table: "Degrees");

            migrationBuilder.DropForeignKey(
                name: "FK_Degrees_Users_UserId",
                table: "Degrees");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Degrees_DegreeTypeId",
                table: "Degrees");

            migrationBuilder.DropIndex(
                name: "IX_Degrees_UserId",
                table: "Degrees");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DegreeTypeId",
                table: "Degrees");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Degrees");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });
        }
    }
}
