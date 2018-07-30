using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeMusica.Models
{
    public class Album
    {
        public virtual int AlbumId { get; set; }
        public virtual int GeneroId { get; set; }
        public virtual int ArtistaId { get; set; }
        public virtual string Titulo { get; set; }
        public virtual decimal Precio { get; set; }
        public virtual string AlbumArtURL { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Artista Artista { get; set; }
    }
}