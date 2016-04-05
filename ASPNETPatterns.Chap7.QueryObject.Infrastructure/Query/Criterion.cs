using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.QueryObject.Infrastructure.Query
{
    public class Criterion
    {
        private string _propertyName;
        private object _value;
        private CriteriaOperator _criteriaOperator;

        public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator)
        {
            this._propertyName = propertyName;
            this._value = value;
            this._criteriaOperator = criteriaOperator;
        }

        public string PropertyName { get { return this._propertyName; }
        }

        public object Value { get { return this._value; } }

        public CriteriaOperator CriteriaOperator { get { return this._criteriaOperator; } }
    }
}
