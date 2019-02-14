using System.Collections.Generic;

namespace DocumentsControl.Application
{
    public interface INodeService
    {
        void Create(CreateNodeDto dto);
        void Delete(long Id);
        void Update(NodeDto dto);
        List<NodeDto> GetAll();
    }
}