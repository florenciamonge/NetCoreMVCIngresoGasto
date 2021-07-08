using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlIngresoGasto.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        [Display(Name = "Nombre categorìa")]
        public string NombreCategoria { get; set; }

        [Required]
        [MaxLength(2)]
        [Display(Name = "Tipo")]
        public string tipo { get; set; } //IN ingreso GA gasto

        [Required]
        public bool Estado { get; set; }

    }
}
