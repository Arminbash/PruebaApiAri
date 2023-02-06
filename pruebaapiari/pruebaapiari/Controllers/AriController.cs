using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaapiari.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AriController : ControllerBase
    {
        private readonly ILogger<AriController> _logger;

        public AriController(ILogger<AriController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ListAriRequest Get(string userId)
        {
            var listRequest = new List<AriRequest>();

            listRequest.Add(new AriRequest("OT-001", "Johnny Arcia", 1234, "Corte", userId));
            listRequest.Add(new AriRequest("OT-002", "Byron Fonseca",2345,"Corte", userId));
            listRequest.Add(new AriRequest("OT-003", "Test usuario", 3456, "Corte", userId));
            listRequest.Add(new AriRequest("OT-004", "Test usuario", 3456, "Corte", userId));
            listRequest.Add(new AriRequest("OT-005", "Test usuario", 3456, "Corte", userId));
            listRequest.Add(new AriRequest("OT-006", "Test usuario", 3456, "Corte", userId));
            listRequest.Add(new AriRequest("OT-007", "Test usuario", 3456, "Corte", userId));
            listRequest.Add(new AriRequest("OT-008", "Test usuario", 3456, "Corte", userId));
            listRequest.Add(new AriRequest("OT-009", "Test usuario", 3456, "Corte", userId));
            listRequest.Add(new AriRequest("OT-010", "Test usuario", 3456, "Corte", userId));
            listRequest.Add(new AriRequest("OT-011", "Test 1", 7891, "Reconexion", userId));
            listRequest.Add(new AriRequest("OT-012", "Test 2", 7891, "Reconexion", userId));
            listRequest.Add(new AriRequest("OT-013", "Test 3", 7891, "Reconexion", userId));
            listRequest.Add(new AriRequest("OT-014", "Test 3", 7891, "Reconexion", userId));
            listRequest.Add(new AriRequest("OT-015", "Test 3", 7891, "Reconexion", userId));
            listRequest.Add(new AriRequest("OT-016", "Test 3", 7891, "Reconexion", userId));
            listRequest.Add(new AriRequest("OT-017", "Test 3", 7891, "Reconexion", userId));
            listRequest.Add(new AriRequest("OT-018", "Test 3", 7891, "Reconexion", userId));
            listRequest.Add(new AriRequest("OT-019", "Test 3", 7891, "Reconexion", userId));
            listRequest.Add(new AriRequest("OT-020", "Test 3", 7891, "Reconexion", userId));
            return new ListAriRequest(listRequest);
        }
    }
    public class ListAriRequest
    {
        public ListAriRequest(List<AriRequest> request) 
        {
            orders = request;
        }
        public List<AriRequest> orders { get; set; }
    }

    public class AriRequest
    {
        public AriRequest(string _numeroOrden, string _nombre, int _numeroMedidor, string _tipoFlujo, string _idUsuario)
        {
            numeroOrden= _numeroOrden;
            numeroMedidor = _numeroMedidor;
            nombre= _nombre;
            numeroMedidor = (int)_numeroMedidor;
            tipoFlujo= _tipoFlujo;
            idUsuario= _idUsuario;
        }

        public string numeroOrden { get; set; }

        public string nombre { get; set; }

        public int numeroMedidor { get; set; }

        public string tipoFlujo { get; set; }
        public string idUsuario { get; set; }
    }
}
