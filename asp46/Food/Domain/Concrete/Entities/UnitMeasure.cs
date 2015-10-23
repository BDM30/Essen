/*
Класс сущности используется для биекции с одноименной таблицей в базе данных ( с помощью Entity Framework)
Отношения всех сущностей смотрите в файле relations.png
*/
namespace Domain.Entities
{
  public class UnitMeasure
  {
    public int UnitMeasureID { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
  }
}
