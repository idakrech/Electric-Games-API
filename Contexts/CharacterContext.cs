#nullable disable

using Microsoft.EntityFrameworkCore;

namespace ElectricGamesApi.Contexts;

public class CharacterContext : DbContext
{
    public CharacterContext(DbContextOptions<CharacterContext> options) : base(options){}
    public DbSet<ElectricGamesApi.Models.Character> Character {get; set;}
}