using Microsoft.AspNetCore.Mvc;

namespace ShopEase.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        db_handler db_handler = new db_handler();

        [HttpPost("AddOrder")]
        public async Task<int> AddOrder(Order new_order)
        {
            try
            {
                return await db_handler.AddAsync(new OrderViewModel
                {
                    ConsumerId = new_order.ConsumerId,
                    ProductId = new_order.ProductId,
                    Quantity = new_order.Quantity,
                    Price = new_order.Price,
                    TotalAmount = new_order.TotalAmount
                });
            }
            catch { }
            return -1;
        }

        [HttpPut("UpdateOrder")]
        public async Task<int> UpdateOrder(Order edited_order)
        {
            try
            {
                return await db_handler.UpdateAsync(new OrderViewModel
                {
                    Id = edited_order.Id,
                    ConsumerId = edited_order.ConsumerId,
                    ProductId = edited_order.ProductId,
                    Quantity = edited_order.Quantity,
                    Price = edited_order.Price,
                    TotalAmount = edited_order.TotalAmount,
                    Status = edited_order.Status,
                    OrderDate = edited_order.OrderDate
                });
            }
            catch { }
            return -1;
        }
    }
}
