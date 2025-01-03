using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressToMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "MemberTbl",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FeedsTbl",
                columns: table => new
                {
                    FeedsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeedsTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedType = table.Column<int>(type: "int", nullable: false),
                    FeedsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedsTbl", x => x.FeedsId);
                });

            migrationBuilder.CreateTable(
                name: "FeedsPhoto",
                columns: table => new
                {
                    FeedsPhotoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedsId = table.Column<long>(type: "bigint", nullable: false),
                    PhotoPathFile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedsPhoto", x => x.FeedsPhotoId);
                    table.ForeignKey(
                        name: "FK_FeedsPhoto_FeedsTbl_FeedsId",
                        column: x => x.FeedsId,
                        principalTable: "FeedsTbl",
                        principalColumn: "FeedsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedsVideo",
                columns: table => new
                {
                    FeedsVideoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedsId = table.Column<long>(type: "bigint", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedsVideo", x => x.FeedsVideoId);
                    table.ForeignKey(
                        name: "FK_FeedsVideo_FeedsTbl_FeedsId",
                        column: x => x.FeedsId,
                        principalTable: "FeedsTbl",
                        principalColumn: "FeedsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedsPhoto_FeedsId",
                table: "FeedsPhoto",
                column: "FeedsId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedsVideo_FeedsId",
                table: "FeedsVideo",
                column: "FeedsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedsPhoto");

            migrationBuilder.DropTable(
                name: "FeedsVideo");

            migrationBuilder.DropTable(
                name: "FeedsTbl");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "MemberTbl");
        }
    }
}
