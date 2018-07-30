using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TiendaDeMusica.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }

        [Display(Name="Fecha de Pedido")]
        [DataType(DataType.DateTime)]
        public DateTime FechaPedido { get; set; }

        [ScaffoldColumn(true)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(160)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(160)]
        public string Apellidos { get; set; }

        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }

        [Display(Name ="Código Postal")]
        [DataType(DataType.PostalCode)]
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [ReadOnly(true)]
        public decimal Total { get; set; }
        //public List<DetallesPedido> DetallesPedido { get; set; }
    }
}