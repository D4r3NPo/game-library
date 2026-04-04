using GameLibraryApi.Data;
using GameLibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController(AppDbContext db) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Game game)
    {
        db.Games.Add(game);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var games = await db.Games.ToListAsync();
        return Ok(games);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var game = await db.Games.FindAsync(id);
        return game is null ? NotFound() : Ok(game);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Game updatedGame)
    {
        if (updatedGame.Id != id) return BadRequest("'id' in URL do not match 'id' in provided data");

        Game? existingGame = await db.Games.FindAsync(id);
        if (existingGame is null) return NotFound();

        existingGame.Title = updatedGame.Title;
        existingGame.Platforms = updatedGame.Platforms;
        existingGame.Genres = updatedGame.Genres;
        existingGame.Status = updatedGame.Status;
        existingGame.Rating =  updatedGame.Rating;

        await db.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var game = await db.Games.FindAsync(id);
        if (game is null) return NotFound();

        db.Games.Remove(game);
        
        await db.SaveChangesAsync();

        return NoContent();
    }
}