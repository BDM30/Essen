/*
 * Класс для связи Entity Framework с баззой данных
 * его поля - таблицы в БД
 */

using System.Data.Entity;
using Essen.Domain.Entities;

namespace Essen.Domain.Concrete
{
  public class DataContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<UserProduct> UserProducts { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<UnitMeasure> UnitsMeasure { get; set; }
  }
}
