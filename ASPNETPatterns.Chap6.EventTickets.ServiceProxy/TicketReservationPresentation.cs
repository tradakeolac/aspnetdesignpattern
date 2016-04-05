using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap6.EventTickets.ServiceProxy
{
    public class TicketReservationPresentation
    {
        public string EventId { get; set; }
        public string ReservationId { get; set; }
        public string Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool TicketWasSuccessfullyReserved { get; set; }
    }
}
