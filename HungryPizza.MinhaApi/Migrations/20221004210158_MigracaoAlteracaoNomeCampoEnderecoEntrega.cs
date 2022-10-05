using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryPizza.MinhaApi.Migrations
{
    public partial class MigracaoAlteracaoNomeCampoEnderecoEntrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Pedidos");

            migrationBuilder.AddColumn<string>(
                name: "EnderecoEntrega",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnderecoEntrega",
                table: "Pedidos");

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
