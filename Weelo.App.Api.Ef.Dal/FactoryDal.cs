using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;
using Weelo.App.Api.EF.DataModel.Context;
using Microsoft.Extensions.Logging;
using Weelo.App.Api.Config;
using Weelo.App.Api.Config.Enums;

namespace Weelo.App.Api.Ef.Dal
{
    public class FactoryDal : IDesignTimeDbContextFactory<WeeloContext>
    {

        public WeeloContext CreateDbContext(string[] args = null)
        {
         
            var optionsBuilder = new DbContextOptionsBuilder<WeeloContext>(); 
            optionsBuilder
            .UseSqlServer(AppConfiguration.Instance.Read(DataBase.Weelo.ToString(), StringKey.ConnectionStrings.ToString()));

            return new WeeloContext(optionsBuilder.Options);
        }
    }
}
