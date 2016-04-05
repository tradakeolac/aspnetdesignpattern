using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Core.Quering
{
    public class Query
    {
        private readonly IList<Query> _subQueries = new List<Query>();
        private readonly IList<Criterion> _criteria = new List<Criterion>();

        public IEnumerable<Criterion> Criteria { get { return this._criteria; } }
        public IEnumerable<Query> SubQueries { get { return this._subQueries; } }
        public QueryOperator QueryOperator { get; set; }
        public OrderByClause OrderByProperty { get; set; }

        public void AddSubQuery(Query query) => this._subQueries.Add(query);
        public void Add(Criterion criteria) => this._criteria.Add(criteria);

    }
}
