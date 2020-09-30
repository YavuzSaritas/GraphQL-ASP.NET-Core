﻿// <auto-generated />
using System;
using GraphQL_DotNetCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphQL_DotNetCore.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GraphQL_DotNetCore.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ee60418d-b6c4-4ea4-94a1-7d58030e61e9"),
                            Description = "Cash Account for our users",
                            OwnerId = new Guid("69c019b7-96cf-41ca-8ec3-0ceb944b724d"),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("bef49c07-b9fc-4347-ba48-80a0f392ac0d"),
                            Description = "Saving Account for our users",
                            OwnerId = new Guid("6ffc429b-af1c-4aba-bc59-c884fd864e8f"),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("c5969954-a0d8-4832-a098-e91f0bd8cf36"),
                            Description = "Cash Account for our users",
                            OwnerId = new Guid("6ffc429b-af1c-4aba-bc59-c884fd864e8f"),
                            Type = 3
                        });
                });

            modelBuilder.Entity("GraphQL_DotNetCore.Entities.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = new Guid("69c019b7-96cf-41ca-8ec3-0ceb944b724d"),
                            Address = "John Doe's Adress",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = new Guid("6ffc429b-af1c-4aba-bc59-c884fd864e8f"),
                            Address = "Jane Doe's Adress",
                            Name = "Jane Done"
                        });
                });

            modelBuilder.Entity("GraphQL_DotNetCore.Entities.Account", b =>
                {
                    b.HasOne("GraphQL_DotNetCore.Entities.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
