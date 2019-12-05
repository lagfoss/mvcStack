using Microsoft.EntityFrameworkCore.Migrations;

namespace StackITmvc.Migrations
{
    public partial class AddCompanyToSub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Subscription",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_CustomerId",
                table: "Subscription",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Customer_CustomerId",
                table: "Subscription",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Customer_CustomerId",
                table: "Subscription");

            migrationBuilder.DropIndex(
                name: "IX_Subscription_CustomerId",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Subscription");
        }
    }
}
