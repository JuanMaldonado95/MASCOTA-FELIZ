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
    public class BorrarVeterinariosModel : PageModel
    {
        private readonly IRepositorioVeterinario _repoVeterinario;
        [BindProperty]
        public Veterinario veterinario{get;set;}

        public BorrarVeterinariosModel()
        {
            this._repoVeterinario  = new RepositorioVeterinario(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int? veterinarioId)
        {
            if (veterinarioId.HasValue)
            {
                veterinario = _repoVeterinario.GetVeterinario(veterinarioId.Value);
            }

            if (veterinario == null)
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
            if (veterinario.Id > 0)
            {
                _repoVeterinario.DeleteVeterinario(veterinario.Id);
            }
            else
            {
                _repoVeterinario.AddVeterinario(veterinario);
            }
            return Page();
        }
    }
}
