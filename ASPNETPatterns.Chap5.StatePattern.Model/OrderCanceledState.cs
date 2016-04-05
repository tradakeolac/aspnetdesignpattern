using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.StatePattern.Model
{
    public class OrderCanceledState : IOrderState
    {
        public OrderStatus Status
        {
            get { return OrderStatus.Canceled; }
        }

        public bool CanCancel(Order order)
        {
            return false;
        }

        public void Cancel(Order order)
        {
            throw new NotImplementedException("This order is already cancelled!");
        }

        public bool CanShip(Order order)
        {
            return true;
        }

        public void Ship(Order order)
        {
            throw new NotImplementedException("You can't ship a canceled order!");
        }
    }
}
