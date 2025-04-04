using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace todo_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Finish the coding assignment for the C# class by Friday.", "Complete C# Project" },
                    { 2, "Pick up ingredients for dinner and snacks for the week.", "Buy Groceries" },
                    { 3, "Go for a 5km run around the neighborhood.", "Morning Workout" },
                    { 4, "Read the remaining chapters of 'The Silent Patient'.", "Finish Reading Book" },
                    { 5, "Research destinations for a weekend getaway, check flight options.", "Plan Weekend Trip" },
                    { 6, "Tidy up the desk and file paperwork. Sort through old documents.", "Organize Office" },
                    { 7, "Discuss project updates, deadlines, and current challenges.", "Meeting with Team" },
                    { 8, "Relax and watch a new movie, preferably a thriller or mystery.", "Watch a Movie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
