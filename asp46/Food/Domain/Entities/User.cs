/*
Класс сущности используется для биекции с одноименной таблицей в базе данных ( с помощью Entity Framework)
Отношения всех сущностей смотрите в файле relations.png
*/

namespace Domain.Entities
{
  public class User
  {
    public int UserID { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
  }
}
