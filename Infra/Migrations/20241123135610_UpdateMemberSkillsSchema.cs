using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMemberSkillsSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemberSkillsTbl_MemberId",
                table: "MemberSkillsTbl");

            migrationBuilder.CreateIndex(
                name: "IX_MemberSkillsTbl_MemberId_SkillId",
                table: "MemberSkillsTbl",
                columns: new[] { "MemberId", "SkillId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemberSkillsTbl_MemberId_SkillId",
                table: "MemberSkillsTbl");

            migrationBuilder.CreateIndex(
                name: "IX_MemberSkillsTbl_MemberId",
                table: "MemberSkillsTbl",
                column: "MemberId");
        }
    }
}
