using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapMochaApi.Models
{
    public class Categorias
    {
        [Key]
        public int IdCategorias { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }


        public int IdTipoProductores { get; set; }
        public TipoProductores tipoproductores { get; set; }

    }
}
