using Prueba_Front_Josue_Minaya.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba_Front_Josue_Minaya.Servicio
{
    public interface IService_Api
    {
      
        Task<List<Orden>> GetOrden();
        Task<List<OrdenDetalle>> GetById(int id);


    }
}
