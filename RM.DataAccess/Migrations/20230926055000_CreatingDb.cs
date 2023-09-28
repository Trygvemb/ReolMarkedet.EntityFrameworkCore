using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RM.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreatingDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShelfTenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelfTenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Barcodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountInPercentage = table.Column<double>(type: "float", nullable: false),
                    ShelfTenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barcodes_ShelfTenants_ShelfTenantId",
                        column: x => x.ShelfTenantId,
                        principalTable: "ShelfTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalSale = table.Column<double>(type: "float", nullable: false),
                    Fine = table.Column<double>(type: "float", nullable: false),
                    CommissionInPercentage = table.Column<double>(type: "float", nullable: false),
                    CommissionDeducted = table.Column<double>(type: "float", nullable: false),
                    TotalPayout = table.Column<double>(type: "float", nullable: false),
                    ShelfTenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payouts_ShelfTenants_ShelfTenantId",
                        column: x => x.ShelfTenantId,
                        principalTable: "ShelfTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DiscountInPercentage = table.Column<double>(type: "float", nullable: false),
                    PriceOfSale = table.Column<double>(type: "float", nullable: false),
                    BarcodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Barcodes_BarcodeId",
                        column: x => x.BarcodeId,
                        principalTable: "Barcodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ShelfTenants",
                columns: new[] { "Id", "BankAccountDetails", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Bank 1234-12345678", "JonDoe@Mail.com", "jon", "Doe", "12345678" },
                    { 2, "Bank 1234-22222222", "JaneD@Mail.com", "Jane", "Doe", "2222222" },
                    { 3, "Bank 1234-333333333", "Something@Mail.com", "Some", "Thing", "33333333" }
                });

            migrationBuilder.InsertData(
                table: "Barcodes",
                columns: new[] { "Id", "DiscountInPercentage", "ShelfTenantId" },
                values: new object[,]
                {
                    { 1, 0.0, 1 },
                    { 2, 50.0, 1 },
                    { 3, 0.0, 2 },
                    { 4, 0.0, 3 }
                });

            migrationBuilder.InsertData(
                table: "Payouts",
                columns: new[] { "Id", "CommissionDeducted", "CommissionInPercentage", "Fine", "ShelfTenantId", "TotalPayout", "TotalSale" },
                values: new object[,]
                {
                    { 1, 0.0, 15.0, 0.0, 1, 0.0, 0.0 },
                    { 2, 0.0, 15.0, 350.0, 2, 0.0, 0.0 },
                    { 3, 0.0, 15.0, 0.0, 3, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "BarcodeId", "DiscountInPercentage", "Price", "PriceOfSale" },
                values: new object[,]
                {
                    { 1, 1, 0.0, 50.0, 0.0 },
                    { 2, 1, 0.0, 30.0, 0.0 },
                    { 3, 2, 50.0, 110.0, 55.0 },
                    { 4, 3, 0.0, 50.5, 0.0 },
                    { 5, 4, 0.0, 80.299999999999997, 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barcodes_ShelfTenantId",
                table: "Barcodes",
                column: "ShelfTenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Payouts_ShelfTenantId",
                table: "Payouts",
                column: "ShelfTenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BarcodeId",
                table: "Sales",
                column: "BarcodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payouts");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Barcodes");

            migrationBuilder.DropTable(
                name: "ShelfTenants");
        }
    }
}
