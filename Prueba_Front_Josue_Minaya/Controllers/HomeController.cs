using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prueba_Front_Josue_Minaya.Models;
using Prueba_Front_Josue_Minaya.Servicio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Front_Josue_Minaya.Controllers
{
    public class HomeController : Controller
    {

        private readonly IService_Api _service;

        public HomeController(IService_Api service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Orden> listaOrden = await _service.GetOrden();

            return View(listaOrden);
        }

        public async Task<IActionResult> Detalle(int id)
        {
            List<OrdenDetalle> listaOrden = await _service.GetById(id);

            return View(listaOrden);
        }


    }
}
