using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.Core.Domain
{
    public abstract class EntityBase<TId> : AggregateRoot
    {
        private List<BusinessRule> _brokenRules = new List<BusinessRule>();

        public TId Id { get; set; }

        protected abstract void Validate();

        public IEnumerable<BusinessRule> GetBrokenRules()
        {
            this._brokenRules.Clear();
            this.Validate();
            return this._brokenRules;
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            this._brokenRules.Add(businessRule);
        }

        public override bool Equals(object entity)
        {
            return entity != null && entity is EntityBase<TId> && this == (EntityBase<TId>)entity;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> left, EntityBase<TId> right)
        {
            if ((object)left == null && (object)right == null)
                return true;

            if ((object)left == null || (object)right == null)
                return false;

            if (left.Id.ToString() == right.Id.ToString())
                return true;

            return false;
        }

        public static bool operator !=(EntityBase<TId> left, EntityBase<TId> right)
        {
            return (!(left == right));
        }
    }
}
