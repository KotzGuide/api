using Api.Core;
using Api.Services;
using Api.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaintController : BaseController
    {
        private readonly SaintService _service;

        public SaintController(SaintService service)
        {
            _service = service; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return SuccessData(await _service.Get());
        }
        
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertSaintDto dto)
        {
            return SuccessData(await _service.Insert(dto));
        }
    }
}
