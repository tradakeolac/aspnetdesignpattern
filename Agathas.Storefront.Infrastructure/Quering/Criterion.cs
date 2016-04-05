using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Core.Quering
{
    public class Criterion
    {
        private readonly string _propertyName;
        private readonly object _value;
        private readonly CriteriaOperator _criteriaOperator;

        public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator)
        {
            this._propertyName = propertyName;
            this._value = value;
            this._criteriaOperator = criteriaOperator;
        }

        public string PropertyName { get { return this._propertyName; } }
        public object Value { get { return this._value; } }
        public CriteriaOperator CriteriaOperator { get { return this._criteriaOperator; } }

        public static Criterion Create<T>(Expression<Func<T, object>> expression, object value, CriteriaOperator criteriaOperator)
        {
            var propertyName = PropertyNameHelper.ResolvePropertyName<T>(expression);
            var criteria = new Criterion(propertyName, value, criteriaOperator);
            return criteria;
        }
    }
}
