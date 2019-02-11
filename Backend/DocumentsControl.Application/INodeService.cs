using System.Collections.Generic;

namespace DocumentsControl.Application
{
    public interface INodeService
    {
        void Create(CreateNodeDto dto);
        List<NodeDto> GetAll();
    }
}