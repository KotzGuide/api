﻿using Api.Core;
using Api.Core.Attributes;
using Api.Services;
using Api.Services.Dtos;
using Api.Services.Dtos.Saint;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class SaintController : BaseController
    {
        private readonly SaintService _service;

        public SaintController(SaintService service)
        {
            _service = service; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int id)
        {
            return SuccessData(await _service.Get(id));
        }

        [TypeFilter(typeof(BearerAttribute))]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertSaintDto dto)
        {
            return SuccessData(await _service.Insert(dto));
        }
    }
}
