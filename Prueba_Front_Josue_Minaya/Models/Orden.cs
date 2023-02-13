using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba_Front_Josue_Minaya.Models
{
    public class Orden
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public double Total { get; set; }
        public string Asesor { get; set; }
    }
}
