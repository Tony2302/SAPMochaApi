using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapMochaApi.Models
{
    public class Productos
    {

        [Key]
        public int IdProductos { get; set; }
        public string NombreProducto { get; set; }
        
        public String Unidad { get; set; }
        public string Descripcion { get; set; }
        public string Talla { get; set; }


        public int IdCategorias { get; set; }
        public Categorias categorias { get; set; }

    }
}
