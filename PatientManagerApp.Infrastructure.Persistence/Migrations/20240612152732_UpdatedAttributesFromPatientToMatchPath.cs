using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientManagerApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAttributesFromPatientToMatchPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Patients",
                newName: "PicturePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PicturePath",
                table: "Patients",
                newName: "Picture");
        }
    }
}
