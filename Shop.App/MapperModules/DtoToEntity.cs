using AutoMapper;
using Shop.Domain.DataAccess.DTO;
using Shop.Domain.Models;

namespace Shop.MapperModules
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<PhotoDTO, Photo>();
            CreateMap<ProductDTO, Product>();
            CreateMap<ProductTypeDTO, ProductType>();
            CreateMap<ShopingCartItemDto, ShopingCartItem>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderItemDTO, OrderItem>();
        }
    }

    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<Photo, PhotoDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductType, ProductTypeDTO>();
            CreateMap<ShopingCartItem, ShopingCartItemDto>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderItem, OrderItemDTO>();

            CreateMap<OrderItem, ShopingCartItem>();
            CreateMap<ShopingCartItem, OrderItem>();
        }
    }
}