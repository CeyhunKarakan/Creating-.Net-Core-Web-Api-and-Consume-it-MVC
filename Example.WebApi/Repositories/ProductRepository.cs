using Example.WebApi.Data;
using Example.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContex _context;

        public ProductRepository(ProductContex context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var removedEntity = await _context.Products.FindAsync(id);
            _context.Products.Remove(removedEntity);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            var unchangedEntity = await _context.Products.FindAsync(product.Id);
            _context.Entry(unchangedEntity).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
        }
    }
}
