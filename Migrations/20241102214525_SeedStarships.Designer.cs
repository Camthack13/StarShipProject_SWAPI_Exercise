﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace StarshipProject.Migrations
{
    [DbContext(typeof(StarshipContext))]
    [Migration("20241102214525_SeedStarships")]
    partial class SeedStarships
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Starship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StarshipClass")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Starships");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Manufacturer = "Corellian Engineering Corporation",
                            Model = "YT-1300 light freighter",
                            Name = "Millennium Falcon",
                            StarshipClass = "Light freighter"
                        },
                        new
                        {
                            Id = 2,
                            Manufacturer = "Incom Corporation",
                            Model = "T-65 X-wing starfighter",
                            Name = "X-Wing",
                            StarshipClass = "Starfighter"
                        },
                        new
                        {
                            Id = 3,
                            Manufacturer = "Sienar Fleet Systems",
                            Model = "Twin Ion Engine starfighter",
                            Name = "TIE Fighter",
                            StarshipClass = "Starfighter"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
