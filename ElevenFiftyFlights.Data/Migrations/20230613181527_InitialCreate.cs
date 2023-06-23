using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElevenFiftyFlights.Data.Migrations
{
	/// <inheritdoc />
	public partial class InitialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Airport",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
					City = table.Column<string>(type: "nvarchar(max)", nullable: false),
					State = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Airport", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Flight",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					AirlineId = table.Column<int>(type: "int", nullable: false),
					OriginId = table.Column<int>(type: "int", nullable: false),
					DestinationId = table.Column<int>(type: "int", nullable: false),
					DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
					TicketPrice = table.Column<float>(type: "real", nullable: false),
					Gate = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Flight", x => x.Id);
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Airport");

			migrationBuilder.DropTable(
				name: "Flight");
		}
	}
}
