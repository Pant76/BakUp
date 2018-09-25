using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeUpBackendR1.Models.Claim
{
    public class Description:BaseModel
    {
        public string Deleted_at { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
        public string It { get; set; }
        public string En { get; set; }
    }
}