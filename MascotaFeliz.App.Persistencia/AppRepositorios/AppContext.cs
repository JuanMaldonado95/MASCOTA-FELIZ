using Microsoft.EntityFrameworkCore;   // Es un import
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia 
{
    public class AppContext : DbContext  // AppContext es hereda de DbContext el que se encarga de hacer el mapeo
    {
        public DbSet<Persona> Personas {get;set;}  // El DbSet es la tabla que se va a crear, en este caso se llama Personas
        public DbSet<Dueno> Duenos {get;set;}
        public DbSet<Historia> Historias {get;set;}
        public DbSet<Mascota> Mascotas {get;set;}
        public DbSet<Veterinario> Veterinarios {get;set;}
        public DbSet<VisitaPyP> Visitas {get;set;}
    

        // El siguiente hace la conexion con la base de datos, siempre es el mismo codigo
        //.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MascotaFelizData");// Esta es la cadena de conexion el local este es el servidor (localdB)\\MSSQLLocalDB y va a tener toda la tabla
   
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MascotaFelizData");
            }
        }
   
    }   
}