namespace Shop.Domain.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; set; }
        IPhotoRepository PhotoRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
        IProductTypeRepository ProductTypeRepository { get; set; }
        IOrderRepository OrderRepository { get; set; }
        IShopCartRepository ShopCartRepository { get; set; }
        IComentRepository ComentRepository { get; set; }
        void Save();

        void BeginTransaction();

        void Commit();

        void Rollback();
        void SaveAsync();
        category.name=dto.name
    }
}