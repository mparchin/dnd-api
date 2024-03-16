using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CharacterSpellsForeignKeyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpellId",
                table: "CharacterSpells",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpells_SpellId",
                table: "CharacterSpells",
                column: "SpellId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSpells_Spells_SpellId",
                table: "CharacterSpells",
                column: "SpellId",
                principalTable: "Spells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpells_Spells_SpellId",
                table: "CharacterSpells");

            migrationBuilder.DropIndex(
                name: "IX_CharacterSpells_SpellId",
                table: "CharacterSpells");

            migrationBuilder.DropColumn(
                name: "SpellId",
                table: "CharacterSpells");
        }
    }
}
