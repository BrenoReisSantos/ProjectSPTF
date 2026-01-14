using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sptf.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilterOperations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterOperations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationParameterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationParameterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationsParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SequencePosition = table.Column<int>(type: "integer", nullable: false),
                    IsList = table.Column<bool>(type: "boolean", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    FilterOperationId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationsParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationsParameters_FilterOperations_FilterOperationId",
                        column: x => x.FilterOperationId,
                        principalTable: "FilterOperations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OperationsParameters_OperationParameterTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "OperationParameterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OutputPlaylistName = table.Column<string>(type: "text", nullable: false),
                    OutputPlaylistId = table.Column<string>(type: "text", nullable: true),
                    InputPlaylistId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterOperationOrganizer",
                columns: table => new
                {
                    FilterOperationsId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterOperationOrganizer", x => new { x.FilterOperationsId, x.OrganizersId });
                    table.ForeignKey(
                        name: "FK_FilterOperationOrganizer_FilterOperations_FilterOperationsId",
                        column: x => x.FilterOperationsId,
                        principalTable: "FilterOperations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilterOperationOrganizer_Organizers_OrganizersId",
                        column: x => x.OrganizersId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationParameterTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Integer" },
                    { 2, "Text" },
                    { 3, "Boolean" },
                    { 4, "Date" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilterOperationOrganizer_OrganizersId",
                table: "FilterOperationOrganizer",
                column: "OrganizersId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterOperations_Name",
                table: "FilterOperations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationParameterTypes_Name",
                table: "OperationParameterTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationsParameters_FilterOperationId",
                table: "OperationsParameters",
                column: "FilterOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationsParameters_Id_SequencePosition",
                table: "OperationsParameters",
                columns: new[] { "Id", "SequencePosition" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationsParameters_TypeId",
                table: "OperationsParameters",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_UserId",
                table: "Organizers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilterOperationOrganizer");

            migrationBuilder.DropTable(
                name: "OperationsParameters");

            migrationBuilder.DropTable(
                name: "Organizers");

            migrationBuilder.DropTable(
                name: "FilterOperations");

            migrationBuilder.DropTable(
                name: "OperationParameterTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
