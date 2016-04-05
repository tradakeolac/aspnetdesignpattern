using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap6.EventTickets.Model
{
    public class Event
    {
        public Event()
        {
            this.ReservedTickets = new List<TicketReservation>();
            this.PurchasedTickets = new List<TicketPurchase>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Allocation { get; set; }
        public List<TicketReservation> ReservedTickets { get; set; }
        public List<TicketPurchase> PurchasedTickets { get; set; }

        public int AvailableLocation()
        {
            var salesAndReservations = this.PurchasedTickets.Sum(t => t.TicketQuantity);

            salesAndReservations += ReservedTickets.FindAll(r => r.StillActive()).Sum(r => r.TicketQuantity);
            return this.Allocation - salesAndReservations;
        }

        public bool CanPurchaseTicketWith(Guid reservationId)
        {
            if (this.HasReservationWith(reservationId))
                return this.GetReservationWith(reservationId).StillActive();

            return false;
        }

        public TicketPurchase PurchaseTicketWith(Guid reservationId)
        {
            if (!this.CanPurchaseTicketWith(reservationId))
                throw new ApplicationException(this.DetermiteWhyATicketCannotBePurchasedWith(reservationId));

            TicketReservation reservation = this.GetReservationWith(reservationId);

            TicketPurchase ticket = TicketPurchaseFactory.CreateTicket(this, reservation.TicketQuantity);

            reservation.HasBeenRedeemed = true;

            this.PurchasedTickets.Add(ticket);

            return ticket;
        }

        public TicketReservation GetReservationWith(Guid reservationId)
        {
            if (!HasReservationWith(reservationId))
                throw new ApplicationException(string.Format("No reservation ticket with matching id of '{0'", reservationId.ToString()));

            return this.ReservedTickets.FirstOrDefault(r => r.Id == reservationId);
        }

        private bool HasReservationWith(Guid reservationId)
        {
            return this.ReservedTickets.Any(r => r.Id == reservationId);
        }

        public string DetermiteWhyATicketCannotBePurchasedWith(Guid reservationId)
        {
            string reservationIssue = "";
            if (this.HasReservationWith(reservationId))
            {
                TicketReservation reservation = this.GetReservationWith(reservationId);
                if (reservation.HasExpired())
                    reservationIssue = string.Format("Ticket reservation '{0}' has expired", reservationId.ToString());
                else if (reservation.HasBeenRedeemed)
                    reservationIssue = string.Format("Ticket reservation '{0}' has already been redeemed", reservationId);
            }
            else
            {
                reservationIssue = string.Format("There is no ticket reservation with the Id '{0}'", reservationId);
            }

            return reservationIssue;
        }

        private void ThrowExceptionWithDetailsOnWhyTicketsCannotBeReserved()
        {
            throw new ApplicationException("There are no tickets available to reservel");
        }

        public bool CanReserveTicket(int quantity)
        {
            return this.AvailableLocation() >= quantity;
        }

        public TicketReservation ReserveTicket(int ticketQuantity)
        {
            if (!this.CanReserveTicket(ticketQuantity))
                this.ThrowExceptionWithDetailsOnWhyTicketsCannotBeReserved();

            TicketReservation reservation = TicketReservationFactory.CreateReservation(this, ticketQuantity);

            this.ReservedTickets.Add(reservation);

            return reservation;
        }
    }
}