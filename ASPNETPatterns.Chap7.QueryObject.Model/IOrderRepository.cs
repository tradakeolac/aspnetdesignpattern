using ASPNETPatterns.Chap7.QueryObject.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.QueryObject.Model
{
    public interface IOrderRepository
    {
        IEnumerable<Order> FindBy(Query query);
    }
}
