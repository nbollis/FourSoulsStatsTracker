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
                new TransientLifetimeManager(), new InjectionConstructor(false));

            container.RegisterType<IFourSoulsData, MockedFourSoulsDataClient>("MockedData",
                new TransientLifetimeManager(), new InjectionConstructor(10));
        }
    }
}
