using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.StatePattern.Model
{
    public class OrderShippedState : IOrderState
    {
        public OrderStatus Status
        {
            get
            {
                return OrderStatus.Shipped;
            }
        }

        public bool CanCancel(Order order)
        {
            return false;
        }

        public void Cancel(Order order)
        {
            throw new NotImplementedException();
        }

        public bool CanShip(Order order)
        {
            return false;
        }

        public void Ship(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
