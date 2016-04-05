using ASPNETPatterns.Chap7.ProxyPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.ProxyPattern.Repository
{
    public class CustomerProxy : Customer
    {
        private bool _haveLoadedOrders = false;
        private IEnumerable<Order> _orders;

        public IOrderRepository OrderRepository { get; set; }

        public bool HaveLoadedOrders() => this._haveLoadedOrders;

        public override IEnumerable<Order> Orders
        {
            get
            {
                if(!this.HaveLoadedOrders())
                {
                    this.RetrieveOrders();
                }

                return this._orders;
            }

            set
            {
                base.Orders = value;
            }
        }

        private void RetrieveOrders()
        {
            this._orders = this.OrderRepository.FindAllBy(base.Id);
            this._haveLoadedOrders = true;
        }
    }
}
