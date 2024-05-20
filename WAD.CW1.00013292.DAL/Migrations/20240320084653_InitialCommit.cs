using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WAD.CW1._00013292.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyTypes",
                columns: table => new
                {
                    KeyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyTypes", x => x.KeyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "KeyItems",
                columns: table => new
                {
                    KeyItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyItems", x => x.KeyItemId);
                    table.ForeignKey(
                        name: "FK_KeyItems_KeyTypes_KeyTypeId",
                        column: x => x.KeyTypeId,
                        principalTable: "KeyTypes",
                        principalColumn: "KeyTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "KeyTypes",
                columns: new[] { "KeyTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Keys for API access", "API Key" },
                    { 2, "Keys for software licensing", "License Key" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyItems_KeyTypeId",
                table: "KeyItems",
                column: "KeyTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyItems");

            migrationBuilder.DropTable(
                name: "KeyTypes");
        }
    }
}
