﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArduinoWeb.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dispositivos",
                columns: table => new
                {
                    DispositivoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivos", x => x.DispositivoId);
                });

            migrationBuilder.CreateTable(
                name: "Estacionamentos",
                columns: table => new
                {
                    EstacionamentoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamentos", x => x.EstacionamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    LocalizacaoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.LocalizacaoId);
                });

            migrationBuilder.CreateTable(
                name: "RelatorioDispositivos",
                columns: table => new
                {
                    RelatorioDispositivoId = table.Column<int>(type: "int", nullable: false),
                    DispositivoId = table.Column<int>(type: "int", nullable: false),
                    LocalizacaoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimoIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatorioDispositivos", x => x.RelatorioDispositivoId);
                    table.ForeignKey(
                        name: "FK_RelatorioDispositivos_Dispositivos_DispositivoId",
                        column: x => x.DispositivoId,
                        principalTable: "Dispositivos",
                        principalColumn: "DispositivoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelatorioDispositivos_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "LocalizacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicoes",
                columns: table => new
                {
                    MedicaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatorioDispositivoId = table.Column<int>(type: "int", nullable: false),
                    EstacionamentoId = table.Column<int>(type: "int", nullable: false),
                    LocalizacaoId = table.Column<int>(type: "int", nullable: false),
                    ValorLido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataMedicao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicoes", x => x.MedicaoId);
                    table.ForeignKey(
                        name: "FK_Medicoes_Estacionamentos_EstacionamentoId",
                        column: x => x.EstacionamentoId,
                        principalTable: "Estacionamentos",
                        principalColumn: "EstacionamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicoes_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "LocalizacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicoes_RelatorioDispositivos_RelatorioDispositivoId",
                        column: x => x.RelatorioDispositivoId,
                        principalTable: "RelatorioDispositivos",
                        principalColumn: "RelatorioDispositivoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicoes_EstacionamentoId",
                table: "Medicoes",
                column: "EstacionamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicoes_LocalizacaoId",
                table: "Medicoes",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicoes_RelatorioDispositivoId",
                table: "Medicoes",
                column: "RelatorioDispositivoId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatorioDispositivos_DispositivoId",
                table: "RelatorioDispositivos",
                column: "DispositivoId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatorioDispositivos_LocalizacaoId",
                table: "RelatorioDispositivos",
                column: "LocalizacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicoes");

            migrationBuilder.DropTable(
                name: "Estacionamentos");

            migrationBuilder.DropTable(
                name: "RelatorioDispositivos");

            migrationBuilder.DropTable(
                name: "Dispositivos");

            migrationBuilder.DropTable(
                name: "Localizacoes");
        }
    }
}
