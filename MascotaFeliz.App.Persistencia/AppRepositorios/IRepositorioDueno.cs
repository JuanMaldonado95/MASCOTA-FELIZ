using System;
using System.Collections; // para uso de listas
using System.Collections.Generic; // para uso de listas 
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioDueno
    {
        IEnumerable<Dueno> GetAllDuenos(); // lista de elementos tipo dueño
        Dueno AddDueno(Dueno dueno); // de la clase dueño recibe una variable
        Dueno UpdateDueno(Dueno dueno);
        void DeleteDueno(int idDueno);
        Dueno GetDueno(int idDueno);
        IEnumerable<Dueno> GetDuenosPorFiltro(string filtro); // Lista de tipo dueño devuelve los que cumpla la condicion del metodo filtro
    }
}