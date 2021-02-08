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
        public async Task<IActionResult> Get(
            [FromQuery] int? id, 
            [FromQuery] bool? name,
            [FromQuery] bool? constellation,
            [FromQuery] bool? rank
            )
        {
            if (id != null)
                return SuccessData(await repository.Get(id.Value));
            return SuccessList(await repository.GetAll(name, constellation, rank));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertSaintDto dto)
        {
            return SuccessId<int>(await repository.Insert(dto));
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            return SuccessData(await repository.Delete(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSaintDto dto)
        {
            return SuccessData(await repository.Update(dto));
        }
    }
}
