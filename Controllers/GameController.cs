#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectricGamesApi.Contexts;
using ElectricGamesApi.Models;


namespace ElectricGamesApi.Controllers;

[ApiController]
[Route("[controller]")]

public class GameController : ControllerBase
{
    private readonly GameContext _context;

    public GameController(GameContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Game>>> GetAllGames() 
    {
        try{
        List<Game> games = await _context.Game.ToListAsync();
        return Ok(games);
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGameById(int id) 
    {
        try
        {
            Game game = await _context.Game.FindAsync(id);

            if (game != null)
            {
                return Ok(game);
            }
            else 
            {
                return NotFound();
            }
        }
        catch
        {
            return StatusCode(500);
        }
    }
   
    [HttpGet]
    [Route("[action]/{title}")]
    public async Task<ActionResult<List<Game>>> GetGameByTitle (string title)
    {
        try 
        {
            List<Game> games = await _context.Game.Where(game => game.Title == title).ToListAsync();
            // Game chosenGame = games.Find(game => game.Title == title);

            if (games != null)
            {
                return Ok(games[0]);
            }
            else 
            {
                return NotFound();
            }
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Game>> Post (Game newGame)
    {
        try 
        {
        _context.Game.Add(newGame);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Get", new {id = newGame.Id}, newGame);
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try {
            Game game = await _context.Game.FindAsync(id);

            if(game != null){
                _context.Game.Remove(game);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
            return NotFound();
            }
        }
        catch{
            return StatusCode(500);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(Game editedGame)
    {
        try {
            _context.Entry(editedGame).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch{
            return StatusCode(500);
        }
    }
}