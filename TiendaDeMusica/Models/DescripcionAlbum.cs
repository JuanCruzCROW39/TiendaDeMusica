using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeMusica.Models
{
    public class DescripcionAlbum
    {
        public virtual int DescripcionAlbumId { get; set; }
        public virtual string Texto { get; set; }
        public virtual int AlbumId { get; set; }
    }
}