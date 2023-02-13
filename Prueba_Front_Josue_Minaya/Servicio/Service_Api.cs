

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Prueba_Front_Josue_Minaya.Models;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Front_Josue_Minaya.Servicio
{
    public class Service_Api:IService_Api
    {
        private static string _usuario;
        private static string _password;
        private static string _baseUrl;
        private static string _token;

        public Service_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _usuario = builder.GetSection("ApiSetting:usuario").Value;
            _password = builder.GetSection("ApiSetting:password").Value;
            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;


        }
        public async Task Autenticar()
        {
            var cliente = new HttpClient();
            cliente.BaseAddress=new System.Uri(_baseUrl);
            var credenciales = new Credencial() { IdUsuario = _usuario, Contrasena=_password };
            var content = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("api/Autentificacion", content);
            var json_respuesta=await response.Content.ReadAsStringAsync();
            _token = json_respuesta;
        }

        public async Task<List<OrdenDetalle>> GetById(int id)
        {
            List<OrdenDetalle> orden = new List<OrdenDetalle>();
            await Autenticar();
            var cliente = new HttpClient();
            cliente.BaseAddress = new System.Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
            var response = await cliente.GetAsync("api/Orden/"+id);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<List<OrdenDetalle>>(json_respuesta);
                orden = respuesta;

            }
            return orden;
        }

        public async Task<List<Orden>> GetOrden()
        {
            List<Orden> listaorden = new List<Orden>();
            await Autenticar();
            var cliente=new HttpClient();
            cliente.BaseAddress = new System.Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",_token);
            var response = await cliente.GetAsync("api/Orden");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<List<Orden>>(json_respuesta);
                listaorden = respuesta;

            }
            return listaorden;
        }
    }
}
