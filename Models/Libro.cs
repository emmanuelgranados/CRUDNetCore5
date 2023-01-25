using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDNetCore5.Models
{
    public class Libro
    {
        [Key]
        public int id { get; set; }

        [Required (ErrorMessage ="El campo titulo es obligatorio")]
        [StringLength(50,ErrorMessage ="El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name ="Título")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "El campo descripción es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "El campo fecha es obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de lanzamiento")]
        public DateTime fechaLanzamiento { get; set; }

        [Required(ErrorMessage = "El campo autor es obligatorio")]
        [Display(Name = "Autor")]
        public string autor { get; set; }

        [Required(ErrorMessage = "El campo precio es obligatorio")]
        [Display(Name = "Precio")]
        public int precio { get; set; }


    }
}
