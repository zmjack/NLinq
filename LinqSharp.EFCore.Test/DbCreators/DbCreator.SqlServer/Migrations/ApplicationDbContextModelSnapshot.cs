﻿// <auto-generated />
using System;
using LinqSharp.EFCore.Data.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbCreator.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LinqSharp.EFCore.Data.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.LS_Name", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name", "CreationTime")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("LS_Names");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.RowLockModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LockDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RowLockModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AppRegistryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("Value")
                        .HasMaxLength(768)
                        .HasColumnType("nvarchar(768)");

                    b.HasKey("Id");

                    b.HasIndex("Item", "Key")
                        .IsUnique();

                    b.ToTable("AppRegistries");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AuditLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Root")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ValueCount")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Root");

                    b.ToTable("AuditLevels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AuditRoot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LimitQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalQuantity")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AuditRoots");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AuditValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Level")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Level");

                    b.ToTable("AuditValues");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AutoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Condensed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Even")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastWriteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lower")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Month_DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("Month_DateTimeOffset")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("Month_NullableDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset?>("Month_NullableDateTimeOffset")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Trim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Upper")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AutoModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.BulkTestModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("UniqueCode");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[UniqueCode] IS NOT NULL");

                    b.ToTable("BulkTestModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.CPKeyModel", b =>
                {
                    b.Property<Guid>("Id1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id2")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id1", "Id2");

                    b.ToTable("CompositeKeyModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.ConcurrencyModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClientWinValue")
                        .HasColumnType("int");

                    b.Property<int>("DatabaseWinValue")
                        .HasColumnType("int");

                    b.Property<int>("RowVersion")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ConcurrencyModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.EntityMonitorModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChangeValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Event")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EntityMonitorModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.LS_Index", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Int0")
                        .HasColumnType("int");

                    b.Property<int>("Int1")
                        .HasColumnType("int");

                    b.Property<int>("Int2_G1")
                        .HasColumnType("int");

                    b.Property<int>("Int3_G1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Int0");

                    b.HasIndex("Int1")
                        .IsUnique();

                    b.HasIndex("Int2_G1", "Int3_G1")
                        .IsUnique();

                    b.ToTable("LS_Indices");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.LS_Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DictionaryModel")
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("JsonModel")
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("NameModel")
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.Property<string>("Password")
                        .HasMaxLength(127)
                        .HasColumnType("nvarchar(127)");

                    b.HasKey("Id");

                    b.ToTable("LS_Providers");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.SimpleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SimpleModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.SimpleRow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("SimpleRows");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.YearMonthModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("YearMonthModels");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Test.FacadeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("FacadeModels");
                });

            modelBuilder.Entity("Northwnd.Data.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("@n.Categories", (string)null);
                });

            modelBuilder.Entity("Northwnd.Data.Customer", b =>
                {
                    b.Property<string>("CustomerID")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Address")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("City")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ContactName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ContactTitle")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Country")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Fax")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Phone")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Region")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CustomerID");

                    b.ToTable("@n.Customers", (string)null);
                });

            modelBuilder.Entity("Northwnd.Data.CustomerCustomerDemo", b =>
                {
                    b.Property<string>("CustomerTypeID")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CustomerID")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("CustomerTypeID", "CustomerID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("CustomerTypeID");

                    b.ToTable("@n.CustomerCustomerDemos", (string)null);
                });

            modelBuilder.Entity("Northwnd.Data.CustomerDemographic", b =>
                {
                    b.Property<string>("CustomerTypeID")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CustomerDesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerTypeID");

                    b.ToTable("@n.CustomerDemographics", (string)null);
                });

            modelBuilder.Entity("Northwnd.Data.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Country")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Extension")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HomePhone")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhotoPath")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Region")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("ReportsTo")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TitleOfCourtesy")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("ReportsTo");

                    b.ToTable("@n.Employees", (string)null);
                });

            modelBuilder.Entity("Northwnd.Data.EmployeeTerritory", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("TerritoryID")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("EmployeeID", "TerritoryID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TerritoryID");

                    b.ToTable("@n.EmployeeTerritories", (string)null);
                });

            modelBuilder.Entity("Northwnd.Data.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerID")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<double?>("Freight")
                        .HasColumnType("float");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RequiredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShipAddress")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("ShipCity")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ShipCountry")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ShipName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ShipPostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ShipRegion")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("ShipVia")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ShipVia");

                    b.ToTable("@n.Orders", (string)null);
                });

            modelBuilder.Entity("Northwnd.Data.OrderDetail", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("@n.OrderDetails", (string)null);
                });

            modelBuilder.Entity("Northwnd.Data.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<bool>("Discontinued")
                        .HasColumnType("bit");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("QuantityPerUnit")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<short?>("ReorderLevel")
                        .HasColumnType("smallint");

                    b.Property<int?>("SupplierID")
                        .HasColumnType("int");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float");

                    b.Property<short?>("UnitsInStock")
                        .HasColumnType("smallint");

                    b.Property<short?>("UnitsOnOrder")
                        .HasColumnType("smallint");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SupplierID");

                    b.ToTable("@n.Products", (string)null);
                });

            modelBuilder.Entity("Northwnd.Data.Region", b =>
                {
                    b.Property<int>("RegionID")
                        .HasColumnType("int");

                    b.Property<string>("RegionDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RegionID");

                    b.ToTable("@n.Regions", (string)null);
                });

            modelBuilder.Entity("Northwnd.Data.Shipper", b =>
                {
                    b.Property<int>("ShipperID")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Phone")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("ShipperID");

                    b.ToTable("@n.Shippers", (string)null);
                });

            modelBuilder.Entity("Northwnd.Data.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("City")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ContactName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ContactTitle")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Country")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Fax")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("HomePage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Region")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("SupplierID");

                    b.ToTable("@n.Suppliers", (string)null);
                });

            modelBuilder.Entity("Northwnd.Data.Territory", b =>
                {
                    b.Property<string>("TerritoryID")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("RegionID")
                        .HasColumnType("int");

                    b.Property<string>("TerritoryDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TerritoryID");

                    b.HasIndex("RegionID");

                    b.ToTable("@n.Territories", (string)null);
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Client", b =>
                {
                    b.OwnsOne("LinqSharp.EFCore.Data.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("ClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("Street")
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AuditLevel", b =>
                {
                    b.HasOne("LinqSharp.EFCore.Data.Test.AuditRoot", "RootLink")
                        .WithMany("Levels")
                        .HasForeignKey("Root")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RootLink");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AuditValue", b =>
                {
                    b.HasOne("LinqSharp.EFCore.Data.Test.AuditLevel", "LevelLink")
                        .WithMany("Values")
                        .HasForeignKey("Level")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LevelLink");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.SimpleRow", b =>
                {
                    b.OwnsOne("LinqSharp.EFCore.Data.Test.SimpleRowItemGroup", "Group", b1 =>
                        {
                            b1.Property<Guid>("SimpleRowId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Age")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.HasKey("SimpleRowId");

                            b1.ToTable("SimpleRows");

                            b1.WithOwner()
                                .HasForeignKey("SimpleRowId");
                        });

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Northwnd.Data.CustomerCustomerDemo", b =>
                {
                    b.HasOne("Northwnd.Data.Customer", "CustomerLink")
                        .WithMany("CustomerCustomerDemos")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Northwnd.Data.CustomerDemographic", "CustomerDemographicLink")
                        .WithMany("CustomerCustomerDemos")
                        .HasForeignKey("CustomerTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerDemographicLink");

                    b.Navigation("CustomerLink");
                });

            modelBuilder.Entity("Northwnd.Data.Employee", b =>
                {
                    b.HasOne("Northwnd.Data.Employee", "Superordinate")
                        .WithMany("Subordinates")
                        .HasForeignKey("ReportsTo");

                    b.Navigation("Superordinate");
                });

            modelBuilder.Entity("Northwnd.Data.EmployeeTerritory", b =>
                {
                    b.HasOne("Northwnd.Data.Employee", "EmployeeLink")
                        .WithMany("EmployeeTerritories")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Northwnd.Data.Territory", "TerritoryLink")
                        .WithMany("EmployeeTerritories")
                        .HasForeignKey("TerritoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeLink");

                    b.Navigation("TerritoryLink");
                });

            modelBuilder.Entity("Northwnd.Data.Order", b =>
                {
                    b.HasOne("Northwnd.Data.Customer", "CustomerLink")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID");

                    b.HasOne("Northwnd.Data.Employee", "EmployeeLink")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("Northwnd.Data.Shipper", "ShipperLink")
                        .WithMany("Orders")
                        .HasForeignKey("ShipVia");

                    b.Navigation("CustomerLink");

                    b.Navigation("EmployeeLink");

                    b.Navigation("ShipperLink");
                });

            modelBuilder.Entity("Northwnd.Data.OrderDetail", b =>
                {
                    b.HasOne("Northwnd.Data.Order", "OrderLink")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Northwnd.Data.Product", "ProductLink")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OrderLink");

                    b.Navigation("ProductLink");
                });

            modelBuilder.Entity("Northwnd.Data.Product", b =>
                {
                    b.HasOne("Northwnd.Data.Category", "CategoryLink")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");

                    b.HasOne("Northwnd.Data.Supplier", "SupplierLink")
                        .WithMany("Products")
                        .HasForeignKey("SupplierID");

                    b.Navigation("CategoryLink");

                    b.Navigation("SupplierLink");
                });

            modelBuilder.Entity("Northwnd.Data.Territory", b =>
                {
                    b.HasOne("Northwnd.Data.Region", "Region")
                        .WithMany("Territories")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AuditLevel", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("LinqSharp.EFCore.Data.Test.AuditRoot", b =>
                {
                    b.Navigation("Levels");
                });

            modelBuilder.Entity("Northwnd.Data.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Northwnd.Data.Customer", b =>
                {
                    b.Navigation("CustomerCustomerDemos");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Northwnd.Data.CustomerDemographic", b =>
                {
                    b.Navigation("CustomerCustomerDemos");
                });

            modelBuilder.Entity("Northwnd.Data.Employee", b =>
                {
                    b.Navigation("EmployeeTerritories");

                    b.Navigation("Orders");

                    b.Navigation("Subordinates");
                });

            modelBuilder.Entity("Northwnd.Data.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Northwnd.Data.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Northwnd.Data.Region", b =>
                {
                    b.Navigation("Territories");
                });

            modelBuilder.Entity("Northwnd.Data.Shipper", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Northwnd.Data.Supplier", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Northwnd.Data.Territory", b =>
                {
                    b.Navigation("EmployeeTerritories");
                });
#pragma warning restore 612, 618
        }
    }
}
