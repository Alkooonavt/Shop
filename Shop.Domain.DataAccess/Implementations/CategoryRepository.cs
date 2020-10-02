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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public CategoryRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CategoryDTO Get(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return null;
            var categoryDto = _mapper.Map<CategoryDTO>(category);
            return categoryDto;
        }

        public IList<CategoryDTO> GetAll()
        {
            var categories = _context.Categories.ToList();
            var categoriesDto = _mapper.Map<IList<CategoryDTO>>(categories);
            return categoriesDto;
        }

        public CategoryDTO Create(CategoryDTO entity)
        {
            var category = _mapper.Map<Category>(entity);
            if (category == null) return null;
            var entityEntry = _context.Categories.Add(category);
            var categoryDto = _mapper.Map<CategoryDTO>(entityEntry.Entity);
            return categoryDto;
        }

        public CategoryDTO Edit(int id, CategoryDTO entity)
        {
            _context.Entry(_context.Categories.FirstOrDefault(x => x.Id == id)!).CurrentValues
                .SetValues(entity);
            var category = _context.Categories.Find(id);
            var categoryDto = _mapper.Map<CategoryDTO>(category);
            return categoryDto;
        }

        public CategoryDTO Delete(CategoryDTO entity)
        {
            var category = _mapper.Map<Category>(entity);
            if (category == null) return null;
            var entityEntry = _context.Categories.Remove(category);
            var categoryDto = _mapper.Map<CategoryDTO>(entityEntry.Entity);
            return categoryDto;
        }

        public async Task<CategoryDTO> GetAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return null;
            var categoryDto = _mapper.Map<CategoryDTO>(category);
            return categoryDto;
        }

        public async Task<IList<CategoryDTO>> GetAllAsync()
        {
            var categories =await _context.Categories.ToListAsync();
            var categoriesDto = _mapper.Map<IList<CategoryDTO>>(categories);
            return categoriesDto;
        }

        public async Task<CategoryDTO> CreateAsync(CategoryDTO entity)
        {

            var category = _mapper.Map<Category>(entity);
            if (category == null) return null;
            var entityEntry = await _context.Categories.AddAsync(category);
            var categoryDto = _mapper.Map<CategoryDTO>(entityEntry.Entity);
            return categoryDto;
        }

        public async Task<CategoryDTO> EditAsync(int id, CategoryDTO entity)
        {

            _context.Entry(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id)!).CurrentValues
                .SetValues(entity);
            var category =await _context.Categories.FindAsync(id);
            var categoryDto = _mapper.Map<CategoryDTO>(category);
            return categoryDto;
        }

    }
}