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
        [Required(ErrorMessage = "Telefono es obligatorio")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Direccion es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Comentario { get; set; }
        [Required(ErrorMessage = "Direccion es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]

        [NotMapped]
        public int Top_Aux { get; set; }
       
    }
}
