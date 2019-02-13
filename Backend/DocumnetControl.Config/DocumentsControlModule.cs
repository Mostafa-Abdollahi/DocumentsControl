using System;
using Academy.DataAccess.EFCore;
using Autofac;
using DocumentsControl.Application;

namespace DocumnetsControl.Config
{
    public class DocumentsControlModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NodeService>().As<INodeService>().InstancePerLifetimeScope();
            builder.RegisterType<DocumentsControlDbContext>().InstancePerLifetimeScope();
        }
    }
}