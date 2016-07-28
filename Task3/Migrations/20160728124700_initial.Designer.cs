using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Task2.north;

namespace Task2.Migrations
{
    [DbContext(typeof(NorhWd))]
    [Migration("20160728124700_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Task2.north.Categories", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("blob");

                    b.HasKey("CategoryId")
                        .HasName("sqlite_autoindex_Categories_1");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Task2.north.CustomerCustomerDemo", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnName("CustomerID")
                        .HasColumnType("char");

                    b.Property<string>("CustomerTypeId")
                        .HasColumnName("CustomerTypeID")
                        .HasColumnType("char");

                    b.HasKey("CustomerId", "CustomerTypeId")
                        .HasName("sqlite_autoindex_CustomerCustomerDemo_1");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("CustomerCustomerDemo");
                });

            modelBuilder.Entity("Task2.north.CustomerDemographics", b =>
                {
                    b.Property<string>("CustomerTypeId")
                        .HasColumnName("CustomerTypeID")
                        .HasColumnType("char");

                    b.Property<string>("CustomerDesc")
                        .HasColumnType("nvarchar");

                    b.HasKey("CustomerTypeId")
                        .HasName("sqlite_autoindex_CustomerDemographics_1");

                    b.ToTable("CustomerDemographics");
                });

            modelBuilder.Entity("Task2.north.Customers", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnName("CustomerID")
                        .HasColumnType("char");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar");

                    b.Property<string>("ContactTitle")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar");

                    b.HasKey("CustomerId")
                        .HasName("sqlite_autoindex_Customers_1");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Task2.north.Employees", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar");

                    b.Property<string>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Deleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("HireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("HomePhone")
                        .HasColumnType("nvarchar");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("blob");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar");

                    b.Property<long?>("ReportsTo")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar");

                    b.Property<string>("TitleOfCourtesy")
                        .HasColumnType("nvarchar");

                    b.HasKey("EmployeeId")
                        .HasName("sqlite_autoindex_Employees_1");

                    b.HasIndex("ReportsTo");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Task2.north.EmployeeTerritories", b =>
                {
                    b.Property<long>("EmployeeId")
                        .HasColumnName("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("TerritoryId")
                        .HasColumnName("TerritoryID")
                        .HasColumnType("nvarchar");

                    b.HasKey("EmployeeId", "TerritoryId")
                        .HasName("sqlite_autoindex_EmployeeTerritories_1");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TerritoryId");

                    b.ToTable("EmployeeTerritories");
                });

            modelBuilder.Entity("Task2.north.OrderDetails", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnName("OrderID")
                        .HasColumnType("int");

                    b.Property<long>("ProductId")
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("Discount")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SINGLE")
                        .HasDefaultValueSql("'0'");

                    b.Property<long>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("'1'");

                    b.Property<string>("UnitPrice")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal")
                        .HasDefaultValueSql("'0'");

                    b.HasKey("OrderId", "ProductId")
                        .HasName("sqlite_autoindex_Order Details_1");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Order Details");
                });

            modelBuilder.Entity("Task2.north.Orders", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerId")
                        .HasColumnName("CustomerID")
                        .HasColumnType("char");

                    b.Property<long?>("EmployeeId")
                        .HasColumnName("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Freight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal")
                        .HasDefaultValueSql("0");

                    b.Property<string>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<string>("RequiredDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ShipAddress")
                        .HasColumnType("nvarchar");

                    b.Property<string>("ShipCity")
                        .HasColumnType("nvarchar");

                    b.Property<string>("ShipCountry")
                        .HasColumnType("nvarchar");

                    b.Property<string>("ShipName")
                        .HasColumnType("nvarchar");

                    b.Property<string>("ShipPostalCode")
                        .HasColumnType("nvarchar");

                    b.Property<string>("ShipRegion")
                        .HasColumnType("nvarchar");

                    b.Property<long?>("ShipVia")
                        .HasColumnType("int");

                    b.Property<string>("ShippedDate")
                        .HasColumnType("datetime");

                    b.HasKey("OrderId")
                        .HasName("sqlite_autoindex_Orders_1");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ShipVia");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Task2.north.ProductCategoryMap", b =>
                {
                    b.Property<long>("CategoryId")
                        .HasColumnName("CategoryID")
                        .HasColumnType("int");

                    b.Property<long>("ProductId")
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "ProductId")
                        .HasName("sqlite_autoindex_Product_Category_Map_1");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("Product_Category_Map");
                });

            modelBuilder.Entity("Task2.north.Products", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("AttributeXml")
                        .HasColumnName("AttributeXML")
                        .HasColumnType("varchar");

                    b.Property<long?>("CategoryId")
                        .HasColumnName("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar");

                    b.Property<string>("CreatedOn")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Deleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Discontinued")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar");

                    b.Property<string>("ModifiedOn")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("ProductGuid")
                        .HasColumnName("ProductGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("QuantityPerUnit")
                        .HasColumnType("nvarchar");

                    b.Property<long?>("ReorderLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("0");

                    b.Property<long?>("SupplierId")
                        .HasColumnName("SupplierID")
                        .HasColumnType("int");

                    b.Property<string>("UnitPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal")
                        .HasDefaultValueSql("0");

                    b.Property<long?>("UnitsInStock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("0");

                    b.Property<long?>("UnitsOnOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("0");

                    b.HasKey("ProductId")
                        .HasName("sqlite_autoindex_Products_1");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Task2.north.Region", b =>
                {
                    b.Property<long>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RegionID")
                        .HasColumnType("int");

                    b.Property<string>("RegionDescription")
                        .IsRequired()
                        .HasColumnType("char");

                    b.HasKey("RegionId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("Task2.north.Shippers", b =>
                {
                    b.Property<long>("ShipperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ShipperID")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar");

                    b.HasKey("ShipperId")
                        .HasName("sqlite_autoindex_Shippers_1");

                    b.ToTable("Shippers");
                });

            modelBuilder.Entity("Task2.north.Suppliers", b =>
                {
                    b.Property<long>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SupplierID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar");

                    b.Property<string>("ContactTitle")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar");

                    b.Property<string>("HomePage")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar");

                    b.HasKey("SupplierId")
                        .HasName("sqlite_autoindex_Suppliers_1");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Task2.north.Territories", b =>
                {
                    b.Property<string>("TerritoryId")
                        .HasColumnName("TerritoryID")
                        .HasColumnType("nvarchar");

                    b.Property<long>("RegionId")
                        .HasColumnName("RegionID")
                        .HasColumnType("int");

                    b.Property<string>("TerritoryDescription")
                        .IsRequired()
                        .HasColumnType("char");

                    b.HasKey("TerritoryId")
                        .HasName("sqlite_autoindex_Territories_1");

                    b.HasIndex("RegionId");

                    b.ToTable("Territories");
                });

            modelBuilder.Entity("Task2.north.TextEntry", b =>
                {
                    b.Property<long>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("contentID")
                        .HasColumnType("int");

                    b.Property<string>("CallOut")
                        .HasColumnName("callOut")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Content")
                        .HasColumnName("content")
                        .HasColumnType("nvarchar");

                    b.Property<string>("ContentGuid")
                        .IsRequired()
                        .HasColumnName("contentGUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContentName")
                        .IsRequired()
                        .HasColumnName("contentName")
                        .HasColumnType("nvarchar");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("createdBy")
                        .HasColumnType("nvarchar");

                    b.Property<string>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("createdOn")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("DateExpires")
                        .HasColumnName("dateExpires")
                        .HasColumnType("datetime");

                    b.Property<string>("ExternalLink")
                        .HasColumnName("externalLink")
                        .HasColumnType("nvarchar");

                    b.Property<string>("IconPath")
                        .HasColumnName("iconPath")
                        .HasColumnType("nvarchar");

                    b.Property<string>("LastEditedBy")
                        .HasColumnName("lastEditedBy")
                        .HasColumnType("nvarchar");

                    b.Property<long>("ListOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("listOrder")
                        .HasColumnType("int")
                        .HasDefaultValueSql("1");

                    b.Property<string>("ModifiedBy")
                        .HasColumnName("modifiedBy")
                        .HasColumnType("nvarchar");

                    b.Property<string>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("modifiedOn")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Status")
                        .HasColumnName("status")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("nvarchar");

                    b.HasKey("ContentId")
                        .HasName("sqlite_autoindex_TextEntry_1");

                    b.ToTable("TextEntry");
                });

            modelBuilder.Entity("Task2.north.CustomerCustomerDemo", b =>
                {
                    b.HasOne("Task2.north.Customers", "Customer")
                        .WithMany("CustomerCustomerDemo")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Task2.north.CustomerDemographics", "CustomerType")
                        .WithMany("CustomerCustomerDemo")
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Task2.north.Employees", b =>
                {
                    b.HasOne("Task2.north.Employees", "ReportsToNavigation")
                        .WithMany("InverseReportsToNavigation")
                        .HasForeignKey("ReportsTo");
                });

            modelBuilder.Entity("Task2.north.EmployeeTerritories", b =>
                {
                    b.HasOne("Task2.north.Employees", "Employee")
                        .WithMany("EmployeeTerritories")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Task2.north.Territories", "Territory")
                        .WithMany("EmployeeTerritories")
                        .HasForeignKey("TerritoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Task2.north.OrderDetails", b =>
                {
                    b.HasOne("Task2.north.Orders", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Task2.north.Products", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Task2.north.Orders", b =>
                {
                    b.HasOne("Task2.north.Customers", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Task2.north.Employees", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Task2.north.Shippers", "ShipViaNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("ShipVia");
                });

            modelBuilder.Entity("Task2.north.ProductCategoryMap", b =>
                {
                    b.HasOne("Task2.north.Categories", "Category")
                        .WithMany("ProductCategoryMap")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Task2.north.Products", "Product")
                        .WithMany("ProductCategoryMap")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Task2.north.Products", b =>
                {
                    b.HasOne("Task2.north.Categories", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Task2.north.Suppliers", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("Task2.north.Territories", b =>
                {
                    b.HasOne("Task2.north.Region", "Region")
                        .WithMany("Territories")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
