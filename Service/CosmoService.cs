using Domain.Enums;
using Domain.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using NikCore;
using NikCore.Helpers;
using Service.Dtos.Cosmo;
using System;
using System.Threading.Tasks;

namespace Service
{
    public class CosmoService
    {
        private readonly DBContext _context;
        private readonly ErrorContext _errorContext;
        private readonly SaintService _saintService;

        public CosmoService(DBContext context, ErrorContext errorContext, SaintService saintService)
        {
            _context = context;
            _errorContext = errorContext;
            _saintService = saintService;
        }
   
        
        
        //Cosmo Sets

        public async Task<int> InsertCosmoSet(InsertCosmoSetDto dto)
        {
            
        }
        
    }
}
