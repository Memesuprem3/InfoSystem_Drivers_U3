using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfoSystem_Drivers_U3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarChar(50)", nullable: false),
                    CarReg = table.Column<string>(type: "nvarChar(7)", nullable: false),
                    NoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoteDescription = table.Column<string>(type: "nvarChar(150)", nullable: true),
                    ResponsibleEmployee = table.Column<string>(type: "nvarChar(50)", nullable: false),
                    BeloppUt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BeloppIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBeloppUt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBeloppIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoteDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeloppIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BeloppUt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DriverID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Drivers_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "DriverID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverID", "BeloppIn", "BeloppUt", "CarReg", "DriverName", "NoteDate", "NoteDescription", "ResponsibleEmployee", "TotalBeloppIn", "TotalBeloppUt" },
                values: new object[,]
                {
                    { 1, 1000.00m, 200.00m, "OAG112", "Steffe", new DateTime(2024, 10, 26, 14, 56, 18, 329, DateTimeKind.Local).AddTicks(1135), "Delivered supplies", "Steffe", 1000.00m, 200.00m },
                    { 2, 0.00m, 500.00m, "OKO340", "Roffe", new DateTime(2024, 10, 23, 14, 56, 18, 329, DateTimeKind.Local).AddTicks(1158), "Added Fuel", "Jonas", 0.00m, 500.00m },
                    { 3, 1000.00m, 100.00m, "UFG198", "Anita", new DateTime(2024, 10, 24, 14, 56, 18, 329, DateTimeKind.Local).AddTicks(1179), "Delivered supplies", "Helene", 1000.00m, 100.00m },
                    { 4, 2000.00m, 200.00m, "KAD441", "Håkan", new DateTime(2024, 10, 24, 14, 56, 18, 329, DateTimeKind.Local).AddTicks(1198), "Delivered supplies", "Jonas", 2000.00m, 200.00m },
                    { 5, 1000.00m, 500.00m, "PUG962", "Ellen", new DateTime(2024, 10, 23, 14, 56, 18, 329, DateTimeKind.Local).AddTicks(1215), "Delivered supplies", "Jonas", 1000.00m, 500.00m }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "Chris@knug.se", "Chris", "jagärbäst", "Admin" },
                    { 2, "Jonas.Riqqe@Driverman.com", "Jonas Rikke", "Rikke", "Employee" },
                    { 3, "H.Ornholm@Queen.com", "Helene Örnholm", "Queen", "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "BeloppIn", "BeloppUt", "DriverID", "NoteDate", "NoteDescription" },
                values: new object[,]
                {
                    { 1, 1000.00m, 0.00m, 1, new DateTime(2024, 10, 23, 14, 56, 18, 329, DateTimeKind.Local).AddTicks(1238), "Delivered supplies" },
                    { 2, 0.00m, 1000.00m, 2, new DateTime(2024, 10, 26, 14, 56, 18, 329, DateTimeKind.Local).AddTicks(1257), "Fueled Car" },
                    { 3, 500.00m, 0.00m, 3, new DateTime(2024, 10, 22, 14, 56, 18, 329, DateTimeKind.Local).AddTicks(1272), "Delivered supplies" },
                    { 4, 0.00m, 2000.00m, 4, new DateTime(2024, 10, 25, 14, 56, 18, 329, DateTimeKind.Local).AddTicks(1289), "Car Service" },
                    { 5, 1800.00m, 0.00m, 5, new DateTime(2024, 10, 25, 14, 56, 18, 329, DateTimeKind.Local).AddTicks(1305), "Delivered supplies" },
                    { 6, 700.00m, 0.00m, 1, new DateTime(2024, 10, 24, 14, 56, 18, 329, DateTimeKind.Local).AddTicks(1321), "Delivered supplies" },
                    { 7, 1200.00m, 0.00m, 2, new DateTime(2024, 10, 23, 14, 56, 18, 329, DateTimeKind.Local).AddTicks(1336), "Delivered supplies" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_DriverID",
                table: "Events",
                column: "DriverID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
