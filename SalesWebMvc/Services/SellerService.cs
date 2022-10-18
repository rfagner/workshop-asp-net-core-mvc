using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Lista de Sellers
        /// </summary>
        /// <returns>Lista de Sellers</returns>
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        /// <summary>
        /// Cadastrar um Seller no banco
        /// </summary>
        /// <param name="obj">Dados do vendedor</param>
        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
