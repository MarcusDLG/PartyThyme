﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PartyThyme;

namespace PartyThyme.Migrations
{
    [DbContext(typeof(PlantContext))]
    [Migration("20200226182034_AddedPlantTable")]
    partial class AddedPlantTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PartyThyme.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("LastWateredDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("LightNeeded")
                        .HasColumnType("double precision");

                    b.Property<string>("LocatedPlanted")
                        .HasColumnType("text");

                    b.Property<DateTime>("PlantedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Species")
                        .HasColumnType("text");

                    b.Property<double>("WaterNeeded")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Plants");
                });
#pragma warning restore 612, 618
        }
    }
}
