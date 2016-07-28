using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<long>(type: "int", nullable: false)
                        .Annotation("Autoincrement", true),
                    CategoryName = table.Column<string>(type: "nvarchar", nullable: false),
                    Description = table.Column<string>(type: "nvarchar", nullable: true),
                    Picture = table.Column<byte[]>(type: "blob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_Categories_1", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDemographics",
                columns: table => new
                {
                    CustomerTypeID = table.Column<string>(type: "char", nullable: false),
                    CustomerDesc = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_CustomerDemographics_1", x => x.CustomerTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<string>(type: "char", nullable: false),
                    Address = table.Column<string>(type: "nvarchar", nullable: true),
                    City = table.Column<string>(type: "nvarchar", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar", nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar", nullable: true),
                    Country = table.Column<string>(type: "nvarchar", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar", nullable: true),
                    Region = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_Customers_1", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<long>(type: "int", nullable: false)
                        .Annotation("Autoincrement", true),
                    Address = table.Column<string>(type: "nvarchar", nullable: true),
                    BirthDate = table.Column<string>(type: "datetime", nullable: true),
                    City = table.Column<string>(type: "nvarchar", nullable: true),
                    Country = table.Column<string>(type: "nvarchar", nullable: true),
                    Deleted = table.Column<string>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Extension = table.Column<string>(type: "nvarchar", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar", nullable: false),
                    HireDate = table.Column<string>(type: "datetime", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar", nullable: true),
                    Photo = table.Column<byte[]>(type: "blob", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar", nullable: true),
                    Region = table.Column<string>(type: "nvarchar", nullable: true),
                    ReportsTo = table.Column<long>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar", nullable: true),
                    TitleOfCourtesy = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_Employees_1", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ReportsTo",
                        column: x => x.ReportsTo,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionID = table.Column<long>(type: "int", nullable: false)
                        .Annotation("Autoincrement", true),
                    RegionDescription = table.Column<string>(type: "char", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    ShipperID = table.Column<long>(type: "int", nullable: false)
                        .Annotation("Autoincrement", true),
                    CompanyName = table.Column<string>(type: "nvarchar", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_Shippers_1", x => x.ShipperID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<long>(type: "int", nullable: false)
                        .Annotation("Autoincrement", true),
                    Address = table.Column<string>(type: "nvarchar", nullable: true),
                    City = table.Column<string>(type: "nvarchar", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar", nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar", nullable: true),
                    Country = table.Column<string>(type: "nvarchar", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar", nullable: true),
                    HomePage = table.Column<string>(type: "nvarchar", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar", nullable: true),
                    Region = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_Suppliers_1", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "TextEntry",
                columns: table => new
                {
                    contentID = table.Column<long>(type: "int", nullable: false)
                        .Annotation("Autoincrement", true),
                    callOut = table.Column<string>(type: "nvarchar", nullable: true),
                    content = table.Column<string>(type: "nvarchar", nullable: true),
                    contentGUID = table.Column<string>(type: "uniqueidentifier", nullable: false),
                    contentName = table.Column<string>(type: "nvarchar", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar", nullable: true),
                    createdOn = table.Column<string>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    dateExpires = table.Column<string>(type: "datetime", nullable: true),
                    externalLink = table.Column<string>(type: "nvarchar", nullable: true),
                    iconPath = table.Column<string>(type: "nvarchar", nullable: true),
                    lastEditedBy = table.Column<string>(type: "nvarchar", nullable: true),
                    listOrder = table.Column<long>(type: "int", nullable: false, defaultValueSql: "1")
                        .Annotation("Autoincrement", true),
                    modifiedBy = table.Column<string>(type: "nvarchar", nullable: true),
                    modifiedOn = table.Column<string>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<string>(type: "nvarchar", nullable: true),
                    title = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_TextEntry_1", x => x.contentID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCustomerDemo",
                columns: table => new
                {
                    CustomerID = table.Column<string>(type: "char", nullable: false),
                    CustomerTypeID = table.Column<string>(type: "char", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_CustomerCustomerDemo_1", x => new { x.CustomerID, x.CustomerTypeID });
                    table.ForeignKey(
                        name: "FK_CustomerCustomerDemo_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCustomerDemo_CustomerDemographics_CustomerTypeID",
                        column: x => x.CustomerTypeID,
                        principalTable: "CustomerDemographics",
                        principalColumn: "CustomerTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Territories",
                columns: table => new
                {
                    TerritoryID = table.Column<string>(type: "nvarchar", nullable: false),
                    RegionID = table.Column<long>(type: "int", nullable: false),
                    TerritoryDescription = table.Column<string>(type: "char", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_Territories_1", x => x.TerritoryID);
                    table.ForeignKey(
                        name: "FK_Territories_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<long>(type: "int", nullable: false)
                        .Annotation("Autoincrement", true),
                    CustomerID = table.Column<string>(type: "char", nullable: true),
                    EmployeeID = table.Column<long>(type: "int", nullable: true),
                    Freight = table.Column<string>(type: "decimal", nullable: true, defaultValueSql: "0"),
                    OrderDate = table.Column<string>(type: "datetime", nullable: true),
                    RequiredDate = table.Column<string>(type: "datetime", nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar", nullable: true),
                    ShipCity = table.Column<string>(type: "nvarchar", nullable: true),
                    ShipCountry = table.Column<string>(type: "nvarchar", nullable: true),
                    ShipName = table.Column<string>(type: "nvarchar", nullable: true),
                    ShipPostalCode = table.Column<string>(type: "nvarchar", nullable: true),
                    ShipRegion = table.Column<string>(type: "nvarchar", nullable: true),
                    ShipVia = table.Column<long>(type: "int", nullable: true),
                    ShippedDate = table.Column<string>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_Orders_1", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Shippers_ShipVia",
                        column: x => x.ShipVia,
                        principalTable: "Shippers",
                        principalColumn: "ShipperID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<long>(type: "int", nullable: false)
                        .Annotation("Autoincrement", true),
                    AttributeXML = table.Column<string>(type: "varchar", nullable: true),
                    CategoryID = table.Column<long>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar", nullable: true),
                    CreatedOn = table.Column<string>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateCreated = table.Column<string>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Deleted = table.Column<string>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Discontinued = table.Column<string>(type: "bit", nullable: false, defaultValueSql: "0"),
                    ModifiedBy = table.Column<string>(type: "nvarchar", nullable: true),
                    ModifiedOn = table.Column<string>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ProductGUID = table.Column<string>(type: "uniqueidentifier", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar", nullable: false),
                    QuantityPerUnit = table.Column<string>(type: "nvarchar", nullable: true),
                    ReorderLevel = table.Column<long>(type: "smallint", nullable: true, defaultValueSql: "0")
                        .Annotation("Autoincrement", true),
                    SupplierID = table.Column<long>(type: "int", nullable: true),
                    UnitPrice = table.Column<string>(type: "decimal", nullable: true, defaultValueSql: "0"),
                    UnitsInStock = table.Column<long>(type: "smallint", nullable: true, defaultValueSql: "0")
                        .Annotation("Autoincrement", true),
                    UnitsOnOrder = table.Column<long>(type: "smallint", nullable: true, defaultValueSql: "0")
                        .Annotation("Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_Products_1", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTerritories",
                columns: table => new
                {
                    EmployeeID = table.Column<long>(type: "int", nullable: false),
                    TerritoryID = table.Column<string>(type: "nvarchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_EmployeeTerritories_1", x => new { x.EmployeeID, x.TerritoryID });
                    table.ForeignKey(
                        name: "FK_EmployeeTerritories_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTerritories_Territories_TerritoryID",
                        column: x => x.TerritoryID,
                        principalTable: "Territories",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order Details",
                columns: table => new
                {
                    OrderID = table.Column<long>(type: "int", nullable: false),
                    ProductID = table.Column<long>(type: "int", nullable: false),
                    Discount = table.Column<string>(type: "SINGLE", nullable: false, defaultValueSql: "'0'"),
                    Quantity = table.Column<long>(type: "smallint", nullable: false, defaultValueSql: "'1'")
                        .Annotation("Autoincrement", true),
                    UnitPrice = table.Column<string>(type: "decimal", nullable: false, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_Order Details_1", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_Order Details_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order Details_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Category_Map",
                columns: table => new
                {
                    CategoryID = table.Column<long>(type: "int", nullable: false),
                    ProductID = table.Column<long>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_Product_Category_Map_1", x => new { x.CategoryID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_Product_Category_Map_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_Map_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCustomerDemo_CustomerID",
                table: "CustomerCustomerDemo",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCustomerDemo_CustomerTypeID",
                table: "CustomerCustomerDemo",
                column: "CustomerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsTo",
                table: "Employees",
                column: "ReportsTo");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTerritories_EmployeeID",
                table: "EmployeeTerritories",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTerritories_TerritoryID",
                table: "EmployeeTerritories",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Order Details_OrderID",
                table: "Order Details",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Order Details_ProductID",
                table: "Order Details",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeID",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipVia",
                table: "Orders",
                column: "ShipVia");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_Map_CategoryID",
                table: "Product_Category_Map",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_Map_ProductID",
                table: "Product_Category_Map",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierID",
                table: "Products",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Territories_RegionID",
                table: "Territories",
                column: "RegionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCustomerDemo");

            migrationBuilder.DropTable(
                name: "EmployeeTerritories");

            migrationBuilder.DropTable(
                name: "Order Details");

            migrationBuilder.DropTable(
                name: "Product_Category_Map");

            migrationBuilder.DropTable(
                name: "TextEntry");

            migrationBuilder.DropTable(
                name: "CustomerDemographics");

            migrationBuilder.DropTable(
                name: "Territories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
