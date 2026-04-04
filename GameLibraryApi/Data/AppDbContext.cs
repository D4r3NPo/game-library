using GameLibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameLibraryApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
}