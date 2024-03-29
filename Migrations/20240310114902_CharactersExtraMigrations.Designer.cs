﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20240310114902_CharactersExtraMigrations")]
    partial class CharactersExtraMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityAlwaysColumns(modelBuilder);

            modelBuilder.Entity("ClassSpell", b =>
                {
                    b.Property<int>("RestrictedClassesId")
                        .HasColumnType("integer");

                    b.Property<int>("RestrictedSpellsId")
                        .HasColumnType("integer");

                    b.HasKey("RestrictedClassesId", "RestrictedSpellsId");

                    b.HasIndex("RestrictedSpellsId");

                    b.ToTable("ClassSpell");
                });

            modelBuilder.Entity("ConditionSpell", b =>
                {
                    b.Property<int>("RelatedConditionsId")
                        .HasColumnType("integer");

                    b.Property<int>("RelatedSpellsId")
                        .HasColumnType("integer");

                    b.HasKey("RelatedConditionsId", "RelatedSpellsId");

                    b.HasIndex("RelatedSpellsId");

                    b.ToTable("ConditionSpell");
                });

            modelBuilder.Entity("SpellSpellTag", b =>
                {
                    b.Property<int>("SpellTagsId")
                        .HasColumnType("integer");

                    b.Property<int>("SpellsId")
                        .HasColumnType("integer");

                    b.HasKey("SpellTagsId", "SpellsId");

                    b.HasIndex("SpellsId");

                    b.ToTable("SpellSpellTag");
                });

            modelBuilder.Entity("api.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("AcrobaticsId")
                        .HasColumnType("integer");

                    b.Property<int>("AnimalHandlingId")
                        .HasColumnType("integer");

                    b.Property<int>("ArcanaId")
                        .HasColumnType("integer");

                    b.Property<string>("ArmorClassExtra")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AthleticsId")
                        .HasColumnType("integer");

                    b.Property<int>("AttributesId")
                        .HasColumnType("integer");

                    b.Property<string>("Background")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CharismaSaveId")
                        .HasColumnType("integer");

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<int>("ConstitutionSaveId")
                        .HasColumnType("integer");

                    b.Property<int>("DeceptionId")
                        .HasColumnType("integer");

                    b.Property<int>("DextritySaveId")
                        .HasColumnType("integer");

                    b.Property<int>("HistoryId")
                        .HasColumnType("integer");

                    b.Property<int>("HpId")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<int>("InititiveId")
                        .HasColumnType("integer");

                    b.Property<int>("InsightId")
                        .HasColumnType("integer");

                    b.Property<int>("IntelligenceSaveId")
                        .HasColumnType("integer");

                    b.Property<int>("IntimidationId")
                        .HasColumnType("integer");

                    b.Property<int>("InvestigationId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<int>("MedicineId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NatureId")
                        .HasColumnType("integer");

                    b.Property<int>("PerceptionId")
                        .HasColumnType("integer");

                    b.Property<int>("PerformanceId")
                        .HasColumnType("integer");

                    b.Property<int>("PersuasionId")
                        .HasColumnType("integer");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ReligionId")
                        .HasColumnType("integer");

                    b.Property<int>("SleightOfHandsId")
                        .HasColumnType("integer");

                    b.Property<int>("Speed")
                        .HasColumnType("integer");

                    b.Property<int>("SpellCastingId")
                        .HasColumnType("integer");

                    b.Property<int>("StealthId")
                        .HasColumnType("integer");

                    b.Property<int>("StrengthSaveId")
                        .HasColumnType("integer");

                    b.Property<string>("SubClassName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SurvivalId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UsedHealingSurge")
                        .HasColumnType("integer");

                    b.Property<int>("UsedHitDie")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("WisdomSaveId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AcrobaticsId");

                    b.HasIndex("AnimalHandlingId");

                    b.HasIndex("ArcanaId");

                    b.HasIndex("AthleticsId");

                    b.HasIndex("AttributesId");

                    b.HasIndex("CharismaSaveId");

                    b.HasIndex("ClassId");

                    b.HasIndex("ConstitutionSaveId");

                    b.HasIndex("DeceptionId");

                    b.HasIndex("DextritySaveId");

                    b.HasIndex("HistoryId");

                    b.HasIndex("HpId");

                    b.HasIndex("InititiveId");

                    b.HasIndex("InsightId");

                    b.HasIndex("IntelligenceSaveId");

                    b.HasIndex("IntimidationId");

                    b.HasIndex("InvestigationId");

                    b.HasIndex("MedicineId");

                    b.HasIndex("NatureId");

                    b.HasIndex("PerceptionId");

                    b.HasIndex("PerformanceId");

                    b.HasIndex("PersuasionId");

                    b.HasIndex("ReligionId");

                    b.HasIndex("SleightOfHandsId");

                    b.HasIndex("SpellCastingId");

                    b.HasIndex("StealthId");

                    b.HasIndex("StrengthSaveId");

                    b.HasIndex("SurvivalId");

                    b.HasIndex("WisdomSaveId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("api.Models.CharacterAttributes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("Charisma")
                        .HasColumnType("integer");

                    b.Property<int>("Constitution")
                        .HasColumnType("integer");

                    b.Property<int>("Dextrity")
                        .HasColumnType("integer");

                    b.Property<int>("Intelligence")
                        .HasColumnType("integer");

                    b.Property<int>("Strength")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Wisdom")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CharacterAttributes");
                });

            modelBuilder.Entity("api.Models.CharacterExpert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("AttributeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExtraText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("HasAdvantage")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsExpert")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsProficient")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("CharacterExperts");
                });

            modelBuilder.Entity("api.Models.CharacterExtra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("integer");

                    b.Property<string>("CustomRefreshFormula")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MaximumFormula")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("RefreshOnLongRest")
                        .HasColumnType("boolean");

                    b.Property<bool>("RefreshOnShortRest")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Used")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterExtras");
                });

            modelBuilder.Entity("api.Models.CharacterHitpoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("AverageMaximumExtra")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CustomMaximum")
                        .HasColumnType("integer");

                    b.Property<int>("DamageTakenAfterTemp")
                        .HasColumnType("integer");

                    b.Property<int>("MaximumModifire")
                        .HasColumnType("integer");

                    b.Property<int>("Temp")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("CharacterHitpoints");
                });

            modelBuilder.Entity("api.Models.CharacterSpellCasting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("AttackExtra")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CastingAbility")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DcExtra")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UsedMana")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CharacterSpellCastings");
                });

            modelBuilder.Entity("api.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("CasterSubClassName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HitDie")
                        .HasColumnType("integer");

                    b.Property<string>("ManaPerLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProficiencyBonous")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("api.Models.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("api.Models.Feat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Book")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prerequisite")
                        .HasColumnType("text");

                    b.Property<string>("Repeatable")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Feats");
                });

            modelBuilder.Entity("api.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClassId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDetails")
                        .HasColumnType("boolean");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("Subclass")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("api.Models.Rule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Order")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("api.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("api.Models.Spell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<int>("Action")
                        .HasColumnType("integer");

                    b.Property<string>("Book")
                        .HasColumnType("text");

                    b.Property<string>("DamageFormula")
                        .HasColumnType("text");

                    b.Property<string>("DamageTypesString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("HasSomaticComponent")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasVerbalComponent")
                        .HasColumnType("boolean");

                    b.Property<string>("HigherLevelDescription")
                        .HasColumnType("text");

                    b.Property<bool>("IsConcentration")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRitual")
                        .HasColumnType("boolean");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("LongerAction")
                        .HasColumnType("text");

                    b.Property<string>("Materials")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Range")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SavingThrow")
                        .HasColumnType("integer");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("integer");

                    b.Property<string>("SpellListsString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("api.Models.SpellTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("SpellTags");
                });

            modelBuilder.Entity("ClassSpell", b =>
                {
                    b.HasOne("api.Models.Class", null)
                        .WithMany()
                        .HasForeignKey("RestrictedClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Spell", null)
                        .WithMany()
                        .HasForeignKey("RestrictedSpellsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConditionSpell", b =>
                {
                    b.HasOne("api.Models.Condition", null)
                        .WithMany()
                        .HasForeignKey("RelatedConditionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Spell", null)
                        .WithMany()
                        .HasForeignKey("RelatedSpellsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpellSpellTag", b =>
                {
                    b.HasOne("api.Models.SpellTag", null)
                        .WithMany()
                        .HasForeignKey("SpellTagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Spell", null)
                        .WithMany()
                        .HasForeignKey("SpellsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.Character", b =>
                {
                    b.HasOne("api.Models.CharacterExpert", "Acrobatics")
                        .WithMany()
                        .HasForeignKey("AcrobaticsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "AnimalHandling")
                        .WithMany()
                        .HasForeignKey("AnimalHandlingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Arcana")
                        .WithMany()
                        .HasForeignKey("ArcanaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Athletics")
                        .WithMany()
                        .HasForeignKey("AthleticsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterAttributes", "Attributes")
                        .WithMany("Characters")
                        .HasForeignKey("AttributesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "CharismaSave")
                        .WithMany()
                        .HasForeignKey("CharismaSaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Class", "Class")
                        .WithMany("Characters")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "ConstitutionSave")
                        .WithMany()
                        .HasForeignKey("ConstitutionSaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Deception")
                        .WithMany()
                        .HasForeignKey("DeceptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "DextritySave")
                        .WithMany()
                        .HasForeignKey("DextritySaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "History")
                        .WithMany()
                        .HasForeignKey("HistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterHitpoint", "Hp")
                        .WithMany("Characters")
                        .HasForeignKey("HpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Inititive")
                        .WithMany()
                        .HasForeignKey("InititiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Insight")
                        .WithMany()
                        .HasForeignKey("InsightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "IntelligenceSave")
                        .WithMany()
                        .HasForeignKey("IntelligenceSaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Intimidation")
                        .WithMany()
                        .HasForeignKey("IntimidationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Investigation")
                        .WithMany()
                        .HasForeignKey("InvestigationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Nature")
                        .WithMany()
                        .HasForeignKey("NatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Perception")
                        .WithMany()
                        .HasForeignKey("PerceptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Performance")
                        .WithMany()
                        .HasForeignKey("PerformanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Persuasion")
                        .WithMany()
                        .HasForeignKey("PersuasionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Religion")
                        .WithMany()
                        .HasForeignKey("ReligionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "SleightOfHands")
                        .WithMany()
                        .HasForeignKey("SleightOfHandsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterSpellCasting", "SpellCasting")
                        .WithMany("Characters")
                        .HasForeignKey("SpellCastingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Stealth")
                        .WithMany()
                        .HasForeignKey("StealthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "StrengthSave")
                        .WithMany()
                        .HasForeignKey("StrengthSaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "Survival")
                        .WithMany()
                        .HasForeignKey("SurvivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.CharacterExpert", "WisdomSave")
                        .WithMany()
                        .HasForeignKey("WisdomSaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acrobatics");

                    b.Navigation("AnimalHandling");

                    b.Navigation("Arcana");

                    b.Navigation("Athletics");

                    b.Navigation("Attributes");

                    b.Navigation("CharismaSave");

                    b.Navigation("Class");

                    b.Navigation("ConstitutionSave");

                    b.Navigation("Deception");

                    b.Navigation("DextritySave");

                    b.Navigation("History");

                    b.Navigation("Hp");

                    b.Navigation("Inititive");

                    b.Navigation("Insight");

                    b.Navigation("IntelligenceSave");

                    b.Navigation("Intimidation");

                    b.Navigation("Investigation");

                    b.Navigation("Medicine");

                    b.Navigation("Nature");

                    b.Navigation("Perception");

                    b.Navigation("Performance");

                    b.Navigation("Persuasion");

                    b.Navigation("Religion");

                    b.Navigation("SleightOfHands");

                    b.Navigation("SpellCasting");

                    b.Navigation("Stealth");

                    b.Navigation("StrengthSave");

                    b.Navigation("Survival");

                    b.Navigation("WisdomSave");
                });

            modelBuilder.Entity("api.Models.CharacterExtra", b =>
                {
                    b.HasOne("api.Models.Character", "Character")
                        .WithMany("Extras")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("api.Models.Feature", b =>
                {
                    b.HasOne("api.Models.Class", "Class")
                        .WithMany("Features")
                        .HasForeignKey("ClassId");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("api.Models.Spell", b =>
                {
                    b.HasOne("api.Models.School", "School")
                        .WithMany("Spells")
                        .HasForeignKey("SchoolId");

                    b.Navigation("School");
                });

            modelBuilder.Entity("api.Models.Character", b =>
                {
                    b.Navigation("Extras");
                });

            modelBuilder.Entity("api.Models.CharacterAttributes", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("api.Models.CharacterHitpoint", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("api.Models.CharacterSpellCasting", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("api.Models.Class", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Features");
                });

            modelBuilder.Entity("api.Models.School", b =>
                {
                    b.Navigation("Spells");
                });
#pragma warning restore 612, 618
        }
    }
}
