using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Domain.Models;
using Shop.Domain.DataAccess.DTO;

namespace Shop.Domain.DataAccess.Interfaces
{
    public interface ICategoryRepository
    {
        CategoryDTO Get(int id);
        IList<CategoryDTO> GetAll();
        CategoryDTO Create(CategoryDTO entity);
        CategoryDTO Edit(int id, CategoryDTO entity);
        CategoryDTO Delete(CategoryDTO entity);
        Task<CategoryDTO> GetAsync(int id);
        Task<IList<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO> CreateAsync(CategoryDTO entity);
        Task<CategoryDTO> EditAsync(int id, CategoryDTO entity);
    }

    public interface IShopCartRepository
    {
        Task<ShopingCartItem> GetAsync(int id);
        Task<IList<ShopingCartItem>> GetByUser(string id);
        Task<IList<ShopingCartItem>> ClearByUser(string id);

        Task<ShopingCartItem> CreateAsync(ShopingCartItemDto entity);
        Task<ShopingCartItem> EditAsync(int id, ShopingCartItemDto entity);
        Task<ShopingCartItem> Delete(ShopingCartItemDto entity);
        Task<ShopingCartItem> Delete(int id);
    }
    public interface IComentRepository
    {
        Task<Comment> GetAsync(int id);
        Task<IList<Comment>> GetAllAsync();
        // Task<IList<Comment>> GetByProduct(int id);

        Task<Comment> CreateAsync(CommentDTO entity);
        Task<Comment> EditAsync(int id, CommentDTO entity);
        Task<Comment> Delete(CommentDTO entity);
    }
    public interface IOrderRepository
    {
        OrderDTO Get(int id);
        IList<OrderDTO> GetAll();
        OrderDTO Create(OrderDTO entity);
        OrderDTO Edit(int id, OrderDTO entity);
        OrderDTO Delete(OrderDTO entity);
        Task<OrderDTO> GetAsync(int id);
        Task<IList<OrderDTO>> GetAllAsync();
        Task<OrderDTO> CreateAsync(OrderDTO entity);
        Task<OrderDTO> EditAsync(int id, OrderDTO entity);
    }
    public interface IPhotoRepository
    {
        PhotoDTO Get(int id);
        IList<PhotoDTO> GetAll();
        PhotoDTO Create(PhotoDTO entity);
        PhotoDTO Edit(int id, PhotoDTO entity);
        PhotoDTO Delete(PhotoDTO entity);
        Task<PhotoDTO> GetAsync(int id);
        Task<IList<PhotoDTO>> GetAllAsync();
        Task<PhotoDTO> CreateAsync(PhotoDTO entity);
        Task<PhotoDTO> EditAsync(int id, PhotoDTO entity);
    }
    public interface IProductRepository
    {
        ProductDTO Get(int id);
        IList<ProductDTO> GetAll();
        ProductDTO Create(ProductDTO entity);
        ProductDTO Edit(int id, ProductDTO entity);
        ProductDTO Delete(ProductDTO entity);
        Task<ProductDTO> GetAsync(int id);
        Task<IList<ProductDTO>> GetAllAsync();
        Task<ProductDTO> CreateAsync(ProductDTO entity);
        Task<ProductDTO> EditAsync(int id, ProductDTO entity);
    }
    public interface IProductTypeRepository
    {
        ProductTypeDTO Get(int id);
        IList<ProductTypeDTO> GetAll();
        ProductTypeDTO Create(ProductTypeDTO entity);
        ProductTypeDTO Edit(int id, ProductTypeDTO entity);
        ProductTypeDTO Delete(ProductTypeDTO entity);
        Task<ProductTypeDTO> GetAsync(int id);
        Task<IList<ProductTypeDTO>> GetAllAsync();
        Task<ProductTypeDTO> CreateAsync(ProductTypeDTO entity);
        Task<ProductTypeDTO> EditAsync(int id, ProductTypeDTO entity);
    }
  
}