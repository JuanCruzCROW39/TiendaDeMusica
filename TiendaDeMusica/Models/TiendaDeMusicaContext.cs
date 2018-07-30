using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TiendaDeMusica.Models
{
    public class TiendaDeMusicaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TiendaDeMusicaContext() : base("name=TiendaDeMusicaContext")
        {
        }

        public System.Data.Entity.DbSet<TiendaDeMusica.Models.Album> Albums { get; set; }

        public System.Data.Entity.DbSet<TiendaDeMusica.Models.Artista> Artistas { get; set; }

        public System.Data.Entity.DbSet<TiendaDeMusica.Models.Genero> Generoes { get; set; }

        public DbSet<TiendaDeMusica.Models.Departamento> Departamentos { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Sexo> Sexo { get; set; }

        public DbSet<EstadoCivil> EstadoCivil { get; set; }

        public DbSet<Cancion> Canciones { get; set; }
        public DbSet<DescripcionAlbum> DescripcionAlbums { get; set; }
        public DbSet<Hospitales> Hospitales { get; set; }
        public DbSet<Marker> Markers { get; set; }
    }
}
