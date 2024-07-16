using AutoMapper;
using EquipPayBackend.Context;
using EquipPayBackend.DTOs.Order;
using EquipPayBackend.DTOs.RecipeDTO;
using EquipPayBackend.Models;
using EquipPayBackend.Services.Tools;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EquipPayBackend.Services.OrdersService
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) throw new KeyNotFoundException("Order Not Found");

            return order;
        }

        public async Task<Order> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) throw new KeyNotFoundException("Recipe Not Found");
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;

        }

        //public async Task<Order> PlaceOrder(PlaceOrderDTO DTO)
        //{
            
        //    var user = await _context.UserAccounts.FindAsync(DTO.CustomerId);
        //    var order = new Order
        //    {
        //        User = user,
        //        CustomerId = DTO.CustomerId,
        //        OrderDate = DateTime.Now,
        //        Location = DTO.Location,
        //    };
        //}

        public async Task<Recipe> UpdateRecipe(UpdateRecipeDTO DTO)
        {
            var recipe = await _context.Recipes
                                .Where(ro => ro.Id == DTO.Id)
                                .FirstOrDefaultAsync();
            if (recipe == null) throw new KeyNotFoundException("Recipe Not Found");
            recipe = _mapper.Map(DTO, recipe);
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }
    }
}
