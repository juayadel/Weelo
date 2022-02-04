using Microsoft.EntityFrameworkCore;

namespace Weelo.App.Api.EF.DataModel.Context
{
    public class WeeloContext : DbContext
    {
        //For code first, please comment the constructor and descomment for the method OnConfiguring,           
        //open this class project with a only project, execute the next code line, and create the BD with name 'Weelo' 
        //before execute the next code lines en the PM console, Add-Migration Initial, Update-DataBase
        //protected override void OnConfiguring(DbContextOptionsBuilder options) 
        //{
        //    options.UseSqlServer("Data Source=localhost;Initial Catalog=Weelo;User ID=sa;Password=Str0ngPa$$w0rd");
        //}
        public WeeloContext(DbContextOptions<WeeloContext> options) : base(options) { }

        public DbSet<Owner> Owner { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyTrace> PropertiesTrace { get; set; }
        public DbSet<PropertyImage> PropertiesImages { get; set; }
        
    }
}
