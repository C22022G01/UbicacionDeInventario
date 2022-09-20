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
    public class Bodega
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Sucursal")]
        [Required(ErrorMessage = "Sucursal es obligatorio")]
        [Display(Name = "Sucursal")]
        public int IdSucursal { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public String Nombre { get; set; }
        [Display(Name = "Fecha registro")]
        public DateTime FechaCreacion { get; set; }
        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Estatus { get; set; }
        [Required(ErrorMessage = "El descripcion es requerida")]
        [StringLength(150, ErrorMessage = "Maximo 150 caracteres")]
        public string Descripcion { get; set; }

        public Sucursal Sucursal { get; set; }

        [NotMapped]

        public int Top_Aux { get; set; }

    }

    public enum Estatus_Bodega
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}
