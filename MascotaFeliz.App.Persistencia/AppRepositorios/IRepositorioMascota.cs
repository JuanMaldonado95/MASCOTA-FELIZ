using System;
using System.Collections; // para uso de listas
using System.Collections.Generic; // para uso de listas 
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioMascota
    {
        IEnumerable<Mascota> GetAllMascota(); 
        Mascota AddMascota(Mascota mascota); 
        Mascota UpdateMascota(Mascota mascota);
        void DeleteMascota(int idMascota);
        Mascota GetMascota(int idMascota);
        IEnumerable<Mascota> GetMascotaPorFiltro(string filtro); 
    }
}