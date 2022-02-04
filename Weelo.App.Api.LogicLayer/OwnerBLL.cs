using Weelo.App.Api.Ef.Dal;
using Weelo.App.Api.Entities.Owner;
using Weelo.App.Api.EF.DataModel;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Weelo.App.Api.LogicLayer
{
    public class OwnerBLL : BaseBLL<OwnerBLL>
    {
        FactoryDal factory = new FactoryDal();
        public int Insert(OwnerENT entity, IFormFile photo)
        {
            var contex = factory.CreateDbContext();
            contex.Owner.Add(
                new Owner()
                {
                    Address = entity.Address,
                    Birthday = entity.Birthday,
                    Photo = GetImage(photo),
                    PhotoName = photo is null ? null : photo.FileName,
                    Name = entity.Name,
                    OwnerId = entity.OwnerId,
                    PropertyId = entity.PropertyId
                });
            return contex.SaveChangesAsync().Result;
        }
        public int Update(OwnerENT entity, IFormFile photo)
        {
            var contex = factory.CreateDbContext();
            var owner = contex.Owner.Find(entity.OwnerId);
            owner.Name = entity.Name;
            owner.Photo = GetImage(photo);
            owner.PropertyId = entity.PropertyId;
            owner.PhotoName = photo.FileName;
            owner.Address = entity.Address;
            owner.Birthday = entity.Birthday;

            return contex.SaveChangesAsync().Result;
        }

        private byte[] GetImage(IFormFile photo)
        {
            if (photo is not null)
            {
                using (var ms = new MemoryStream())
                {
                    photo?.CopyTo(ms);
                    return ms.ToArray();
                }
            }
            return null;
        }
    }
}
