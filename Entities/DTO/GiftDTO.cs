﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class GiftDTO
    {
       
        public Guid GiftNumber { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
    }
}