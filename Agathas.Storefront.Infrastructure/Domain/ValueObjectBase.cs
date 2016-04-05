using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Core.Domain
{
    public abstract class ValueObjectBase
    {
        private List<BusinessRule> _brokenRules = new List<BusinessRule>();

        public ValueObjectBase() { }

        protected abstract void Validate();

        public void ThrowExceptionIfInvalid()
        {
            this._brokenRules.Clear();
            this.Validate();
            if(this._brokenRules.Count > 0)
            {
                StringBuilder issues = new StringBuilder();
                foreach (var businessRule in this._brokenRules)
                    issues.AppendLine(businessRule.Rule);

                throw new ValueObjectIsInvalidException(issues.ToString());
            }
        }
    }
}
