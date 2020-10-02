using System.Collections.Generic;
using Shop.Domain.Models;
using Shop.Domain.DataAccess.Interfaces;

namespace Shop.Domain.DataAccess.Implementations
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public ICategoryRepository CategoryRepository { get; set; }
        public IPhotoRepository PhotoRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IProductTypeRepository ProductTypeRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        //   public IUserRepository UserRepository { get; set; }
        public IComentRepository ComentRepository { get; set; }
        public IShopCartRepository ShopCartRepository { get; set; }


        public EFUnitOfWork(ICategoryRepository categoryRepository,
            IPhotoRepository photoRepository,
            IProductRepository productRepository,
            IProductTypeRepository productTypeRepository, IOrderRepository orderRepository, IComentRepository comentRepository,
            IShopCartRepository shopCartRepository, Context context)
        {
            CategoryRepository = categoryRepository;
            PhotoRepository = photoRepository;
            ProductRepository = productRepository;
            ProductTypeRepository = productTypeRepository;
            OrderRepository = orderRepository;
            ComentRepository = comentRepository;
            ShopCartRepository = shopCartRepository;
            _context = context;

            var categories = new List<Category>()
                { new Category {Id = 1, Name = "Футболки" },
                  new Category {Id = 2, Name = "Куртки" },
                  new Category {Id = 3, Name = "Брюки" }
                };
            var photo = new List<Photo>
            {
                new Photo()
                    {Id = 1, Url = "https://images.satu.kz/46090190_futbolki-muzhskie.jpg", Alt = "Футболка"}, new Photo()
                    {Id = 2, Url = "https://images.satu.kz/46090190_futbolki-muzhskie.jpg", Alt = "Футболка"}
            };
            var photosTypes = new List<ProductType>()
            {
                new ProductType() {Id = 1, Size = "Xl"},
                new ProductType() {Id = 2, Size = "X"},
                new ProductType() {Id = 3, Size = "L"}
            };
            var products = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Обычная футболка", Category = categories[0], Count = 50,
                    Description = "Обычные футболки для всех", Price = 500,
                    Photos = photo,
                    ProductTypes =photosTypes
                },
                new Product
                {
                    Id = 2,
                    Name = "НеОбычная футболка", Category = categories[0], Count = 50,
                    Description = "НеОбычные футболки для всех", Price = 500,
                    Photos =  photo,
                    ProductTypes =photosTypes
                },
                new Product
                {
                    Id = 3,
                    Name = "Обычная куртка",Category = categories[1],Count = 50,Description = "Обычные куртки для всех",Price = 500,
                    Photos =  photo,
                    ProductTypes =photosTypes
                },
                new Product
                  {
                      Id = 4,
                      Name = "Необычная куртка",Category = categories[1],Count = 50,Description = "необычная куртка для всех",Price = 500,
                      Photos =  photo,
                      ProductTypes =photosTypes
                  },
                new Product
                {
                    Id = 5,
                    Name = "Обычный брюк", Category = categories[2], Count = 50,
                    Description = "Обычные брюки для всех", Price = 500,
                    Photos =  photo,
                    ProductTypes =photosTypes
                },
                new Product
                {
                    Id = 6,
                    Name = "Необынчый брюк", Category = categories[2], Count = 50,
                    Description = "неОбычные брюки для всех", Price = 500,
                    Photos =  photo,
                    ProductTypes =photosTypes
                }
            };
            //  _context.Users.AddRange(_people);
          // _context.Products.AddRange(products);
            //      _context.SaveChanges();

        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.Database?.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database?.CommitTransaction();
        }

        public void Rollback()
        {
            _context.Database?.RollbackTransaction();
        }

        public async void SaveAsync()
        {
            await _context.SaveChangesAsync();
        }



    }
}