using ASPNETPatterns.Chap6.EventTickets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ASPNETPatterns.Chap6.EventTickets.DataContract;

namespace ASPNETPatterns.Chap6.EventTickets.ServiceProxy
{
    public class TicketServiceClientProxy : ClientBase<ITicketService>, ITicketService
    {
        public PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest purchaseTicketRequest)
        {
            return base.Channel.PurchaseTicket(purchaseTicketRequest);
        }

        public ReserveTicketResponse ReserveTicket(ReserveTicketRequest reserveTicketRequest)
        {
            return base.Channel.ReserveTicket(reserveTicketRequest);
        }
    }
}
