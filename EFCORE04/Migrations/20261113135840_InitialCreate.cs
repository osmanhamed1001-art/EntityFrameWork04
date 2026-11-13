using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCORE04.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adderss = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Emall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhonNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomersType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationalld = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhonNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireData = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adderss = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhonNumer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    managersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Branches_Managers_managersId",
                        column: x => x.managersId,
                        principalTable: "Managers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccounNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrrentBalace = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccounType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeingData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccounNumber);
                    table.ForeignKey(
                        name: "FK_Accounts_Branches_BraId",
                        column: x => x.BraId,
                        principalTable: "Branches",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "AccountCustomers",
                columns: table => new
                {
                    customersId = table.Column<int>(type: "int", nullable: false),
                    accountsId = table.Column<int>(type: "int", nullable: false),
                    OwnershipType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnershipStartdata = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCustomers", x => new { x.customersId, x.accountsId });
                    table.ForeignKey(
                        name: "FK_AccountCustomers_Accounts_accountsId",
                        column: x => x.accountsId,
                        principalTable: "Accounts",
                        principalColumn: "AccounNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountCustomers_Customers_customersId",
                        column: x => x.customersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionsNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GetAccountsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionsNumber);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_GetAccountsId",
                        column: x => x.GetAccountsId,
                        principalTable: "Accounts",
                        principalColumn: "AccounNumber");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Adderss", "CustomersType", "DataOfBirth", "Emall", "FullName", "Nationalld", "PhonNumber" },
                values: new object[,]
                {
                    { 1, "Cairo", "Regular", new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@gmail.com", "Ahmed Mohamed", "29505101234567", "01012345678" },
                    { 2, "Alexandria", "VIP", new DateTime(1998, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohamed@gmail.com", "Mohamed Ali", "29808151234567", "01112345678" },
                    { 3, "Giza", "Regular", new DateTime(1992, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar@gmail.com", "Omar Hassan", "29203201234567", "01212345678" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Emall", "FullName", "HireData", "PhonNumber" },
                values: new object[,]
                {
                    { 1, "ahmed@gmail.com", "Ahmed Mohamed", new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01012345678" },
                    { 2, "mohamed@gmail.com", "Mohamed Ali", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01112345678" },
                    { 3, "omar@gmail.com", "Omar Hassan", new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01212345678" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Adderss", "Name", "PhonNumer", "managersId" },
                values: new object[,]
                {
                    { 1, "Nasr City", "Cairo Branch", "0223456789", 1 },
                    { 2, "Smouha", "Alexandria Branch", "0345678910", 2 },
                    { 3, "Dokki", "Giza Branch", "0234567890", 3 }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccounNumber", "AccounType", "BraId", "CrrentBalace", "OpeingData" },
                values: new object[,]
                {
                    { 1001, "Saving", 1, 15000m, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1002, "Current", 2, 25000m, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1003, "Saving", 1, 10000m, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AccountCustomers",
                columns: new[] { "accountsId", "customersId", "AccountStatus", "OwnershipStartdata", "OwnershipType" },
                values: new object[,]
                {
                    { 1001, 1, "Active", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary" },
                    { 1002, 2, "Active", new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary" },
                    { 1003, 3, "Active", new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joint" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionsNumber", "Amount", "GetAccountsId", "Note", "TransactionData", "TransactionType" },
                values: new object[,]
                {
                    { 1, 5000m, 1001, "Cash deposit", new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit" },
                    { 2, 2000m, 1002, "ATM withdrawal", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal" },
                    { 3, 3000m, 1003, "Bank transfer", new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountCustomers_accountsId",
                table: "AccountCustomers",
                column: "accountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BraId",
                table: "Accounts",
                column: "BraId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_managersId",
                table: "Branches",
                column: "managersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_GetAccountsId",
                table: "Transactions",
                column: "GetAccountsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountCustomers");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
