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
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSpell_Class_RestrictedClassesId",
                table: "ClassSpell");

            migrationBuilder.DropForeignKey(
                name: "FK_ConditionSpell_Condition_RelatedConditionsId",
                table: "ConditionSpell");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellSpellTag_SpellTag_SpellTagsId",
                table: "SpellSpellTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpellTag",
                table: "SpellTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Condition",
                table: "Condition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class",
                table: "Class");

            migrationBuilder.RenameTable(
                name: "SpellTag",
                newName: "SpellTags");

            migrationBuilder.RenameTable(
                name: "Condition",
                newName: "Conditions");

            migrationBuilder.RenameTable(
                name: "Class",
                newName: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "SpellList",
                table: "Spells",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpellTags",
                table: "SpellTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conditions",
                table: "Conditions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSpell_Classes_RestrictedClassesId",
                table: "ClassSpell",
                column: "RestrictedClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionSpell_Conditions_RelatedConditionsId",
                table: "ConditionSpell",
                column: "RelatedConditionsId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellSpellTag_SpellTags_SpellTagsId",
                table: "SpellSpellTag",
                column: "SpellTagsId",
                principalTable: "SpellTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSpell_Classes_RestrictedClassesId",
                table: "ClassSpell");

            migrationBuilder.DropForeignKey(
                name: "FK_ConditionSpell_Conditions_RelatedConditionsId",
                table: "ConditionSpell");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellSpellTag_SpellTags_SpellTagsId",
                table: "SpellSpellTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpellTags",
                table: "SpellTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conditions",
                table: "Conditions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "SpellList",
                table: "Spells");

            migrationBuilder.RenameTable(
                name: "SpellTags",
                newName: "SpellTag");

            migrationBuilder.RenameTable(
                name: "Conditions",
                newName: "Condition");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "Class");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpellTag",
                table: "SpellTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Condition",
                table: "Condition",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class",
                table: "Class",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSpell_Class_RestrictedClassesId",
                table: "ClassSpell",
                column: "RestrictedClassesId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionSpell_Condition_RelatedConditionsId",
                table: "ConditionSpell",
                column: "RelatedConditionsId",
                principalTable: "Condition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellSpellTag_SpellTag_SpellTagsId",
                table: "SpellSpellTag",
                column: "SpellTagsId",
                principalTable: "SpellTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
