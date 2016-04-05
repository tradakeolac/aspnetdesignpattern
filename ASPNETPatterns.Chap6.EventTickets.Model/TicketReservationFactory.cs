using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap6.EventTickets.Model
{
    public class TicketReservationFactory
    {
        public static TicketReservation CreateReservation(Event _event, int ticketQuantity)
        {
            TicketReservation reservation = new TicketReservation()
            {
                Id = Guid.NewGuid(),
                Event = _event,
                ExpiryTime = DateTime.Now.AddMinutes(1),
                TicketQuantity = ticketQuantity
            };

            return reservation;
        }
    }
}
