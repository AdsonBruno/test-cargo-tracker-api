﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_cargo_tracker_api.Migrations
{
    /// <inheritdoc />
    public partial class AddCnpjAndCustomerCreationDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTimestamp",
                table: "Customer",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "cnpj",
                table: "Customer",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTimestamp",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "cnpj",
                table: "Customer");
        }
    }
}
