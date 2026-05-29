using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduClick.Migrations
{
    /// <inheritdoc />
    public partial class CambiarPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acudientes_Usuarios_UsuarioCorreo",
                table: "Acudientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Docentes_Usuarios_UsuarioCorreo",
                table: "Docentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Usuarios_UsuarioCorreo",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rectores_Usuarios_UsuarioCorreo",
                table: "Rectores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Rectores_UsuarioCorreo",
                table: "Rectores");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_UsuarioCorreo",
                table: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_Docentes_UsuarioCorreo",
                table: "Docentes");

            migrationBuilder.DropIndex(
                name: "IX_Acudientes_UsuarioCorreo",
                table: "Acudientes");

            migrationBuilder.DropColumn(
                name: "UsuarioCorreo",
                table: "Rectores");

            migrationBuilder.DropColumn(
                name: "UsuarioCorreo",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "UsuarioCorreo",
                table: "Docentes");

            migrationBuilder.DropColumn(
                name: "UsuarioCorreo",
                table: "Acudientes");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rectores_UsuarioId",
                table: "Rectores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_UsuarioId",
                table: "Estudiantes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Docentes_UsuarioId",
                table: "Docentes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Acudientes_UsuarioId",
                table: "Acudientes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acudientes_Usuarios_UsuarioId",
                table: "Acudientes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Docentes_Usuarios_UsuarioId",
                table: "Docentes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Usuarios_UsuarioId",
                table: "Estudiantes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rectores_Usuarios_UsuarioId",
                table: "Rectores",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acudientes_Usuarios_UsuarioId",
                table: "Acudientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Docentes_Usuarios_UsuarioId",
                table: "Docentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Usuarios_UsuarioId",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rectores_Usuarios_UsuarioId",
                table: "Rectores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Rectores_UsuarioId",
                table: "Rectores");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_UsuarioId",
                table: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_Docentes_UsuarioId",
                table: "Docentes");

            migrationBuilder.DropIndex(
                name: "IX_Acudientes_UsuarioId",
                table: "Acudientes");

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCorreo",
                table: "Rectores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCorreo",
                table: "Estudiantes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCorreo",
                table: "Docentes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCorreo",
                table: "Acudientes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Correo");

            migrationBuilder.CreateIndex(
                name: "IX_Rectores_UsuarioCorreo",
                table: "Rectores",
                column: "UsuarioCorreo");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_UsuarioCorreo",
                table: "Estudiantes",
                column: "UsuarioCorreo");

            migrationBuilder.CreateIndex(
                name: "IX_Docentes_UsuarioCorreo",
                table: "Docentes",
                column: "UsuarioCorreo");

            migrationBuilder.CreateIndex(
                name: "IX_Acudientes_UsuarioCorreo",
                table: "Acudientes",
                column: "UsuarioCorreo");

            migrationBuilder.AddForeignKey(
                name: "FK_Acudientes_Usuarios_UsuarioCorreo",
                table: "Acudientes",
                column: "UsuarioCorreo",
                principalTable: "Usuarios",
                principalColumn: "Correo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Docentes_Usuarios_UsuarioCorreo",
                table: "Docentes",
                column: "UsuarioCorreo",
                principalTable: "Usuarios",
                principalColumn: "Correo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Usuarios_UsuarioCorreo",
                table: "Estudiantes",
                column: "UsuarioCorreo",
                principalTable: "Usuarios",
                principalColumn: "Correo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rectores_Usuarios_UsuarioCorreo",
                table: "Rectores",
                column: "UsuarioCorreo",
                principalTable: "Usuarios",
                principalColumn: "Correo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
