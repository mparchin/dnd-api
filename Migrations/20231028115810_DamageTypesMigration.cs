using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DamageTypesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamageType",
                table: "Spells");

            migrationBuilder.AddColumn<string>(
                name: "DamageTypesString",
                table: "Spells",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamageTypesString",
                table: "Spells");

            migrationBuilder.AddColumn<int>(
                name: "DamageType",
                table: "Spells",
                type: "integer",
                nullable: true);
        }
    }
}
