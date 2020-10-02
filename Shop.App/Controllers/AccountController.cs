using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Shop.Domain.DataAccess.DTO;
using Shop.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shop.App.Models;
using Shop.Domain.DataAccess.Interfaces;

namespace Shop.Client.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(IMapper mapper, IUnitOfWork uow, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _uow = uow;
            _userManager = userManager;
            //_products = new List<OrderItemDTO>();
        }
        public async Task<IActionResult> Order()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var items = await _uow.ShopCartRepository.GetByUser(user.Id);
            if (items.Count == 0) return Redirect("~/Products/Index");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Order([FromBody] OrderViewModel order)
        {
            try
            {
                if (order.CreditCard.Trim() != string.Empty && order.Address.Trim() != string.Empty &&
                    order.City.Trim() != string.Empty && order.FIO.Trim() != string.Empty &&
                    order.CardHoldersName.Trim() != string.Empty &&order.CardExpMonth.Trim() != string.Empty &&
                    order.Ccv.Trim() != string.Empty &&order.Email != string.Empty )
                {


                    _uow.BeginTransaction();

                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    var items = await _uow.ShopCartRepository.GetByUser(user.Id);
                    var ordersItems = _mapper.Map<List<OrderItem>>(items);
                    var data = new Order
                    {
                        UserId = user.Id,
                        Orders = ordersItems,
                        Address = order.Address,
                        CardExpMonth = order.CardExpMonth,
                        CardHoldersName = order.CardHoldersName,
                        Ccv = order.Ccv,
                        City = order.City,
                        CreditCard = order.CreditCard,
                        Email = order.Email,
                        FIO = order.FIO,
                    };
                    await _uow.OrderRepository.CreateAsync(_mapper.Map<OrderDTO>(data));
                    await _uow.ShopCartRepository.ClearByUser(user.Id);
                    _uow.Save();
                    _uow.Commit();
                    return Json(new {success = true, responseText = "Успех!"});
                }
                else
                {
                    return Json(new { success = false, responseText = "Заполните все поля." });

                }
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Console.WriteLine(e);
                return Json(new {success = false, responseText = "Ошибка сервера"});

            }

        }
        public async Task<IActionResult> Basket()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var items = await _uow.ShopCartRepository.GetByUser(user.Id);
            var dtos = _mapper.Map<IList<ShopingCartItemDto>>(items);
            return View(dtos);

        }


        [HttpPost]
        public async void Delete([FromBody] int data)
        {


            var item = await _uow.ShopCartRepository.Delete(data);
            if (item != null) _uow.Save();
        }


    }
}

