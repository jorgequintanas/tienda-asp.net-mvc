using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tiendaMVC.Models
{
    public class Producto
    {
        [Required]
        [Display(Name = "Sku")]
        [Range(1, 999999, ErrorMessage = "El sku debe ser numérico de 1 a 999999")]
        public int Sku { get; set; }

        [Required]
        [Display(Name = "Artículo")]
        [StringLength(15)]
        public string Articulo { get; set; }

        [Required]
        [Display(Name = "Marca")]
        [StringLength(15)]
        public string Marca { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        [StringLength(20)]
        public string Modelo { get; set; }

        [Required]
        [Range(1, 9, ErrorMessage = "El departamento debe ser un valor de 1 a 9")]
        public int Departamento { get; set; }

        [Display(Name = "Departamento")]
        public string DepartamentoNombre { get; set; }

        [Required]
        [Range(1, 99, ErrorMessage = "La clase debe ser un valor de 1 a 99")]
        public int Clase { get; set; }

        [Display(Name = "Clase")]
        public string ClaseNombre { get; set; }

        [Required]
        [Range(1, 999, ErrorMessage = "La familia debe ser un valor de 1 a 999")]
        public int Familia { get; set; }

        [Display(Name = "Familia")]
        public string FamiliaNombre { get; set; }

        [Required]
        [Display(Name = "Fecha Alta")]
        [DataType(DataType.Date, ErrorMessage = "Debe capturar formado de fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public System.DateTime Fecha_Alta { get; set; }

        [Required]
        [Display(Name = "Stock")]
        [Range(0, 999999999, ErrorMessage = "El stock debe ser un valor de 0 a 999999999")]
        public int Stock { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        [Range(0, 999999999, ErrorMessage = "La cantidad debe ser un valor de 0 a 999999999")]
        public int Cantidad { get; set; }

        [Required]
        [Display(Name = "Descontinuado")]
        public bool Descontinuado { get; set; }

        [Required]
        [Display(Name = "Fecha Baja")]
        [DataType(DataType.Date, ErrorMessage = "Debe capturar formado de fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime Fecha_Baja { get; set; }

        public List<Departamento> listaDepartamentos { get; set; }
    }
}