using ASPNETPatterns.Chap6.EventTickets.DataContract;
using ASPNETPatterns.Chap6.EventTickets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap6.EventTickets.Service
{
    public static class TicketPurchaseExtensionMethods
    {
        public static PurchaseTicketResponse ConvertToPurchaseTicketResponse(this TicketPurchase ticketPurchase)
        {
            return new PurchaseTicketResponse()
            {
                TicketId = ticketPurchase.Id.ToString(),
                EventName = ticketPurchase.Event.Name,
                EventId = ticketPurchase.Event.Id.ToString(),
                NoOfTickets = ticketPurchase.TicketQuantity
            };
        }
    }
}
