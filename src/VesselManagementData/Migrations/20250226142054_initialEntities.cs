using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VesselManagementData.Migrations
{
    /// <inheritdoc />
    public partial class initialEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Giorgio", "Tomaino" },
                    { 2, "Tommaso", "Turigliato" }
                });

            migrationBuilder.InsertData(
                table: "Vessels",
                columns: new[] { "Id", "ImoNumber", "OwnerId" },
                values: new object[,]
                {
                    { 1, "IMO 0000001", null },
                    { 2, "IMO 0000002", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vessels",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
