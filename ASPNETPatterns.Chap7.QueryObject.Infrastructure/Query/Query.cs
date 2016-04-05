using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.QueryObject.Infrastructure.Query
{
    public class Query
    {
        private QueryName _name;
        private IList<Criterion> _criteria;

        public Query() : this(QueryName.Dynamic, new List<Criterion>())
        {

        }

        public Query(QueryName name, IList<Criterion> criteria)
        {
            this._name = name;
            this._criteria = criteria;
        }

        public QueryName Name { get { return this._name; } }

        public bool IsNamedQuery() => this.Name != QueryName.Dynamic;

        public IEnumerable<Criterion> Criteria { get { return this._criteria; } }

        public void Add(Criterion criterion)
        {
            if (!IsNamedQuery())
                this._criteria.Add(criterion);
            else
                throw new ApplicationException("You cannot add additional criteria to named queries.");
        }

        public QueryOperator QueryOperator { get; set; }

        public OrderByClause OrderByProperty { get; set; }
    }
}
