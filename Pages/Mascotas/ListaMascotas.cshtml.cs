using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;


namespace MascotaFeliz.App.Frontend.Pages
{
    public class ListaMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());

        public IEnumerable<Mascota> ListaMascotas{get;set;}

        public void OnGet()
        {
            ListaMascotas=_repoMascota.GetAllMascota();
        }
    }
}
