﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlunosApi.Migrations
{
    /// <inheritdoc />
    public partial class Correção : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Alunos",
                newName: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Alunos",
                newName: "Name");
        }
    }
}
