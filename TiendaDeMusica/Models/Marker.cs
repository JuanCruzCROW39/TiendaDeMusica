using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaDeMusica.Models
{
    public class Marker
    {
        public virtual int MarkerId { get; set; }
        public virtual double? Latitud { get; set; }
        public virtual double? Longitud { get; set; }
        public virtual string InfoWindow { get; set; }
        public virtual int HospitalId { get; set; }
    }
}