using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba_Front_Josue_Minaya.Models
{
    public class OrdenDetalle
    {
        public int Id { get; set; }
        public int IdOrden { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double Monto { get; set; }
       
    }
}
