using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapMochaApi.Models
{
    public class TipoProductores
    {
        [Key]
        public int IdTipoProductores { get; set; }
        public string Nombre { get; set; }
    }
}
