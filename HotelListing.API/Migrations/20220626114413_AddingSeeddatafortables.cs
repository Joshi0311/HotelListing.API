using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.API.Migrations
{
    public partial class AddingSeeddatafortables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "countries",
                columns: new[] { "ID", "Name", "shortName" },
                values: new object[] { 1, "India", "IND" });

            migrationBuilder.InsertData(
                table: "countries",
                columns: new[] { "ID", "Name", "shortName" },
                values: new object[] { 2, "Australia", "AUS" });

            migrationBuilder.InsertData(
                table: "countries",
                columns: new[] { "ID", "Name", "shortName" },
                values: new object[] { 3, "Newzeland", "NZ" });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[] { 1, "Ratahara", 1, "Landmark Hotel", 5.2999999999999998 });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[] { 2, "NehruNagar", 2, "sanskaar Hotel", 4.0 });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[] { 3, "Malviya Nagar ", 2, "Dang Hotel", 4.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
