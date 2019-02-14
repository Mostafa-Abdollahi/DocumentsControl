using DocumentsControl.Domain;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentsControl.DataAccess.EFCore;

namespace DocumentsControl.Application
{
    public class SettingService : ISettingService
    {
        private readonly DocumentsControlDbContext _dbContext;
        public SettingService(DocumentsControlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SettingDto GetSetting()
        {
            try
            {
                //TODO: whole tree is loading, make it lazy

                var entities = _dbContext.Settings.ToList();

                if (entities.Count == 1)
                {
                    return entities.FirstOrDefault().Adapt<SettingDto>();
                }
                else
                {
                    // TODO : alert admin "setting is broken"
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
