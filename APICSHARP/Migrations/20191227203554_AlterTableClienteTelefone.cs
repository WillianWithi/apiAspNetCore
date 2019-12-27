using Microsoft.EntityFrameworkCore.Migrations;

namespace APICSHARP.Migrations
{
    public partial class AlterTableClienteTelefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_cliente",
                table: "cliente_telefone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cliente_telefone_id_cliente",
                table: "cliente_telefone",
                column: "id_cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_cliente_telefone_cliente_id_cliente",
                table: "cliente_telefone",
                column: "id_cliente",
                principalTable: "cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cliente_telefone_cliente_id_cliente",
                table: "cliente_telefone");

            migrationBuilder.DropIndex(
                name: "IX_cliente_telefone_id_cliente",
                table: "cliente_telefone");

            migrationBuilder.DropColumn(
                name: "id_cliente",
                table: "cliente_telefone");
        }
    }
}
