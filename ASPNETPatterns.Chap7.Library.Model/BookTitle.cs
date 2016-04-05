using ASPNETPatterns.Chap7.UnitOfWork.Infrastructure;

namespace ASPNETPatterns.Chap7.Library.Model
{
    public class BookTitle : IAggregateRoot
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
    }
}
