using ASPNETPatterns.Chap6.EventTickets.Contracts;
using ASPNETPatterns.Chap6.EventTickets.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap6.EventTickets.ServiceProxy
{
    public class TicketServiceFacade
    {
        private ITicketService _ticketService;

        public TicketServiceFacade(ITicketService ticketService)
        {
            this._ticketService = ticketService;
        }

        public TicketReservationPresentation ReserveTicketsFor(string eventId, int noOfTickets)
        {
            TicketReservationPresentation reservation = new TicketReservationPresentation();
            ReserveTicketRequest request = new ReserveTicketRequest()
            {
                EventId = eventId,
                TicketQuantity = noOfTickets
            };

            ReserveTicketResponse response = this._ticketService.ReserveTicket(request);

            if(response.Success)
            {
                reservation.TicketWasSuccessfullyReserved = true;
                reservation.ReservationId = response.ReservationNumber;
                reservation.ExpiryDate = response.ExpirationDate;
                reservation.EventId = response.EventId;
                reservation.Description = string.Format("{0} ticket(s) reserved for {1}.<br/>" +
                    "<small>This reservation will expire on {2} at {3}.</small>", response.NoOfTickets
                    , response.EventName, response.ExpirationDate.ToLongDateString(), response.ExpirationDate.ToLongTimeString());
            }
            else
            {
                reservation.TicketWasSuccessfullyReserved = false;
                reservation.Description = response.Message;
            }

            return reservation;
        }

        public TicketPresentation PurchaseReservedTicket(string eventId, string reservationId)
        {
            TicketPresentation ticket = new TicketPresentation();
            PurchaseTicketResponse response = new PurchaseTicketResponse();
            PurchaseTicketRequest request = new PurchaseTicketRequest();
            request.ReservationId = reservationId;
            request.EventId = eventId;
            request.CorrelationId = reservationId;
            response = this._ticketService.PurchaseTicket(request);

            if(response.Success)
            {
                ticket.Description = string.Format("{0} ticket(s) purchased for {1}.<br/>" +
                                                    "<small>YOur e-tickets id is {2}.</small>", response.NoOfTickets, response.EventName, response.TicketId);
                ticket.EventId = response.EventId;
                ticket.TicketId = response.TicketId;
                ticket.WasAbleToPurchaseTicket = true;
            }
            else
            {
                ticket.WasAbleToPurchaseTicket = false;
                ticket.Description = response.Message;
            }

            return ticket;
        }
    }
}
