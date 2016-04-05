using ASPNETPatterns.Chap7.ProxyPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.ProxyPattern.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IOrderRepository _orderRepository;
        public CustomerRepository(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public Customer FindBy(Guid id)
        {
            Customer customer = new CustomerProxy();

            // Code to connect to the database and retrieve a customer...

            ((CustomerProxy)customer).OrderRepository = this._orderRepository;

            return customer;
        }
    }
}
