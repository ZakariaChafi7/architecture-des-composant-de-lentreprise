using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artisanaux.Services.ProductAPI.Migrations
{
    public partial class seedsMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "ImageURL", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, "Rongement", "https://artisanamf.blob.core.windows.net/artisana/1.jpeg", 1500.0, "Espace de Rongement" },
                    { 2, "Rongement", "https://artisanamf.blob.core.windows.net/artisana/2.jpg", 1600.0, " Rongement" },
                    { 3, "Rongement", "https://artisanamf.blob.core.windows.net/artisana/3.jpeg", 2600.0, " Rongement simple" },
                    { 4, "Rongement", "https://artisanamf.blob.core.windows.net/artisana/4.jpeg", 600.0, " Rongement complex" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
