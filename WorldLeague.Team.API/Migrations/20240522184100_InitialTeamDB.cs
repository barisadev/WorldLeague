using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorldLeague.Team.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialTeamDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "league");

            migrationBuilder.CreateTable(
                name: "Draws",
                schema: "league",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawnBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                schema: "league",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawGroups",
                schema: "league",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawId = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrawGroups_Draws_DrawId",
                        column: x => x.DrawId,
                        principalSchema: "league",
                        principalTable: "Draws",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrawGroupTeam",
                schema: "league",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawGroupTeam", x => new { x.GroupId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_DrawGroupTeam_DrawGroups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "league",
                        principalTable: "DrawGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrawGroupTeam_Teams_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "league",
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrawGroupTeam_TeamId",
                schema: "league",
                table: "DrawGroupTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawGroups_DrawId",
                schema: "league",
                table: "DrawGroups",
                column: "DrawId");

            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso İstanbul', 'Türkiye')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Ankara', 'Türkiye')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso İzmir', 'Türkiye')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Antalya', 'Türkiye')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Berlin', 'Almanya')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Frankfurt', 'Almanya')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Münih', 'Almanya')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Dortmund', 'Almanya')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Paris', 'Fransa')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Marsilya', 'Fransa')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Nice', 'Fransa')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Lyon', 'Fransa')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Amsterdam', 'Hollanda')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Rotterdam', 'Hollanda')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Lahey', 'Hollanda')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Eindhoven', 'Hollanda')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Lisbon', 'Portekiz')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Porto', 'Portekiz')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Braga', 'Portekiz')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Coimbra', 'Portekiz')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Roma', 'İtalya')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Milano', 'İtalya')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Venedik', 'İtalya')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Napoli', 'İtalya')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Sevilla', 'İspanya')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Madrid', 'İspanya')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Barselona', 'İspanya')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Granada', 'İspanya')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Brüksel', 'Belçika')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Brugge', 'Belçika')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Gent', 'Belçika')");
            migrationBuilder.Sql("INSERT INTO league.Teams(Name, Country) VALUES('Adesso Anvers', 'Belçika')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrawGroupTeam",
                schema: "league");

            migrationBuilder.DropTable(
                name: "DrawGroups",
                schema: "league");

            migrationBuilder.DropTable(
                name: "Teams",
                schema: "league");

            migrationBuilder.DropTable(
                name: "Draws",
                schema: "league");
        }
    }
}
