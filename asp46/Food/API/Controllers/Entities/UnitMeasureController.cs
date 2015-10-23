using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Domain.Abstract;
using Domain.Entities;

/*
Котроллер сущности позволяет совершать CRUD операции и в будущем и другие
*/

namespace API.Controllers.Entities
{
  public class UnitMeasureController : ApiController
  {
    private ICommonRepository<UnitMeasure> unitMeasureRepository;

    public UnitMeasureController(ICommonRepository<UnitMeasure> unitsMeasure)
    {
      unitMeasureRepository = unitsMeasure;
    }

    [Route("UnitMeasure/all")]
    [HttpGet]
    public IEnumerable<UnitMeasure> GetUnitsMeasure()
    {
      return unitMeasureRepository.Data;
    }

    [HttpGet]
    [Route("UnitMeasure/getby")]
    public IEnumerable<UnitMeasure> GetUnitMeasureBy([FromUri] UnitMeasure u)
    {
      return (from x in unitMeasureRepository.Data
              where (x.Name == u.Name && x.Name != null || x.ShortName == u.ShortName && x.ShortName != null ||
              x.UnitMeasureID == u.UnitMeasureID && x.UnitMeasureID != 0)
              select x);
    }

    // если id валидный - то редактирование, иначе создастся новый
    [HttpGet]
    [Route("UnitMeasure/save")]
    public string SaveUnitMeasure([FromUri] UnitMeasure um)
    {
      unitMeasureRepository.SaveData(um);
      return "ok";
    }

    [HttpGet]
    [Route("UnitMeasure/remove")]
    public string RemoveUnitMeasure(int id)
    {
      unitMeasureRepository.DeleteData(id);
      return "ok";
    }
  }
}
