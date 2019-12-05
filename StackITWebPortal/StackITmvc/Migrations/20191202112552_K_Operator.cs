using Microsoft.EntityFrameworkCore.Migrations;

namespace StackITmvc.Migrations
{
    public partial class K_Operator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "K_AdminSubscriptions",
                columns: table => new
                {
                    K_AdminId = table.Column<int>(nullable: false),
                    SubscriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_K_AdminSubscriptions", x => new { x.K_AdminId, x.SubscriptionId });
                    table.ForeignKey(
                        name: "FK_K_AdminSubscriptions_K_Admin_K_AdminId",
                        column: x => x.K_AdminId,
                        principalTable: "K_Admin",
                        principalColumn: "K_AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_K_AdminSubscriptions_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "SubscriptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "K_Operator",
                columns: table => new
                {
                    K_OperatorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNo = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_K_Operator", x => x.K_OperatorId);
                    table.ForeignKey(
                        name: "FK_K_Operator_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "K_OperatorSubscriptions",
                columns: table => new
                {
                    K_OperatorId = table.Column<int>(nullable: false),
                    SubscriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_K_OperatorSubscriptions", x => new { x.K_OperatorId, x.SubscriptionId });
                    table.ForeignKey(
                        name: "FK_K_OperatorSubscriptions_K_Operator_K_OperatorId",
                        column: x => x.K_OperatorId,
                        principalTable: "K_Operator",
                        principalColumn: "K_OperatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_K_OperatorSubscriptions_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "SubscriptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_K_AdminSubscriptions_SubscriptionId",
                table: "K_AdminSubscriptions",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_K_Operator_CustomerId",
                table: "K_Operator",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_K_OperatorSubscriptions_SubscriptionId",
                table: "K_OperatorSubscriptions",
                column: "SubscriptionId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Customer_CustomerId",
                table: "Subscription");

            migrationBuilder.DropTable(
                name: "K_AdminSubscriptions");

            migrationBuilder.DropTable(
                name: "K_OperatorSubscriptions");

            migrationBuilder.DropTable(
                name: "K_Operator");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Subscription",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

        }
    }
}
