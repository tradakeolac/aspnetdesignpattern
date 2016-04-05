using ASPNETPatterns.Chap7.IdentityMap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.IdentityMap.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IdentityMap<Employee> _employeeMap;

        public EmployeeRepository()
        {
            this._employeeMap = new IdentityMap<Employee>();
        }

        public Employee FindBy(Guid id)
        {
            Employee employee = this._employeeMap.GetById(id);

            if(employee == null)
            {
                employee = this.DataStoreFindBy(id);
                if (employee != null)
                    this._employeeMap.Store(employee, employee.Id);
            }

            return employee;
        }

        private Employee DataStoreFindBy(Guid id)
        {
            Employee employee = default(Employee);

            // Code to hydrate employee from datastore...

            return employee;
        }
    }
}
