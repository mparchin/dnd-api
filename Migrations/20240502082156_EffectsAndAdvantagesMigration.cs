using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class EffectsAndAdvantagesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ItemEffects");

            migrationBuilder.AddColumn<int>(
                name: "Effect",
                table: "ItemEffects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsEquipped",
                table: "CharacterItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasDisAdvantage",
                table: "CharacterExperts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Effect",
                table: "ItemEffects");

            migrationBuilder.DropColumn(
                name: "IsEquipped",
                table: "CharacterItems");

            migrationBuilder.DropColumn(
                name: "HasDisAdvantage",
                table: "CharacterExperts");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ItemEffects",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
