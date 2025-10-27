using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Car_Rental_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlateNumber = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DailyRate = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_car_branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "branch",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customerProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LicenseNumber = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LicenseExpiry = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customerProfile_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "maintenanceRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cost = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenanceRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_maintenanceRecord_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rentalTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentalTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rentalTransaction_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_rentalTransaction_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "branch",
                columns: new[] { "Id", "Capacity", "City", "Name" },
                values: new object[,]
                {
                    { 1, 20, "Giza", "AutoFleet Giza" },
                    { 2, 25, "Cairo", "AutoFleet Cairo" },
                    { 3, 15, "Alexandria", "AutoFleet Alexandria" },
                    { 4, 10, "Mansoura", "AutoFleet Mansoura" }
                });

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "ahmed.hassan@example.com", "Ahmed Hassan", "01012345678" },
                    { 2, "mona.ali@example.com", "Mona Ali", "01122334455" },
                    { 3, "khaled.youssef@example.com", "Khaled Youssef", "01099887766" },
                    { 4, "sara.ibrahim@example.com", "Sara Ibrahim", "01233445566" },
                    { 5, "youssef.adel@example.com", "Youssef Adel", "01077665544" },
                    { 6, "omar.elsayed@example.com", "Omar Elsayed", "01166778899" },
                    { 7, "heba.mohamed@example.com", "Heba Mohamed", "01088997766" },
                    { 8, "tarek.samir@example.com", "Tarek Samir", "01299001122" },
                    { 9, "laila.magdy@example.com", "Laila Magdy", "01155002233" },
                    { 10, "mahmoud.nabil@example.com", "Mahmoud Nabil", "01077001122" }
                });

            migrationBuilder.InsertData(
                table: "car",
                columns: new[] { "Id", "BranchId", "Brand", "DailyRate", "Model", "PlateNumber", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Toyota", 700m, "Corolla", "GYZ1234", "Available" },
                    { 2, 2, "Honda", 750m, "Civic", "CAI4567", "Rented" },
                    { 3, 3, "Hyundai", 650m, "Elantra", "ALX8901", "Available" },
                    { 4, 2, "Tesla", 1500m, "Model 3", "CAI2222", "Maintenance" },
                    { 5, 1, "Toyota", 900m, "Camry", "GYZ7777", "Rented" },
                    { 6, 4, "Ford", 600m, "Focus", "MAN1100", "Available" },
                    { 7, 3, "BMW", 1300m, "X5", "ALX5500", "Available" },
                    { 8, 2, "Nissan", 680m, "Kicks", "CAI9090", "Rented" },
                    { 9, 1, "Hyundai", 850m, "Sonata", "GYZ2244", "Available" },
                    { 10, 4, "Mazda", 950m, "CX-5", "MAN3344", "Available" }
                });

            migrationBuilder.InsertData(
                table: "customerProfile",
                columns: new[] { "Id", "Address", "CustomerId", "LicenseExpiry", "LicenseNumber" },
                values: new object[,]
                {
                    { 1, "Giza, El Haram", 1, new DateTime(2027, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "L12345" },
                    { 2, "Nasr City, Cairo", 2, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L22346" },
                    { 3, "Smouha, Alexandria", 3, new DateTime(2028, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "L32347" },
                    { 4, "Zamalek, Cairo", 4, new DateTime(2029, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "L42348" },
                    { 5, "Dokki, Giza", 5, new DateTime(2027, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "L52349" },
                    { 6, "Mansoura, Dakahlia", 6, new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "L62350" },
                    { 7, "Cairo, Maadi", 7, new DateTime(2028, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "L72351" },
                    { 8, "Alexandria, Montaza", 8, new DateTime(2029, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "L82352" },
                    { 9, "Cairo, Shoubra", 9, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "L92353" },
                    { 10, "Giza, Faisal", 10, new DateTime(2027, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "L10354" }
                });

            migrationBuilder.InsertData(
                table: "maintenanceRecord",
                columns: new[] { "Id", "CarId", "Cost", "Date", "Description" },
                values: new object[,]
                {
                    { 1, 4, 4500m, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Battery replacement" },
                    { 2, 4, 900m, new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tire alignment" },
                    { 3, 2, 700m, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oil change" },
                    { 4, 8, 2500m, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brake pads replacement" },
                    { 5, 7, 3500m, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "AC system repair" },
                    { 6, 3, 2700m, new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engine tuning" }
                });

            migrationBuilder.InsertData(
                table: "rentalTransaction",
                columns: new[] { "Id", "CarId", "CustomerId", "EndDate", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, 2, 1, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 2, 5, 2, new DateTime(2025, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { 3, 8, 3, new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 4, 1, 4, new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canceled" },
                    { 5, 7, 5, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { 6, 3, 6, new DateTime(2025, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 7, 6, 7, new DateTime(2025, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { 8, 9, 8, new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 9, 10, 9, new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 10, 4, 10, new DateTime(2025, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_branch_Name",
                table: "branch",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_car_BranchId",
                table: "car",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_car_PlateNumber",
                table: "car",
                column: "PlateNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customerProfile_CustomerId",
                table: "customerProfile",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customerProfile_LicenseNumber",
                table: "customerProfile",
                column: "LicenseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_maintenanceRecord_CarId",
                table: "maintenanceRecord",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_rentalTransaction_CarId",
                table: "rentalTransaction",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_rentalTransaction_CustomerId",
                table: "rentalTransaction",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerProfile");

            migrationBuilder.DropTable(
                name: "maintenanceRecord");

            migrationBuilder.DropTable(
                name: "rentalTransaction");

            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "branch");
        }
    }
}
