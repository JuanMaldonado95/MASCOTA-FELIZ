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
    public class ListaVisitasModel : PageModel
    {
        private readonly IRepositorioVisitaPyP _repoVisitaPyP;
        public IEnumerable<VisitaPyP> ListaVisitas {get;set;}

        public ListaVisitasModel()
        {
            this._repoVisitaPyP=new RepositorioVisitaPyP(new Persistencia.AppContext());
        }


        public void OnGet()
        {
            ListaVisitas=_repoVisitaPyP.GetAllVisita();
        }
    }
}
