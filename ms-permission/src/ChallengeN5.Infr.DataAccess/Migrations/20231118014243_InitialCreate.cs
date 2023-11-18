using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChallengeN5.Infr.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposPermisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Permission description")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPermisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Employee Forename"),
                    ApellidoEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Employee Surname"),
                    TipoPermiso = table.Column<int>(type: "int", nullable: false, comment: "Permission Type"),
                    FechaPermiso = table.Column<DateOnly>(type: "date", nullable: false, comment: "Permission granted on Date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permisos_TiposPermisos_TipoPermiso",
                        column: x => x.TipoPermiso,
                        principalTable: "TiposPermisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposPermisos",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "ADMIN" },
                    { 2, "READ_WRITE" },
                    { 3, "WRITE" },
                    { 4, "READ" }
                });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "FechaPermiso", "NombreEmpleado", "ApellidoEmpleado", "TipoPermiso" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 11, 14), "Miguel", "Garcia", 1 },
                    { 2, new DateOnly(2023, 11, 14), "Pedro", "Pereira", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_TipoPermiso",
                table: "Permisos",
                column: "TipoPermiso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "TiposPermisos");
        }
    }
}
