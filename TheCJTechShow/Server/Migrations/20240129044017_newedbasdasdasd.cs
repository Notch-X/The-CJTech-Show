using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCJTechShow.Server.Migrations
{
    /// <inheritdoc />
    public partial class newedbasdasdasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizerID",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorID",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerID",
                table: "Events",
                column: "OrganizerID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VendorID",
                table: "Events",
                column: "VendorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerID",
                table: "Events",
                column: "OrganizerID",
                principalTable: "Organizers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Vendors_VendorID",
                table: "Events",
                column: "VendorID",
                principalTable: "Vendors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerID",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Vendors_VendorID",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_OrganizerID",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_VendorID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "OrganizerID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VendorID",
                table: "Events");
        }
    }
}
