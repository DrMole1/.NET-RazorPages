using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationRazor.Data;
using WebApplicationRazor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationRazor.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly WebApplicationRazor.Data.WebApplicationRazorContext _context;

        public IndexModel(WebApplicationRazor.Data.WebApplicationRazorContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            // Requête LINQ pour récupérer tous les genres dans la db
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            // Requête LINQ pour trouver les films
            var movies = from m in _context.Movie
                         select m;

            // La requête LINQ précédente est soumise à différentes clauses WHERE
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            // Liste possédant comme valeurs les différents genres trouvées dans la db
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            Movie = await movies.ToListAsync();
        }

        [BindProperty(SupportsGet = true)] // SupportsGet nécessaire pour les requêtes GET
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }
    }
}
