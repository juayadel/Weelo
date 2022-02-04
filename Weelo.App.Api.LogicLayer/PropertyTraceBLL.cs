using Weelo.App.Api.Ef.Dal;
using Weelo.App.Api.EF.DataModel;
using Weelo.App.Api.Entities.Trace;

namespace Weelo.App.Api.LogicLayer
{
    public class PropertyTraceBLL : BaseBLL<PropertyTraceBLL>
    {
        FactoryDal factory = new FactoryDal();
        public int Insert(PropertyTraceENT entity)
        {
            var contex = factory.CreateDbContext();
            contex.PropertiesTrace.Add(
                new PropertyTrace()
                {
                    DateSale = entity.DateSale,
                    Name = entity.Name,
                    Value = entity.Value,
                    PropertyTraceId = entity.PropertyTraceId,
                    Tax = entity.Tax,
                    PropertyId = entity.PropertyId
                });
            return contex.SaveChangesAsync().Result;
        }
        public int Update(PropertyTraceENT entity)
        {
            var contex = factory.CreateDbContext();
            var owner = contex.PropertiesTrace.Find(entity.PropertyTraceId);
            owner.Name = entity.Name;
            owner.Value = entity.Value;
            owner.Tax = entity.Tax;
            owner.DateSale = entity.DateSale;
            owner.PropertyId = entity.PropertyId;

            return contex.SaveChangesAsync().Result; ;
        }
    }
}
