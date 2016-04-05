using ASPNETPatterns.Chap6.EventTickets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap6.EventTickets.Repository
{
    public interface IEventRepository
    {
        Event FindBy(Guid id);
        void Save(Event eventEntity);
    }
}
