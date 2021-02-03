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
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RequiredTeams = table.Column<int>(type: "int", nullable: false),
                    HasStarted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasEnded = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Stage = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CurrentTurn = table.Column<int>(type: "int", nullable: false),
                    FightType = table.Column<int>(type: "int", nullable: false),
                    WinnerTeam = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    WaitingForAction = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FightLength = table.Column<int>(type: "int", nullable: false),
                    Channel = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Debug = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ForcedDiceRoll = table.Column<int>(type: "int", nullable: false),
                    DiceLess = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Sensuality = table.Column<int>(type: "int", nullable: false),
                    Toughness = table.Column<int>(type: "int", nullable: false),
                    Endurance = table.Column<int>(type: "int", nullable: false),
                    Willpower = table.Column<int>(type: "int", nullable: false),
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
                    UserName = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Hp = table.Column<int>(type: "int", nullable: false),
                    Lust = table.Column<int>(type: "int", nullable: false),
                    LivesRemaining = table.Column<int>(type: "int", nullable: false),
                    Focus = table.Column<int>(type: "int", nullable: false),
                    ConsecutiveTurnsWithoutFocus = table.Column<int>(type: "int", nullable: false),
                    StartingPower = table.Column<int>(type: "int", nullable: false),
                    StartingSensuality = table.Column<int>(type: "int", nullable: false),
                    StartingToughness = table.Column<int>(type: "int", nullable: false),
                    StartingEndurance = table.Column<int>(type: "int", nullable: false),
                    StartingDexterity = table.Column<int>(type: "int", nullable: false),
                    StartingWillpower = table.Column<int>(type: "int", nullable: false),
                    PowerDelta = table.Column<int>(type: "int", nullable: false),
                    SensualityDelta = table.Column<int>(type: "int", nullable: false),
                    ToughnessDelta = table.Column<int>(type: "int", nullable: false),
                    EnduranceDelta = table.Column<int>(type: "int", nullable: false),
                    DexterityDelta = table.Column<int>(type: "int", nullable: false),
                    WillpowerDelta = table.Column<int>(type: "int", nullable: false),
                    HpDamageLastRound = table.Column<int>(type: "int", nullable: false),
                    LpDamageLastRound = table.Column<int>(type: "int", nullable: false),
                    FpDamageLastRound = table.Column<int>(type: "int", nullable: false),
                    HpHealLastRound = table.Column<int>(type: "int", nullable: false),
                    LpHealLastRound = table.Column<int>(type: "int", nullable: false),
                    FpHealLastRound = table.Column<int>(type: "int", nullable: false),
                    HeartsDamageLastRound = table.Column<int>(type: "int", nullable: false),
                    OrgasmsDamageLastRound = table.Column<int>(type: "int", nullable: false),
                    HeartsHealLastRound = table.Column<int>(type: "int", nullable: false),
                    OrgasmsHealLastRound = table.Column<int>(type: "int", nullable: false),
                    CurrentPower = table.Column<int>(type: "int", nullable: false),
                    CurrentSensuality = table.Column<int>(type: "int", nullable: false),
                    CurrentToughness = table.Column<int>(type: "int", nullable: false),
                    CurrentEndurance = table.Column<int>(type: "int", nullable: false),
                    CurrentDexterity = table.Column<int>(type: "int", nullable: false),
                    CurrentWillpower = table.Column<int>(type: "int", nullable: false),
                    RWFightId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    RWFighterStateId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AssignedTeam = table.Column<int>(type: "int", nullable: false),
                    TargetsAsString = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IsReady = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastDiceRoll = table.Column<int>(type: "int", nullable: false),
                    IsInTheRing = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CanMoveFromOrOffRing = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastTagTurn = table.Column<int>(type: "int", nullable: false),
                    WantsDraw = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DistanceFromRingCenter = table.Column<int>(type: "int", nullable: false),
                    FightStatus = table.Column<int>(type: "int", nullable: false),
                    FightId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FighterStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FighterStates_FighterStates_RWFighterStateId",
                        column: x => x.RWFighterStateId,
                        principalTable: "FighterStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FighterStates_Fights_FightId",
                        column: x => x.FightId,
                        principalTable: "Fights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    BrawlAtksCount = table.Column<int>(type: "int", nullable: false),
                    SexstrikesCount = table.Column<int>(type: "int", nullable: false),
                    TagsCount = table.Column<int>(type: "int", nullable: false),
                    RestCount = table.Column<int>(type: "int", nullable: false),
                    SubholdCount = table.Column<int>(type: "int", nullable: false),
                    SexholdCount = table.Column<int>(type: "int", nullable: false),
                    BondageCount = table.Column<int>(type: "int", nullable: false),
                    HumholdCount = table.Column<int>(type: "int", nullable: false),
                    ItemPickups = table.Column<int>(type: "int", nullable: false),
                    SextoyPickups = table.Column<int>(type: "int", nullable: false),
                    DegradationCount = table.Column<int>(type: "int", nullable: false),
                    ForcedWorshipCount = table.Column<int>(type: "int", nullable: false),
                    HighRiskCount = table.Column<int>(type: "int", nullable: false),
                    PenetrationCount = table.Column<int>(type: "int", nullable: false),
                    StunCount = table.Column<int>(type: "int", nullable: false),
                    EscapeCount = table.Column<int>(type: "int", nullable: false),
                    SubmitCount = table.Column<int>(type: "int", nullable: false),
                    StraptoyCount = table.Column<int>(type: "int", nullable: false),
                    FinishCount = table.Column<int>(type: "int", nullable: false),
                    MasturbateCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FightsCount = table.Column<int>(type: "int", nullable: false),
                    FightsCountCS = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    LossesSeason = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    WinsSeason = table.Column<int>(type: "int", nullable: false),
                    CurrentlyPlaying = table.Column<int>(type: "int", nullable: false),
                    CurrentlyPlayingSeason = table.Column<int>(type: "int", nullable: false),
                    FightsPendingReady = table.Column<int>(type: "int", nullable: false),
                    FightsPendingReadySeason = table.Column<int>(type: "int", nullable: false),
                    FightsPendingStart = table.Column<int>(type: "int", nullable: false),
                    FightsPendingStartSeason = table.Column<int>(type: "int", nullable: false),
                    FightsPendingDraw = table.Column<int>(type: "int", nullable: false),
                    FightsPendingDrawSeason = table.Column<int>(type: "int", nullable: false),
                    FavoriteTeam = table.Column<int>(type: "int", nullable: false),
                    FavoriteTagPartner = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    TimesFoughtWithFavoriteTagPartner = table.Column<int>(type: "int", nullable: false),
                    Nemesis = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    LossesAgainstNemesis = table.Column<int>(type: "int", nullable: false),
                    AverageDiceRoll = table.Column<int>(type: "int", nullable: false),
                    MissedAttacks = table.Column<int>(type: "int", nullable: false),
                    ActionsCount = table.Column<int>(type: "int", nullable: false),
                    ActionsDefended = table.Column<int>(type: "int", nullable: false),
                    MatchesInLast24Hours = table.Column<int>(type: "int", nullable: false),
                    MatchesInLast48Hours = table.Column<int>(type: "int", nullable: false),
                    EloRating = table.Column<int>(type: "int", nullable: false),
                    GlobalRank = table.Column<int>(type: "int", nullable: false),
                    Forfeits = table.Column<int>(type: "int", nullable: false),
                    Quits = table.Column<int>(type: "int", nullable: false)
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
                    HpDamage = table.Column<int>(type: "int", nullable: false),
                    LustDamage = table.Column<int>(type: "int", nullable: false),
                    FocusDamage = table.Column<int>(type: "int", nullable: false),
                    HpHeal = table.Column<int>(type: "int", nullable: false),
                    LustHeal = table.Column<int>(type: "int", nullable: false),
                    FocusHeal = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    AreDamageMultipliers = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DiceRoll = table.Column<int>(type: "int", nullable: false),
                    EscapeRoll = table.Column<int>(type: "int", nullable: false),
                    Uses = table.Column<int>(type: "int", nullable: false),
                    TriggeringEvent = table.Column<int>(type: "int", nullable: false),
                    TimeToTrigger = table.Column<int>(type: "int", nullable: false),
                    IdParentActions = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    FightId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    ApplierId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    ReceiverId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    IsStun = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsHold = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                name: "IX_FighterStates_RWFighterStateId",
                table: "FighterStates",
                column: "RWFighterStateId");

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
