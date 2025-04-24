#nullable disable

using Microsoft.EntityFrameworkCore;

namespace ElectricGamesApi.Contexts;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions<GameContext> options) : base(options){}
    public DbSet<ElectricGamesApi.Models.Game> Game {get; set;}
}