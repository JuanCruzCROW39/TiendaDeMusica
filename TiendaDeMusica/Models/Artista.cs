using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeMusica.Models
{
    public class Artista
    {
        public virtual int ArtistaId { get; set; }
        public virtual string Nombre { get; set; }
    }
}