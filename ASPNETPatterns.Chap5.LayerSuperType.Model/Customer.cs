using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap5.LayerSuperType.Model
{
    public class Customer : EntityBase<long>
    {
        public Customer(long id):base(id)
        {

        }

        protected override void CheckForBrokenRules()
        {
            if (string.IsNullOrEmpty(this.FirstName))
                base.AddBrokenRule("You must supply a first name.");

            if (string.IsNullOrEmpty(this.LastName))
                base.AddBrokenRule("You must supply a last name.");
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
