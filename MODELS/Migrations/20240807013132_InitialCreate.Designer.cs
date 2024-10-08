﻿// <auto-generated />
using MODELS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MODELS.Migrations
{
    [DbContext(typeof(ModelsContext))]
    [Migration("20240807013132_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MODELS.Models.CV", b =>
                {
                    b.Property<string>("userId")
                        .HasColumnType("text");

                    b.Property<string>("PracticalExperience")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("education")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("phon")
                        .HasColumnType("integer");

                    b.Property<string>("profile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("skills")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("userId");

                    b.ToTable("cv");
                });

            modelBuilder.Entity("MODELS.Models.CVJobs", b =>
                {
                    b.Property<long>("cvJobsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("cvJobsId"));

                    b.Property<long>("jobId")
                        .HasColumnType("bigint");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("cvJobsId");

                    b.ToTable("cvJobs");
                });

            modelBuilder.Entity("MODELS.Models.Job", b =>
                {
                    b.Property<long>("jobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("jobId"));

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("experience")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("requirements")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("jobId");

                    b.ToTable("jobs");
                });

            modelBuilder.Entity("MODELS.Models.Users", b =>
                {
                    b.Property<string>("userId")
                        .HasColumnType("text");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("isAdmin")
                        .HasColumnType("integer");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("userId");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
