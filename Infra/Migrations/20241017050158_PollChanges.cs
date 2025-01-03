using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class PollChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PollId",
                table: "PollOptionTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PollOptionTbl_PollId",
                table: "PollOptionTbl",
                column: "PollId");

            migrationBuilder.AddForeignKey(
                name: "FK_PollOptionTbl_PollTbl_PollId",
                table: "PollOptionTbl",
                column: "PollId",
                principalTable: "PollTbl",
                principalColumn: "PollId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollOptionTbl_PollTbl_PollId",
                table: "PollOptionTbl");

            migrationBuilder.DropIndex(
                name: "IX_PollOptionTbl_PollId",
                table: "PollOptionTbl");

            migrationBuilder.DropColumn(
                name: "PollId",
                table: "PollOptionTbl");
        }
    }
}
