using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeUpBackendR1.Entities
{
    public class ValidEntity:EntityBase
    {
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public ValidEntity()
        {
            ValidFrom = DateTime.Now;
            ValidTo = null;
        }
    }
}