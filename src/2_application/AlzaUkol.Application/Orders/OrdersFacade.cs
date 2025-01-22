using AlzaUkol.Application._Shared.Db;
using AlzaUkol.Application._Shared.Error;
using AlzaUkol.Application.Orders.DTOs;
using AlzaUkol.Application.Orders.Models;
using Microsoft.EntityFrameworkCore;

namespace AlzaUkol.Application.Orders;

public class OrdersFacade
{
    private readonly OrdersRepository _ordersRepo;

    public OrdersFacade(OrdersRepository ordersRepo)
    {
        _ordersRepo = ordersRepo;
    }
    
    public async Task<int> CreateOrder(OrderIN inputDTO)
    {
        // validate
        inputDTO.Validate();

        // create order
        Order order = Order.Create(inputDTO);

        using (AppDbContext dbContext = new AppDbContext())
        {
            // save to db
            int id = await _ordersRepo.InsertAsync(dbContext, order);

            // return id
            return id;
        }
    }

    public async Task<List<OrderForListOUT>> ListOrders()
    {
        using (AppDbContext dbContext = new AppDbContext())
        {
            // get all orders
            List<OrderForListOUT> list = await _ordersRepo.GetOrdersForListAsync(dbContext);

            // return list
            return list;
        }
    }

    public async Task UpdateOrderPaymentInfo(OrderPaymentInfoIN inputDTO)
    {
        using (AppDbContext dbContext = new AppDbContext())
        {
            // get order by id
            Order? order = await _ordersRepo.GetById(dbContext, inputDTO.OrderId);
            if (order == null)
                throw ErrorEx.ApplicationError($"Order with id: '{inputDTO.OrderId}' was not found.");

            // update payment info
            order.UpdatePaymentInfo(inputDTO.Paid);

            // save to db
            await dbContext.SaveChangesAsync();
        }
    }
}
