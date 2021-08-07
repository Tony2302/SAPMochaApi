using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SapMochaApi.Models
{
    public class Productores
    {
        [Key]
        public int IdProductores { get; set; }

        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string PaginaWeb { get; set; }
        public string Cargo { get; set; }
        public bool Organizacion { get; set; }
        public string DetalleOrganizacion { get; set; }
        public bool Discapacidad { get; set; }
        public string DetalleDiscapacidad { get; set; }
        public int PorcentajeDiscapacidad { get; set; }


        public int IdTipoProductores { get; set; }
        public TipoProductores tipoproductores { get; set; }
       


    }
}
