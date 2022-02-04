using NUnit.Framework;
using Weelo.App.Api.Ef.Dal;
using Weelo.App.Api.EF.DataModel;
using System.Linq;

namespace Weelo.App.Api.EF.Test
{
    public class CreateDataBaseTest
    {
        FactoryDal factory = new FactoryDal();
        [Test]
        public void CreateDb()
        {
            var resourceName = Properties.Resources.ResourceManager.GetObject("homer");            
            using var dbContext = factory.CreateDbContext();
            if (GetHomer() is null)
            {
                dbContext.Owner.Add(new Owner() { Name = "Homero Simpson", Address = "Av Siempre Viva 723", PhotoName = "homer.jpg", Photo = (byte[])resourceName, Birthday = System.DateTime.Now });

                Assert.IsTrue(dbContext.SaveChangesAsync().Result > 0, "No se pudo crear un registro en la tabla Owner");
            }
        }

        [Test]
        public void GetHomerDb()
        {            
            using var context = factory.CreateDbContext();
            var owner = GetHomer();

            Assert.IsTrue(owner.Name.Equals("Homero Simpson"), "No existen registros o homero no ha sido creado");
        }

        private Owner GetHomer()
        {
            using var context = factory.CreateDbContext();
            var owner = (from o in context.Owner
                         where o.Name.Equals("Homero Simpson")
                         select o).ToList<Owner>();
            return owner.FirstOrDefault();
        }
    }
}
