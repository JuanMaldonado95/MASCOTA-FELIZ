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
    public class BorrarMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        [BindProperty]
        public Mascota mascota{get;set;}

        public BorrarMascotasModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        }


        public IActionResult OnGet(int? mascotaId)
        {
            if (mascotaId.HasValue)
            {
                mascota = _repoMascota.GetMascota(mascotaId.Value);
            }

            if (mascota == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (mascota.Id > 0)
            {
                _repoMascota.DeleteMascota(mascota.Id);
            }
            else
            {
                _repoMascota.AddMascota(mascota);
            }
            return Page();
        }
    }
}
