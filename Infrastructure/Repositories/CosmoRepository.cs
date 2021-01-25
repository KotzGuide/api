using Data.Dtos.Cosmo;
using Data.Interfaces;
using Domain.Enums;
using Domain.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using NikCore;
using NikCore.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CosmoRepository : ICosmoRepository
    {
        private readonly DBContext _context;
        private readonly ErrorContext _errorContext;

        public CosmoRepository(DBContext context, ErrorContext errorContext)
        {
            _context = context;
            _errorContext = errorContext;
        }
        public async Task<CosmoModel> Get(int id)
        {
            try
            {
                return await _context.Cosmos.SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                _errorContext.AddError(UserMessages.DEFAULT, e);
                return null;
            }
        }

        public async Task<List<CosmoModel>> GetAll()
        {
            throw new NotImplementedException();
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
                _errorContext.AddError(UserMessages.DEFAULT, e.Message + "\n\n" + e.StackTrace);
                return -1;
            }
        }

        public async Task<int> InsertCosmoSet(InsertCosmoSetDto dto)
        {
            try
            {
                var model = dto.ToModel();
                if (!model.Validate(_errorContext))
                    return -1;


                //var saint = await _saintService.Get(dto.SaintId);
                //if (saint == null)
                //{
                //    _errorContext.AddError("Cavaleiro não encontrado!", DeveloperMessages.NOT_FOUND);
                //    return -1;
                //}

                var solarCosmo = await Get(dto.SolarCosmoId);
                if (solarCosmo == null)
                    _errorContext.AddError("Cosmo solar não encontrado!", DeveloperMessages.NOT_FOUND);

                var lunarCosmo = await Get(dto.LunarCosmoId);
                if (solarCosmo == null)
                    _errorContext.AddError("Cosmo solar não encontrado!", DeveloperMessages.NOT_FOUND);

                var starCosmo = await Get(dto.StarCosmoId);
                if (solarCosmo == null)
                    _errorContext.AddError("Cosmo solar não encontrado!", DeveloperMessages.NOT_FOUND);

                var legendaryCosmo = await Get(dto.LegendaryCosmoId);
                if (solarCosmo == null)
                    _errorContext.AddError("Cosmo solar não encontrado!", DeveloperMessages.NOT_FOUND);

                if (_errorContext.HasError)
                    return -1;

                if (!CheckCosmoType(solarCosmo, CosmoType.Solar))
                    _errorContext.AddError($"Cosmo {solarCosmo.Name} não é Solar", DeveloperMessages.NOT_ALLOWED);

                if (!CheckCosmoType(lunarCosmo, CosmoType.Lunar))
                    _errorContext.AddError($"Cosmo {lunarCosmo.Name} não é Lunar", DeveloperMessages.NOT_ALLOWED);

                if (!CheckCosmoType(starCosmo, CosmoType.Star))
                    _errorContext.AddError($"Cosmo {starCosmo.Name} não é Estrela", DeveloperMessages.NOT_ALLOWED);

                if (!CheckCosmoType(legendaryCosmo, CosmoType.Legendary))
                    _errorContext.AddError($"Cosmo {legendaryCosmo.Name} não é Lendário", DeveloperMessages.NOT_ALLOWED);

                await _context.CosmoSets.AddAsync(model);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch (Exception e)
            {
                _errorContext.AddError(UserMessages.DEFAULT, e.Message + "\n\n" + e.StackTrace);
                return -1;
            }
        }

        private bool CheckCosmoType(CosmoModel model, CosmoType type) => model.CosmoType == type;
    }
}
