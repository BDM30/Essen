using System.Collections.Generic;
using Domain.Abstract;
using Domain.Entities;

/*
Класс реализует паттерн Репозиторий те упрощает и инкапсулирует работу с данными из класса FoodContext
*/

namespace Domain.Concrete
{
  public class UnitMeasureRepository : ICommonRepository<UnitMeasure>
  {
    private FoodContext context = new FoodContext();

    public IEnumerable<UnitMeasure> Data
    {
      get { return context.UnitsMeasure; }
    }

    public void SaveData(UnitMeasure data)
    {
      if (data.UnitMeasureID == 0)
      {
        context.UnitsMeasure.Add(data);
      }
      else
      {
        UnitMeasure dbEntry = context.UnitsMeasure.Find(data.UnitMeasureID);
        if (dbEntry != null)
        {
          dbEntry.Name = data.Name;
        }
      }
      context.SaveChanges();
    }

    public UnitMeasure DeleteData(int unitMeasureId)
    {
      UnitMeasure dbEntry = context.UnitsMeasure.Find(unitMeasureId);
      if (dbEntry != null)
      {
        context.UnitsMeasure.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }
  }
}
