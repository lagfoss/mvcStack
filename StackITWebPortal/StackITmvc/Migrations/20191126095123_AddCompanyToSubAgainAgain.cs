using Microsoft.EntityFrameworkCore.Migrations;

namespace StackITmvc.Migrations
{
    public partial class AddCompanyToSubAgainAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Customer_CustomerId",
                table: "Subscription");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Hardware_HardwareId",
                table: "Subscription");

            migrationBuilder.RenameColumn(
                name: "HardwareId",
                table: "Subscription",
                newName: "HardwareID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Subscription",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_HardwareId",
                table: "Subscription",
                newName: "IX_Subscription_HardwareID");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_CustomerId",
                table: "Subscription",
                newName: "IX_Subscription_CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Customer_CustomerID",
                table: "Subscription",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Hardware_HardwareID",
                table: "Subscription",
                column: "HardwareID",
                principalTable: "Hardware",
                principalColumn: "HardwareId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Customer_CustomerID",
                table: "Subscription");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Hardware_HardwareID",
                table: "Subscription");

            migrationBuilder.RenameColumn(
                name: "HardwareID",
                table: "Subscription",
                newName: "HardwareId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Subscription",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_HardwareID",
                table: "Subscription",
                newName: "IX_Subscription_HardwareId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_CustomerID",
                table: "Subscription",
                newName: "IX_Subscription_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Customer_CustomerId",
                table: "Subscription",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Hardware_HardwareId",
                table: "Subscription",
                column: "HardwareId",
                principalTable: "Hardware",
                principalColumn: "HardwareId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
