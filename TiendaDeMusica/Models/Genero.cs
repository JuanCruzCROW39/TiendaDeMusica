using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeMusica.Models
{
    public class Genero
    {
        public virtual int GeneroId { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Descripcion { get; set; }
        //public virtual List<Album> Albums { get; set; }
    }
}