using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitorManagement.Migrations
{
    public partial class Add_UpdateBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TimeSlots_TimeSlotId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TimeSlotId",
                table: "Bookings",
                newName: "TimeSlotMappingId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TimeSlotId",
                table: "Bookings",
                newName: "IX_Bookings_TimeSlotMappingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TimeSlotMappings_TimeSlotMappingId",
                table: "Bookings",
                column: "TimeSlotMappingId",
                principalTable: "TimeSlotMappings",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TimeSlotMappings_TimeSlotMappingId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TimeSlotMappingId",
                table: "Bookings",
                newName: "TimeSlotId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TimeSlotMappingId",
                table: "Bookings",
                newName: "IX_Bookings_TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TimeSlots_TimeSlotId",
                table: "Bookings",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
