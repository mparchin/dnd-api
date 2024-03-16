using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CharacterSpellCascadeDeleteMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpells_Spells_SpellId",
                table: "CharacterSpells");

            migrationBuilder.AlterColumn<int>(
                name: "SpellId",
                table: "CharacterSpells",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSpells_Spells_SpellId",
                table: "CharacterSpells",
                column: "SpellId",
                principalTable: "Spells",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterSpells_Spells_SpellId",
                table: "CharacterSpells");

            migrationBuilder.AlterColumn<int>(
                name: "SpellId",
                table: "CharacterSpells",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterSpells_Spells_SpellId",
                table: "CharacterSpells",
                column: "SpellId",
                principalTable: "Spells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
