using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using IMRL.WhatsInMyFridge.DataAccess;
using IMRL.WhatsInMyFridge.DataAccess.Repositories;
using IMRL.WhatsInMyFridge.DataAccess.SqlServer;
using IMRL.WhatsInMyFridge.DataAccess.SqlServer.Repositories;

namespace IMRL.WhatsInMyFridge.IoC
{
   public class AutofacBootstrapper
    {
        public static IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<WhatsInMyFridgeContext>().SingleInstance();

            builder.RegisterType<UnitOfWork>()
                    .As<IUnitOfWork>();

            builder.RegisterType<DataRepository>()
                .As<IDataRepository>();

            return builder.Build();
        }
    }
}
