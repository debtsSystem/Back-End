using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dal.Migrations
{
    /// <inheritdoc />
    public partial class changeDebtTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false),
                    customerName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__customer__B611CB7DC5FAAA13", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "paymentType",
                columns: table => new
                {
                    paymentCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeOfpayment = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__paymentT__B5D907FA7BC5B257", x => x.paymentCode);
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    saleId = table.Column<int>(type: "int", nullable: false),
                    eventTime = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    saleName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sales__FAE8F4F5DFE88E78", x => x.saleId);
                });

            migrationBuilder.CreateTable(
                name: "regularCustomer",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    defaultPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    homePhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    fax = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    mail = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    activy = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__regularC__B611CB7DC61E679F", x => x.customerId);
                    table.ForeignKey(
                        name: "FK__regularCu__custo__3D5E1FD2",
                        column: x => x.customerId,
                        principalTable: "customer",
                        principalColumn: "customerId");
                });

            migrationBuilder.CreateTable(
                name: "debts",
                columns: table => new
                {
                    debtsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerId = table.Column<int>(type: "int", nullable: true),
                    sumOfDebts = table.Column<int>(type: "int", nullable: true),
                    saleId = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    isPaid = table.Column<bool>(type: "bit", nullable: true),
                    notes = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    paymentType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__debts__A8B8A7A2150106E6", x => x.debtsId);
                    table.ForeignKey(
                        name: "FK__debts__paymentTy__440B1D61",
                        column: x => x.paymentType,
                        principalTable: "paymentType",
                        principalColumn: "paymentCode");
                    table.ForeignKey(
                        name: "FK__debts__saleId__4316F928",
                        column: x => x.saleId,
                        principalTable: "sales",
                        principalColumn: "saleId");
                    table.ForeignKey(
                        name: "FK_debts_customer_customerId",
                        column: x => x.customerId,
                        principalTable: "customer",
                        principalColumn: "customerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_debts_customerId",
                table: "debts",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_debts_paymentType",
                table: "debts",
                column: "paymentType");

            migrationBuilder.CreateIndex(
                name: "IX_debts_saleId",
                table: "debts",
                column: "saleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "debts");

            migrationBuilder.DropTable(
                name: "regularCustomer");

            migrationBuilder.DropTable(
                name: "paymentType");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
