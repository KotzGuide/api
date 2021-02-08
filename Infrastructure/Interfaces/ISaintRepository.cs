using Data.Dtos.Saint;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ISaintRepository
    {
        Task<List<SaintModel>> GetAll(bool? name, bool? constellation, bool? rank);
        Task<SaintModel> Get(int id);
        Task<int> Insert(InsertSaintDto dto);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateSaintDto dto);
    }
}
