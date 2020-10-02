using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.DataAccess.DTO;
using Shop.Domain.DataAccess.Interfaces;
using Shop.Domain.Models;

namespace Shop.Domain.DataAccess.Implementations
{
    public class ShopCartRepository : IShopCartRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ShopCartRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShopingCartItem> GetAsync(int id)
        {
            var item = await _context.ShopingCart.FindAsync(id);
            return item;
        }

        public async Task<IList<ShopingCartItem>> GetByUser(string id)
        {
            return (await _context.ShopingCart.ToListAsync()).Where(x => x.UserId == id).ToList();
        }

        public async Task<IList<ShopingCartItem>> ClearByUser(string id)
        {
        var items= (await _context.ShopingCart.ToListAsync()).Where(x => x.UserId == id).ToList();
        _context.ShopingCart.RemoveRange(items);
        return items;
        }

        public async Task<ShopingCartItem> CreateAsync(ShopingCartItemDto entity)
        {
            var cartItem = _mapper.Map<ShopingCartItem>(entity);
            if (cartItem == null) return null;
            var entityEntry = await _context.ShopingCart.AddAsync(cartItem);
            return entityEntry.Entity;
        }

        public async Task<ShopingCartItem> EditAsync(int id, ShopingCartItemDto entity)
        {
            _context.Entry(await _context.ShopingCart.FirstOrDefaultAsync(x => x.Id == id)!).CurrentValues
                .SetValues(entity);
            var comment = await _context.ShopingCart.FindAsync(id);
            return comment;
        }

        public async Task<ShopingCartItem> Delete(ShopingCartItemDto entity)
        {
            var item = _context.ShopingCart.Remove(await _context.ShopingCart.FindAsync(entity.Id)).Entity;
            return item;
        }

        public async Task<ShopingCartItem> Delete(int id)
        {
            var product = await _context.ShopingCart.FindAsync(id);
            if (product != null)
            {
                var item = _context.ShopingCart.Remove(product);
                return item.Entity;
            }
            else
            {
                return null;
            }

        }
    }
}