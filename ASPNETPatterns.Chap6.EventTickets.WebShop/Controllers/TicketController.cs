using ASPNETPatterns.Chap6.EventTickets.ServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETPatterns.Chap6.EventTickets.WebShop.Controllers
{
    public class TicketController : Controller
    {
        private TicketServiceFacade _ticketServiceFacade;

        public TicketController()
        {
            this._ticketServiceFacade = new TicketServiceFacade(new TicketServiceClientProxy());
        }

        // GET: Ticket
        public ActionResult Index()
        {
            TicketReservationPresentation reservation = this._ticketServiceFacade.ReserveTicketsFor("Event1", 1);
            return View();
        }
    }
}