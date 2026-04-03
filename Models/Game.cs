public record Game(string Id, string Title, Platform[] Platforms, Genre[] Genres, Status Status, int? Rating);

public enum Platform
{
    MacOS,
    Linux,
    Windows,
    iOS,
    Android,
}

public enum Status
{
    ToDo,
    InProgress,
    Done
}

public enum Genre {
    RPG,
    Factory,
    Sandbox,
    OpenWorld,
    Dungeon,
    Multiplayer,
    FPS
}