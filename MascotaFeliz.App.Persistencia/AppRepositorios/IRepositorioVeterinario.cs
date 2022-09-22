using System;
using System.Collections; // para uso de listas
using System.Collections.Generic; // para uso de listas 
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        IEnumerable<Veterinario> GetAllVeterinario(); 
        Veterinario AddVeterinario(Veterinario veterinario); 
        Veterinario UpdateVeterinario(Veterinario veterinario);
        void DeleteVeterinario(int idVeterinario);
        Veterinario GetVeterinario(int idVeterinario);
        IEnumerable<Veterinario> GetVeterinarioPorFiltro(string filtro); 
    }
}