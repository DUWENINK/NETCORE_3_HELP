using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Data.Entity
{
   public class VaeEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string ContentId { get; set; }

    }
}
