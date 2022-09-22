using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());

        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());

        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());

        private static IRepositorioVisitaPyP _repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());


        static void Main(string[] args)
        {
            Console.WriteLine("Hola amigos soy el metodo main para llamar metodos");

            //AddDueno();
            //BuscarDueno();
            //ListarDuenos();

            //AddVeterinario();
            //BuscarVeterinario(2);
            //ListarVeterinarios();

            //AddMascota();
            //ListarMascotas();

            //AddHistoria();

            //AddVisita();


        }

        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                //Cedula = "1212",
                Nombre = "David",
                Apellidos = "Maldonado",
                Direccion = "Bajo un rio",
                Telefono = "1053",
                correo = "juanadfassinmiedo@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }

        private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                //Cedula = "1212",
                Nombre = "Juan",
                Apellidos = "VET 1",
                Direccion = "VET 21",
                Telefono = "123456412",
                TarjetaProfesional= "123456789423"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        private static void AddMascota()
        {
            var mascota = new Mascota
            {
                //Cedula = "1212",
                Nombre = "NOVA",
                Color = "BLANCO/NEGRO",
                Especie = "SIBERIANO",
                Raza = "PERRO",
            };
            _repoMascota.AddMascota(mascota);
        }

        private static void AddHistoria()
        {
            var historia = new Historia
            {
                FechaInicial=new DateTime(2000,04,19)
            };
            _repoHistoria.AddHistoria(historia);
        }

        private static void AddVisita()
        {
            var visita = new VisitaPyP
            {
                FechaVisita = new DateTime(2022,09,11),
                Temperatura =  35.5F,
                Peso = 47.5F,
                FrecuenciaRespiratoria = 24.5F,
                FrecuenciaCardiaca = 25,
                Estadoanimo = "BUENO",
            };
            _repoVisitaPyP.AddVisita(visita);
        }

        private static void BuscarDueno(int idDueno)
            {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Nombre + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Telefono + " " + dueno.correo);
        }


        private static void ListarDuenos()
            {
            var duenos = _repoDueno.GetAllDuenos();
            foreach (Dueno d in duenos)
            {
                Console.WriteLine(d.Nombre + " " + d.Apellidos);
            }
        }


        private static void BuscarVeterinario(int idVeterinarios)
            {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinarios);
            Console.WriteLine(veterinario.Nombre + " " + veterinario.Apellidos);
        }

        
        private static void ListarVeterinarios()
            {
            var veterinarios = _repoVeterinario.GetAllVeterinario();
            foreach (Veterinario v in veterinarios)
            {
                Console.WriteLine(v.Nombre + " " + v.Apellidos);
            }
        }

        private static void ListarMascotas()
            {
            var mascotas = _repoMascota.GetAllMascota();
            foreach (Mascota m in mascotas)
            {
                Console.WriteLine(m.Nombre + " " + m.Color + " " + m.Especie + " "+ m.Raza + " " + m.Dueno);
            }
        }

    }
}
