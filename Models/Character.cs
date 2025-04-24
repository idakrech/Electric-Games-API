using System.ComponentModel.DataAnnotations;
using ElectricGamesApi.Interfaces;
namespace ElectricGamesApi.Models;

public class Character : ICharacter
{
    [Key]
    public int Id {get; set;}
    public string Name {get; set;} = "Not set";
    public string Game {get; set;} = "Not set";
    public string Image {get; set;} = "Not set";
}