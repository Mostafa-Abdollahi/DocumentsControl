using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentsControl.Domain
{
    public class Node
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public string Path { get; set; }
        public long? ParentNodeId { get; set; }
        public Node ParentNode { get; set; }
        public List<Node> Children { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsFile { get; set; }

    }
}
