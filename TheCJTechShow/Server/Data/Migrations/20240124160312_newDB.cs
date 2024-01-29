using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCJTechShow.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class newDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SponsorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SponsorContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventIDId = table.Column<int>(type: "int", nullable: true),
                    OrganizerIDId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sponsors_Events_EventIDId",
                        column: x => x.EventIDId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sponsors_Organizers_OrganizerIDId",
                        column: x => x.OrganizerIDId,
                        principalTable: "Organizers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_EventIDId",
                table: "Sponsors",
                column: "EventIDId");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_OrganizerIDId",
                table: "Sponsors",
                column: "OrganizerIDId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sponsors");
        }
    }
}
