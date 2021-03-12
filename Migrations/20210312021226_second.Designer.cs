﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesManagememtSystem.Data;

namespace MoviesManagememtSystem.Migrations
{
    [DbContext(typeof(MovieArtistsDbContext))]
    [Migration("20210312021226_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoviesManagememtSystem.Models.Maker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieFK")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MovieFK");

                    b.ToTable("Maker");
                });

            modelBuilder.Entity("MoviesManagememtSystem.Models.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsHit")
                        .HasColumnType("bit");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProduceDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("plot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("publishTime")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MoviesManagememtSystem.Models.MovieArtist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFamous")
                        .HasColumnType("bit");

                    b.Property<int>("MovieFK")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MovieFK");

                    b.ToTable("MovieArtist");
                });

            modelBuilder.Entity("MoviesManagememtSystem.Models.Maker", b =>
                {
                    b.HasOne("MoviesManagememtSystem.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesManagememtSystem.Models.MovieArtist", b =>
                {
                    b.HasOne("MoviesManagememtSystem.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}
