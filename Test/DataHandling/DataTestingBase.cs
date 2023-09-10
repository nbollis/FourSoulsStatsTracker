using FourSoulsDataConnection.DataBase;
using Unity;

namespace Test.DataHandling;

public class DataTestingBase
{
    static DataTestingBase()
    {
        var container = new UnityContainer();
        ContainerBootStrapper.RegisterTypes(container);
        MockedData = container.Resolve<IFourSoulsData>("MockedData").Data;
    }

    protected static FourSoulsData MockedData;
}