using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota  // Repositorio dueño implementa los metodos de la interfaz IRepositorioDueno
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
        
        public RepositorioMascota(AppContext appContext) // Metodo Constructor, recibe un AppContext y lo almacena en appContext
        {
            _appContext = appContext; // lo que se recibe se le asigana a la variabel de la clase _appContext
        }

        public Mascota AddMascota(Mascota mascota)
        {
            var mascotaAdicionado = _appContext.Mascotas.Add(mascota); // En la tabla agrega
            _appContext.SaveChanges();  // Guarda el cambio
            return mascotaAdicionado.Entity;
        }

        public void DeleteMascota(int idMascota)
        {
            var mascotaEncontrado = _appContext.Mascotas.FirstOrDefault(d => d.Id == idMascota);
            if (mascotaEncontrado == null)
                return;
            _appContext.Mascotas.Remove(mascotaEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Mascota> GetAllMascota()
        {
            return GetAllMascota_();
        }

        public IEnumerable<Mascota> GetMascotaPorFiltro(string filtro)
        {
            var mascota = GetAllMascota(); // Obtiene todos los saludos
            if (mascota != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    mascota = mascota.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return mascota;
        }

        public IEnumerable<Mascota> GetAllMascota_()
        {
            return _appContext.Mascotas;
        }

        public Mascota GetMascota(int idMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(d => d.Id == idMascota);
        }

        public Mascota UpdateMascota(Mascota mascota)
        {
            var mascotaEncontrado = _appContext.Mascotas.FirstOrDefault(d => d.Id == mascota.Id);
            if (mascotaEncontrado != null)
            {
                mascotaEncontrado.Nombre = mascota.Nombre;
                mascotaEncontrado.Color = mascota.Color;
                mascotaEncontrado.Especie = mascota.Especie;
                mascotaEncontrado.Raza = mascota.Raza;
                _appContext.SaveChanges();
            }
            return mascotaEncontrado;
        }     
    }
}