#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectricGamesApi.Models;
using ElectricGamesApi.Contexts;

namespace ElectricGamesApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CharacterController : ControllerBase
{
    private readonly CharacterContext _context;

    public CharacterController(CharacterContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetAllCharacters()
    {
        try
        {
            List<Character> characters = await _context.Character.ToListAsync();
            return Ok(characters);
        }
        catch
        {
            return StatusCode(500);
        }

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetCharacterById(int id)
    {
        try
        {
            Character character = await _context.Character.FindAsync(id);

            if(character != null)
            {
                return Ok(character);
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
    [Route("[action]/{name}")]
    public async Task<ActionResult<List<Character>>> GetCharacterByName (string name)
    {
        List<Character> characters = await _context.Character.Where(character => character.Name == name).ToListAsync();

        if (characters != null)
        {
            return Ok(characters[0]);
        }
        else 
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<Character>> Post (Character newCharacter)
    {
        try
        {
            _context.Character.Add(newCharacter);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new {id = newCharacter.Id}, newCharacter);
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Character character = await _context.Character.FindAsync(id);

            if(character != null){
                _context.Character.Remove(character);
                await _context.SaveChangesAsync();
                return NoContent();
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

    

    [HttpPut]
    public async Task<IActionResult> Put(Character editedCharacter)
    {
        try
        {
            _context.Entry(editedCharacter).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch
        {
            return StatusCode(500);
        }
    }
}