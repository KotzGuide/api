using Api.Context;
using Api.Core;
using Api.Core.Helpers;
using Api.Models;
using Api.Services.Dtos.Cosmo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Api.Services
{
    public class CosmoService
    {
        private readonly DBContext _context;
        private readonly ErrorContext _errorContext;
        public CosmoService(DBContext context, ErrorContext errorContext)
        {
            _context = context;
            _errorContext = errorContext;
        }

        public async Task<int> Insert(InsertCosmoDto dto)
        {
            try
            {
                var model = dto.ToModel();
                if (!model.Validate(_errorContext))
                    return -1;

                await _context.Cosmos.AddAsync(model);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch (Exception e)
            {
                _errorContext.AddError(Messages.DEFAULT_USER_MESSAGE, e.Message + "\n\n" + e.StackTrace);
                return -1;
            }
        }public async Task<CosmoModel> Get(int id)
        {
            try
            {
                return await _context.Cosmos.SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                _errorContext.AddError(Messages.DEFAULT_USER_MESSAGE, e.Message + "\n\n" + e.StackTrace);
                return null;
            }
        }
    }
}
