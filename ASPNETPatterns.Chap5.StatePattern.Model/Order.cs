using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.StatePattern.Model
{
    public class Order
    {
        private IOrderState _orderState;

        public Order(IOrderState baseState)
        {
            this._orderState = baseState;
        }

        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime OrderedDate { get; set; }
        public OrderStatus Status ()
        {
            return this._orderState.Status;
        }

        public bool CanCancel()
        {
            return this._orderState.CanCancel(this);
        }

        public void Cancel()
        {
            if (this.CanCancel())
                this._orderState.Cancel(this);
        }

        public bool CanShip()
        {
            return this._orderState.CanShip(this);
        }

        public void Ship()
        {
            if (this.CanShip())
                this._orderState.Ship(this);
        }

        internal void Change(IOrderState orderState)
        {
            this._orderState = orderState;
        }
    }
}
