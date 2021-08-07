using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SapMochaApi.Models
{
    public class DetalleCategorias
    {

        [Key]
        public int IdDetalleCategorias { get; set; }

        public int IdProductos { get; set; }
        public Productos Productos { get; set; }

        public int Stock { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public Decimal PrecioUnidad { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public Decimal PrecioDocena { get; set; }


        public int IdProductores { get; set; }
        public Productores Productores { get; set; }




    }
}   
