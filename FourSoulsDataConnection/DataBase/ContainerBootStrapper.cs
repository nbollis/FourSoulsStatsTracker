using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace FourSoulsDataConnection.DataBase
{
    public class ContainerBootStrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IFourSoulsData, FourSoulsDataDirectClient>("FourSoulsData",
                                            new TransientLifetimeManager(),
                                            new InjectionConstructor(false));

        }
    }
}
