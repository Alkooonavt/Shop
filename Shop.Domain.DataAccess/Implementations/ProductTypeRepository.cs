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
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ProductTypeRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProductTypeDTO Get(int id)
        {
            var productType = _context.ProductTypes.Find(id);
            if (productType == null) return null;
            var productDto = _mapper.Map<ProductTypeDTO>(productType);
            return productDto;
        }

        public IList<ProductTypeDTO> GetAll()
        {
            var productTypes = _context.ProductTypes.ToList();
            var productTypeDtos = _mapper.Map<IList<ProductTypeDTO>>(productTypes);
            return productTypeDtos;
        }

        public ProductTypeDTO Create(ProductTypeDTO entity)
        {
            var productType = _mapper.Map<ProductType>(entity);
            if (productType == null) return null;
            var entityEntry = _context.ProductTypes.Add(productType);
            var productTypeDto = _mapper.Map<ProductTypeDTO>(entityEntry.Entity);
            return productTypeDto;
        }

        public ProductTypeDTO Edit(int id, ProductTypeDTO entity)
        {
            _context.Entry(_context.ProductTypes.FirstOrDefault(x => x.Id == id)!).CurrentValues
                .SetValues(entity);
            var productType = _context.ProductTypes.Find(id);
            var productTypeDto = _mapper.Map<ProductTypeDTO>(productType);
            return productTypeDto;
        }

        public ProductTypeDTO Delete(ProductTypeDTO entity)
        {
            var productType = _mapper.Map<ProductType>(entity);
            if (productType == null) return null;
            var entityEntry = _context.ProductTypes.Remove(productType);
            var productTypeDto = _mapper.Map<ProductTypeDTO>(entityEntry.Entity);
            return productTypeDto;
        }

        public async Task<ProductTypeDTO> GetAsync(int id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);
            if (productType == null) return null;
            var productTypeDto = _mapper.Map<ProductTypeDTO>(productType);
            return productTypeDto;
        }

        public async Task<IList<ProductTypeDTO>> GetAllAsync()
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
            var productTypeDtos = _mapper.Map<IList<ProductTypeDTO>>(productTypes);
            return productTypeDtos;
        }

        public async Task<ProductTypeDTO> CreateAsync(ProductTypeDTO entity)
        {

            var productType = _mapper.Map<ProductType>(entity);
            if (productType == null) return null;
            var entityEntry = await _context.ProductTypes.AddAsync(productType);
            var productTypeDto = _mapper.Map<ProductTypeDTO>(entityEntry.Entity);
            return productTypeDto;
        }

        public async Task<ProductTypeDTO> EditAsync(int id, ProductTypeDTO entity)
        {

            _context.Entry(await _context.Photos.FirstOrDefaultAsync(x => x.Id == id)!).CurrentValues
                .SetValues(entity);
            var productType = await _context.ProductTypes.FindAsync(id);
            var productTypeDto = _mapper.Map<ProductTypeDTO>(productType);
            return productTypeDto;
        }

    }
}