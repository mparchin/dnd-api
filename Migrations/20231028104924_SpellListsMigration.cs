using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SpellListsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpellList",
                table: "Spells");

            migrationBuilder.AddColumn<string>(
                name: "SpellListsString",
                table: "Spells",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpellListsString",
                table: "Spells");

            migrationBuilder.AddColumn<int>(
                name: "SpellList",
                table: "Spells",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
