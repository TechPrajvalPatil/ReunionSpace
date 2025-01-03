using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddMobiletoMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyAdminTbl_CompanyAdminTbl_CompanyAdminId1",
                table: "CompanyAdminTbl");

            migrationBuilder.DropIndex(
                name: "IX_CompanyAdminTbl_CompanyAdminId1",
                table: "CompanyAdminTbl");

            migrationBuilder.DropColumn(
                name: "CompanyAdminId1",
                table: "CompanyAdminTbl");

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                table: "MemberTbl",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "MemberTbl");

            migrationBuilder.AddColumn<long>(
                name: "CompanyAdminId1",
                table: "CompanyAdminTbl",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAdminTbl_CompanyAdminId1",
                table: "CompanyAdminTbl",
                column: "CompanyAdminId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyAdminTbl_CompanyAdminTbl_CompanyAdminId1",
                table: "CompanyAdminTbl",
                column: "CompanyAdminId1",
                principalTable: "CompanyAdminTbl",
                principalColumn: "CompanyAdminId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
