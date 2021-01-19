﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RendezvousWrestling.Common.DataContext;

namespace RendezvousWrestling.Migrations
{
    [DbContext(typeof(RWDataContext))]
    [Migration("20210119024919_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("RWFight", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("channel")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("currentTurn")
                        .HasColumnType("int");

                    b.Property<bool>("debug")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("diceLess")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("fightLength")
                        .HasColumnType("int");

                    b.Property<int>("fightType")
                        .HasColumnType("int");

                    b.Property<int>("forcedDiceRoll")
                        .HasColumnType("int");

                    b.Property<bool>("hasEnded")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("hasStarted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("requiredTeams")
                        .HasColumnType("int");

                    b.Property<int>("season")
                        .HasColumnType("int");

                    b.Property<string>("stage")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("test")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("waitingForAction")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("winnerTeam")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Fights");
                });

            modelBuilder.Entity("RWFighterState", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FightId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RWFightId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("assignedTeam")
                        .HasColumnType("int");

                    b.Property<bool>("canMoveFromOrOffRing")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("consecutiveTurnsWithoutFocus")
                        .HasColumnType("int");

                    b.Property<int>("currentDexterity")
                        .HasColumnType("int");

                    b.Property<int>("currentEndurance")
                        .HasColumnType("int");

                    b.Property<int>("currentPower")
                        .HasColumnType("int");

                    b.Property<int>("currentSensuality")
                        .HasColumnType("int");

                    b.Property<int>("currentToughness")
                        .HasColumnType("int");

                    b.Property<int>("currentWillpower")
                        .HasColumnType("int");

                    b.Property<int>("dexterityDelta")
                        .HasColumnType("int");

                    b.Property<int>("distanceFromRingCenter")
                        .HasColumnType("int");

                    b.Property<int>("enduranceDelta")
                        .HasColumnType("int");

                    b.Property<int>("fightStatus")
                        .HasColumnType("int");

                    b.Property<int>("focus")
                        .HasColumnType("int");

                    b.Property<int>("fpDamageLastRound")
                        .HasColumnType("int");

                    b.Property<int>("fpHealLastRound")
                        .HasColumnType("int");

                    b.Property<int>("heartsDamageLastRound")
                        .HasColumnType("int");

                    b.Property<int>("heartsHealLastRound")
                        .HasColumnType("int");

                    b.Property<int>("hp")
                        .HasColumnType("int");

                    b.Property<int>("hpDamageLastRound")
                        .HasColumnType("int");

                    b.Property<int>("hpHealLastRound")
                        .HasColumnType("int");

                    b.Property<bool>("isInTheRing")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isReady")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("lastDiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("lastTagTurn")
                        .HasColumnType("int");

                    b.Property<int>("livesRemaining")
                        .HasColumnType("int");

                    b.Property<int>("lpDamageLastRound")
                        .HasColumnType("int");

                    b.Property<int>("lpHealLastRound")
                        .HasColumnType("int");

                    b.Property<int>("lust")
                        .HasColumnType("int");

                    b.Property<int>("orgasmsDamageLastRound")
                        .HasColumnType("int");

                    b.Property<int>("orgasmsHealLastRound")
                        .HasColumnType("int");

                    b.Property<int>("powerDelta")
                        .HasColumnType("int");

                    b.Property<int>("sensualityDelta")
                        .HasColumnType("int");

                    b.Property<int>("startingDexterity")
                        .HasColumnType("int");

                    b.Property<int>("startingEndurance")
                        .HasColumnType("int");

                    b.Property<int>("startingPower")
                        .HasColumnType("int");

                    b.Property<int>("startingSensuality")
                        .HasColumnType("int");

                    b.Property<int>("startingToughness")
                        .HasColumnType("int");

                    b.Property<int>("startingWillpower")
                        .HasColumnType("int");

                    b.Property<string>("targets")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("toughnessDelta")
                        .HasColumnType("int");

                    b.Property<bool>("wantsDraw")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("willpowerDelta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FightId");

                    b.HasIndex("RWFightId");

                    b.HasIndex("UserId");

                    b.ToTable("FighterStates");
                });

            modelBuilder.Entity("RWFighterStats", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("actionsCount")
                        .HasColumnType("int");

                    b.Property<int>("actionsDefended")
                        .HasColumnType("int");

                    b.Property<int>("averageDiceRoll")
                        .HasColumnType("int");

                    b.Property<int>("bondageCount")
                        .HasColumnType("int");

                    b.Property<int>("brawlAtksCount")
                        .HasColumnType("int");

                    b.Property<int>("currentlyPlaying")
                        .HasColumnType("int");

                    b.Property<int>("currentlyPlayingSeason")
                        .HasColumnType("int");

                    b.Property<int>("degradationCount")
                        .HasColumnType("int");

                    b.Property<int>("eloRating")
                        .HasColumnType("int");

                    b.Property<int>("escapeCount")
                        .HasColumnType("int");

                    b.Property<string>("favoriteTagPartner")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("favoriteTeam")
                        .HasColumnType("int");

                    b.Property<int>("fightsCount")
                        .HasColumnType("int");

                    b.Property<int>("fightsCountCS")
                        .HasColumnType("int");

                    b.Property<int>("fightsPendingDraw")
                        .HasColumnType("int");

                    b.Property<int>("fightsPendingDrawSeason")
                        .HasColumnType("int");

                    b.Property<int>("fightsPendingReady")
                        .HasColumnType("int");

                    b.Property<int>("fightsPendingReadySeason")
                        .HasColumnType("int");

                    b.Property<int>("fightsPendingStart")
                        .HasColumnType("int");

                    b.Property<int>("fightsPendingStartSeason")
                        .HasColumnType("int");

                    b.Property<int>("finishCount")
                        .HasColumnType("int");

                    b.Property<int>("forcedWorshipCount")
                        .HasColumnType("int");

                    b.Property<int>("forfeits")
                        .HasColumnType("int");

                    b.Property<int>("globalRank")
                        .HasColumnType("int");

                    b.Property<int>("highRiskCount")
                        .HasColumnType("int");

                    b.Property<int>("humholdCount")
                        .HasColumnType("int");

                    b.Property<int>("itemPickups")
                        .HasColumnType("int");

                    b.Property<int>("losses")
                        .HasColumnType("int");

                    b.Property<int>("lossesAgainstNemesis")
                        .HasColumnType("int");

                    b.Property<int>("lossesSeason")
                        .HasColumnType("int");

                    b.Property<int>("masturbateCount")
                        .HasColumnType("int");

                    b.Property<int>("matchesInLast24Hours")
                        .HasColumnType("int");

                    b.Property<int>("matchesInLast48Hours")
                        .HasColumnType("int");

                    b.Property<int>("missedAttacks")
                        .HasColumnType("int");

                    b.Property<string>("nemesis")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("penetrationCount")
                        .HasColumnType("int");

                    b.Property<int>("quits")
                        .HasColumnType("int");

                    b.Property<int>("restCount")
                        .HasColumnType("int");

                    b.Property<int>("sexholdCount")
                        .HasColumnType("int");

                    b.Property<int>("sexstrikesCount")
                        .HasColumnType("int");

                    b.Property<int>("sextoyPickups")
                        .HasColumnType("int");

                    b.Property<int>("straptoyCount")
                        .HasColumnType("int");

                    b.Property<int>("stunCount")
                        .HasColumnType("int");

                    b.Property<int>("subholdCount")
                        .HasColumnType("int");

                    b.Property<int>("submitCount")
                        .HasColumnType("int");

                    b.Property<int>("tagsCount")
                        .HasColumnType("int");

                    b.Property<int>("timesFoughtWithFavoriteTagPartner")
                        .HasColumnType("int");

                    b.Property<int>("wins")
                        .HasColumnType("int");

                    b.Property<int>("winsSeason")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("RWModifier", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ApplierId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FightId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("areDamageMultipliers")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("diceRoll")
                        .HasColumnType("int");

                    b.Property<int>("escapeRoll")
                        .HasColumnType("int");

                    b.Property<int>("focusDamage")
                        .HasColumnType("int");

                    b.Property<int>("focusHeal")
                        .HasColumnType("int");

                    b.Property<int>("hpDamage")
                        .HasColumnType("int");

                    b.Property<int>("hpHeal")
                        .HasColumnType("int");

                    b.Property<string>("idParentActions")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("lustDamage")
                        .HasColumnType("int");

                    b.Property<int>("lustHeal")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("tier")
                        .HasColumnType("int");

                    b.Property<int>("timeToTrigger")
                        .HasColumnType("int");

                    b.Property<int>("triggeringEvent")
                        .HasColumnType("int");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.Property<int>("uses")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplierId");

                    b.HasIndex("FightId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Modifiers");
                });

            modelBuilder.Entity("RWUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<bool>("AreStatsPrivate")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Tokens")
                        .HasColumnType("int");

                    b.Property<int>("TokensSpent")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("dexterity")
                        .HasColumnType("int");

                    b.Property<int>("endurance")
                        .HasColumnType("int");

                    b.Property<int>("power")
                        .HasColumnType("int");

                    b.Property<int>("sensuality")
                        .HasColumnType("int");

                    b.Property<int>("toughness")
                        .HasColumnType("int");

                    b.Property<int>("willpower")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RendezvousWrestling.FightSystem.Achievements.RWAchievement", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserName");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("RendezvousWrestling.FightSystem.Features.RWFeature", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Permanent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Uses")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("RWFighterState", b =>
                {
                    b.HasOne("RWFight", "Fight")
                        .WithMany("Fighters")
                        .HasForeignKey("FightId");

                    b.HasOne("RWFight", null)
                        .WithMany("currentTarget")
                        .HasForeignKey("RWFightId");

                    b.HasOne("RWUser", "User")
                        .WithMany("FighterStates")
                        .HasForeignKey("UserId");

                    b.Navigation("Fight");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RWFighterStats", b =>
                {
                    b.HasOne("RWUser", "User")
                        .WithOne("Stats")
                        .HasForeignKey("RWFighterStats", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RWModifier", b =>
                {
                    b.HasOne("RWFighterState", "Applier")
                        .WithMany("AppliedModifiers")
                        .HasForeignKey("ApplierId");

                    b.HasOne("RWFight", "Fight")
                        .WithMany()
                        .HasForeignKey("FightId");

                    b.HasOne("RWFighterState", "Receiver")
                        .WithMany("ReceivedModifiers")
                        .HasForeignKey("ReceiverId");

                    b.Navigation("Applier");

                    b.Navigation("Fight");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("RendezvousWrestling.FightSystem.Achievements.RWAchievement", b =>
                {
                    b.HasOne("RWUser", "User")
                        .WithMany("Achievements")
                        .HasForeignKey("UserName");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RendezvousWrestling.FightSystem.Features.RWFeature", b =>
                {
                    b.HasOne("RWUser", "Receiver")
                        .WithMany("Features")
                        .HasForeignKey("ReceiverId");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("RWFight", b =>
                {
                    b.Navigation("currentTarget");

                    b.Navigation("Fighters");
                });

            modelBuilder.Entity("RWFighterState", b =>
                {
                    b.Navigation("AppliedModifiers");

                    b.Navigation("ReceivedModifiers");
                });

            modelBuilder.Entity("RWUser", b =>
                {
                    b.Navigation("Achievements");

                    b.Navigation("Features");

                    b.Navigation("FighterStates");

                    b.Navigation("Stats");
                });
#pragma warning restore 612, 618
        }
    }
}
