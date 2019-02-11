using Academy.DataAccess.EFCore;
using DocumentsControl.Domain;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentsControl.Application
{
    public class NodeService : INodeService
    {
        private readonly DocumentsControlDbContext _dbContext;
        public NodeService(DocumentsControlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(CreateNodeDto dto)
        {
            var entity = new Node()
            {
                ParentNodeId = dto.ParentNodeId,
                Title = dto.Title,
                Children = dto.Children,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                IsFile = dto.IsFile,
                Path = "",
                Version = dto.Version

            };
            _dbContext.Nodes.Add(entity);
            _dbContext.SaveChanges();
        }
        public List<NodeDto> GetAll()
        {
            //TODO: whole tree is loading, make it lazy
            var entities = _dbContext.Nodes.ToList()
                            .Where(a => a.ParentNodeId == null)
                            .ToList();
            return entities.Adapt<List<NodeDto>>();
        }
    }
}
