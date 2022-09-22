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
    public class DetallesVisitasModel : PageModel
    {
       private readonly IRepositorioVisitaPyP _repoVisitaPyP;
        public VisitaPyP visita{get;set;}
        public DetallesVisitasModel()
        {
            this._repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int visitaId)
        {
           visita = _repoVisitaPyP.GetVisita(visitaId);
           
           if (visitaId == null)
           {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}
