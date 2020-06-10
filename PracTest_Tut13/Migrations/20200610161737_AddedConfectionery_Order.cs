using Microsoft.EntityFrameworkCore.Migrations;

namespace PracTest_Tut13.Migrations
{
    public partial class AddedConfectionery_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Confectioneries",
                table: "Confectioneries");

            migrationBuilder.RenameTable(
                name: "Confectioneries",
                newName: "Confectionery");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Confectionery",
                table: "Confectionery",
                column: "IdConfection");

            migrationBuilder.CreateTable(
                name: "Confectionery_Order",
                columns: table => new
                {
                    IdConfection = table.Column<int>(nullable: false),
                    IdOrder = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Notes = table.Column<int>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery_Order", x => new { x.IdConfection, x.IdOrder });
                    table.ForeignKey(
                        name: "FK_Confectionery_Order_Confectionery_IdConfection",
                        column: x => x.IdConfection,
                        principalTable: "Confectionery",
                        principalColumn: "IdConfection",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confectionery_Order_Order_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confectionery_Order_IdConfection",
                table: "Confectionery_Order",
                column: "IdConfection",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Confectionery_Order_IdOrder",
                table: "Confectionery_Order",
                column: "IdOrder",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionery_Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Confectionery",
                table: "Confectionery");

            migrationBuilder.RenameTable(
                name: "Confectionery",
                newName: "Confectioneries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Confectioneries",
                table: "Confectioneries",
                column: "IdConfection");
        }
    }
}
