using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations.Tenants
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tenants",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    key = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    created_on = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenants", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tenants");
        }
    }
}
