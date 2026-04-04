using System.Text.Json.Serialization;

namespace GameLibraryApi.Models;

public class Game
{
	public string Id { get; set; } = "";
	public string Title { get; set; } = "";
	public Platform[] Platforms { get; set; } = [];
	public Genre[] Genres { get; set; } = [];
	public Status Status { get; set; } = Status.ToDo;
	public int? Rating { get; set; } = null;

	public override bool Equals(object? obj)
	{
		return obj is Game game &&
			Id == game.Id &&
			Title == game.Title &&
			Platforms.SequenceEqual(game.Platforms) &&
			Genres.SequenceEqual(game.Genres) &&
			Status == game.Status &&
			Rating == game.Rating;
	}

	public override int GetHashCode() => HashCode.Combine(Id, Title, Platforms, Genres, Status, Rating);
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Platform
{
	MacOS,
	Linux,
	Windows,
	iOS,
	Android,
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
	ToDo,
	InProgress,
	Done
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Genre
{
	RPG,
	Factory,
	Sandbox,
	OpenWorld,
	Dungeon,
	Multiplayer,
	FPS
}
