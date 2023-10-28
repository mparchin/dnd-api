using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Book = table.Column<string>(type: "text", nullable: true),
                    SchoolId = table.Column<int>(type: "integer", nullable: true),
                    SpellList = table.Column<int>(type: "integer", nullable: false),
                    HasVerbalComponent = table.Column<bool>(type: "boolean", nullable: false),
                    HasSomaticComponent = table.Column<bool>(type: "boolean", nullable: false),
                    Materials = table.Column<string>(type: "text", nullable: true),
                    SavingThrow = table.Column<int>(type: "integer", nullable: true),
                    DamageType = table.Column<int>(type: "integer", nullable: true),
                    Action = table.Column<int>(type: "integer", nullable: false),
                    LongerAction = table.Column<string>(type: "text", nullable: true),
                    Range = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<string>(type: "text", nullable: false),
                    IsConcentration = table.Column<bool>(type: "boolean", nullable: false),
                    IsRitual = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    HigherLevelDescription = table.Column<string>(type: "text", nullable: true),
                    DamageFormula = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spells_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClassSpell",
                columns: table => new
                {
                    RestrictedClassesId = table.Column<int>(type: "integer", nullable: false),
                    RestrictedSpellsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSpell", x => new { x.RestrictedClassesId, x.RestrictedSpellsId });
                    table.ForeignKey(
                        name: "FK_ClassSpell_Classes_RestrictedClassesId",
                        column: x => x.RestrictedClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSpell_Spells_RestrictedSpellsId",
                        column: x => x.RestrictedSpellsId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConditionSpell",
                columns: table => new
                {
                    RelatedConditionsId = table.Column<int>(type: "integer", nullable: false),
                    RelatedSpellsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionSpell", x => new { x.RelatedConditionsId, x.RelatedSpellsId });
                    table.ForeignKey(
                        name: "FK_ConditionSpell_Conditions_RelatedConditionsId",
                        column: x => x.RelatedConditionsId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConditionSpell_Spells_RelatedSpellsId",
                        column: x => x.RelatedSpellsId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpellSpellTag",
                columns: table => new
                {
                    SpellTagsId = table.Column<int>(type: "integer", nullable: false),
                    SpellsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellSpellTag", x => new { x.SpellTagsId, x.SpellsId });
                    table.ForeignKey(
                        name: "FK_SpellSpellTag_SpellTags_SpellTagsId",
                        column: x => x.SpellTagsId,
                        principalTable: "SpellTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellSpellTag_Spells_SpellsId",
                        column: x => x.SpellsId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassSpell_RestrictedSpellsId",
                table: "ClassSpell",
                column: "RestrictedSpellsId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionSpell_RelatedSpellsId",
                table: "ConditionSpell",
                column: "RelatedSpellsId");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_SchoolId",
                table: "Spells",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellSpellTag_SpellsId",
                table: "SpellSpellTag",
                column: "SpellsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassSpell");

            migrationBuilder.DropTable(
                name: "ConditionSpell");

            migrationBuilder.DropTable(
                name: "SpellSpellTag");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "SpellTags");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
