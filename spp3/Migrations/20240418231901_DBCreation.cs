using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class DBCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommercialOrganizations",
                columns: table => new
                {
                    coId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    organizationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialOrganizations", x => x.coId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patrynomic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: true),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CuId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orId);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ageLimit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ptId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    suId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.suId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    urId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.urId);
                });

            migrationBuilder.CreateTable(
                name: "tradeOutlets",
                columns: table => new
                {
                    toId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    outletName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    outletType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    size = table.Column<double>(type: "float", nullable: true),
                    rent = table.Column<double>(type: "float", nullable: true),
                    counters = table.Column<int>(type: "int", nullable: true),
                    coId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tradeOutlets", x => x.toId);
                    table.ForeignKey(
                        name: "FK_tradeOutlets_CommercialOrganizations_coId",
                        column: x => x.coId,
                        principalTable: "CommercialOrganizations",
                        principalColumn: "coId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonusCards",
                columns: table => new
                {
                    BcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discount = table.Column<float>(type: "real", nullable: false),
                    cuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusCards", x => x.BcId);
                    table.ForeignKey(
                        name: "FK_BonusCards_Customers_cuId",
                        column: x => x.cuId,
                        principalTable: "Customers",
                        principalColumn: "CuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    prId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    ptId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.prId);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ptId",
                        column: x => x.ptId,
                        principalTable: "ProductTypes",
                        principalColumn: "ptId");
                });

            migrationBuilder.CreateTable(
                name: "OrderToSuppluer",
                columns: table => new
                {
                    orID = table.Column<int>(type: "int", nullable: false),
                    suID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderToSupplier", x => new { x.orID, x.suID });
                    table.ForeignKey(
                        name: "FK__OrderToSupplier__orID",
                        column: x => x.orID,
                        principalTable: "Orders",
                        principalColumn: "orId");
                    table.ForeignKey(
                        name: "FK__OrderToSupplier__suID",
                        column: x => x.suID,
                        principalTable: "Suppliers",
                        principalColumn: "suId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    usId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.usId);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_urId",
                        column: x => x.urId,
                        principalTable: "UserRoles",
                        principalColumn: "urId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutletSections",
                columns: table => new
                {
                    osId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sectionFloor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sectionHall = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    toId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutletSections", x => x.osId);
                    table.ForeignKey(
                        name: "FK_OutletSections_tradeOutlets_toId",
                        column: x => x.toId,
                        principalTable: "tradeOutlets",
                        principalColumn: "toId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductToOrder",
                columns: table => new
                {
                    prID = table.Column<int>(type: "int", nullable: false),
                    orID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductToOrder", x => new { x.prID, x.orID });
                    table.ForeignKey(
                        name: "FK__ProductToOrder__orID",
                        column: x => x.orID,
                        principalTable: "Orders",
                        principalColumn: "orId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ProductToOrder__prID",
                        column: x => x.prID,
                        principalTable: "Products",
                        principalColumn: "prId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionManagers",
                columns: table => new
                {
                    smId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patrynomic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salary = table.Column<double>(type: "float", nullable: true),
                    experience = table.Column<double>(type: "float", nullable: true),
                    osId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionManagers", x => x.smId);
                    table.ForeignKey(
                        name: "FK_SectionManagers_OutletSections_osId",
                        column: x => x.osId,
                        principalTable: "OutletSections",
                        principalColumn: "osId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    selId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patrynomic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salary = table.Column<double>(type: "float", nullable: true),
                    endOfContract = table.Column<DateOnly>(type: "date", nullable: true),
                    osId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.selId);
                    table.ForeignKey(
                        name: "FK_Sellers_OutletSections_osId",
                        column: x => x.osId,
                        principalTable: "OutletSections",
                        principalColumn: "osId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    dlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dealMoment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cuId = table.Column<int>(type: "int", nullable: false),
                    prId = table.Column<int>(type: "int", nullable: false),
                    selId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.dlId);
                    table.ForeignKey(
                        name: "FK_Deals_Customers_cuId",
                        column: x => x.cuId,
                        principalTable: "Customers",
                        principalColumn: "CuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Products_prId",
                        column: x => x.prId,
                        principalTable: "Products",
                        principalColumn: "prId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Sellers_selId",
                        column: x => x.selId,
                        principalTable: "Sellers",
                        principalColumn: "selId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BonusCards_cuId",
                table: "BonusCards",
                column: "cuId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deals_cuId",
                table: "Deals",
                column: "cuId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_prId",
                table: "Deals",
                column: "prId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_selId",
                table: "Deals",
                column: "selId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderToSuppluer_suID",
                table: "OrderToSuppluer",
                column: "suID");

            migrationBuilder.CreateIndex(
                name: "IX_OutletSections_toId",
                table: "OutletSections",
                column: "toId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ptId",
                table: "Products",
                column: "ptId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToOrder_orID",
                table: "ProductToOrder",
                column: "orID");

            migrationBuilder.CreateIndex(
                name: "IX_SectionManagers_osId",
                table: "SectionManagers",
                column: "osId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_osId",
                table: "Sellers",
                column: "osId");

            migrationBuilder.CreateIndex(
                name: "IX_tradeOutlets_coId",
                table: "tradeOutlets",
                column: "coId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_urId",
                table: "Users",
                column: "urId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BonusCards");

            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "OrderToSuppluer");

            migrationBuilder.DropTable(
                name: "ProductToOrder");

            migrationBuilder.DropTable(
                name: "SectionManagers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "OutletSections");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "tradeOutlets");

            migrationBuilder.DropTable(
                name: "CommercialOrganizations");
        }
    }
}
