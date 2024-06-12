using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientManagerApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedNavegationPropertyToLaboratoryResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LaboratoryResultId",
                table: "LaboratoryTests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "LaboratoryResults",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryTests_LaboratoryResultId",
                table: "LaboratoryTests",
                column: "LaboratoryResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryTests_LaboratoryResults_LaboratoryResultId",
                table: "LaboratoryTests",
                column: "LaboratoryResultId",
                principalTable: "LaboratoryResults",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryTests_LaboratoryResults_LaboratoryResultId",
                table: "LaboratoryTests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryTests_LaboratoryResultId",
                table: "LaboratoryTests");

            migrationBuilder.DropColumn(
                name: "LaboratoryResultId",
                table: "LaboratoryTests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LaboratoryResults");
        }
    }
}
