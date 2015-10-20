﻿/*
 * Применяем Repository Pattern
 * 
 * В двух словах, паттерн Repository инкапсулирует объекты, представленыые в хранилище данных и операции,
 * производимые над ними, предоставляя более объектно-ориентированное представление реальных данных. 
 * Repository также преследует цель достижения полного разделения и односторонней зависимости между уровнями
 * области определения и распределения данных. Класс изпользующий ICommonRepository <User> может получать User без знаний, как он реализован
 * и где хранится.
 */

/*
 * ICommonRepository - реализует CRUD архутектуру. С ним будет общаться ,например, наш Контроллер. 
 * Этот интерфейс благодаря Ninject - то, как видят все остальные наши классы работу с БД. ИКАПСУЛЯЦИЯ РУЛИТ. 
 * общий интерфейс для репозитоев User, Product, ...
 */

using System.Collections.Generic;

namespace Essen.Domain.Abstract
{
  public interface ICommonRepository<T>
  {
    IEnumerable<T> Data { get; }
    void SaveData(T data);
    T DeleteData(int userProductId);
  }
}
