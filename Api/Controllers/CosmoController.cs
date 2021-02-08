using Data.Dtos.Cosmo;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using NikCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class CosmoController : BaseController
    {
        private readonly ICosmoRepository repository;

        public CosmoController(ICosmoRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int id)
        {
            return SuccessData(await repository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertCosmoDto dto)
        {
            return SuccessData(await repository.Insert(dto));
        }

        [HttpPost]
        [Route("CosmoSet")]
        public async Task<IActionResult> InsertCosmoSet([FromBody] InsertCosmoSetDto dto)
        {
            return SuccessData(await repository.InsertCosmoSet(dto));
        }
    }
}
