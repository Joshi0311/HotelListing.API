using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.API.Migrations
{
    public partial class AddingRoleConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6876a343-49b8-4bdb-95c8-69ae33e3c4cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8a758f2-0249-438b-b1e7-62d8838371c6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33f21070-846b-433c-97d8-cf570c26b8ba", "ec4a072f-2d2b-432f-bcfa-933c1a18d36c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6dc7057c-1fbe-4c80-9153-23778fbaa3db", "1b007599-440e-4e59-a618-006d5af4f079", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33f21070-846b-433c-97d8-cf570c26b8ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dc7057c-1fbe-4c80-9153-23778fbaa3db");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6876a343-49b8-4bdb-95c8-69ae33e3c4cc", "0664ef37-e34b-445b-8af9-1465d058c10b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8a758f2-0249-438b-b1e7-62d8838371c6", "a2d3fbe6-e774-4963-89fe-f1215db80753", "Administrator", "ADMINISTRATOR" });
        }
    }
}
