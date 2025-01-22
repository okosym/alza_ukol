using AlzaUkol.Application._Shared.Db;
using AlzaUkol.Application.Orders.DTOs;
using AlzaUkol.Application.Orders.Models;
using Microsoft.EntityFrameworkCore;

namespace AlzaUkol.Application.Orders;

public class OrdersRepository
{
    public async Task<int> InsertAsync(AppDbContext dbContext, Order order)
    {
        dbContext.Orders.Add(order);
        await dbContext.SaveChangesAsync();
        return order.Id;
    }

    public async Task<List<OrderForListOUT>> GetOrdersForListAsync(AppDbContext dbContext)
    {
        List<OrderForListOUT> list = await dbContext.Orders
            .Select(order => new OrderForListOUT
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                State = order.State,
                TotalPrice = order.Items.Sum(item => item.PricePerItem * item.Count)
            })
            .ToListAsync();

        return list;
    }

    public async Task<Order?> GetById(AppDbContext dbContext, int id)
    {
        Order? order = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
        return order;
    }
}
