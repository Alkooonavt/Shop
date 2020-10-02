using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.DataAccess.DTO;
using Shop.Domain.DataAccess.Interfaces;
using Shop.Domain.Models;

namespace Shop.Domain.DataAccess.Implementations
{
    public class ComentRepository : IComentRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ComentRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Comment> GetAsync(int id)
        {
            return await _context.Coments.FindAsync(id);
        }

        //public async Task<IList<Comment>> GetByProduct(int id)
        //{
        //    return await _context.Coments.Where(x => x.Product.Id == id).ToListAsync();
        //}
        public async Task<IList<Comment>> GetAllAsync()
        {
            return await _context.Coments.ToListAsync();
        }

        public async Task<Comment> CreateAsync(CommentDTO entity)
        {
            var product = _mapper.Map<Comment>(entity);
            var item = await _context.Coments.AddAsync(product);
            return item.Entity;
        }

        public async Task<Comment> EditAsync(int id, CommentDTO entity)
        {
            _context.Entry(await _context.Coments.FirstOrDefaultAsync(x => x.Id == id)!).CurrentValues
                .SetValues(entity);
            var comment = await _context.Coments.FindAsync(id);
            return comment;
        }

        public async Task<Comment> Delete(CommentDTO entity)
        {
          var item=_context.Coments.Remove(await _context.Coments.FindAsync(entity.Id)).Entity;
          return item;
        }
    }
}