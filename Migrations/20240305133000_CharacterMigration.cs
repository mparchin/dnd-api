using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CharacterMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Strength = table.Column<int>(type: "integer", nullable: false),
                    Dextrity = table.Column<int>(type: "integer", nullable: false),
                    Constitution = table.Column<int>(type: "integer", nullable: false),
                    Intelligence = table.Column<int>(type: "integer", nullable: false),
                    Wisdom = table.Column<int>(type: "integer", nullable: false),
                    Charisma = table.Column<int>(type: "integer", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterExperts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    HasAdvantage = table.Column<bool>(type: "boolean", nullable: false),
                    IsProficient = table.Column<bool>(type: "boolean", nullable: false),
                    IsExpert = table.Column<bool>(type: "boolean", nullable: false),
                    AttributeName = table.Column<string>(type: "text", nullable: false),
                    ExtraText = table.Column<string>(type: "text", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterExperts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterHitpoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CustomMaximum = table.Column<int>(type: "integer", nullable: true),
                    AverageMaximumExtra = table.Column<string>(type: "text", nullable: false),
                    MaximumModifire = table.Column<int>(type: "integer", nullable: false),
                    Temp = table.Column<int>(type: "integer", nullable: false),
                    DamageTakenAfterTemp = table.Column<int>(type: "integer", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterHitpoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSpellCastings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UsedMana = table.Column<int>(type: "integer", nullable: false),
                    CastingAbility = table.Column<string>(type: "text", nullable: false),
                    AttackExtra = table.Column<string>(type: "text", nullable: false),
                    DcExtra = table.Column<string>(type: "text", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSpellCastings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Race = table.Column<string>(type: "text", nullable: false),
                    Background = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    SubClassName = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    AttributesId = table.Column<int>(type: "integer", nullable: false),
                    Speed = table.Column<int>(type: "integer", nullable: false),
                    InititiveId = table.Column<int>(type: "integer", nullable: false),
                    ArmorClassExtra = table.Column<string>(type: "text", nullable: false),
                    HpId = table.Column<int>(type: "integer", nullable: false),
                    SpellCastingId = table.Column<int>(type: "integer", nullable: false),
                    StrengthSaveId = table.Column<int>(type: "integer", nullable: false),
                    DextritySaveId = table.Column<int>(type: "integer", nullable: false),
                    ConstitutionSaveId = table.Column<int>(type: "integer", nullable: false),
                    IntelligenceSaveId = table.Column<int>(type: "integer", nullable: false),
                    WisdomSaveId = table.Column<int>(type: "integer", nullable: false),
                    CharismaSaveId = table.Column<int>(type: "integer", nullable: false),
                    AthleticsId = table.Column<int>(type: "integer", nullable: false),
                    AcrobaticsId = table.Column<int>(type: "integer", nullable: false),
                    SleightOfHandsId = table.Column<int>(type: "integer", nullable: false),
                    StealthId = table.Column<int>(type: "integer", nullable: false),
                    ArcanaId = table.Column<int>(type: "integer", nullable: false),
                    HistoryId = table.Column<int>(type: "integer", nullable: false),
                    InvestigationId = table.Column<int>(type: "integer", nullable: false),
                    NatureId = table.Column<int>(type: "integer", nullable: false),
                    ReligionId = table.Column<int>(type: "integer", nullable: false),
                    AnimalHandlingId = table.Column<int>(type: "integer", nullable: false),
                    InsightId = table.Column<int>(type: "integer", nullable: false),
                    MedicineId = table.Column<int>(type: "integer", nullable: false),
                    PerceptionId = table.Column<int>(type: "integer", nullable: false),
                    SurvivalId = table.Column<int>(type: "integer", nullable: false),
                    DeceptionId = table.Column<int>(type: "integer", nullable: false),
                    IntimidationId = table.Column<int>(type: "integer", nullable: false),
                    PerformanceId = table.Column<int>(type: "integer", nullable: false),
                    PersuasionId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterAttributes_AttributesId",
                        column: x => x.AttributesId,
                        principalTable: "CharacterAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_AcrobaticsId",
                        column: x => x.AcrobaticsId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_AnimalHandlingId",
                        column: x => x.AnimalHandlingId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_ArcanaId",
                        column: x => x.ArcanaId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_AthleticsId",
                        column: x => x.AthleticsId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_CharismaSaveId",
                        column: x => x.CharismaSaveId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_ConstitutionSaveId",
                        column: x => x.ConstitutionSaveId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_DeceptionId",
                        column: x => x.DeceptionId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_DextritySaveId",
                        column: x => x.DextritySaveId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_InititiveId",
                        column: x => x.InititiveId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_InsightId",
                        column: x => x.InsightId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_IntelligenceSaveId",
                        column: x => x.IntelligenceSaveId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_IntimidationId",
                        column: x => x.IntimidationId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_InvestigationId",
                        column: x => x.InvestigationId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_NatureId",
                        column: x => x.NatureId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_PerceptionId",
                        column: x => x.PerceptionId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_PersuasionId",
                        column: x => x.PersuasionId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_SleightOfHandsId",
                        column: x => x.SleightOfHandsId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_StealthId",
                        column: x => x.StealthId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_StrengthSaveId",
                        column: x => x.StrengthSaveId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_SurvivalId",
                        column: x => x.SurvivalId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterExperts_WisdomSaveId",
                        column: x => x.WisdomSaveId,
                        principalTable: "CharacterExperts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterHitpoints_HpId",
                        column: x => x.HpId,
                        principalTable: "CharacterHitpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharacterSpellCastings_SpellCastingId",
                        column: x => x.SpellCastingId,
                        principalTable: "CharacterSpellCastings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AcrobaticsId",
                table: "Characters",
                column: "AcrobaticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AnimalHandlingId",
                table: "Characters",
                column: "AnimalHandlingId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ArcanaId",
                table: "Characters",
                column: "ArcanaId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AthleticsId",
                table: "Characters",
                column: "AthleticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AttributesId",
                table: "Characters",
                column: "AttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharismaSaveId",
                table: "Characters",
                column: "CharismaSaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassId",
                table: "Characters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ConstitutionSaveId",
                table: "Characters",
                column: "ConstitutionSaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_DeceptionId",
                table: "Characters",
                column: "DeceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_DextritySaveId",
                table: "Characters",
                column: "DextritySaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HistoryId",
                table: "Characters",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HpId",
                table: "Characters",
                column: "HpId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_InititiveId",
                table: "Characters",
                column: "InititiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_InsightId",
                table: "Characters",
                column: "InsightId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_IntelligenceSaveId",
                table: "Characters",
                column: "IntelligenceSaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_IntimidationId",
                table: "Characters",
                column: "IntimidationId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_InvestigationId",
                table: "Characters",
                column: "InvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MedicineId",
                table: "Characters",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_NatureId",
                table: "Characters",
                column: "NatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PerceptionId",
                table: "Characters",
                column: "PerceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PerformanceId",
                table: "Characters",
                column: "PerformanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PersuasionId",
                table: "Characters",
                column: "PersuasionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ReligionId",
                table: "Characters",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SleightOfHandsId",
                table: "Characters",
                column: "SleightOfHandsId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SpellCastingId",
                table: "Characters",
                column: "SpellCastingId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_StealthId",
                table: "Characters",
                column: "StealthId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_StrengthSaveId",
                table: "Characters",
                column: "StrengthSaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SurvivalId",
                table: "Characters",
                column: "SurvivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_WisdomSaveId",
                table: "Characters",
                column: "WisdomSaveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "CharacterAttributes");

            migrationBuilder.DropTable(
                name: "CharacterExperts");

            migrationBuilder.DropTable(
                name: "CharacterHitpoints");

            migrationBuilder.DropTable(
                name: "CharacterSpellCastings");
        }
    }
}
