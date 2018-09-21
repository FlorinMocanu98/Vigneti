using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vigneti.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VineGrower",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VineGrower", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Wine",
                columns: table => new
                {
                    WineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wine", x => x.WineID);
                });

            migrationBuilder.CreateTable(
                name: "Vineyard",
                columns: table => new
                {
                    VineyardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dimension = table.Column<double>(nullable: false),
                    Humidity = table.Column<double>(nullable: false),
                    VineGrowerID = table.Column<int>(nullable: false),
                    WineID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vineyard", x => x.VineyardID);
                    table.ForeignKey(
                        name: "FK_Vineyard_VineGrower_VineGrowerID",
                        column: x => x.VineGrowerID,
                        principalTable: "VineGrower",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vineyard_Wine_WineID",
                        column: x => x.WineID,
                        principalTable: "Wine",
                        principalColumn: "WineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vineyard_VineGrowerID",
                table: "Vineyard",
                column: "VineGrowerID");

            migrationBuilder.CreateIndex(
                name: "IX_Vineyard_WineID",
                table: "Vineyard",
                column: "WineID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vineyard");

            migrationBuilder.DropTable(
                name: "VineGrower");

            migrationBuilder.DropTable(
                name: "Wine");
        }
    }
}
