﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeUpBackendR1.Models.Claim
{
    public class DescriptableModel:BaseModel
    {
        public Description Description { get; set; }
        public Description ShortDescription { get; set; }
        public bool Online { get; set; }
    }
}