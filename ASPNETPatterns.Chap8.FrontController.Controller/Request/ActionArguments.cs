﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap8.FrontController.Controller.Request
{
    public class ActionArguments
    {
        public static readonly Argument<int> CategoryId = new Argument<int>("categoryId");

        public static readonly Argument<int> ProductId = new Argument<int>("productId");
    }
}