using Data.Dtos.Saint;
using Data.Interfaces;
using Domain.Enums;
using Domain.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using NikCore;
using NikCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<SaintModel>> GetAll(bool? name, bool? constellation, bool? rank)
        {
            try
            {
                List<SaintModel> list;
                if(name != null)
                {
                    if(name.Value)
                        list = await _context.Saints.OrderBy(x => x.Name).ToListAsync();
                    else
                        list = await _context.Saints.OrderByDescending(x => x.Name).ToListAsync();
                }
                else if (constellation != null)
                {
                    if (constellation.Value)
                        list = await _context.Saints.OrderBy(x => x.Constellation).ToListAsync();
                    else
                        list = await _context.Saints.OrderByDescending(x => x.Constellation).ToListAsync();
                }
                else if(rank != null)
                {
                    if (rank.Value)
                        list = await _context.Saints.OrderByDescending(x => x.Rank).ToListAsync();
                    else
                        list = await _context.Saints.OrderBy(x => x.Rank).ToListAsync();
                }
                else
                {
                    list = await _context.Saints.ToListAsync();
                }
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
                _errorContext.AddError(UserMessages.DEFAULT, e);
                return -1;
            }
        }
    
        public async Task<bool> Delete(int id)
        {
            try
            {
                var saint = await _context.Saints.SingleOrDefaultAsync(x => x.Id == id);
                if(saint == null)
                {
                    _errorContext.AddError("Cavaleiro não encontrado!", "Cavaleiro não encontrado");
                    return false;
                }
                _context.Saints.Remove(saint);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _errorContext.AddError(UserMessages.DEFAULT, e);
                return false;
            }
        }
    
        public async Task<bool> Update(UpdateSaintDto dto)
        {
            try
            {
                var foundModel = await _context.Saints.FindAsync(dto.Id);
                if(foundModel == null)
                {
                    _errorContext.AddError(UserMessages.NOT_FOUND, "Cavaleiro não encontrado");
                    return false;
                }

                foundModel.Update(dto.Name, dto.Constellation, dto.Description, (Rank)dto.Rank);
                if(!foundModel.Validate(_errorContext))
                    return false;

                _context.Update(foundModel);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _errorContext.AddError(UserMessages.DEFAULT, e);
                return false;
            }
        }
    }
}
