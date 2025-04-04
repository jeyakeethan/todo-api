﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace todo_api.Migrations
{
    [DbContext(typeof(TodoDbContext))]
    partial class TodoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Finish the coding assignment for the C# class by Friday.",
                            Title = "Complete C# Project"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Pick up ingredients for dinner and snacks for the week.",
                            Title = "Buy Groceries"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Go for a 5km run around the neighborhood.",
                            Title = "Morning Workout"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Read the remaining chapters of 'The Silent Patient'.",
                            Title = "Finish Reading Book"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Research destinations for a weekend getaway, check flight options.",
                            Title = "Plan Weekend Trip"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Tidy up the desk and file paperwork. Sort through old documents.",
                            Title = "Organize Office"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Discuss project updates, deadlines, and current challenges.",
                            Title = "Meeting with Team"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Relax and watch a new movie, preferably a thriller or mystery.",
                            Title = "Watch a Movie"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
