using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationRazor.Models
{
    // Modèle de films utilisé


    // [Required] pour spécifier que le champs soit non-null
    // [StringLength(x, MinimumLength = x)] pour spécifier le maximum de caractères d'une chaine, MinimumLength pour le minimum de caractères
    // [Display(Name="")] pour changer le nom de la colonne à l'affichage
    // [DataType(DataType.type)] pour typer le champs (date, heure, email, téléphone ...)
    // [RegularExpression()] pour indiquer le formatage d'une chaine de caractères, quels caractères sont exclus
    // [Range(x,x)] pour que la valeur numérique soit comprise dans l'interval demandé

    public class Movie
    {
        // Un champ est public, possède un mutateur et un ascesseur. Les strings sont initialisées à string.Empty

        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; } = string.Empty;

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; } = string.Empty;
    }
}
