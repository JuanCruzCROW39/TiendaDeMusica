using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeMusica.Models
{
    public class TiendaDeMusicaDBInitializer : System.Data.Entity.DropCreateDatabaseAlways<TiendaDeMusicaContext>
    {
        protected override void Seed(TiendaDeMusicaContext context)
        {
            //context.Artistas.Add(new Artista { Nombre = "Avenged Sevenfold" });
            //context.Generoes.Add(new Genero { Nombre = "Heavy Metal" });
            context.Albums.Add(new Album
            {
                Artista = new Artista { Nombre = "El Tri" },
                Genero = new Genero { Nombre = "Rock" },
                Titulo = "El Tri Sinfonico",
                Precio = 100,
                AlbumArtURL = "http://images.coveralia.com/audio/e/El_Tri-Sinfonico-Frontal.jpg?621"
            });

            context.Albums.Add(new Album
            {
                Artista = new Artista { Nombre = "Avenged Sevenfold" },
                Genero = new Genero { Nombre = "Heavy Metal" },
                Titulo = "Avenged Sevenfold",
                Precio = 120,
                AlbumArtURL = ""
            });

            context.Albums.Add(new Album
            {
                Artista = new Artista { Nombre = "Michael Jackson" },
                Genero = new Genero { Nombre = "Pop" },
                Titulo = "Thriller",
                Precio = 80,
                AlbumArtURL=""
            });

            context.Albums.Add(new Album
            {
                Artista = new Artista { Nombre = "Eminem" },
                Genero = new Genero { Nombre = "Hip Hop" },
                Titulo = "Recovery",
                Precio = 100,
                AlbumArtURL=""
            });

            context.Albums.Add(new Album
            {
                Artista = new Artista { Nombre = "The Prodigy" },
                Genero = new Genero { Nombre = "Electronica" },
                Titulo = "Always Outnumbered, Never Outgunned",
                Precio = 120,
                AlbumArtURL=""
            });

            context.Departamentos.Add(new Departamento
            {
                Nombre = "Contaduria"
            });

            context.Departamentos.Add(new Departamento
            {
                Nombre = "Desarrollo de Software"
            });

            context.Departamentos.Add(new Departamento
            {
                Nombre = "Ingenieria"
            });

            base.Seed(context);

            context.Sexo.Add(new Sexo { Nombre = "Hombre" });

            context.Sexo.Add(new Sexo { Nombre = "Mujer" });

            context.EstadoCivil.Add(new EstadoCivil { Nombre = "Soltero(a)" });

            context.EstadoCivil.Add(new EstadoCivil { Nombre = "Casado(a)" });

            context.Canciones.Add(new Cancion
            {
                Nombre = "Critical Acclaim",
                NoPista = 1,
                AlbumId = 2
            });

            context.Canciones.Add(new Cancion
            {
                Nombre = "Almost Easy",
                NoPista = 2,
                AlbumId = 2
            });

            context.Canciones.Add(new Cancion
            {
                Nombre = "Scream",
                NoPista = 3,
                AlbumId = 2
            });
            context.Canciones.Add(new Cancion
            {
                Nombre = "Afterlife",
                NoPista = 4,
                AlbumId = 2
            });

            context.Canciones.Add(new Cancion
            {
                Nombre = "Gunslinger",
                NoPista = 5,
                AlbumId = 2
            });
            context.Canciones.Add(new Cancion
            {
                Nombre = "Unbound (The Wild Ride)",
                NoPista = 6,
                AlbumId = 2
            });
            context.Canciones.Add(new Cancion
            {
                Nombre = "Brompton Cocktail",
                NoPista = 7,
                AlbumId = 2
            });
            context.Canciones.Add(new Cancion
            {
                Nombre = "Lost",
                NoPista = 8,
                AlbumId = 2
            });
            context.Canciones.Add(new Cancion
            {
                Nombre = "A Little Piece of Heaven",
                NoPista = 9,
                AlbumId = 2
            });
            context.Canciones.Add(new Cancion
            {
                Nombre = "Dear God",
                NoPista = 10,
                AlbumId = 2
            });
            context.Canciones.Add(new Cancion
            {
                Nombre = "Virgen Morena",
                NoPista = 1,
                AlbumId = 1
            });
            context.Canciones.Add(new Cancion
            {
                Nombre = "Mente Roquera",
                NoPista = 2,
                AlbumId = 1
            });
            context.Canciones.Add(new Cancion
            {
                Nombre = "Maria Sabina",
                NoPista = 3,
                AlbumId = 1
            });
            context.Canciones.Add(new Cancion { Nombre = "Los Minusválidos", NoPista = 4, AlbumId = 1 });
            context.Canciones.Add(new Cancion { Nombre = "Las Piedras Rodantes", NoPista = 5, AlbumId = 1 });
            context.Canciones.Add(new Cancion { Nombre = "El Niño Sin Amor", NoPista = 6, AlbumId = 1 });
            context.Canciones.Add(new Cancion { Nombre = "Dificil", NoPista = 7, AlbumId = 1 });
            context.Canciones.Add(new Cancion { Nombre = "Cuando Tu No Estas", NoPista = 8, AlbumId = 1 });
            context.Canciones.Add(new Cancion { Nombre = "Nostalgia", NoPista = 9, AlbumId = 1 });
            context.Canciones.Add(new Cancion { Nombre = "Triste Cancion", NoPista = 10, AlbumId = 1 });
            context.Canciones.Add(new Cancion { Nombre = "Pobre Soñador", NoPista = 11, AlbumId = 1 });
            context.Canciones.Add(new Cancion { Nombre = "A.D.O", NoPista = 12, AlbumId = 1 });

            context.Canciones.Add(new Cancion { Nombre = "Wanna Be Startin' Somethin'", NoPista = 1, AlbumId = 3 });
            context.Canciones.Add(new Cancion { Nombre = "Baby Be Mine", NoPista = 2, AlbumId = 3 });
            context.Canciones.Add(new Cancion { Nombre = "The Girl Is Mine", NoPista = 3, AlbumId = 3 });
            context.Canciones.Add(new Cancion { Nombre = "Thriller", NoPista = 4, AlbumId = 3 });
            context.Canciones.Add(new Cancion { Nombre = "Beat It", NoPista = 5, AlbumId = 3 });
            context.Canciones.Add(new Cancion { Nombre = "Billie Jean", NoPista = 6, AlbumId = 3 });
            context.Canciones.Add(new Cancion { Nombre = "Human Nature", NoPista = 7, AlbumId = 3 });
            context.Canciones.Add(new Cancion { Nombre = "P.Y.T. (Pretty Young Thing)", NoPista = 8, AlbumId = 3 });
            context.Canciones.Add(new Cancion { Nombre = "The Lady in My Life", NoPista = 9, AlbumId = 3 });

            context.Canciones.Add(new Cancion { Nombre = "Cold Wind Blows", NoPista = 1, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "Talkin' 2 Myself", NoPista = 2, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "On Fire", NoPista = 3, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "Won't Back Down", NoPista = 4, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "W.T.P.", NoPista = 5, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "Going Through Changes", NoPista = 6, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "Not Afraid", NoPista = 7, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "Seduction", NoPista = 8, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "No Love", NoPista = 9, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "Space Bound", NoPista = 10, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "Cinderella Man", NoPista = 11, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "25 to Life", NoPista = 12, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "So Bad", NoPista = 13, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "Almost Famous", NoPista = 14, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "Love the Way You Lie", NoPista = 15, AlbumId = 4 });
            context.Canciones.Add(new Cancion { Nombre = "You're Never Over", NoPista = 16, AlbumId = 4 });

            context.Canciones.Add(new Cancion { Nombre = "Spitfire", NoPista = 1, AlbumId = 5 });
            context.Canciones.Add(new Cancion { Nombre = "Girls", NoPista = 2, AlbumId = 5 });
            context.Canciones.Add(new Cancion { Nombre = "Memphis Bells", NoPista = 3, AlbumId = 5 });
            context.Canciones.Add(new Cancion { Nombre = "Get Up Get Off", NoPista = 4, AlbumId = 5 });
            context.Canciones.Add(new Cancion { Nombre = "Hotride", NoPista = 5, AlbumId = 5 });
            context.Canciones.Add(new Cancion { Nombre = "Wake Up Call", NoPista = 6, AlbumId = 5 });
            context.Canciones.Add(new Cancion { Nombre = "Action Radar", NoPista = 7, AlbumId = 5 });
            context.Canciones.Add(new Cancion { Nombre = "Medusa's Path", NoPista = 8, AlbumId = 5 });
            context.Canciones.Add(new Cancion { Nombre = "Phoenix", NoPista = 9, AlbumId = 5 });
            context.Canciones.Add(new Cancion { Nombre = "You'll Be Under My Wheels", NoPista = 10, AlbumId = 5 });
            context.Canciones.Add(new Cancion { Nombre = "The Way It Is", NoPista = 11, AlbumId = 5 });
            context.Canciones.Add(new Cancion { Nombre = "Shoot Down", NoPista = 12, AlbumId = 5 });

            context.DescripcionAlbums.Add(new DescripcionAlbum
            {
                Texto = "Sinfónico es un álbum en vivo de rock sinfónico de la banda mexicana El Tri. El álbum fue grabado el 12 y 13 de octubre del 1998 en el Auditorio Nacional de la Ciudad de México para conmemorar y celebrar el aniversario número 30 de El Tri. El álbum vendió más de 100,000 copias rápidamente después de su lanzamiento, convirtiéndose en un álbum platino y uno de los más vendidos y famosos de la banda. La sinfonía invitada para este proyecto fue la Sinfónica Metropolitana de México, con el Mtro. Eduardo Diazmuñoz como director musical, misma que volvería a participar para el álbum Sinfónico II (2001).Sinfónico es el decimosexto álbum de El Tri,y el cuarto grabado en vivo; e incluye una recopilación de las canciones más representativas del grupo, además de dos monólogos de Alex Lora; el primero como introducción del concierto y el segundo antes de la canción «Nostalgia». El álbum obtuvo una certificación de oro.",
                AlbumId = 1
            });

            context.DescripcionAlbums.Add(new DescripcionAlbum
            {
                Texto = "Avenged Sevenfold es el cuarto álbum de estudio de Avenged Sevenfold editado el 30 de octubre de 2007 en Warner Bros. En principio, el álbum estaba programado para ser editado el 16 de octubre, pero su fecha de publicación fue retrasada para completar el material extra del disco, incluyendo una versión animada de la canción «A Little Piece Of Heaven». Este álbum debutó en el número cuatro en Billboard 200, y el 23 de septiembre de 2008 fue considerado álbum de oro por la RIAA. Avenged Sevenfold ganó el premio Kerrang! del Mejor Álbum en 2008. Además, fue incluido en'666 Álbumes que Debes Escuchar Antes de Mori' de Kerrang.",
                AlbumId = 2
            });

            context.DescripcionAlbums.Add(new DescripcionAlbum
            {
                Texto = "Thriller es el nombre del sexto álbum de estudio del artista estadounidense Michael Jackson. Fue lanzado al mercado el 30 de noviembre de 1982 por Epic Records después del exitoso y aclamado álbum de Jackson Off the Wall de 1979. Incluye géneros similares a los de Off the Wall, incluyendo la música post-disco, el R&B, el pop y el rock.Thriller estableció el estatus de Jackson como una de las estrellas del pop por excelencia a finales del siglo XX, y le permitió romper las barreras raciales a través de sus apariciones en MTV y su reunión con el presidente Ronald Reagan en la Casa Blanca.El disco contó con la especial colaboración de los integrantes de la banda Toto. Entre ellos Jeff Porcaro (batería), Steve Porcaro y David Paich (teclados), Steve Lukather (guitarra) y el teclista Greg Phillinganes —quien sería futuro integrante de la banda—.",
                AlbumId = 3
            });

            context.DescripcionAlbums.Add(new DescripcionAlbum
            {
                Texto = "Recovery es el séptimo álbum de estudio del rapero y productor discográfico estadounidense Eminem, lanzado el 18 de junio de 2010 por Aftermath, Interscope y Shady Records. La producción del álbum se llevó a cabo durante los años 2009 y 2010, y fue manejada por diversos productores, incluyendo a Dr. Dre, Havoc, Just Blaze, Mr. Porter, entre otros.El álbum debutó en el número uno en el Billboard 200 en los Estados Unidos, vendiendo 741,000 copias en su primera semana.Es su sexto álbum consecutivo en alcanzar el número uno, y ha producido dos sencillos de éxito internacional: \"Not Afraid\" y \"Love the Way You Lie\".",
                AlbumId = 4
            });

            context.DescripcionAlbums.Add(new DescripcionAlbum
            {
                Texto = "Always Outnumbered, Never Outgunned es el cuarto álbum de estudio de la banda inglesa de rock electrónico The Prodigy.1​ Fue lanzado durante agosto y septiembre de 2004 en Reino Unido por XL Recordings y en Estados Unidos por Mute Records y Maverick Records. Fue el primer álbum de The Prodigy sin Leeroy Thornhill y sin contener las voces de Keith Flint o Maxim Reality en la mayoría de las canciones.",
                AlbumId = 5
            });


            context.Hospitales.Add(new Hospitales
            {
                Id = 1,
                Nombre = "Jurisdiccion Sanitaria 1",
                Child = true,
                Expanded = false
            });

            context.Hospitales.Add(new Hospitales { Id = 2, PId = 1, Nombre = "Hospital 1" });
            context.Hospitales.Add(new Hospitales { Id = 3, PId = 1, Nombre = "Hospital 2" });
            context.Hospitales.Add(new Hospitales { Id = 4, PId = 1, Nombre = "Hospital 3" });

            context.Hospitales.Add(new Hospitales
            {
                Id = 5,
                Nombre = "Jurisdiccion Sanitaria 2",
                Child = true,
                Expanded = false
            });

            context.Hospitales.Add(new Hospitales { Id = 6, PId = 5, Nombre = "Hospital 4" });
            context.Hospitales.Add(new Hospitales { Id = 7, PId = 5, Nombre = "Hospital 5" });
            context.Hospitales.Add(new Hospitales { Id = 8, PId = 5, Nombre = "Hospital 6" });
            context.Hospitales.Add(new Hospitales { Id = 9, PId = 5, Nombre = "Hospital 7" });

            context.Hospitales.Add(new Hospitales
            {
                Id = 10,
                Nombre = "Jurisdiccion Sanitaria 3",
                Child = true,
                Expanded = false
            });

            context.Hospitales.Add(new Hospitales { Id = 11, PId = 10, Nombre = "Hospital 8" });
            context.Hospitales.Add(new Hospitales { Id = 12, PId = 10, Nombre = "Hospital 9" });

            context.Markers.Add(new Marker { Latitud = 18.4875, Longitud = -98.63638889, InfoWindow = "Aqui esta el hospital 1", HospitalId = 2 });
            context.Markers.Add(new Marker { Latitud = 18.25701944, Longitud = -98.10485556, InfoWindow = "Aqui esta el hospital 2", HospitalId = 3 });
            context.Markers.Add(new Marker { Latitud = 20.42381944, Longitud = -98.02726667, InfoWindow = "Aqui esta el hospital 3", HospitalId = 4 });
            context.Markers.Add(new Marker { Latitud = 19.71235556, Longitud = -97.65304167, InfoWindow = "Aqui esta el hospital 4", HospitalId = 6 });
            context.Markers.Add(new Marker { Latitud = 19.08301111, Longitud = -97.53750833, InfoWindow = "Aqui esta el hospital 5", HospitalId = 7 });
            context.Markers.Add(new Marker { Latitud = 19.99944722, Longitud = -97.77408056, InfoWindow = "Aqui esta el hospital 6", HospitalId = 8 });
            context.Markers.Add(new Marker { Latitud = 18.73675, Longitud = -98.16233889, InfoWindow = "Aqui esta el hospital 7", HospitalId = 9 });
            context.Markers.Add(new Marker { Latitud = 20.08586944, Longitud = -97.99807778, InfoWindow = "Aqui esta el hospital 8", HospitalId = 11 });
            context.Markers.Add(new Marker { Latitud = 19.07935, Longitud = -98.18544167, InfoWindow = "Aqui esta el hospital 9", HospitalId = 12 });

        }
    }
}