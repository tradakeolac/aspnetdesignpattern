using Agathas.Storefront.Core.Quering;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Repository.NHibernate.Extensions
{
    public static class QueryExtensions
    {
        public static ICriteria TranslateIntoNHQuery<T>(this Query query, ICriteria criteria)
        {
            BuildQueryFrom(query, criteria);
            if (query.OrderByProperty != null)
                criteria.AddOrder(new Order(query.OrderByProperty.PropertyName,
                !query.OrderByProperty.Desc));
            return criteria;
        }
        private static void BuildQueryFrom(Query query, ICriteria criteria)
        {
            IList<ICriterion> criterions = new List<ICriterion>();
            if (query.Criteria != null)
            {
                foreach (Criterion c in query.Criteria)
                {
                    ICriterion criterion;
                    switch (c.CriteriaOperator)
                    {
                        case CriteriaOperator.Equal:
                            criterion = Expression.Eq(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.LessThanOrEqual:
                            criterion = Expression.Le(c.PropertyName, c.Value);
                            break;
                        default:
                            throw new ApplicationException("No operator defined");
                    }
                    criterions.Add(criterion);
                }
                if (query.QueryOperator == QueryOperator.And)
                {
                    Conjunction andSubQuery = Expression.Conjunction();
                    foreach (ICriterion criterion in criterions)
                    {
                        andSubQuery.Add(criterion);
                    }
                    criteria.Add(andSubQuery);
                }
                else
                {
                    Disjunction orSubQuery = Expression.Disjunction();
                    foreach (ICriterion criterion in criterions)
                    {
                        orSubQuery.Add(criterion);
                    }
                    criteria.Add(orSubQuery);
                }
                foreach (Query sub in query.SubQueries)
                {
                    BuildQueryFrom(sub, criteria);
                }
            }
        }
    }
}
