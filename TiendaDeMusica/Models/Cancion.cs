using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeMusica.Models
{
    public class Cancion
    {
        public virtual int CancionId { get; set; }
        public virtual string Nombre { get; set; }
        public virtual int NoPista { get; set; }
        public virtual int AlbumId { get; set; }
    }
}