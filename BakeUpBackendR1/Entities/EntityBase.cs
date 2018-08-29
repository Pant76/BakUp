using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeUpBackendR1.Entities
{
    public class EntityBase
    {
        public Guid UniqueId { get; set; }
        public int Id { get; set; }



        public DateTime CreationDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsActive { get; set; }

        public EntityBase()
        {
            CreationDate = DateTime.Now;
            ModifyDate = DateTime.Now;
            UniqueId = Guid.NewGuid();
            IsActive = true;
        }
    }
}