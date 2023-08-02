using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Ciudad",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Producto",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Correo", "Apellido", "Cedula", "Ciudad", "Direccion", "Genero", "HashPassword", "Nombre", "RolId", "Telefono" },
                values: new object[] { "admin123@gmail.com", "", "", "", "", "", "CD0FD917F8A83A248614BCE69172839D2E06F30D77C6ADBD9DBD693DF6184ABE", "", 1, "" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_UsuarioId",
                table: "Producto",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Usuario_UsuarioId",
                table: "Producto",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Correo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Usuario_UsuarioId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Producto_UsuarioId",
                table: "Producto");

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Correo",
                keyValue: "admin123@gmail.com");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Producto");

            migrationBuilder.AlterColumn<string>(
                name: "Ciudad",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
