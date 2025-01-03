using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class FeedChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MemberId",
                table: "FeedsTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_FeedsTbl_MemberId",
                table: "FeedsTbl",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedsTbl_MemberTbl_MemberId",
                table: "FeedsTbl",
                column: "MemberId",
                principalTable: "MemberTbl",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedsTbl_MemberTbl_MemberId",
                table: "FeedsTbl");

            migrationBuilder.DropIndex(
                name: "IX_FeedsTbl_MemberId",
                table: "FeedsTbl");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "FeedsTbl");
        }
    }
}
