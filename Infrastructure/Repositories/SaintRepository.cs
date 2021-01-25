using Data.Dtos.Saint;
using Data.Interfaces;
using Domain.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using NikCore;
using NikCore.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SaintRepository : ISaintRepository
    {
        private readonly DBContext _context;
        private readonly ErrorContext _errorContext;

        public SaintRepository(DBContext context, ErrorContext errorContext)
        {
            _context = context;
            _errorContext = errorContext;
        }

        public async Task<SaintModel> Get(int id)
        {
            try
            {
                return await _context.Saints.SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                _errorContext.AddError(UserMessages.DEFAULT, e);
                return null;
            }
        }

        public async Task<List<SaintModel>> GetAll()
        {
            try
            {
                var list = await _context.Saints.ToListAsync();
                return list;
            }
            catch (Exception e)
            {
                _errorContext.AddError(UserMessages.DEFAULT, e);
                return null;
            }
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
                _errorContext.AddError(UserMessages.DEFAULT, e.Message + "\n\n" + e.StackTrace);
                return -1;
            }
        }
    }
}
