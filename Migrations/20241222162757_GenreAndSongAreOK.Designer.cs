﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicLibrary.Data;

#nullable disable

namespace MusicLibrary.Migrations
{
    [DbContext(typeof(MusicLibraryDbContext))]
    [Migration("20241222162757_GenreAndSongAreOK")]
    partial class GenreAndSongAreOK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicLibrary.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rock"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Grunge"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Metal"
                        });
                });

            modelBuilder.Entity("MusicLibrary.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistName = "Queen",
                            GenreId = 1,
                            ReleaseDate = new DateTime(1975, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Bohemian Rhapsody"
                        },
                        new
                        {
                            Id = 2,
                            ArtistName = "Led Zeppelin",
                            GenreId = 1,
                            ReleaseDate = new DateTime(1971, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Stairway to Heaven"
                        },
                        new
                        {
                            Id = 3,
                            ArtistName = "Eagles",
                            GenreId = 1,
                            ReleaseDate = new DateTime(1977, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Hotel California"
                        },
                        new
                        {
                            Id = 4,
                            ArtistName = "John Lennon",
                            GenreId = 1,
                            ReleaseDate = new DateTime(1971, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Imagine"
                        },
                        new
                        {
                            Id = 5,
                            ArtistName = "Nirvana",
                            GenreId = 2,
                            ReleaseDate = new DateTime(1991, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Smells Like Teen Spirit"
                        },
                        new
                        {
                            Id = 6,
                            ArtistName = "Metallica",
                            GenreId = 3,
                            ReleaseDate = new DateTime(1989, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "One"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
