using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.LayerSuperType.Model
{
    public abstract class EntityBase<T>
    {
        private T _id;
        private IList<string> _brokenRules = new List<string>();
        private bool _idHasBeenSet = false;

        public EntityBase()
        {

        }

        public EntityBase(T id)
        {
            this.Id = id;
        }

        public T Id
        {
            get { return _id; }
            set
            {
                if (this._idHasBeenSet)
                    ThrowExceptionIfOverwritingAnId();

                this._id = value;
                this._idHasBeenSet = true;
            }
        }

        private void ThrowExceptionIfOverwritingAnId()
        {
            throw new ApplicationException("You cannot change the id of an entity.");
        }

        public bool IsValid ()
        {
            this.ClearCollectionOfBrokenRules();
            this.CheckForBrokenRules();
            return this._brokenRules.Count == 0;
        }

        protected abstract void CheckForBrokenRules();

        private void ClearCollectionOfBrokenRules()
        {
            this._brokenRules.Clear();
        }

        public IEnumerable<string> GetBrokenBusinessRules()
        {
            return this._brokenRules;
        }

        protected void AddBrokenRule(string brokenRule)
        {
            this._brokenRules.Add(brokenRule);
        }
    }
}
