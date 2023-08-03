using MagicVilla_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Datos
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionns) : base(optionns) 
        {
            
        }
        public DbSet<Villa> Villas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Nombre = "Villa Real",
                    Detalle = "Detalle de la Villa",
                    ImagenUrl = "",
                    Ocupantes = 5,
                    MetrosCuadrados = 5,
                    Tarifa = 200,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                },

                 new Villa()
                 {
                     Id = 2,
                     Nombre = "Villa Chica",
                     Detalle = "Detalle de la Villa",
                     ImagenUrl = "",
                     Ocupantes = 4,
                     MetrosCuadrados = 4,
                     Tarifa = 200,
                     Amenidad = "",
                     FechaCreacion = DateTime.Now,
                     FechaActualizacion = DateTime.Now
                 }
                 );

        }

    }
}
