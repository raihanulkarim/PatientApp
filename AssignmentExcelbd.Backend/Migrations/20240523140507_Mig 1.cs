using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentExcelbd.Backend.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NCD_Details_NCDs_NcdId",
                table: "NCD_Details");

            migrationBuilder.RenameColumn(
                name: "NcdId",
                table: "NCD_Details",
                newName: "NCDId");

            migrationBuilder.RenameIndex(
                name: "IX_NCD_Details_NcdId",
                table: "NCD_Details",
                newName: "IX_NCD_Details_NCDId");

            migrationBuilder.AddForeignKey(
                name: "FK_NCD_Details_NCDs_NCDId",
                table: "NCD_Details",
                column: "NCDId",
                principalTable: "NCDs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NCD_Details_NCDs_NCDId",
                table: "NCD_Details");

            migrationBuilder.RenameColumn(
                name: "NCDId",
                table: "NCD_Details",
                newName: "NcdId");

            migrationBuilder.RenameIndex(
                name: "IX_NCD_Details_NCDId",
                table: "NCD_Details",
                newName: "IX_NCD_Details_NcdId");

            migrationBuilder.AddForeignKey(
                name: "FK_NCD_Details_NCDs_NcdId",
                table: "NCD_Details",
                column: "NcdId",
                principalTable: "NCDs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
