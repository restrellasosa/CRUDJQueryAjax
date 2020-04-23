using Microsoft.EntityFrameworkCore.Migrations;

namespace JQueryAjax.Migrations
{
    public partial class InitialCreateAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_transactionModels",
                table: "transactionModels");

            migrationBuilder.RenameTable(
                name: "transactionModels",
                newName: "TransactionModels");

            migrationBuilder.AlterColumn<string>(
                name: "SWIFTCode",
                table: "TransactionModels",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BeneficiaryName",
                table: "TransactionModels",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "TransactionModels",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "TransactionModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "TransactionModels",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionModels",
                table: "TransactionModels",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionModels",
                table: "TransactionModels");

            migrationBuilder.RenameTable(
                name: "TransactionModels",
                newName: "transactionModels");

            migrationBuilder.AlterColumn<string>(
                name: "SWIFTCode",
                table: "transactionModels",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "BeneficiaryName",
                table: "transactionModels",
                type: "nvarchar(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "transactionModels",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Amount",
                table: "transactionModels",
                type: "nvarchar(11)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "transactionModels",
                type: "nvarchar(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactionModels",
                table: "transactionModels",
                column: "TransactionId");
        }
    }
}
