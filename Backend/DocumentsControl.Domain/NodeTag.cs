using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentsControl.Domain
{
    public class NodeTag
    {
        public long Id { get; set; }
        public long NodeId { get; set; }
        public virtual Node node { get; set; }
        public long TagId { get; set; }
        public virtual Tag tag { get; set; }
        public string Value { get; set; }
    }
}
