﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap6.EventTickets.DataContract
{
    [DataContract]
    public class ReserveTicketRequest
    {
        [DataMember]
        public string EventId { get; set; }

        [DataMember]
        public int TicketQuantity { get; set; }
    }
}
