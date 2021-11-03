using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurante
{
   public class Contexto : DbContext
    {
        public Contexto(): base("Menu")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new Datosdeinicio());
        }

        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
 
    }
}
