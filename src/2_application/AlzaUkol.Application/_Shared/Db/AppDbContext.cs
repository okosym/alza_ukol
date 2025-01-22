using AlzaUkol.Application._Shared.Utils;
using AlzaUkol.Application.Orders.Models;
using Microsoft.EntityFrameworkCore;

namespace AlzaUkol.Application._Shared.Db;

public class AppDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string dbFolder = MyFileUtils.GetDbFolder();
        string dbFilePath = Path.Combine(dbFolder, "alza.db");
        string connectionString = $"Data Source={dbFilePath}";
        optionsBuilder.UseSqlite(connectionString);
    }
}
