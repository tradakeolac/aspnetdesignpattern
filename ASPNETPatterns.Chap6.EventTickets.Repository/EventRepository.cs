using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNETPatterns.Chap6.EventTickets.Model;

namespace ASPNETPatterns.Chap6.EventTickets.Repository
{
    public class EventRepository : IEventRepository
    {
        public Event FindBy(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Event eventEntity)
        {
            throw new NotImplementedException();
        }
    }
}
