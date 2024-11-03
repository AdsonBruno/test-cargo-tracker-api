﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using test_cargo_tracker_api.src.Data;

#nullable disable

namespace test_cargo_tracker_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241030023507_movements-and-relationship-with-container")]
    partial class movementsandrelationshipwithcontainer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("test_cargo_tracker_api.src.Models.Container.ContainerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ContainerCategory")
                        .HasColumnType("integer");

                    b.Property<string>("ContainerNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ContainerStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfLastUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TypeContainer")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Container");
                });

            modelBuilder.Entity("test_cargo_tracker_api.src.Models.CustomerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("cnpj")
                        .HasColumnType("text");

                    b.Property<string>("cpf")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("test_cargo_tracker_api.src.Models.Movements.MovementModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContainerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("EndDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("test_cargo_tracker_api.src.Models.Movements.MovementModel", b =>
                {
                    b.HasOne("test_cargo_tracker_api.src.Models.Container.ContainerModel", "Container")
                        .WithMany("Movements")
                        .HasForeignKey("ContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Container");
                });

            modelBuilder.Entity("test_cargo_tracker_api.src.Models.Container.ContainerModel", b =>
                {
                    b.Navigation("Movements");
                });
#pragma warning restore 612, 618
        }
    }
}
