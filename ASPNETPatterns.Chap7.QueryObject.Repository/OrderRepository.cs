using ASPNETPatterns.Chap7.QueryObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNETPatterns.Chap7.QueryObject.Infrastructure.Query;
using System.Data.SqlClient;

namespace ASPNETPatterns.Chap7.QueryObject.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private string _connectionString;

        public OrderRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public IEnumerable<Order> FindBy(Query query)
        {
            IList<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                query.TranslateInto(command);
                connection.Open();

                using (SqlDataReader reder = command.ExecuteReader())
                {
                    while(reder.Read())
                    {
                        orders.Add(new Order()
                        {
                            CustomerId = new Guid(reder["CustomerId"].ToString()),
                            OrderDate = DateTime.Parse(reder["OrderDate"].ToString()),
                            Id = new Guid(reder["Id"].ToString())
                        });
                    }
                }
            }

            return orders;
        }
    }
}
