using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Best_Shop_Doors.Migrations
{
    public partial class addnewtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Zakaz",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zakaz", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zakaz_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OZakaze",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZakazID = table.Column<int>(type: "int", nullable: false),
                    DoorID = table.Column<int>(type: "int", nullable: false),
                    Kolich = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OZakaze", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OZakaze_Door_DoorID",
                        column: x => x.DoorID,
                        principalTable: "Door",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OZakaze_Zakaz_ZakazID",
                        column: x => x.ZakazID,
                        principalTable: "Zakaz",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OZakaze_DoorID",
                table: "OZakaze",
                column: "DoorID");

            migrationBuilder.CreateIndex(
                name: "IX_OZakaze_ZakazID",
                table: "OZakaze",
                column: "ZakazID");

            migrationBuilder.CreateIndex(
                name: "IX_Zakaz_AppUserId",
                table: "Zakaz",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OZakaze");

            migrationBuilder.DropTable(
                name: "Zakaz");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
