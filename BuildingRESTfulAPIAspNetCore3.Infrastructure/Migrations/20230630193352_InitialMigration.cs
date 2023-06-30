using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuildingRESTfulAPIAspNetCore3.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MainCategory = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                    table.UniqueConstraint("AK_Author_Guid", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.UniqueConstraint("AK_Course_Guid", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Course_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "BirthDate", "FirstName", "Guid", "LastName", "MainCategory" },
                values: new object[,]
                {
                    { 1L, new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berry", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Griffin Beak Eldritch", "Ships" },
                    { 2L, new DateTime(1668, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nancy", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Swashbuckler Rye", "Rum" },
                    { 3L, new DateTime(1701, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eli", new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Ivory Bones Sweet", "Singing" },
                    { 4L, new DateTime(1702, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arnold", new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "The Unseen Stafford", "Singing" },
                    { 5L, new DateTime(1690, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seabury", new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "Toxic Reyson", "Maps" },
                    { 6L, new DateTime(1723, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rutherford", new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), "Fearless Cloven", "General debauchery" },
                    { 7L, new DateTime(1721, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Atherton", new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), "Crow Ridley", "Rum" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "AuthorId", "Description", "Guid", "Title" },
                values: new object[,]
                {
                    { 1L, 1L, "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers.", new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "Commandeering a Ship Without Getting Caught" },
                    { 2L, 1L, "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.", new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), "Overthrowing Mutiny" },
                    { 3L, 2L, "Every good pirate loves rum, but it also has a tendency to get you into trouble.  In this course you'll learn how to avoid that.  This new exclusive edition includes an additional chapter on how to run fast without falling while drunk.", new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), "Avoiding Brawls While Drinking as Much Rum as You Desire" },
                    { 4L, 3L, "In this course you'll learn how to sing all-time favourite pirate songs without sounding like you actually know the words or how to hold a note.", new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), "Singalong Pirate Hits" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_AuthorId",
                table: "Course",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
