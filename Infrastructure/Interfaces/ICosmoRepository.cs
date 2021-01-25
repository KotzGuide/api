using Data.Dtos.Cosmo;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICosmoRepository
    {
        Task<List<CosmoModel>> GetAll();
        Task<CosmoModel> Get(int id);
        Task<int> Insert(InsertCosmoDto dto);
        Task<int> InsertCosmoSet(InsertCosmoSetDto dto);
    }
}
