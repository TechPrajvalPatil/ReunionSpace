using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminTbl",
                columns: table => new
                {
                    AdminId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTbl", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "CountryTbl",
                columns: table => new
                {
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTbl", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "MemberConnectionRequestTbl",
                columns: table => new
                {
                    MemberConnectionRequestId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestFromID = table.Column<long>(type: "bigint", nullable: false),
                    RequestToID = table.Column<long>(type: "bigint", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestStatus = table.Column<int>(type: "int", nullable: false),
                    RequestNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberConnectionRequestTbl", x => x.MemberConnectionRequestId);
                });

            migrationBuilder.CreateTable(
                name: "PollOptionTbl",
                columns: table => new
                {
                    PollOptionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollOptionTbl", x => x.PollOptionId);
                });

            migrationBuilder.CreateTable(
                name: "StateTbl",
                columns: table => new
                {
                    StateId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateTbl", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_StateTbl_CountryTbl_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryTbl",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityTbl",
                columns: table => new
                {
                    CityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTbl", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_CityTbl_StateTbl_StateId",
                        column: x => x.StateId,
                        principalTable: "StateTbl",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTbl",
                columns: table => new
                {
                    CompanyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTbl", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_CompanyTbl_CityTbl_CityId",
                        column: x => x.CityId,
                        principalTable: "CityTbl",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberTbl",
                columns: table => new
                {
                    MemberId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTbl", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_MemberTbl_CityTbl_CityId",
                        column: x => x.CityId,
                        principalTable: "CityTbl",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAdminTbl",
                columns: table => new
                {
                    CompanyAdminId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyAdminId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAdminTbl", x => x.CompanyAdminId);
                    table.ForeignKey(
                        name: "FK_CompanyAdminTbl_CityTbl_CityId",
                        column: x => x.CityId,
                        principalTable: "CityTbl",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyAdminTbl_CompanyAdminTbl_CompanyAdminId1",
                        column: x => x.CompanyAdminId1,
                        principalTable: "CompanyAdminTbl",
                        principalColumn: "CompanyAdminId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyAdminTbl_CompanyTbl_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyTbl",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberConnectionTbl",
                columns: table => new
                {
                    MemberConnectionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    ConnectedMemberId = table.Column<long>(type: "bigint", nullable: false),
                    ConnectionRequestId = table.Column<long>(type: "bigint", nullable: false),
                    AcceptDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberConnectionTbl", x => x.MemberConnectionId);
                    table.ForeignKey(
                        name: "FK_MemberConnectionTbl_MemberConnectionRequestTbl_ConnectionRequestId",
                        column: x => x.ConnectionRequestId,
                        principalTable: "MemberConnectionRequestTbl",
                        principalColumn: "MemberConnectionRequestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberConnectionTbl_MemberTbl_MemberId",
                        column: x => x.MemberId,
                        principalTable: "MemberTbl",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberCourseDetTbl",
                columns: table => new
                {
                    MemberCourseDetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttendedYear = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberCourseDetTbl", x => x.MemberCourseDetId);
                    table.ForeignKey(
                        name: "FK_MemberCourseDetTbl_MemberTbl_MemberId",
                        column: x => x.MemberId,
                        principalTable: "MemberTbl",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberRequestTbl",
                columns: table => new
                {
                    MemberRequestId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRequestTbl", x => x.MemberRequestId);
                    table.ForeignKey(
                        name: "FK_MemberRequestTbl_MemberTbl_MemberId",
                        column: x => x.MemberId,
                        principalTable: "MemberTbl",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventTbl",
                columns: table => new
                {
                    EventId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    RegistrationFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberLimit = table.Column<long>(type: "bigint", nullable: false),
                    EventMode = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTbl", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_EventTbl_CompanyAdminTbl_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "CompanyAdminTbl",
                        principalColumn: "CompanyAdminId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PollTbl",
                columns: table => new
                {
                    PollId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PollDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PollStatus = table.Column<int>(type: "int", nullable: false),
                    PollQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollTbl", x => x.PollId);
                    table.ForeignKey(
                        name: "FK_PollTbl_CompanyAdminTbl_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "CompanyAdminTbl",
                        principalColumn: "CompanyAdminId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventRegistrationTbl",
                columns: table => new
                {
                    EventRegistrationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    AcceptedById = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRegistrationTbl", x => x.EventRegistrationId);
                    table.ForeignKey(
                        name: "FK_EventRegistrationTbl_CompanyAdminTbl_AcceptedById",
                        column: x => x.AcceptedById,
                        principalTable: "CompanyAdminTbl",
                        principalColumn: "CompanyAdminId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventRegistrationTbl_EventTbl_EventId",
                        column: x => x.EventId,
                        principalTable: "EventTbl",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventRegistrationTbl_MemberTbl_MemberId",
                        column: x => x.MemberId,
                        principalTable: "MemberTbl",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PollResponseTbl",
                columns: table => new
                {
                    PollResponseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PollResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    PollId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollResponseTbl", x => x.PollResponseId);
                    table.ForeignKey(
                        name: "FK_PollResponseTbl_MemberTbl_MemberId",
                        column: x => x.MemberId,
                        principalTable: "MemberTbl",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PollResponseTbl_PollTbl_PollId",
                        column: x => x.PollId,
                        principalTable: "PollTbl",
                        principalColumn: "PollId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PollResponseOptionTbl",
                columns: table => new
                {
                    PollResponseOptionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PollResponseID = table.Column<long>(type: "bigint", nullable: false),
                    PollOptionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollResponseOptionTbl", x => x.PollResponseOptionId);
                    table.ForeignKey(
                        name: "FK_PollResponseOptionTbl_PollOptionTbl_PollOptionId",
                        column: x => x.PollOptionId,
                        principalTable: "PollOptionTbl",
                        principalColumn: "PollOptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PollResponseOptionTbl_PollResponseTbl_PollResponseID",
                        column: x => x.PollResponseID,
                        principalTable: "PollResponseTbl",
                        principalColumn: "PollResponseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AdminTbl",
                columns: new[] { "AdminId", "Address", "ContactNo", "EmailId", "FirstName", "LastName", "Password" },
                values: new object[] { 1L, null, "8275111415", "percyakr11@gmail.com", "Abhishek", "Kashid", "1234" });

            migrationBuilder.InsertData(
                table: "CountryTbl",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[] { 1L, "India" });

            migrationBuilder.InsertData(
                table: "StateTbl",
                columns: new[] { "StateId", "CountryId", "StateName" },
                values: new object[] { 1L, 1L, "Maharashtra" });

            migrationBuilder.InsertData(
                table: "CityTbl",
                columns: new[] { "CityId", "CityName", "StateId" },
                values: new object[] { 1L, "Kolhapur", 1L });

            migrationBuilder.CreateIndex(
                name: "IX_CityTbl_StateId",
                table: "CityTbl",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAdminTbl_CityId",
                table: "CompanyAdminTbl",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAdminTbl_CompanyAdminId1",
                table: "CompanyAdminTbl",
                column: "CompanyAdminId1");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAdminTbl_CompanyId",
                table: "CompanyAdminTbl",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTbl_CityId",
                table: "CompanyTbl",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrationTbl_AcceptedById",
                table: "EventRegistrationTbl",
                column: "AcceptedById");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrationTbl_EventId",
                table: "EventRegistrationTbl",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrationTbl_MemberId",
                table: "EventRegistrationTbl",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTbl_CreatedById",
                table: "EventTbl",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MemberConnectionTbl_ConnectionRequestId",
                table: "MemberConnectionTbl",
                column: "ConnectionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberConnectionTbl_MemberId",
                table: "MemberConnectionTbl",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberCourseDetTbl_MemberId",
                table: "MemberCourseDetTbl",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRequestTbl_MemberId",
                table: "MemberRequestTbl",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTbl_CityId",
                table: "MemberTbl",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PollResponseOptionTbl_PollOptionId",
                table: "PollResponseOptionTbl",
                column: "PollOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PollResponseOptionTbl_PollResponseID",
                table: "PollResponseOptionTbl",
                column: "PollResponseID");

            migrationBuilder.CreateIndex(
                name: "IX_PollResponseTbl_MemberId",
                table: "PollResponseTbl",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_PollResponseTbl_PollId",
                table: "PollResponseTbl",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_PollTbl_CreatedById",
                table: "PollTbl",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StateTbl_CountryId",
                table: "StateTbl",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminTbl");

            migrationBuilder.DropTable(
                name: "EventRegistrationTbl");

            migrationBuilder.DropTable(
                name: "MemberConnectionTbl");

            migrationBuilder.DropTable(
                name: "MemberCourseDetTbl");

            migrationBuilder.DropTable(
                name: "MemberRequestTbl");

            migrationBuilder.DropTable(
                name: "PollResponseOptionTbl");

            migrationBuilder.DropTable(
                name: "EventTbl");

            migrationBuilder.DropTable(
                name: "MemberConnectionRequestTbl");

            migrationBuilder.DropTable(
                name: "PollOptionTbl");

            migrationBuilder.DropTable(
                name: "PollResponseTbl");

            migrationBuilder.DropTable(
                name: "MemberTbl");

            migrationBuilder.DropTable(
                name: "PollTbl");

            migrationBuilder.DropTable(
                name: "CompanyAdminTbl");

            migrationBuilder.DropTable(
                name: "CompanyTbl");

            migrationBuilder.DropTable(
                name: "CityTbl");

            migrationBuilder.DropTable(
                name: "StateTbl");

            migrationBuilder.DropTable(
                name: "CountryTbl");
        }
    }
}
