using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable



namespace MODELS.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cv",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    lalstName = table.Column<string>(type: "text", nullable: false),
                    mail = table.Column<string>(type: "text", nullable: false),
                    phon = table.Column<int>(type: "integer", nullable: false),
                    profile = table.Column<string>(type: "text", nullable: false),
                    skills = table.Column<string>(type: "text", nullable: false),
                    PracticalExperience = table.Column<string>(type: "text", nullable: false),
                    education = table.Column<string>(type: "text", nullable: false),
                    language = table.Column<string>(type: "text", nullable: false),
                    Jobid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cv", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    password = table.Column<string>(type: "text", nullable: false),
                    firstName = table.Column<string>(type: "text", nullable: false),
                    lalstName = table.Column<string>(type: "text", nullable: false),
                    usercvid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_cv_usercvid",
                        column: x => x.usercvid,
                        principalTable: "cv",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    requirements = table.Column<string>(type: "text", nullable: false),
                    experience = table.Column<string>(type: "text", nullable: false),
                    Usersid = table.Column<int>(type: "integer", nullable: true),
                    Usersid1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Jobs_Users_Usersid",
                        column: x => x.Usersid,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Jobs_Users_Usersid1",
                        column: x => x.Usersid1,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cv_Jobid",
                table: "cv",
                column: "Jobid");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Usersid",
                table: "Jobs",
                column: "Usersid");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_Usersid1",
                table: "Jobs",
                column: "Usersid1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_usercvid",
                table: "Users",
                column: "usercvid");

            migrationBuilder.AddForeignKey(
                name: "FK_cv_Jobs_Jobid",
                table: "cv",
                column: "Jobid",
                principalTable: "Jobs",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cv_Jobs_Jobid",
                table: "cv");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "cv");
        }
    }
}
