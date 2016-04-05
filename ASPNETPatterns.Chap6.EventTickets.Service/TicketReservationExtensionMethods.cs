using ASPNETPatterns.Chap6.EventTickets.DataContract;
using ASPNETPatterns.Chap6.EventTickets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap6.EventTickets.Service
{
    public static class TicketReservationExtensionMethods
    {
        public static ReserveTicketResponse ConvertToReserveTicketResponse(this TicketReservation ticketReservation)
        {
            return new ReserveTicketResponse()
            {
                EventId = ticketReservation.Event.Id.ToString(),
                EventName = ticketReservation.Event.Name,
                NoOfTickets = ticketReservation.TicketQuantity,
                ExpirationDate = ticketReservation.ExpiryTime,
                ReservationNumber = ticketReservation.Id.ToString()
            };
        }
    }
}
