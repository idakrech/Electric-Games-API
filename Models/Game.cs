using System.ComponentModel.DataAnnotations;
using ElectricGamesApi.Interfaces;
namespace ElectricGamesApi.Models;

public class Game : IGame
{
    [Key]
    public int Id {get; set;}
    public string Title {get; set;} = "Not set";
    public string Platform {get; set;} = "Not set";
    public int ReleaseYear {get; set;} = 0;
    // public IFormFile? Image {get; set;} 
    public string Image {get; set;} = "Not set";
}