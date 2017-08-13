using System;

namespace Xngine.Tools.Tests.BaseFramework
{
    //Base class for arrande act assert structute like test
    //Arrange method will prepare test data and any needed dependecy for test
    //Act will be execution of buisness logic 
    //Assert should be write with [Assert] attribute 
    //Cleanup should be used when you have some resources which should be destroyed manually eg. monogame textures
    public abstract class AAATest : IDisposable
    {
        protected AAATest()
        {
            Arrange();
            Act();
        }

        protected abstract void Act();
        protected abstract void Arrange();
        protected virtual void Cleanup() { }

        public void Dispose()
        {
            Cleanup();
        }
    }
}
