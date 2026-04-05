using GameLibrary.Shared.DTOs;

namespace GameLibraryFrontend.Services;

public class GameClient(HttpClient http)
{
    private readonly HttpClient _http = http;

    public async Task<List<GameResponseDto>?> GetGamesAsync()
    {
        return await _http.GetFromJsonAsync<List<GameResponseDto>>("api/games");
    }
}