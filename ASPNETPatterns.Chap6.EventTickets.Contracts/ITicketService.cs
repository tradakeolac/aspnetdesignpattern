using ASPNETPatterns.Chap6.EventTickets.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap6.EventTickets.Contracts
{
    [ServiceContract(Namespace = "ASPNETPatterns.Chap6.EventTickets/")]
    public interface ITicketService
    {
        [OperationContract()]
        ReserveTicketResponse ReserveTicket(ReserveTicketRequest reserveTicketRequest);

        [OperationContract()]
        PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest purchaseTicketRequest);
    }
}
