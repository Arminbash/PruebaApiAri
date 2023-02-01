﻿using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<AriRequest> Get(string userId)
        {
            var listRequest = new List<AriRequest>();

            listRequest.Add(new AriRequest("001", "Johnny Arcia", 1234, "Corte", userId));
            listRequest.Add(new AriRequest("002", "Byron Fonseca", 2345, "Corte", userId));
            listRequest.Add(new AriRequest("003", "Test usuario", 3456, "reconexion", userId));
            listRequest.Add(new AriRequest("004", "Test 2", 7891, "reconexion", userId));
            return listRequest.ToArray();
        }
    }

    public class AriRequest
    {
        public AriRequest(string _numeroOrden, string _nombre, int _numeroMedidor, string _tipoFlujo, string _idUsuario)
        {
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
