using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario  // Repositorio dueño implementa los metodos de la interfaz IRepositorioDueno
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
        
        public RepositorioVeterinario(AppContext appContext) // Metodo Constructor, recibe un AppContext y lo almacena en appContext
        {
            _appContext = appContext; // lo que se recibe se le asigana a la variabel de la clase _appContext
        }

        public Veterinario AddVeterinario(Veterinario veterinario)
        {
            var VeterinarioAdicionado = _appContext.Veterinarios.Add(veterinario); // En la tabla dueño agrega Dueño
            _appContext.SaveChanges();  // Guarda el cambio
            return VeterinarioAdicionado.Entity;
        }

        public void DeleteVeterinario(int idVeterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(d => d.Id == idVeterinario);
            if (veterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Veterinario> GetAllVeterinario()
        {
            return GetAllVeterinario_();
        }

        public IEnumerable<Veterinario> GetVeterinarioPorFiltro(string filtro)
        {
            var veterinarios = GetAllVeterinario(); // Obtiene todos los saludos
            if (veterinarios != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    veterinarios = veterinarios.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return veterinarios;
        }

        public IEnumerable<Veterinario> GetAllVeterinario_()
        {
            return _appContext.Veterinarios;
        }

        public Veterinario GetVeterinario(int idVeterinarios)
        {
            return _appContext.Veterinarios.FirstOrDefault(d => d.Id == idVeterinarios);
        }

        public Veterinario UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(d => d.Id == veterinario.Id);
            if (veterinarioEncontrado != null)
            {
                veterinarioEncontrado.Nombre = veterinario.Nombre;
                veterinarioEncontrado.Apellidos = veterinario.Apellidos;
                veterinarioEncontrado.Direccion = veterinario.Direccion;
                veterinarioEncontrado.Telefono = veterinario.Telefono;
                veterinarioEncontrado.TarjetaProfesional = veterinario.TarjetaProfesional;
                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        }     
    }
}