using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Models.Business
{
    public class STSDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// FromGroup
        /// </summary>
        public string FromGroup { get; set; }

        /// <summary>
        /// FromQQ
        /// </summary>
        public string FromQQ { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// CreateDateTime
        /// </summary>
        public DateTime CreateDateTime { get; set; }
    }
}
