using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class RemoveConstraintMemberSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberSkillsTbl_MemberTbl_MemberId",
                table: "MemberSkillsTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberSkillsTbl_Skills_SkillId",
                table: "MemberSkillsTbl");

            migrationBuilder.DropIndex(
                name: "IX_MemberSkillsTbl_MemberId_SkillId",
                table: "MemberSkillsTbl");

            migrationBuilder.DropIndex(
                name: "IX_MemberSkillsTbl_SkillId",
                table: "MemberSkillsTbl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MemberSkillsTbl_MemberId_SkillId",
                table: "MemberSkillsTbl",
                columns: new[] { "MemberId", "SkillId" });

            migrationBuilder.CreateIndex(
                name: "IX_MemberSkillsTbl_SkillId",
                table: "MemberSkillsTbl",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberSkillsTbl_MemberTbl_MemberId",
                table: "MemberSkillsTbl",
                column: "MemberId",
                principalTable: "MemberTbl",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberSkillsTbl_Skills_SkillId",
                table: "MemberSkillsTbl",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
