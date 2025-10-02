using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Package.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "base");

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Plan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxItems = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "base",
                table: "Subscriptions",
                columns: new[] { "Id", "MaxItems", "Plan", "UserId" },
                values: new object[,]
                {
                    { 1, 10, "enterprise", 1 },
                    { 2, 5, "pro", 2 },
                    { 3, 12, "enterprise", 3 },
                    { 4, 4, "free", 4 },
                    { 5, 20, "pro", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                schema: "base",
                table: "Subscriptions",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions",
                schema: "base");
        }
    }
}
