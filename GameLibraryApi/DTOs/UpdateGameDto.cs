using System.ComponentModel.DataAnnotations;
using GameLibraryApi.Models;

namespace GameLibraryApi.DTOs;

public class UpdateGameDto
{
    [Length(1,30)]
    public string Title { get; set; } = "";
    public Platform[] Platforms { get; set; } = [];
    public Genre[] Genres { get; set; } = [];
    public Status Status { get; set; }
    [Range(0,10)]
    public int? Rating { get; set; }
}