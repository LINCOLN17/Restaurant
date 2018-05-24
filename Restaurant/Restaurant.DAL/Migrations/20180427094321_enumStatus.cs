using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Restaurant.DAL.Migrations
{
    public partial class enumStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SmallTables",
                newName: "SmallTableId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Reservations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Reservations",
                newName: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SmallTableId",
                table: "SmallTables",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reservations",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Reservations",
                newName: "ID");
        }
    }
}
