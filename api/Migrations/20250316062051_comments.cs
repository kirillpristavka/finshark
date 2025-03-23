using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commetns_Stocks_StockId",
                table: "Commetns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commetns",
                table: "Commetns");

            migrationBuilder.RenameTable(
                name: "Commetns",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Commetns_StockId",
                table: "Comments",
                newName: "IX_Comments_StockId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Stocks_StockId",
                table: "Comments",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Stocks_StockId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Commetns");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_StockId",
                table: "Commetns",
                newName: "IX_Commetns_StockId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commetns",
                table: "Commetns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commetns_Stocks_StockId",
                table: "Commetns",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");
        }
    }
}
