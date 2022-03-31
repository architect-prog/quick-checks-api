﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuickChecks.Persistence;

#nullable disable

namespace QuickChecks.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDatabaseContext))]
    [Migration("20220328210127_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QuickChecks.Kernel.Entities.PollTemplateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Title")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("title");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("pk_poll_templates");

                    b.ToTable("poll_templates", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
