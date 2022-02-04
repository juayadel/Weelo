using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Weelo.App.Api.Ef.Dal;
using Weelo.App.Api.EF.DataModel;
using Weelo.App.Api.Entities.Property;

namespace Weelo.App.Api.LogicLayer
{
    public class PropertyBLL : BaseBLL<PropertyBLL>
    {
        FactoryDal factory = new FactoryDal();
        public int Insert(PropertyENT entity, IEnumerable<IFormFile> photos)
        {
            var contex = factory.CreateDbContext();
            var objProperty = new Property()
            {
                Address = entity.Address,
                Name = entity.Name,
                Price = entity.Price,
                Year = entity.Year,
                CodeInternal = entity.CodeInternal
            };

            if (photos.Count() > 0)
                objProperty.Images = GetImages(photos);

            contex.Properties.Add(objProperty);
            return contex.SaveChangesAsync().Result; ;
        }
        public int Update(PropertyENT entity, IEnumerable<IFormFile> photos)
        {
            var contex = factory.CreateDbContext();
            var owner = contex.Properties.Find(entity.PropertyId);
            owner.Name = entity.Name;
            owner.Price = entity.Price;
            owner.Address = entity.Address;
            owner.CodeInternal = entity.CodeInternal;
            owner.Year = entity.Year;

            if (photos.Count() > 0)
                owner.Images = GetImages(photos);

            return contex.SaveChangesAsync().Result; ;
        }
        public List<dynamic> FindPropertiesByYear(int Year)
        {
            var context = factory.CreateDbContext();

            var data = (from p in context.Properties
                        join i in context.PropertiesImages
                        on p.PropertyId equals i.PropertyImageId             
                        where p.Year.Equals(Year)
                         select new
                         {
                             Address = p.Address,
                             CodeInternal = p.CodeInternal,
                             Name = p.Name,
                             Price = p.Price,
                             Year = p.Year,
                             Images = i,
                         }).ToList<dynamic>();

            return data;
        }

        public List<dynamic> FindPropertiesByPrice(double initValue, double endValue)
        {
            var context = factory.CreateDbContext();

            var data = (from p in context.Properties
                        join i in context.PropertiesImages
                        on p.PropertyId equals i.PropertyImageId
                        where p.Price >= initValue && p.Price <= endValue
                        select new
                        {
                            Address = p.Address,
                            CodeInternal = p.CodeInternal,
                            Name = p.Name,
                            Price = p.Price,
                            Year = p.Year,
                            Images = i,
                        }).ToList<dynamic>();

            return data;
        }

        public List<dynamic> FindPropertiesBetweenYear(int YearInit, int YearEnd)
        {
            var context = factory.CreateDbContext();

            var data = (from p in context.Properties
                        join i in context.PropertiesImages
                        on p.PropertyId equals i.PropertyImageId
                        where p.Year >= YearInit && p.Year <= YearEnd
                        select new
                        {
                            Address = p.Address,
                            CodeInternal = p.CodeInternal,
                            Name = p.Name,
                            Price = p.Price,
                            Year = p.Year,
                            Images = i,
                        }).ToList<dynamic>();

            return data;
        }
        private List<PropertyImage> GetImages(IEnumerable<IFormFile> photos)
        {
            List<PropertyImage> response = new List<PropertyImage>();
            photos.ToList().ForEach(l =>
            {

                using (var ms = new MemoryStream())
                {
                    l?.CopyTo(ms);
                    response.Add(new PropertyImage()
                    {
                        Enabled = true,
                        File = ms.ToArray(),
                        ImageName = l.FileName,
                    });
                }

            });
            return response;
        }
    }
}
