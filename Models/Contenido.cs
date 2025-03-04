using System.ComponentModel.DataAnnotations;

namespace ContentAPI.Models
{
    public class Contenido
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, ErrorMessage = "El título no puede exceder 100 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; } = DateTime.Now;
    }
}
