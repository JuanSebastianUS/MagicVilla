using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la Villa", new DateTime(2023, 8, 3, 10, 57, 46, 945, DateTimeKind.Local).AddTicks(4954), new DateTime(2023, 8, 3, 10, 57, 46, 945, DateTimeKind.Local).AddTicks(4943), "", 5, "Villa Real", 5, 200 },
                    { 2, "", "Detalle de la Villa", new DateTime(2023, 8, 3, 10, 57, 46, 945, DateTimeKind.Local).AddTicks(4957), new DateTime(2023, 8, 3, 10, 57, 46, 945, DateTimeKind.Local).AddTicks(4957), "", 4, "Villa Chica", 4, 200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
