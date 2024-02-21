using FrontalMVC.Models.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace FrontalMVC.Composants
{
    public class ComposantFicheViewComponent : ViewComponent
    {

        private TeamContext _context;

        public ComposantFicheViewComponent(TeamContext context)
        {
            _context = context;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {

            var leader = _context.Equipes.OrderByDescending(m => m.MaxMembres).First();
            return Task.FromResult<IViewComponentResult>(View("_FicheEquipe", leader));
        }
    }
}
