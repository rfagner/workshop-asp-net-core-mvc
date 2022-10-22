using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class SalesRecordServices
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordServices(SalesWebMvcContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Operação assíncrona que busca registro de vendas por data
        /// </summary>
        /// <param name="minDate">Data mínima</param>
        /// <param name="maxDate">Data máxima</param>
        /// <returns>Registro de vendas por data</returns>
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            // Join
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
