using System.Text.Json.Serialization;

namespace GameLibrary.Shared.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GameStatus
{
    ToDo,
    InProgress,
    Done
}