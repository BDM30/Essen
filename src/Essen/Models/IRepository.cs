using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Essen.Models.Entities;

namespace Essen.Models
{
  public interface IRepository<T>
  {
    IEnumerable<T> Data { get; }
    void SaveData(T data);
    void DeleteData(int userProductId);
  }
}
