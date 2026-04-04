using System.Net;
using System.Net.Http.Json;
using GameLibraryApi.Models;

namespace GameLibraryApi.Tests;

public class GamesApiTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Get_Games_Returns_Ok()
    {
        var response = await _client.GetAsync("/api/games");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Post_Then_GetById_Works()
    {
        var game = new Game
        {
            Id = "celeste",
            Title = "Celeste",
            Platforms = [],
            Genres = [],
            Status = Status.ToDo,
            Rating = 10
        };

        var postResponse = await _client.PostAsJsonAsync("/api/games", game);
        Assert.Equal(HttpStatusCode.Created, postResponse.StatusCode);

        var getResponse = await _client.GetAsync("/api/games/celeste");
        Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

        var createdGame = await getResponse.Content.ReadFromJsonAsync<Game>();

        Assert.NotNull(createdGame);
        Assert.Equal("Celeste", createdGame.Title);
    }

    [Fact]
    public async Task Get_Unknown_Game_Returns_NotFound()
    {
        var response = await _client.GetAsync("/api/games/unknown");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Update_Then_Get_Works()
    {
        var updatedGame = new Game
        {
            Id = "celeste",
            Title = "Celeste",
            Platforms = [],
            Genres = [],
            Status = Status.ToDo,
            Rating = 2
        };

        var updateGameResponse = await _client.PutAsJsonAsync("/api/games/celeste", updatedGame);
        Assert.Equal(HttpStatusCode.OK, updateGameResponse.StatusCode);

        var getUpdatedGameResponse = await _client.GetAsync("/api/games/celeste");
        Assert.Equal(HttpStatusCode.OK, getUpdatedGameResponse.StatusCode);

        var retrievedUpdatedGame = await getUpdatedGameResponse.Content.ReadFromJsonAsync<Game>();

        Assert.NotNull(retrievedUpdatedGame);
        Assert.Equal(2, retrievedUpdatedGame.Rating);
    }

    [Fact]
    public async Task Create_With_Invalid_Title_Returns_BadRequest()
    {
        var game = new Game
        {
            Id = "",
            Title = "",
            Platforms = [],
            Genres = [],
            Status = Status.ToDo,
            Rating = 5
        };

        var response = await _client.PostAsJsonAsync("/api/games", game);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Create_With_Invalid_Rating_Returns_BadRequest()
    {
        var game = new Game
        {
            Id = "game-name",
            Title = "Invalid Game",
            Platforms = [],
            Genres = [],
            Status = Status.ToDo,
            Rating = 15
        };

        var response = await _client.PostAsJsonAsync("/api/games", game);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Get_With_Filters_Works()
    {
        var game1 = new Game
        {
            Id = "game1",
            Title = "Game 1",
            Platforms = [Platform.Windows],
            Genres = [Genre.RPG],
            Status = Status.ToDo,
            Rating = 5
        };

        var game2 = new Game
        {
            Id = "game2",
            Title = "Game 2",
            Platforms = [Platform.Linux, Platform.Windows],
            Genres = [Genre.FPS],
            Status = Status.InProgress,
            Rating = 7
        };

        await _client.PostAsJsonAsync("/api/games", game1);
        await _client.PostAsJsonAsync("/api/games", game2);

        var response = await _client.GetAsync("/api/games?status=ToDo&platform=Windows");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var games = await response.Content.ReadFromJsonAsync<List<Game>>();
        Assert.NotNull(games);
        Assert.Single(games);
        Assert.Equal(game1.Title, games[0].Title);

        response = await _client.GetAsync("/api/games?platform=Windows");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        games = await response.Content.ReadFromJsonAsync<List<Game>>();
        Assert.NotNull(games);
        Assert.Equal(2, games.Count);
    }

}