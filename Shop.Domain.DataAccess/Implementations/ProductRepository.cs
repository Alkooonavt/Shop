    using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.DataAccess.DTO;
using Shop.Domain.DataAccess.Interfaces;

namespace Shop.Domain.DataAccess.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ProductRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProductDTO Get(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return null;
            var productDto = _mapper.Map<ProductDTO>(product);
            return productDto;
        }

        public IList<ProductDTO> GetAll()
        {
            var products = _context.Products.ToList();
            var productsDto = _mapper.Map<IList<ProductDTO>>(products);
            return productsDto;
        }

        public ProductDTO Create(ProductDTO entity)
        {
            var map = _mapper.Map<Product>(entity);
            if (map == null) return null;
            var entityEntry = _context.Products.Add(map);
            var productDto = _mapper.Map<ProductDTO>(entityEntry.Entity);
            return productDto;
        }

        public ProductDTO Edit(int id, ProductDTO entity)
        {
            _context.Entry(_context.Products.FirstOrDefault(x => x.Id == id)!).CurrentValues
                .SetValues(entity);
            var product = _context.Products.Find(id);
            var productDto = _mapper.Map<ProductDTO>(product);
            return productDto;
        }

        public ProductDTO Delete(ProductDTO entity)
        {
            var product = _mapper.Map<Product>(entity);
            if (product == null) return null;
            var entityEntry = _context.Products.Remove(product);
            var productDto = _mapper.Map<ProductDTO>(entityEntry.Entity);
            return productDto;
        }

        public async Task<ProductDTO> GetAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;
            var productDto = _mapper.Map<ProductDTO>(product);
            return productDto;
        }

        public async Task<IList<ProductDTO>> GetAllAsync()
        {
            var products =  await _context.Products.ToListAsync();
            var productDtos = _mapper.Map<IList<ProductDTO>>(products);
            return productDtos;
        }

        public async Task<ProductDTO> CreateAsync(ProductDTO entity)
        {

            var map = _mapper.Map<Product>(entity);
            if (map == null) return null;
            var entityEntry = await _context.Products.AddAsync(map);
            var productDto = _mapper.Map<ProductDTO>(entityEntry.Entity);
            return productDto;
        }

        public async Task<ProductDTO> EditAsync(int id, ProductDTO entity)
        {

            var item = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            item.Category = entity.Category;
            item.ProductTypes = entity.ProductTypes;
            item.Count = entity.Count;
            item.Comments = entity.Comments;
            item.Price = item.Price;
            item.Name = entity.Name;
            item.Description = entity.Description;
            var result= _context.Products.Update(item).Entity;
            //_context.Entry(item).CurrentValues.SetValues(entity);
            var product = await _context.Products.FindAsync(id);
            var productDto = _mapper.Map<ProductDTO>(product);
            return productDto;
        }

    }
}