﻿// <auto-generated />
using System;
using ElevenFiftyFlights.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElevenFiftyFlights.Data.Migrations
{
	[DbContext(typeof(ApplicationDbContext))]
	[Migration("20230613181527_InitialCreate")]
	partial class InitialCreate
	{
		/// <inheritdoc />
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "7.0.7")
				.HasAnnotation("Relational:MaxIdentifierLength", 128);

			SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

			modelBuilder.Entity("ElevenFiftyFlights.Data.Entities.AirportEntity", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<string>("City")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.Property<string>("Code")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.Property<string>("Country")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.Property<string>("Name")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.Property<string>("State")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.HasKey("Id");

					b.ToTable("Airport");
				});

			modelBuilder.Entity("ElevenFiftyFlights.Data.Entities.FlightEntity", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<int>("AirlineId")
						.HasColumnType("int");

					b.Property<DateTime>("DepartureTime")
						.HasColumnType("datetime2");

					b.Property<int>("DestinationId")
						.HasColumnType("int");

					b.Property<string>("Gate")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.Property<int>("OriginId")
						.HasColumnType("int");

					b.Property<float>("TicketPrice")
						.HasColumnType("real");

					b.HasKey("Id");

					b.ToTable("Flight");
				});
#pragma warning restore 612, 618
		}
	}
}
