using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace lojaComEntity.Migrations
{
    public partial class AddCampoPreco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Produto_Categoria_CategoriaId", table: "Produto");
            migrationBuilder.AddColumn<decimal>(
                name: "preco",
                table: "Produto",
                nullable: false,
                defaultValue: 0m);
            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_CategoriaId",
                table: "Produto",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Produto_Categoria_CategoriaId", table: "Produto");
            migrationBuilder.DropColumn(name: "preco", table: "Produto");
            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_CategoriaId",
                table: "Produto",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
