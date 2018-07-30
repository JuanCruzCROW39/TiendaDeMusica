using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TiendaDeMusica.Models
{
    public class Empleado
    {
        public virtual int EmpleadoId { get; set; }

        [Required]
        [StringLength(80)]
        public virtual string Nombre { get; set; }

        [Required]
        [StringLength(80)]
        public virtual string Apellidos { get; set; }

        [Required]
        [Range(18, 90)]
        public virtual int Edad { get; set; }

        [Required]
        [StringLength(160)]
        public virtual string Direccion { get; set; }

        [Required]
        public virtual int DepartamentoId { get; set; }

        [Required]
        public virtual bool Externo { get; set; }

        [Required]
        [RegularExpression(@"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$")]
        //[RegularExpression(@"/^([A-Z]{4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[HM](AS|BC|BS|CC|CL|CM|CS|CH|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE)[A-Z]{3}[0-9A-Z]\d)$/i")]
        [StringLength(18)]
        public virtual string CURP { get; set; }

        [Required]
        [RegularExpression(@"^([A-ZÑ&]{3,4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$")]
        //[RegularExpression(@"/^([A-Z,Ñ,&]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[A-Z|\d]{3})$/i")]
        public virtual string RFC { get; set; }

        [Required]
        //[RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$")]
        [StringLength(10)]
        public virtual string Telefono { get; set; }

        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        public virtual string Email { get; set; }

        [Required]
        public virtual DateTime FechaDeNacimiento { get; set; }

        [Required]
        public virtual int SexoId { get; set; }

        [Required]
        public virtual int EstadoCivilId { get; set; }

        public virtual Sexo Sexo { get; set; }

        public virtual Departamento Departamento { get; set; }

        public virtual EstadoCivil EstadoCivil { get; set; }

        ///^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$/
        ///^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$/
        ///^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$/
    }
}