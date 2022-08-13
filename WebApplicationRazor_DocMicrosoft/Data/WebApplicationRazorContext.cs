using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationRazor.Models;

namespace WebApplicationRazor.Data
{   
    // Contexte lié à la base de données
    // Entity Framework s'occupe de mapper le modèle pour le faire correspondre à la db utilisée
    public class WebApplicationRazorContext : DbContext
    {
        // Constructeur vide du contexte
        public WebApplicationRazorContext (DbContextOptions<WebApplicationRazorContext> options)
            : base(options)
        {
        }

        // Modèle à appliquer au DbSet
        public DbSet<WebApplicationRazor.Models.Movie> Movie { get; set; } = default!;
    }
}
