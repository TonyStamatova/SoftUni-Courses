namespace P03_SalesDatabase.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class SalesAddDateDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Sales",
                defaultValueSql: "GetDate()",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Sales",
                nullable: true);
        }
    }
}
