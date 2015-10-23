/*
 * Класс для связи Entity Framework с баззой данных
 * его поля - таблицы в БД
 */

using System.Data.Entity;
using Domain.Entities;

namespace Domain.Concrete
{
  public class FoodContext : DbContext
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