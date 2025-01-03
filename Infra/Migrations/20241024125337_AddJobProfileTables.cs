using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddJobProfileTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTbl",
                columns: table => new
                {
                    JobId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimumEducation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfVacancies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnyOtherInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyAdminId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTbl", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_JobTbl_CompanyAdminTbl_CompanyAdminId",
                        column: x => x.CompanyAdminId,
                        principalTable: "CompanyAdminTbl",
                        principalColumn: "CompanyAdminId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberEducationTbl",
                columns: table => new
                {
                    MemberEducationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    EducationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassoutYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityOrCollegeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeOrPercentage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberEducationTbl", x => x.MemberEducationId);
                    table.ForeignKey(
                        name: "FK_MemberEducationTbl_MemberTbl_MemberId",
                        column: x => x.MemberId,
                        principalTable: "MemberTbl",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberExperienceTbl",
                columns: table => new
                {
                    MemberExperienceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    ExperienceTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceDuration = table.Column<double>(type: "float", nullable: false),
                    ExperienceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberExperienceTbl", x => x.MemberExperienceId);
                    table.ForeignKey(
                        name: "FK_MemberExperienceTbl_MemberTbl_MemberId",
                        column: x => x.MemberId,
                        principalTable: "MemberTbl",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberResumeTbl",
                columns: table => new
                {
                    MemberResumeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    ResumeFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpadatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberResumeTbl", x => x.MemberResumeId);
                    table.ForeignKey(
                        name: "FK_MemberResumeTbl_MemberTbl_MemberId",
                        column: x => x.MemberId,
                        principalTable: "MemberTbl",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "MemberSkillsTbl",
                columns: table => new
                {
                    MemberSkillsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    SkillId = table.Column<long>(type: "bigint", nullable: false),
                    Proficiency = table.Column<int>(type: "int", nullable: false),
                    NoOfYears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberSkillsTbl", x => x.MemberSkillsId);
                    table.ForeignKey(
                        name: "FK_MemberSkillsTbl_MemberTbl_MemberId",
                        column: x => x.MemberId,
                        principalTable: "MemberTbl",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberSkillsTbl_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobTbl_CompanyAdminId",
                table: "JobTbl",
                column: "CompanyAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberEducationTbl_MemberId",
                table: "MemberEducationTbl",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberExperienceTbl_MemberId",
                table: "MemberExperienceTbl",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberResumeTbl_MemberId",
                table: "MemberResumeTbl",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberSkillsTbl_MemberId",
                table: "MemberSkillsTbl",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberSkillsTbl_SkillId",
                table: "MemberSkillsTbl",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobTbl");

            migrationBuilder.DropTable(
                name: "MemberEducationTbl");

            migrationBuilder.DropTable(
                name: "MemberExperienceTbl");

            migrationBuilder.DropTable(
                name: "MemberResumeTbl");

            migrationBuilder.DropTable(
                name: "MemberSkillsTbl");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
