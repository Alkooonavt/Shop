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
    public class PhotoRepository : IPhotoRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public PhotoRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PhotoDTO Get(int id)
        {
            var photo = _context.Photos.Find(id);
            if (photo == null) return null;
            var photoDto = _mapper.Map<PhotoDTO>(photo);
            return photoDto;
        }

        public IList<PhotoDTO> GetAll()
        {
            var photos = _context.Photos.ToList();
            var productsDto = _mapper.Map<IList<PhotoDTO>>(photos);
            return productsDto;
        }

        public PhotoDTO Create(PhotoDTO entity)
        {
            var photo = _mapper.Map<Photo>(entity);
            if (photo == null) return null;
            var entityEntry = _context.Photos.Add(photo);
            var photoDto = _mapper.Map<PhotoDTO>(entityEntry.Entity);
            return photoDto;
        }

        public PhotoDTO Edit(int id, PhotoDTO entity)
        {
            _context.Entry(_context.Photos.FirstOrDefault(x => x.Id == id)!).CurrentValues
                .SetValues(entity);
            var photo = _context.Photos.Find(id);
            var photoDto = _mapper.Map<PhotoDTO>(photo);
            return photoDto;
        }

        public PhotoDTO Delete(PhotoDTO entity)
        {
            var photo = _mapper.Map<Photo>(entity);
            if (photo == null) return null;
            var entityEntry = _context.Photos.Remove(photo);
            var photoDto = _mapper.Map<PhotoDTO>(entityEntry.Entity);
            return photoDto;
        }

        public async Task<PhotoDTO> GetAsync(int id)
        {
            var photo = await _context.Photos.FindAsync(id);
            if (photo == null) return null;
            var photoDto = _mapper.Map<PhotoDTO>(photo);
            return photoDto;
        }

        public async Task<IList<PhotoDTO>> GetAllAsync()
        {
            var photos = await _context.Photos.ToListAsync();
            var photoDtos = _mapper.Map<IList<PhotoDTO>>(photos);
            return photoDtos;
        }

        public async Task<PhotoDTO> CreateAsync(PhotoDTO entity)
        {

            var photo = _mapper.Map<Photo>(entity);
            if (photo == null) return null;
            var entityEntry = await _context.Photos.AddAsync(photo);
            var photoDto = _mapper.Map<PhotoDTO>(entityEntry.Entity);
            return photoDto;
        }

        public async Task<PhotoDTO> EditAsync(int id, PhotoDTO entity)
        {

            _context.Entry(await _context.Photos.FirstOrDefaultAsync(x => x.Id == id)!).CurrentValues
                .SetValues(entity);
            var photo = await _context.Photos.FindAsync(id);
            var photoDto = _mapper.Map<PhotoDTO>(photo);
            return photoDto;
        }

    }
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public OrderRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OrderDTO Get(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return null;
            var orderDto = _mapper.Map<OrderDTO>(order);
            return orderDto;
        }

        public IList<OrderDTO> GetAll()
        {
            var orders = _context.Orders.ToList();
            var orderDtos = _mapper.Map<IList<OrderDTO>>(orders);
            return orderDtos;
        }

        public OrderDTO Create(OrderDTO entity)
        {
            var order = _mapper.Map<Order>(entity);
            if (order == null) return null;
            var entityEntry = _context.Orders.Add(order);
            var orderDto = _mapper.Map<OrderDTO>(entityEntry.Entity);
            return orderDto;
        }

        public OrderDTO Edit(int id, OrderDTO entity)
        {
            _context.Entry(_context.Orders.FirstOrDefault(x => x.Id == id)!).CurrentValues
                .SetValues(entity);
            var order = _context.Orders.Find(id);
            var orderDto = _mapper.Map<OrderDTO>(order);
            return orderDto;
        }

        public OrderDTO Delete(OrderDTO entity)
        {
            var order = _mapper.Map<Order>(entity);
            if (order == null) return null;
            var entityEntry = _context.Orders.Remove(order);
            var orderDto = _mapper.Map<OrderDTO>(entityEntry.Entity);
            return orderDto;
        }

        public async Task<OrderDTO> GetAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return null;
            var orderDto = _mapper.Map<OrderDTO>(order);
            return orderDto;
        }

        public async Task<IList<OrderDTO>> GetAllAsync()
        {
            var orders = await _context.Photos.ToListAsync();
            var orderDtos = _mapper.Map<IList<OrderDTO>>(orders);
            return orderDtos;
        }

        public async Task<OrderDTO> CreateAsync(OrderDTO entity)
        {

            var order = _mapper.Map<Order>(entity);
            if (order == null) return null;
            var entityEntry = await _context.Orders.AddAsync(order);
            var orderDto = _mapper.Map<OrderDTO>(entityEntry.Entity);
            return orderDto;
        }

        public async Task<OrderDTO> EditAsync(int id, OrderDTO entity)
        {

            _context.Entry(await _context.Orders.FirstOrDefaultAsync(x => x.Id == id)!).CurrentValues
                .SetValues(entity);
            var order = await _context.Photos.FindAsync(id);
            var orderDto = _mapper.Map<OrderDTO>(order);
            return orderDto;
        }

    }
}