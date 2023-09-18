using System;
using System.Collections;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompServiceApplication.Migrations
{
    /// <inheritdoc />
    public partial class CompService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    DeviceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    DeviceDescription = table.Column<string>(type: "text", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceID);
                });

            migrationBuilder.CreateTable(
                name: "inwork",
                columns: table => new
                {
                    WorkID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkStageDescription = table.Column<string>(type: "text", nullable: false),
                    TaskOrderID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InWorks", x => x.WorkID);
                });

            migrationBuilder.CreateTable(
                name: "parttodevice",
                columns: table => new
                {
                    PartToDeviceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartID = table.Column<int>(type: "integer", nullable: false),
                    DeviceID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartToDevices", x => x.PartToDeviceID);
                });

            migrationBuilder.CreateTable(
                name: "partstoorder",
                columns: table => new
                {
                    PartToOrderID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PurchaseOrderID = table.Column<int>(type: "integer", nullable: false),
                    PartID = table.Column<int>(type: "integer", nullable: false),
                    PartsCount = table.Column<int>(type: "integer", nullable: false),
                    TotalCost = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartToOrders", x => x.PartToOrderID);
                });

            migrationBuilder.CreateTable(
                name: "purchaseorder",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    StatusChangeDate = table.Column<DateTime>(type: "date", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderID);
                });

            migrationBuilder.CreateTable(
                name: "repairinwork",
                columns: table => new
                {
                    RepairInWorkID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RepairID = table.Column<int>(type: "integer", nullable: false),
                    WorkID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairInWorks", x => x.RepairInWorkID);
                });

            migrationBuilder.CreateTable(
                name: "repairtypes",
                columns: table => new
                {
                    RepairTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RepairDescription = table.Column<string>(type: "text", nullable: false),
                    RepairPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairTypes", x => x.RepairTypeID);
                });

            migrationBuilder.CreateTable(
                name: "taskorders",
                columns: table => new
                {
                    TaskOrderID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    ProblemDescription = table.Column<string>(type: "text", nullable: false),
                    FinallyCost = table.Column<decimal>(type: "money", nullable: true),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    DeviceID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskOrders", x => x.TaskOrderID);
                });

            migrationBuilder.CreateTable(
                name: "usedparts",
                columns: table => new
                {
                    UsedPartID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsedPartCount = table.Column<int>(type: "integer", nullable: false),
                    UsedPartPrice = table.Column<decimal>(type: "money", nullable: false),
                    PartID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedParts", x => x.UsedPartID);
                });

            migrationBuilder.CreateTable(
                name: "usedpartsinwork",
                columns: table => new
                {
                    UsedPartsInWorkId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsedPartID = table.Column<int>(type: "integer", nullable: false),
                    WorkID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedPartsInWorks", x => x.UsedPartsInWorkId);
                });

            migrationBuilder.CreateTable(
                name: "userinwork",
                columns: table => new
                {
                    UserInWorkID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    WorkID = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInWorks", x => x.UserInWorkID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastName = table.Column<string>(type: "character varying(50)", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(11)", nullable: false),
                    PassSeries = table.Column<string>(type: "character varying(4)", nullable: false),
                    PassNumber = table.Column<string>(type: "character varying(6)", nullable: false),
                    UserLogin = table.Column<string>(type: "character varying(50)", nullable: false),
                    UserPassword = table.Column<string>(type: "varchar(64)", nullable: false),
                    UserTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "usertypes",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserTypeName = table.Column<string>(type: "character varying(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "visualflows",
                columns: table => new
                {
                    VisualFlowID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VisualFlow = table.Column<BitArray>(type: "bit varying", nullable: false),
                    TaskOrderID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visualflows", x => x.VisualFlowID);
                });

            migrationBuilder.CreateTable(
                name: "warehouse",
                columns: table => new
                {
                    PartID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Manufacturer = table.Column<string>(type: "character varying(50)", nullable: false),
                    PartName = table.Column<string>(type: "text", nullable: false),
                    PartsCount = table.Column<int>(type: "integer", nullable: false),
                    PartPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.PartID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "inwork");

            migrationBuilder.DropTable(
                name: "parttodevice");

            migrationBuilder.DropTable(
                name: "partstoorder");

            migrationBuilder.DropTable(
                name: "purchaseorder");

            migrationBuilder.DropTable(
                name: "repairinwork");

            migrationBuilder.DropTable(
                name: "repairtypes");

            migrationBuilder.DropTable(
                name: "taskorders");

            migrationBuilder.DropTable(
                name: "usedparts");

            migrationBuilder.DropTable(
                name: "usedpartsinwork");

            migrationBuilder.DropTable(
                name: "userinwork");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "usesrtypes");

            migrationBuilder.DropTable(
                name: "visualflows");

            migrationBuilder.DropTable(
                name: "warehouse");
        }
    }
}
