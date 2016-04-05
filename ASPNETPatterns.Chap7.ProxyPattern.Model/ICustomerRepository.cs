﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.ProxyPattern.Model
{
    public interface ICustomerRepository
    {
        Customer FindBy(Guid id);
    }
}
