
/*
Класс сущности используется для биекции с одноименной таблицей в базе данных ( с помощью Entity Framework)
Отношения всех сущностей смотрите в файле relations.png
*/
namespace Domain.Entities
{
  public class UserProduct
  {
    public int UserProductID { get; set; }
    public int UserID { get; set; }
    public int ProductID { get; set; }
    public int CategoryID { get; set; }
    public int Amount { get; set; }
    public string ExpirationDate { get; set; }
  }
}
