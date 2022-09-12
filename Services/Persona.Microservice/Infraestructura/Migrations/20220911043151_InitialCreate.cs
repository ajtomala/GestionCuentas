using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Personaid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Personaid);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Personaid = table.Column<long>(type: "bigint", nullable: false),
                    contrasenia = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Personaid);
                    table.ForeignKey(
                        name: "FK_Cliente_Persona_Personaid",
                        column: x => x.Personaid,
                        principalTable: "Persona",
                        principalColumn: "Personaid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    cuentaid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numcuenta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    tipocuenta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    saldoinicial = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    clienteid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.cuentaid);
                    table.ForeignKey(
                        name: "FK_Cuenta_Cliente_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Cliente",
                        principalColumn: "Personaid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    movimientoid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipomovimiento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    valor = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    cuentaid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.movimientoid);
                    table.ForeignKey(
                        name: "FK_Movimiento_Cuenta_cuentaid",
                        column: x => x.cuentaid,
                        principalTable: "Cuenta",
                        principalColumn: "cuentaid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clienteid",
                table: "Cliente",
                column: "Personaid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_clienteid",
                table: "Cuenta",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_numcuenta",
                table: "Cuenta",
                column: "numcuenta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_cuentaid",
                table: "Movimiento",
                column: "cuentaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
