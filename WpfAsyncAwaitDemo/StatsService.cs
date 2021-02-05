using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAsyncAwaitDemo
{
    class StatsService
    {
        private IOrderRepository _orderRepository;

        public StatsService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        int GetTotalOrdersAmount()
        {
            var orders = _orderRepository.GetAll();
            var sum = 0;
            foreach (var order in orders)
            {
                sum += order.Amount;
            }

            return sum;
        }
    }

    interface IDb
    {
        IEnumerable<T> Query<T>(string sql);
    }

    class Order
    {
        public int Amount { get; }
    }

    interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
    }
    //class OrderRepository : IOrderRepository
    //{
    //    IEnumerable<Order>
    //}
}
