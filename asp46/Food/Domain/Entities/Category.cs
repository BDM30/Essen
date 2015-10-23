/*
Класс сущности используется для биекции с одноименной таблицей в базе данных ( с помощью Entity Framework)
Отношения всех сущностей смотрите в файле relations.png
*/

namespace Domain.Entities
{
  public class Category
  { 
    public int CategoryID { get; set; }
    public string Name { get; set; }
  }
}
