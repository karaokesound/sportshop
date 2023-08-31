﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sportshop.Persistence.Context;

#nullable disable

namespace Sportshop.Persistence.Migrations
{
    [DbContext(typeof(SportshopDbContext))]
    [Migration("20230831095649_userentity")]
    partial class userentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Sportshop.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("61e43f2f-5b6f-43a4-a398-5eac427fd0fb"),
                            Age = 0,
                            City = "City1",
                            FirstName = "Jan",
                            LastName = "Nowak",
                            RefreshToken = "",
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "User1"
                        },
                        new
                        {
                            Id = new Guid("660ff93b-2f8e-4dbe-bed7-5436cbe33978"),
                            Age = 0,
                            City = "City2",
                            FirstName = "Andrzej",
                            LastName = "Kowalski",
                            RefreshToken = "",
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "User2"
                        },
                        new
                        {
                            Id = new Guid("e56c1994-ed3f-4f2c-bd32-474a6673c2a0"),
                            Age = 0,
                            City = "City3",
                            FirstName = "Piotr",
                            LastName = "Kowalczyk",
                            RefreshToken = "",
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "User3"
                        },
                        new
                        {
                            Id = new Guid("cf0ba25f-583f-4fa0-bb10-bb39da96cc5c"),
                            Age = 0,
                            City = "City4",
                            FirstName = "Kamil",
                            LastName = "Grabak",
                            RefreshToken = "",
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "User4"
                        },
                        new
                        {
                            Id = new Guid("35618e63-775e-4e72-868d-5061bf04911c"),
                            Age = 0,
                            City = "City5",
                            FirstName = "Leon",
                            LastName = "Ziutkiewicz",
                            RefreshToken = "",
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "User5"
                        },
                        new
                        {
                            Id = new Guid("9f285aad-92bc-45e8-b6fa-b6cde5dbc551"),
                            Age = 0,
                            City = "City6",
                            FirstName = "",
                            LastName = "",
                            RefreshToken = "",
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "User6"
                        },
                        new
                        {
                            Id = new Guid("d255ba35-a9b2-4322-93cd-0a4882be08a9"),
                            Age = 0,
                            City = "City7",
                            FirstName = "",
                            LastName = "",
                            RefreshToken = "",
                            TokenCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "User7"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}