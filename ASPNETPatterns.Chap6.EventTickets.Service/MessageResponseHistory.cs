using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap6.EventTickets.Service
{
    public class MessageResponseHistory<T>
    {
        private Dictionary<string, T> _responseHistory;

        public MessageResponseHistory()
        {
            this._responseHistory = new Dictionary<string, T>();
        }

        public bool IsAUniqueRequest(string correlationId)
        {
            return !this._responseHistory.ContainsKey(correlationId);
        }

        public void LogResponse(string correlationId, T response)
        {
            if (this._responseHistory.ContainsKey(correlationId))
                this._responseHistory[correlationId] = response;
            else
                this._responseHistory.Add(correlationId, response);
        }

        public T RetrievePreviousResponseFor(string correlationId)
        {
            return this._responseHistory[correlationId];
        }
    }
}
