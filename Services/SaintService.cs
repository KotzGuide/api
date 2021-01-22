﻿using Api.Context;
using Api.Core;
using Api.Core.Helpers;
using Api.Models;
using Api.Services.Dtos;
using Api.Services.Dtos.Saint;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class SaintService
    {
        private readonly DBContext _context;
        private readonly ErrorContext _errorContext;
        public SaintService(DBContext context, ErrorContext errorContext)
        {
            _context = context;
            _errorContext = errorContext;
        }

        public async Task<int> Insert(InsertSaintDto dto)
        {
            try
            {
                var model = dto.ToModel();
                if (!model.Validate(_errorContext))
                    return -1;

                await _context.Saints.AddAsync(model);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch (Exception e)
            {
                _errorContext.AddError(Messages.DEFAULT_USER_MESSAGE, e.Message + "\n\n" + e.StackTrace);
                return -1;
            }
        }

        public async Task<SaintModel> Get(int id)
        {
            try
            {
                return await _context.Saints.SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                _errorContext.AddError(Messages.DEFAULT_USER_MESSAGE, e.Message + "\n\n" + e.StackTrace);
                return null;
            }
        }
    }
}
