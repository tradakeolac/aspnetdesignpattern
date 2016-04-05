using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap8.FrontController.Controller.Request
{
    public class Argument<T>
    {
        private string _key;
        public Argument(string key)
        {
            this._key = key;
        }

        public string Key { get { return this._key; } }

        public T ExtractFrom(NameValueCollection queryArguments)
        {
            try
            {
                return (T)Convert.ChangeType(queryArguments[this._key], typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}
