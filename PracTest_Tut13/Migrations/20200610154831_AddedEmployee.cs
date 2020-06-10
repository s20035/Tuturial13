using Microsoft.EntityFrameworkCore.Migrations;

namespace PracTest_Tut13.Migrations
{
    public partial class AddedEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEmpl",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmpl = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Surname = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdEmpl);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdEmpl",
                table: "Order",
                column: "IdEmpl");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_IdEmpl",
                table: "Order",
                column: "IdEmpl",
                principalTable: "Employee",
                principalColumn: "IdEmpl",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_IdEmpl",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Order_IdEmpl",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IdEmpl",
                table: "Order");
        }
    }
}
