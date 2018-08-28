
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeUpBackendR1.Entities
{
    public class SysPar:EntityBase
    {
        public string Name { get; set; }
        public string Val { get; set; }

        public string Type { get; set; }
    }
}