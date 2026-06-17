using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduClick.Migrations.EduClick
{
    /// <inheritdoc />
    public partial class AgregarObservacionDocente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Docentes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Docentes");
        }
    }
}
