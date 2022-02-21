using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnluCoHafta3.Migrations
{
    public partial class PatikaDev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonelInformations",
                columns: table => new
                {
                    PersonelInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelInformations", x => x.PersonelInformationId);
                });

            migrationBuilder.CreateTable(
                name: "Assistants",
                columns: table => new
                {
                    AssistantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistants", x => x.AssistantId);
                    table.ForeignKey(
                        name: "FK_Assistants_PersonelInformations_PersonelInformationId",
                        column: x => x.PersonelInformationId,
                        principalTable: "PersonelInformations",
                        principalColumn: "PersonelInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authorities",
                columns: table => new
                {
                    AuthorizedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelInformationId = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorities", x => x.AuthorizedId);
                    table.ForeignKey(
                        name: "FK_Authorities_PersonelInformations_PersonelInformationId",
                        column: x => x.PersonelInformationId,
                        principalTable: "PersonelInformations",
                        principalColumn: "PersonelInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_Participants_PersonelInformations_PersonelInformationId",
                        column: x => x.PersonelInformationId,
                        principalTable: "PersonelInformations",
                        principalColumn: "PersonelInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelInformationId = table.Column<int>(type: "int", nullable: false),
                    WorkingStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_PersonelInformations_PersonelInformationId",
                        column: x => x.PersonelInformationId,
                        principalTable: "PersonelInformations",
                        principalColumn: "PersonelInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerKnowledge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_Teachers_PersonelInformations_PersonelInformationId",
                        column: x => x.PersonelInformationId,
                        principalTable: "PersonelInformations",
                        principalColumn: "PersonelInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    AbsenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfWeek = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.AbsenceId);
                    table.ForeignKey(
                        name: "FK_Absences_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuccessAverages",
                columns: table => new
                {
                    AverageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AveragePercent = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuccessAverages", x => x.AverageId);
                    table.ForeignKey(
                        name: "FK_SuccessAverages_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EducationContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    AssistantId = table.Column<int>(type: "int", nullable: false),
                    AuthorizedId = table.Column<int>(type: "int", nullable: false),
                    StartingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Educations_Assistants_AssistantId",
                        column: x => x.AssistantId,
                        principalTable: "Assistants",
                        principalColumn: "AssistantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_Authorities_AuthorizedId",
                        column: x => x.AuthorizedId,
                        principalTable: "Authorities",
                        principalColumn: "AuthorizedId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Educations_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EducationParticipant",
                columns: table => new
                {
                    EducationsEducationId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsParticipantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationParticipant", x => new { x.EducationsEducationId, x.ParticipantsParticipantId });
                    table.ForeignKey(
                        name: "FK_EducationParticipant_Educations_EducationsEducationId",
                        column: x => x.EducationsEducationId,
                        principalTable: "Educations",
                        principalColumn: "EducationId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EducationParticipant_Participants_ParticipantsParticipantId",
                        column: x => x.ParticipantsParticipantId,
                        principalTable: "Participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EducationStudent",
                columns: table => new
                {
                    EducationsEducationId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationStudent", x => new { x.EducationsEducationId, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_EducationStudent_Educations_EducationsEducationId",
                        column: x => x.EducationsEducationId,
                        principalTable: "Educations",
                        principalColumn: "EducationId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EducationStudent_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_StudentId",
                table: "Absences",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assistants_PersonelInformationId",
                table: "Assistants",
                column: "PersonelInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authorities_PersonelInformationId",
                table: "Authorities",
                column: "PersonelInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EducationParticipant_ParticipantsParticipantId",
                table: "EducationParticipant",
                column: "ParticipantsParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_AssistantId",
                table: "Educations",
                column: "AssistantId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_AuthorizedId",
                table: "Educations",
                column: "AuthorizedId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_TeacherId",
                table: "Educations",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationStudent_StudentsStudentId",
                table: "EducationStudent",
                column: "StudentsStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PersonelInformationId",
                table: "Participants",
                column: "PersonelInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_PersonelInformationId",
                table: "Students",
                column: "PersonelInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuccessAverages_StudentId",
                table: "SuccessAverages",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_PersonelInformationId",
                table: "Teachers",
                column: "PersonelInformationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropTable(
                name: "EducationParticipant");

            migrationBuilder.DropTable(
                name: "EducationStudent");

            migrationBuilder.DropTable(
                name: "SuccessAverages");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Assistants");

            migrationBuilder.DropTable(
                name: "Authorities");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "PersonelInformations");
        }
    }
}
