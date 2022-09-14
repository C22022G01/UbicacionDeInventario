using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UbicacionDeInventario.EntidadesDeNegocio
{
    public class Estante
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Bodega")]
        [Required(ErrorMessage = "Bodega es obligatorio")]
        [Display(Name = "Bodega")]
        public int IdBodega { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public String Nombre { get; set; }

        public Bodega Bodega { get; set; }

        [NotMapped]

        public int Top_Aux { get; set; }
    }
}
