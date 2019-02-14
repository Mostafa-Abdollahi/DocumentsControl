using System;
using Autofac;
using DocumentsControl.Application;
using DocumentsControl.DataAccess.EFCore;

namespace DocumnetsControl.Config
{
    public class DocumentsControlModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NodeService>().As<INodeService>().InstancePerLifetimeScope();
            builder.RegisterType<SettingService>().As<ISettingService>().InstancePerLifetimeScope();
            builder.RegisterType<DocumentsControlDbContext>().InstancePerLifetimeScope();
        }
    }
}