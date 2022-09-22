using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVisitaPyP : IRepositorioVisitaPyP  // Repositorio dueño implementa los metodos de la interfaz IRepositorioDueno
    {
        /// <summary>
        /// Referencia al contexto de Dueno
        /// </summary>
        private readonly AppContext _appContext;  // Define un objeto AppContext 
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioVisitaPyP(AppContext appContext) // Metodo Constructor, recibe un AppContext y lo almacena en appContext
        {
            _appContext = appContext; // lo que se recibe se le asigana a la variabel de la clase _appContext
        }

        public VisitaPyP AddVisita(VisitaPyP visita)
        {
            var VisitaAdicionado = _appContext.Visitas.Add(visita); // En la tabla dueño agrega Dueño
            _appContext.SaveChanges();  // Guarda el cambio
            return VisitaAdicionado.Entity;
        }

        public void DeleteVisita(int idVisita)
        {
            var visitaEncontrado = _appContext.Visitas.FirstOrDefault(d => d.Id == idVisita);
            if (visitaEncontrado == null)
                return;
            _appContext.Visitas.Remove(visitaEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<VisitaPyP> GetAllVisita()
        {
            return GetAllVisita_();
        }


        public IEnumerable<VisitaPyP> GetAllVisita_()
        {
            return _appContext.Visitas;
        }

        public VisitaPyP GetVisita(int idVisita)
        {
            return _appContext.Visitas.FirstOrDefault(d => d.Id == idVisita);
        }

        public VisitaPyP UpdateVisita(VisitaPyP visita)
        {
            var visitaEncontrado = _appContext.Visitas.FirstOrDefault(d => d.Id == visita.Id);
            if (visitaEncontrado != null)
            {
                visitaEncontrado.FechaVisita = visita.FechaVisita;
                visitaEncontrado.Temperatura = visita.Temperatura;
                visitaEncontrado.Peso = visita.Peso;
                visitaEncontrado.FrecuenciaRespiratoria = visita.FrecuenciaRespiratoria;
                visitaEncontrado.FrecuenciaCardiaca = visita.FrecuenciaCardiaca;
                visitaEncontrado.Estadoanimo = visita.Estadoanimo;
                _appContext.SaveChanges();
            }
            return visitaEncontrado;
        }     
    }
}