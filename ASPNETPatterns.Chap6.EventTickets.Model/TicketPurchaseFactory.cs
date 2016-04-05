using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap6.EventTickets.Model
{
    public class TicketPurchaseFactory
    {
        public static TicketPurchase CreateTicket(Event Event, int ticketQuantity)
        {
            TicketPurchase ticket = new TicketPurchase
            {
                Id = Guid.NewGuid(),
                Event = Event,
                TicketQuantity = ticketQuantity
            };
            return ticket;
        }
    }
}
