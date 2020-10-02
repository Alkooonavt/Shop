using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.App.Models;
using Shop.Domain.DataAccess.DTO;
using Shop.Domain.DataAccess.Interfaces;
using Shop.Domain.Models;

namespace Shop.Client.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        public ProductsController(IMapper mapper, IUnitOfWork uow, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _uow = uow;
            _userManager = userManager;
        }
        // GET: ProductsController
        public async Task<ActionResult> Index(int page = 1)
        {
            int pageSize = 9;
            var item = (await _uow.ProductRepository.GetAllAsync()).Where(x => x.Count > 0);
            var count = item.Count();
            var items = item.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageDto pageDto = new PageDto(count, page, pageSize);
            IndexDto index = new IndexDto
            {
                Page = pageDto,
                Products = items
            };
            return View(index);
        }

        // GET: ProductsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == 0) return NotFound();
            var item = await _uow.ProductRepository.GetAsync(id);
            return View(item);
        }

        [HttpPost]
        [Authorize]
        public async void AddToBasket([FromBody] ChooseTypeDTO data)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null) return;
            var product = await _uow.ProductRepository.GetAsync(data.Id);
            await _uow.ShopCartRepository.CreateAsync(new ShopingCartItemDto()
            {
                ChooseType = data.SelectedType,
                Name = product.Name,
                Price = product.Price,
                ProductId = product.Id,
                UserId = user.Id
            });
            _uow.Save();
        }

        public async void AddComents(int id, [FromBody] CommentDTO data)
        {
            var item = await _uow.ProductRepository.GetAsync(id);
            item.Comments.Add(new Comment { Body = data.Body, CreationPost = data.CreationPost, Name = data.Name });
            var result = _uow.ProductRepository.EditAsync(id, item);
            _uow.Save();
        }
        [Authorize]
        [HttpPost]
        public async Task AddComment(Comment data)
        {
            await _uow.ComentRepository.CreateAsync(_mapper.Map<CommentDTO>(data));
            _uow.SaveAsync();

        }
    }
}
