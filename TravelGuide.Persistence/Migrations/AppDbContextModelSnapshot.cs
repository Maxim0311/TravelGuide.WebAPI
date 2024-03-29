﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelGuide.Persistence.EFCore;

#nullable disable

namespace TravelGuide.Persistence.EFCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TravelGuide.Domain.Entities.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("latitude");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("longitude");

                    b.Property<int>("RouteId")
                        .HasColumnType("int")
                        .HasColumnName("route_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("point");

                    b.HasIndex("RouteId");

                    b.ToTable("Points");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Latitude = 55.55m,
                            Longitude = 44.44m,
                            RouteId = 1,
                            Title = "point1"
                        },
                        new
                        {
                            Id = 2,
                            Latitude = 54.65m,
                            Longitude = 24.44m,
                            RouteId = 1,
                            Title = "point2"
                        },
                        new
                        {
                            Id = 3,
                            Latitude = 52.75m,
                            Longitude = 14.44m,
                            RouteId = 1,
                            Title = "point3"
                        });
                });

            modelBuilder.Entity("TravelGuide.Domain.Entities.TouristRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<float>("Rating")
                        .HasColumnType("real")
                        .HasColumnName("rating");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("route");

                    b.HasIndex("UserId");

                    b.ToTable("Routes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "Россия",
                            CreatedDate = new DateTime(2022, 2, 21, 14, 46, 33, 71, DateTimeKind.Local).AddTicks(6662),
                            Rating = 4.2f,
                            Title = "testRoute",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TravelGuide.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("firstname");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("lastname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("user");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Firstname",
                            LastName = "Lastname",
                            Password = "password",
                            Username = "User"
                        });
                });

            modelBuilder.Entity("TravelGuide.Domain.Entities.Point", b =>
                {
                    b.HasOne("TravelGuide.Domain.Entities.TouristRoute", "Route")
                        .WithMany("Points")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("TravelGuide.Domain.Entities.TouristRoute", b =>
                {
                    b.HasOne("TravelGuide.Domain.Entities.User", "User")
                        .WithMany("Routes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelGuide.Domain.Entities.TouristRoute", b =>
                {
                    b.Navigation("Points");
                });

            modelBuilder.Entity("TravelGuide.Domain.Entities.User", b =>
                {
                    b.Navigation("Routes");
                });
#pragma warning restore 612, 618
        }
    }
}
