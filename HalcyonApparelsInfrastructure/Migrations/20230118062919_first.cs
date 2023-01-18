using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HalcyonApparelsInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLogin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                columns: table => new
                {
                    ContactId = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Fname = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Lname = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMarketing",
                columns: table => new
                {
                    ContactId = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    ProductTypec = table.Column<string>(name: "Product_Type__c", type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMarketing", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "LoginCredentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginCredentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentOrderIdc = table.Column<string>(name: "Parent_Order_Id__c", type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    dateoforderc = table.Column<string>(name: "date_of_order__c", type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    ProductTypec = table.Column<string>(name: "Product_Type__c", type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Contactc = table.Column<string>(name: "Contact__c", type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CustomerDetailsContactId = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_CustomerDetails_CustomerDetailsContactId",
                        column: x => x.CustomerDetailsContactId,
                        principalTable: "CustomerDetails",
                        principalColumn: "ContactId");
                });

            migrationBuilder.CreateTable(
                name: "AccessoryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccsryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessoryType_Products_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccessoryDetails",
                columns: table => new
                {
                    AccessoryId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessoryName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    AccessoryType = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    AccessoryBrand = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    AccessoryPrice = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    AccessoryDiscount = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDetailsId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryDetails", x => x.AccessoryId);
                    table.ForeignKey(
                        name: "FK_AccessoryDetails_OrderDetails_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryDetails_OrderDetailsId",
                table: "AccessoryDetails",
                column: "OrderDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryType_ProductTypeId",
                table: "AccessoryType",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CustomerDetailsContactId",
                table: "OrderDetails",
                column: "CustomerDetailsContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoryDetails");

            migrationBuilder.DropTable(
                name: "AccessoryType");

            migrationBuilder.DropTable(
                name: "AdminLogin");

            migrationBuilder.DropTable(
                name: "CustomerMarketing");

            migrationBuilder.DropTable(
                name: "LoginCredentials");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CustomerDetails");
        }
    }
}
