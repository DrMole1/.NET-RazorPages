using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationRazor.Data;
using WebApplicationRazor.Models;

namespace WebApplicationRazor.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly WebApplicationRazor.Data.WebApplicationRazorContext _context;

        // Affectation du contexte à l'instanciation
        public CreateModel(WebApplicationRazor.Data.WebApplicationRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        // Lorsque l'utilisateur créée un film
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Movie == null || Movie == null)
            {
                return Page();
            }

            _context.Movie.Add(Movie); // Le film en question est ajouté à la db du contexte
            await _context.SaveChangesAsync();  // Le contexte est sauvegardé

            return RedirectToPage("./Index");   // Redirection vers la page ./Index
        }
    }
}
