using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GamesController: ControllerBase
{
    readonly Dictionary<string, Game> games = new Dictionary<string, Game>
    {
        {"doom", new Game("doom","Doom","MacOS")},
        {"factorio", new Game("factorio","Factorio","Linux")},
        {"wakfu", new Game("wakfu","Wakfu","Windows")},
    };

    [HttpGet]
    public IActionResult Get() => Ok(games.Values);

    [HttpGet("{id}")]
    public IActionResult GetById(string id) => games.TryGetValue(id, out var game) ? Ok(game) : NotFound();

    public record Game(string Id, string Title, string Platform);
}