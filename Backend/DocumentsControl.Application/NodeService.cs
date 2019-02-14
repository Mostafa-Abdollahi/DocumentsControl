using DocumentsControl.Domain;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentsControl.DataAccess.EFCore;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace DocumentsControl.Application
{
    public class NodeService : INodeService
    {
        private readonly DocumentsControlDbContext _dbContext;
        private readonly ISettingService _settingService;
        public NodeService(DocumentsControlDbContext dbContext, ISettingService settingService)
        {
            _dbContext = dbContext;
            _settingService = settingService;
        }
        public void Create(CreateNodeDto dto)
        {
            string tempPath = "";

            //if has father (is not root)
            if (dto.ParentNodeId != null)
            {
                var parentNode = _dbContext.Nodes.FirstOrDefault(x => x.Id == dto.ParentNodeId);

                tempPath = parentNode.Path;

                string[] paths = { tempPath, dto.Title };
                tempPath = Path.Combine(paths);
            }
            // if is root
            else
            {
                tempPath = _settingService.GetSetting().RootPath;

                if (string.IsNullOrEmpty(tempPath))
                {
                    //TODO : alert to fill setting
                }
            }

            if (!dto.IsFile)
            {
                Directory.CreateDirectory(tempPath);
            }
            else
            {
                //TODO :  create file
            }

            var entity = new Node()
            {
                ParentNodeId = dto.ParentNodeId,
                Title = dto.Title,
                Children = dto.Children,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                IsFile = dto.IsFile,
                Path = tempPath,
                Version = dto.Version
            };

            _dbContext.Nodes.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(long Id)
        {
            var selectedNode = _dbContext.Nodes.FirstOrDefault(a => a.Id == Id);

            if (!_dbContext.Nodes.Any(a => a.ParentNodeId == Id))
            {
                try
                {
                    _dbContext.Nodes.Remove(selectedNode);
                    _dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                try
                {
                    if (selectedNode.IsFile)
                    {
                        File.Delete(selectedNode.Path);
                    }
                    else
                    {
                        Directory.Delete(selectedNode.Path);
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                //TODO :alert "has child"
            }


        }

        public void Update(NodeDto dto)
        {
            var selectedNode = _dbContext.Nodes.FirstOrDefault(a => a.Id == dto.Id);
            var parentNode = _dbContext.Nodes.FirstOrDefault(a => a.Id == dto.ParentNodeId);
            var prePath = selectedNode.Path;
            string[] paths = { parentNode.Path, dto.Title };
            var tempPath = Path.Combine(paths);

            try
            {
                //selectedNode = dto.Adapt<Node>();
                selectedNode.DateModified = DateTime.Now;
                selectedNode.Path = tempPath;
                selectedNode.Title = dto.Title;
                _dbContext.Entry(selectedNode).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            try
            {
                Directory.Move(prePath, tempPath);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<NodeDto> GetAll()
        {
            try
            {
                //TODO: whole tree is loading, make it lazy
                var entities = _dbContext.Nodes.ToList()
                .Where(a => a.ParentNodeId == null)
                .ToList();
                var x = entities.Adapt<List<NodeDto>>();
                return x;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
