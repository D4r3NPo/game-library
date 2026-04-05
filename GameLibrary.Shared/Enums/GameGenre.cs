using System.Text.Json.Serialization;

namespace GameLibrary.Shared.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GameGenre
{
    RPG,
    Factory,
    Sandbox,
    OpenWorld,
    Dungeon,
    Multiplayer,
    FPS
}