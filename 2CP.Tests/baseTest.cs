using Autofac.Extras.Moq;

namespace _2CP.Tests
{
    public abstract class BaseTest<TSuT>
        where TSuT : class
    {
        protected TSuT SystemUnderTest { get; }

        protected BaseTest()
        {           
            using (var mock = AutoMock.GetLoose())
            {
                SystemUnderTest = mock.Create<TSuT>();
            }
        }        
    }
}
