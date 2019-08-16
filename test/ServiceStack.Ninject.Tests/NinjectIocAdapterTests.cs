namespace ServiceStack.Ninject.Tests
{
    using System;
    using Xunit;
    using global::Ninject;

    public class NinjectIocAdapterTests
    {
        [Fact]
        public void NullKernel_ThrowsArgumentNullException()
        {
            IKernel kernel = null;
            Assert.Throws<ArgumentNullException>(() => new NinjectIocAdapter(kernel));
        }
    }
}
