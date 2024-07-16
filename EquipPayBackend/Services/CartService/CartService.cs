using AutoMapper;
using EquipPayBackend.Context;
using EquipPayBackend.DTOs.CartDTO;
using EquipPayBackend.Models;
using EquipPayBackend.Services.Tools;

namespace EquipPayBackend.Services.CartService
{
    public class CartService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IToolsService _toolsService;
        public CartService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<Cart> AddToCart(AddToCartDTO DTO)
        //{

        //    var user = await _context.UserAccounts.FindAsync(DTO.CustomerId);
        //    var recipe = await _context.Recipes.FindAsync(DTO.RecipeId);
        //    var order = new Cart
        //    {
        //        IsPaid = false,

        //    };
        //}
    }
}
