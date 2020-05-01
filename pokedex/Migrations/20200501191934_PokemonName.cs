using Microsoft.EntityFrameworkCore.Migrations;

namespace pokedex.Migrations
{
    public partial class PokemonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pokemons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pokemons");
        }
    }
}
