using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.IdentityMap.Repository
{
    public class IdentityMap<T>
    {
        Hashtable entities = new Hashtable();

        public T GetById(Guid id)
        {
            if (this.entities.ContainsKey(id))
                return (T)entities[id];
            else
                return default(T);
        }

        public void Store(T entity, Guid key)
        {
            if (!this.entities.ContainsKey(key))
                this.entities.Add(key, entity);
        }
    }
}
