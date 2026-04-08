using GameLibrary.Shared.DTOs;

namespace GameLibraryFrontend.Services;

public class GameClient(HttpClient http)
{
    private readonly HttpClient _http = http;

    public async Task<GameResponse?> CreateGameAsync(CreateGameRequest dto)
    {
        var response = await _http.PostAsJsonAsync("api/games", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<GameResponse>();
    }

    public async Task<List<GameResponse>?> GetGamesAsync()
    {
        return await _http.GetFromJsonAsync<List<GameResponse>>("api/games");
    }

    public async Task<GameResponse?> UpdateAsync(string id, UpdateGameRequest dto)
    {
        var response = await _http.PutAsJsonAsync($"api/games/{id}", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<GameResponse>();
    }    

    public async Task DeleteAsync(string id)
    {
        var response = await _http.DeleteAsync($"api/games/{id}");
        response.EnsureSuccessStatusCode();
    }
}