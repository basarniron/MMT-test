﻿using MMT.Test.Order.Business.Contracts.Dtos.Response;
using System;

namespace MMT.Test.Order.Business.Contracts.Dtos.Request
{
    public class RecentOrderRequest
    {
        public string User { get; set; }
        public string CustomerId { get; set; }        
    }
}
