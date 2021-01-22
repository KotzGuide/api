using Api.Core;
using Api.Services;
using Api.Services.Dtos.Cosmo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class CosmoController : BaseController
    {
        private readonly CosmoService _service;
        public CosmoController(CosmoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int id)
        {
            return SuccessData(await _service.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertCosmoDto dto)
        {
            return SuccessData(await _service.Insert(dto));
        }
    }
}
