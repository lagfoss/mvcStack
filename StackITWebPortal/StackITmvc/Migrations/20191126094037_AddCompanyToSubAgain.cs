using Microsoft.EntityFrameworkCore.Migrations;

namespace StackITmvc.Migrations
{
    public partial class AddCompanyToSubAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Hardware_HardwareID",
                table: "Subscription");

            migrationBuilder.RenameColumn(
                name: "HardwareID",
                table: "Subscription",
                newName: "HardwareId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_HardwareID",
                table: "Subscription",
                newName: "IX_Subscription_HardwareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Hardware_HardwareId",
                table: "Subscription",
                column: "HardwareId",
                principalTable: "Hardware",
                principalColumn: "HardwareId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Hardware_HardwareId",
                table: "Subscription");

            migrationBuilder.RenameColumn(
                name: "HardwareId",
                table: "Subscription",
                newName: "HardwareID");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_HardwareId",
                table: "Subscription",
                newName: "IX_Subscription_HardwareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Hardware_HardwareID",
                table: "Subscription",
                column: "HardwareID",
                principalTable: "Hardware",
                principalColumn: "HardwareId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
