using System;
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
    //public class UserRepository : IUserRepository
    //{
    //    private readonly Context _context;
    //    private readonly IMapper _mapper;

    //    public UserRepository(Context context, IMapper mapper)
    //    {
    //        _context = context;
    //        _mapper = mapper;
    //    }

    //    public User Get(string loginEmail, string loginPassword)
    //    {
    //        var user =_context.Users.SingleOrDefault(x => x.Email == loginEmail && x.Password == loginPassword);
    //        return user;
    //    }

    //    public User Get(Guid id)
    //    {
    //        var user = _context.Users.Find(id);
    //        return user;
    //    }

    //    public IList<User> GetAll()
    //    {
    //        var users = _context.Users.ToList();
    //        return users;
    //    }

    //    public User Create(User entity)
    //    {
    //        if (entity == null) return null;
    //        var entityEntry = _context.Users.Add(entity);
    //        return entityEntry.Entity;
    //    }

    //    public User Edit(Guid id, User entity)
    //    {
    //        _context.Entry(_context.Users.FirstOrDefault(x => x.Id == id)!).CurrentValues
    //            .SetValues(entity);
    //        var user = _context.Users.Find(id);
    //        return user;
    //    }

    //    public User Delete(User entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public CategoryDTO Delete(CategoryDTO entity)
    //    {
    //        var category = _mapper.Map<Category>(entity);
    //        if (category == null) return null;
    //        var entityEntry = _context.Categories.Remove(category);
    //        var categoryDto = _mapper.Map<CategoryDTO>(entityEntry.Entity);
    //        return categoryDto;
    //    }

    //    public async Task<User> GetAsync(Guid id)
    //    {
    //        var user = await _context.Users.FindAsync(id);
    //        return user;
    //    }

    //    public async Task<User> GetAsync(string loginEmail, string loginPassword)
    //    {
    //        var user = await _context.Users.SingleOrDefaultAsync(x =>
    //            x.Email == loginEmail && loginPassword == x.Password);
    //        return user;
    //    }

    //    public async Task<IList<User>> GetAllAsync()
    //    {
    //        var users = await _context.Users.ToListAsync();
    //        return users;
    //    }

    //    public async Task<User> CreateAsync(User entity)
    //    {

    //        if (entity == null) return null;
    //        var entityEntry = await _context.Users.AddAsync(entity);
    //        return entityEntry.Entity;
    //    }

    //    public async Task<User> EditAsync(Guid id, User entity)
    //    {

    //        _context.Entry(await _context.Users.FirstOrDefaultAsync(x => x.Id == id)!).CurrentValues
    //            .SetValues(entity);
    //        var user = await _context.Users.FindAsync(id);
    //        return user;
    //    }

    //}
}