using Data.Dtos.Saint;
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
    public class SaintController : BaseController
    {
        private readonly ISaintRepository repository;

        public SaintController(ISaintRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? id)
        {
            if (id != null)
                return SuccessData(await repository.Get(id.Value));
            return SuccessList(await repository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertSaintDto dto)
        {
            return SuccessData(await repository.Insert(dto));
        }
    }
}
