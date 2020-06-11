using Microsoft.EntityFrameworkCore.Migrations;

namespace Commander.Migrations
{
    public partial class mockobjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "HowTo", "Line", "Platform" },
                values: new object[] { 1, "Boil an egg", "Boil water", "Kettle & Pan" });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "HowTo", "Line", "Platform" },
                values: new object[] { 2, "Cut bread", "Get a knife", "Knife & chopping board" });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "HowTo", "Line", "Platform" },
                values: new object[] { 3, "Make cup of tea", "Place teabug in cup", "Kettle & Cup" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
