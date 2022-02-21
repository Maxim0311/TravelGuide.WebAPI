using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Persistence.EFCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<float>(type: "real", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("route", x => x.id);
                    table.ForeignKey(
                        name: "FK_Routes_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    route_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("point", x => x.id);
                    table.ForeignKey(
                        name: "FK_Points_Routes_route_id",
                        column: x => x.route_id,
                        principalTable: "Routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "firstname", "lastname", "password", "username" },
                values: new object[] { 1, "Firstname", "Lastname", "password", "User" });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "id", "country", "created_date", "rating", "title", "user_id" },
                values: new object[] { 1, "Россия", new DateTime(2022, 2, 21, 14, 46, 33, 71, DateTimeKind.Local).AddTicks(6662), 4.2f, "testRoute", 1 });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "id", "latitude", "longitude", "route_id", "title" },
                values: new object[] { 1, 55.55m, 44.44m, 1, "point1" });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "id", "latitude", "longitude", "route_id", "title" },
                values: new object[] { 2, 54.65m, 24.44m, 1, "point2" });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "id", "latitude", "longitude", "route_id", "title" },
                values: new object[] { 3, 52.75m, 14.44m, 1, "point3" });

            migrationBuilder.CreateIndex(
                name: "IX_Points_route_id",
                table: "Points",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_user_id",
                table: "Routes",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
