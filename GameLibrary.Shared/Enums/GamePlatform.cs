using System.Text.Json.Serialization;

namespace GameLibrary.Shared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GamePlatform
    {
        MacOS,
        Linux,
        Windows,
        iOS,
        Android,
    }
}