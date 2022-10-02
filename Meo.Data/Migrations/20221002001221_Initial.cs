using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meo.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCampaign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCampaign", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbQuestion_tbCampaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "tbCampaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbForm_tbCampaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "tbCampaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbForm_tbPerson_PersonId",
                        column: x => x.PersonId,
                        principalTable: "tbPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    AnswerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbAnswer_tbForm_FormId",
                        column: x => x.FormId,
                        principalTable: "tbForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbAnswer_tbQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "tbQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbAnswer_FormId",
                table: "tbAnswer",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_tbAnswer_QuestionId",
                table: "tbAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbForm_CampaignId",
                table: "tbForm",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_tbForm_PersonId",
                table: "tbForm",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_tbQuestion_CampaignId",
                table: "tbQuestion",
                column: "CampaignId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbAnswer");

            migrationBuilder.DropTable(
                name: "tbForm");

            migrationBuilder.DropTable(
                name: "tbQuestion");

            migrationBuilder.DropTable(
                name: "tbPerson");

            migrationBuilder.DropTable(
                name: "tbCampaign");
        }
    }
}
