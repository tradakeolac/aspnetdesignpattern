using ASPNETPatterns.Chap6.EventTickets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNETPatterns.Chap6.EventTickets.DataContract;
using ASPNETPatterns.Chap6.EventTickets.Repository;
using ASPNETPatterns.Chap6.EventTickets.Model;

namespace ASPNETPatterns.Chap6.EventTickets.Service
{
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TicketService : ITicketService
    {
        private IEventRepository _eventRepository;
        private static MessageResponseHistory<PurchaseTicketResponse> _reservationResponse = new MessageResponseHistory<PurchaseTicketResponse>();

        public TicketService(IEventRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        public TicketService() : this(new EventRepository())
        {

        }

        public PurchaseTicketResponse PurchaseTicket(PurchaseTicketRequest purchaseTicketRequest)
        {
            PurchaseTicketResponse response = new PurchaseTicketResponse();

            try
            {
                // Check for a duplicate transaction using the Idempotent pattern;
                // the Domain Logic could cope but you can't be sure.
                if(_reservationResponse.IsAUniqueRequest(purchaseTicketRequest.CorrelationId))
                {
                    TicketPurchase ticket;
                    Event eventEntity = this._eventRepository.FindBy(new Guid(purchaseTicketRequest.EventId));

                    if(eventEntity.CanPurchaseTicketWith(new Guid(purchaseTicketRequest.ReservationId)))
                    {
                        ticket = eventEntity.PurchaseTicketWith(new Guid(purchaseTicketRequest.ReservationId));

                        this._eventRepository.Save(eventEntity);

                        response = ticket.ConvertToPurchaseTicketResponse();
                        response.Success = true;
                    }
                    else
                    {
                        response = _reservationResponse.RetrievePreviousResponseFor(purchaseTicketRequest.CorrelationId);
                    }
                }
            }
            catch(Exception ex)
            {
                // Shield exceptions
                response.Message = ErrorLog.GenerateErrorRefMessageAndLog(ex);
                response.Success = false;
            }

            return response;
        }

        public ReserveTicketResponse ReserveTicket(ReserveTicketRequest reserveTicketRequest)
        {
            ReserveTicketResponse response = new ReserveTicketResponse();

            try
            {
                Event eventEntity = this._eventRepository.FindBy(new Guid(reserveTicketRequest.EventId));
                TicketReservation reservation;

                if(eventEntity.CanReserveTicket(reserveTicketRequest.TicketQuantity))
                {
                    reservation = eventEntity.ReserveTicket(reserveTicketRequest.TicketQuantity);
                    this._eventRepository.Save(eventEntity);
                    response = reservation.ConvertToReserveTicketResponse();
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = string.Format("There are {0} ticket(s) available.", eventEntity.AvailableLocation());
                }
            }
            catch(Exception ex)
            {
                // Shield exception
                response.Message = ErrorLog.GenerateErrorRefMessageAndLog(ex);
                response.Success = false;
            }

            return response;
        }
    }
}
