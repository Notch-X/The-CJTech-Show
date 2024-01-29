using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheCJTechShow.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class CJTechShowDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Events_EventID",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_EventID",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Visitors",
                newName: "VisitorName");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Visitors",
                newName: "VisitorEmail");

            migrationBuilder.RenameColumn(
                name: "ContactNo",
                table: "Visitors",
                newName: "VisitorContactNumber");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Visitors",
                newName: "VisitorCompany");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vendors",
                newName: "VendorName");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "Vendors",
                newName: "VendorID");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Vendors",
                newName: "VendorDescription");

            migrationBuilder.RenameColumn(
                name: "ContactNo",
                table: "Vendors",
                newName: "VendorContactDetails");

            migrationBuilder.RenameColumn(
                name: "BoothNo",
                table: "Vendors",
                newName: "SocialMedia");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Organizers",
                newName: "OrganizerPosition");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Organizers",
                newName: "OrganizerPassword");

            migrationBuilder.RenameColumn(
                name: "ContactNo",
                table: "Organizers",
                newName: "OrganizerName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Events",
                newName: "EventTicketPrice");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Events",
                newName: "EventRegistration");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Events",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "ContactNo",
                table: "Events",
                newName: "EventLocation");

            migrationBuilder.AddColumn<int>(
                name: "VisitorID",
                table: "Visitors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BoothNumber",
                table: "Vendors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Products",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizerContactNumber",
                table: "Organizers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizerEmail",
                table: "Organizers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizerID",
                table: "Organizers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VendorIDId",
                table: "Organizers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventContactInformation",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventDescription",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventDuration",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizerIDId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorIDId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_VendorIDId",
                table: "Organizers",
                column: "VendorIDId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerIDId",
                table: "Events",
                column: "OrganizerIDId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VendorIDId",
                table: "Events",
                column: "VendorIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerIDId",
                table: "Events",
                column: "OrganizerIDId",
                principalTable: "Organizers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Vendors_VendorIDId",
                table: "Events",
                column: "VendorIDId",
                principalTable: "Vendors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizers_Vendors_VendorIDId",
                table: "Organizers",
                column: "VendorIDId",
                principalTable: "Vendors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerIDId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Vendors_VendorIDId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizers_Vendors_VendorIDId",
                table: "Organizers");

            migrationBuilder.DropIndex(
                name: "IX_Organizers_VendorIDId",
                table: "Organizers");

            migrationBuilder.DropIndex(
                name: "IX_Events_OrganizerIDId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_VendorIDId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VisitorID",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "BoothNumber",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Products",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "OrganizerContactNumber",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "OrganizerEmail",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "OrganizerID",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "VendorIDId",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "EventContactInformation",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventDescription",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventDuration",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "OrganizerIDId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VendorIDId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "VisitorName",
                table: "Visitors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "VisitorEmail",
                table: "Visitors",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "VisitorContactNumber",
                table: "Visitors",
                newName: "ContactNo");

            migrationBuilder.RenameColumn(
                name: "VisitorCompany",
                table: "Visitors",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "VendorName",
                table: "Vendors",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "VendorID",
                table: "Vendors",
                newName: "EventID");

            migrationBuilder.RenameColumn(
                name: "VendorDescription",
                table: "Vendors",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "VendorContactDetails",
                table: "Vendors",
                newName: "ContactNo");

            migrationBuilder.RenameColumn(
                name: "SocialMedia",
                table: "Vendors",
                newName: "BoothNo");

            migrationBuilder.RenameColumn(
                name: "OrganizerPosition",
                table: "Organizers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OrganizerPassword",
                table: "Organizers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "OrganizerName",
                table: "Organizers",
                newName: "ContactNo");

            migrationBuilder.RenameColumn(
                name: "EventTicketPrice",
                table: "Events",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EventRegistration",
                table: "Events",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Events",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "EventLocation",
                table: "Events",
                newName: "ContactNo");

            migrationBuilder.AddColumn<double>(
                name: "TicketPrice",
                table: "Events",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_EventID",
                table: "Vendors",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Events_EventID",
                table: "Vendors",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
