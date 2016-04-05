using ASPNETPatterns.Chap7.QueryObject.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.QueryObject.Repository
{
    public static class OrderQueryTranslator
    {
        private static string baseSelectQuery = "SELECT * FROM Orders ";

        public static void TranslateInto(this Query query, SqlCommand command)
        {
            if(query.IsNamedQuery())
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = query.Name.ToString();

                foreach(var criterion in query.Criteria)
                {
                    command.Parameters.Add(new SqlParameter("@" + criterion.PropertyName, criterion.Value));
                }
            }
            else
            {
                StringBuilder sqlQuery = new StringBuilder();
                sqlQuery.Append(baseSelectQuery);

                bool _isNotFirstFilterClause = false;

                if (query.Criteria.Count() > 0)
                    sqlQuery.Append("WHERE ");

                foreach(Criterion criterion in query.Criteria)
                {
                    if (!_isNotFirstFilterClause)
                        sqlQuery.Append(GetQueryOperator(query));

                    sqlQuery.Append(AddFilterClauseFrom(criterion));

                    command.Parameters.Add(new SqlParameter("@" + criterion.PropertyName, criterion.Value));

                    _isNotFirstFilterClause = true;
                }

                sqlQuery.Append(GenerateOrderByCluaseFrom(query.OrderByProperty));

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = sqlQuery.ToString();
            }
        }

        private static string GenerateOrderByCluaseFrom(OrderByClause orderByClause)
        {
            return string.Format("ORDER BY {0} {1}", FindTableColumnFor(orderByClause.PropertyName), orderByClause.Desc ? "DESC" : "ASC");
        }

        private static string GetQueryOperator(Query query)
        {
            if (query.QueryOperator == QueryOperator.And)
                return "AND ";
            return "OR ";
        }

        private static string AddFilterClauseFrom(Criterion criterion)
        {
            return string.Format("{0} {1} {2} ",
                FindTableColumnFor(criterion.PropertyName),
                FindSQLOperatorFor(criterion.CriteriaOperator),
                criterion.PropertyName);
        }

        private static string FindSQLOperatorFor(CriteriaOperator criteriaOperator)
        {
            switch(criteriaOperator)
            {
                case CriteriaOperator.Equal:
                    return "=";
                case CriteriaOperator.LessthanOrEqual:
                    return "<=";
                default:
                    throw new ApplicationException("No operator defined.");
            }
        }

        private static string FindTableColumnFor(string propertyName)
        {
            switch(propertyName)
            {
                case "CustomerId":
                    return "CustomerId";
                case "OrderDate":
                    return "OrderDate";
                default:
                    throw new ApplicationException("No column defined for this property.");
            }
        }
    }
}
