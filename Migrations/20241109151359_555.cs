﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ganbare.Migrations
{
    /// <inheritdoc />
    public partial class _555 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Results");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Speed",
                table: "Results",
                type: "interval",
                nullable: true);
        }
    }
}
