using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeMusica.Models
{
    public class Hospitales
    {
        public virtual int Id { get; set; }
        public virtual int? PId { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool? Child { get; set; }
        public virtual bool? Expanded { get; set; }
    }
}