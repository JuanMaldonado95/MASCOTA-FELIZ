using System;
using System.Collections; // para uso de listas
using System.Collections.Generic; // para uso de listas 
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVisitaPyP
    {
        IEnumerable<VisitaPyP> GetAllVisita(); 
        VisitaPyP AddVisita(VisitaPyP visita); 
        VisitaPyP UpdateVisita(VisitaPyP visita);
        void DeleteVisita(int idVisita);
        VisitaPyP GetVisita(int idVisita);
       // IEnumerable<VisitaPyP> GetVisitaPorFiltro(string filtro); 
    }
}