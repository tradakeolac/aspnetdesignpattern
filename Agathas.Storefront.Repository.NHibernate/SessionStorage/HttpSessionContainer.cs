﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using System.Web;

namespace Agathas.Storefront.Repository.NHibernate.SessionStorage
{
    public class HttpSessionContainer : ISessionStorageContainer
    {
        private string _sessionKey = "NHSession";

        public ISession GetCurrentSession()
        {
            ISession session = null;

            if (HttpContext.Current.Items.Contains(_sessionKey))
                session = (ISession)HttpContext.Current.Items[_sessionKey];

            return session;
        }

        public void Store(ISession session)
        {
            if (HttpContext.Current.Items.Contains(_sessionKey))
                HttpContext.Current.Items[_sessionKey] = session;
            else
                HttpContext.Current.Items.Add(_sessionKey, session);
        }
    }
}
