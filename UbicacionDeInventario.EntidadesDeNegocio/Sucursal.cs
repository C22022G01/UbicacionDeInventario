using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ********************************
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UbicacionDeInventario.EntidadesDeNegocio
{
    public class Sucursal
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "La direccion es requerida")]
        [StringLength(20, ErrorMessage = "Maximo 30 caracteres")]
        public string Comentario { get; set; }
        [Required(ErrorMessage = "El comentario es requerido")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]

        [NotMapped]
        public int Top_Aux { get; set; }
       
    }
}
