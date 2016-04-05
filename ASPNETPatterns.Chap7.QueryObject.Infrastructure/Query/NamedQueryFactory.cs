using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.QueryObject.Infrastructure.Query
{
    public class NamedQueryFactory
    {
        public static Query CreateRetrieveOrdersUsingAComplexQuery(Guid customerId)
        {
            IList<Criterion> criteria = new List<Criterion>();
            var query = new Query(QueryName.RetrieveOrderUsingAComplexQuery, criteria);
            criteria.Add(new Criterion("CustomerId", customerId, CriteriaOperator.NotApplicable));

            return query;
        }
    }
}
