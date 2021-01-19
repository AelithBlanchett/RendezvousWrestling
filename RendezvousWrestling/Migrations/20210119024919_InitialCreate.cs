using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RendezvousWrestling.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fights",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    test = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    requiredTeams = table.Column<int>(type: "int", nullable: false),
                    hasStarted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    hasEnded = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    stage = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    currentTurn = table.Column<int>(type: "int", nullable: false),
                    fightType = table.Column<int>(type: "int", nullable: false),
                    winnerTeam = table.Column<int>(type: "int", nullable: false),
                    season = table.Column<int>(type: "int", nullable: false),
                    waitingForAction = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    fightLength = table.Column<int>(type: "int", nullable: false),
                    channel = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    debug = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    forcedDiceRoll = table.Column<int>(type: "int", nullable: false),
                    diceLess = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    dexterity = table.Column<int>(type: "int", nullable: false),
                    power = table.Column<int>(type: "int", nullable: false),
                    sensuality = table.Column<int>(type: "int", nullable: false),
                    toughness = table.Column<int>(type: "int", nullable: false),
                    endurance = table.Column<int>(type: "int", nullable: false),
                    willpower = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AreStatsPrivate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Tokens = table.Column<int>(type: "int", nullable: false),
                    TokensSpent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Uses = table.Column<int>(type: "int", nullable: false),
                    Permanent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ReceiverId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FighterStates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    hp = table.Column<int>(type: "int", nullable: false),
                    lust = table.Column<int>(type: "int", nullable: false),
                    livesRemaining = table.Column<int>(type: "int", nullable: false),
                    focus = table.Column<int>(type: "int", nullable: false),
                    consecutiveTurnsWithoutFocus = table.Column<int>(type: "int", nullable: false),
                    startingPower = table.Column<int>(type: "int", nullable: false),
                    startingSensuality = table.Column<int>(type: "int", nullable: false),
                    startingToughness = table.Column<int>(type: "int", nullable: false),
                    startingEndurance = table.Column<int>(type: "int", nullable: false),
                    startingDexterity = table.Column<int>(type: "int", nullable: false),
                    startingWillpower = table.Column<int>(type: "int", nullable: false),
                    powerDelta = table.Column<int>(type: "int", nullable: false),
                    sensualityDelta = table.Column<int>(type: "int", nullable: false),
                    toughnessDelta = table.Column<int>(type: "int", nullable: false),
                    enduranceDelta = table.Column<int>(type: "int", nullable: false),
                    dexterityDelta = table.Column<int>(type: "int", nullable: false),
                    willpowerDelta = table.Column<int>(type: "int", nullable: false),
                    hpDamageLastRound = table.Column<int>(type: "int", nullable: false),
                    lpDamageLastRound = table.Column<int>(type: "int", nullable: false),
                    fpDamageLastRound = table.Column<int>(type: "int", nullable: false),
                    hpHealLastRound = table.Column<int>(type: "int", nullable: false),
                    lpHealLastRound = table.Column<int>(type: "int", nullable: false),
                    fpHealLastRound = table.Column<int>(type: "int", nullable: false),
                    heartsDamageLastRound = table.Column<int>(type: "int", nullable: false),
                    orgasmsDamageLastRound = table.Column<int>(type: "int", nullable: false),
                    heartsHealLastRound = table.Column<int>(type: "int", nullable: false),
                    orgasmsHealLastRound = table.Column<int>(type: "int", nullable: false),
                    currentPower = table.Column<int>(type: "int", nullable: false),
                    currentSensuality = table.Column<int>(type: "int", nullable: false),
                    currentToughness = table.Column<int>(type: "int", nullable: false),
                    currentEndurance = table.Column<int>(type: "int", nullable: false),
                    currentDexterity = table.Column<int>(type: "int", nullable: false),
                    currentWillpower = table.Column<int>(type: "int", nullable: false),
                    RWFightId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    assignedTeam = table.Column<int>(type: "int", nullable: false),
                    targets = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    isReady = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    lastDiceRoll = table.Column<int>(type: "int", nullable: false),
                    isInTheRing = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    canMoveFromOrOffRing = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    lastTagTurn = table.Column<int>(type: "int", nullable: false),
                    wantsDraw = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    distanceFromRingCenter = table.Column<int>(type: "int", nullable: false),
                    fightStatus = table.Column<int>(type: "int", nullable: false),
                    FightId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FighterStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FighterStates_Fights_FightId",
                        column: x => x.FightId,
                        principalTable: "Fights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FighterStates_Fights_RWFightId",
                        column: x => x.RWFightId,
                        principalTable: "Fights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FighterStates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    brawlAtksCount = table.Column<int>(type: "int", nullable: false),
                    sexstrikesCount = table.Column<int>(type: "int", nullable: false),
                    tagsCount = table.Column<int>(type: "int", nullable: false),
                    restCount = table.Column<int>(type: "int", nullable: false),
                    subholdCount = table.Column<int>(type: "int", nullable: false),
                    sexholdCount = table.Column<int>(type: "int", nullable: false),
                    bondageCount = table.Column<int>(type: "int", nullable: false),
                    humholdCount = table.Column<int>(type: "int", nullable: false),
                    itemPickups = table.Column<int>(type: "int", nullable: false),
                    sextoyPickups = table.Column<int>(type: "int", nullable: false),
                    degradationCount = table.Column<int>(type: "int", nullable: false),
                    forcedWorshipCount = table.Column<int>(type: "int", nullable: false),
                    highRiskCount = table.Column<int>(type: "int", nullable: false),
                    penetrationCount = table.Column<int>(type: "int", nullable: false),
                    stunCount = table.Column<int>(type: "int", nullable: false),
                    escapeCount = table.Column<int>(type: "int", nullable: false),
                    submitCount = table.Column<int>(type: "int", nullable: false),
                    straptoyCount = table.Column<int>(type: "int", nullable: false),
                    finishCount = table.Column<int>(type: "int", nullable: false),
                    masturbateCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    fightsCount = table.Column<int>(type: "int", nullable: false),
                    fightsCountCS = table.Column<int>(type: "int", nullable: false),
                    losses = table.Column<int>(type: "int", nullable: false),
                    lossesSeason = table.Column<int>(type: "int", nullable: false),
                    wins = table.Column<int>(type: "int", nullable: false),
                    winsSeason = table.Column<int>(type: "int", nullable: false),
                    currentlyPlaying = table.Column<int>(type: "int", nullable: false),
                    currentlyPlayingSeason = table.Column<int>(type: "int", nullable: false),
                    fightsPendingReady = table.Column<int>(type: "int", nullable: false),
                    fightsPendingReadySeason = table.Column<int>(type: "int", nullable: false),
                    fightsPendingStart = table.Column<int>(type: "int", nullable: false),
                    fightsPendingStartSeason = table.Column<int>(type: "int", nullable: false),
                    fightsPendingDraw = table.Column<int>(type: "int", nullable: false),
                    fightsPendingDrawSeason = table.Column<int>(type: "int", nullable: false),
                    favoriteTeam = table.Column<int>(type: "int", nullable: false),
                    favoriteTagPartner = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    timesFoughtWithFavoriteTagPartner = table.Column<int>(type: "int", nullable: false),
                    nemesis = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    lossesAgainstNemesis = table.Column<int>(type: "int", nullable: false),
                    averageDiceRoll = table.Column<int>(type: "int", nullable: false),
                    missedAttacks = table.Column<int>(type: "int", nullable: false),
                    actionsCount = table.Column<int>(type: "int", nullable: false),
                    actionsDefended = table.Column<int>(type: "int", nullable: false),
                    matchesInLast24Hours = table.Column<int>(type: "int", nullable: false),
                    matchesInLast48Hours = table.Column<int>(type: "int", nullable: false),
                    eloRating = table.Column<int>(type: "int", nullable: false),
                    globalRank = table.Column<int>(type: "int", nullable: false),
                    forfeits = table.Column<int>(type: "int", nullable: false),
                    quits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Stats_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modifiers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    hpDamage = table.Column<int>(type: "int", nullable: false),
                    lustDamage = table.Column<int>(type: "int", nullable: false),
                    focusDamage = table.Column<int>(type: "int", nullable: false),
                    hpHeal = table.Column<int>(type: "int", nullable: false),
                    lustHeal = table.Column<int>(type: "int", nullable: false),
                    focusHeal = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tier = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    areDamageMultipliers = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    diceRoll = table.Column<int>(type: "int", nullable: false),
                    escapeRoll = table.Column<int>(type: "int", nullable: false),
                    uses = table.Column<int>(type: "int", nullable: false),
                    triggeringEvent = table.Column<int>(type: "int", nullable: false),
                    timeToTrigger = table.Column<int>(type: "int", nullable: false),
                    idParentActions = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    FightId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    ApplierId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    ReceiverId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modifiers_FighterStates_ApplierId",
                        column: x => x.ApplierId,
                        principalTable: "FighterStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modifiers_FighterStates_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "FighterStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modifiers_Fights_FightId",
                        column: x => x.FightId,
                        principalTable: "Fights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_UserName",
                table: "Achievements",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Features_ReceiverId",
                table: "Features",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_FighterStates_FightId",
                table: "FighterStates",
                column: "FightId");

            migrationBuilder.CreateIndex(
                name: "IX_FighterStates_RWFightId",
                table: "FighterStates",
                column: "RWFightId");

            migrationBuilder.CreateIndex(
                name: "IX_FighterStates_UserId",
                table: "FighterStates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Modifiers_ApplierId",
                table: "Modifiers",
                column: "ApplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Modifiers_FightId",
                table: "Modifiers",
                column: "FightId");

            migrationBuilder.CreateIndex(
                name: "IX_Modifiers_ReceiverId",
                table: "Modifiers",
                column: "ReceiverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Modifiers");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "FighterStates");

            migrationBuilder.DropTable(
                name: "Fights");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
