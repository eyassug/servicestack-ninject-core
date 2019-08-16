namespace MediatR.CQRS.Ninject.Tests
{
    using Xunit;
    public class ContravariantBindingResolverTests
    {
        [Fact]
        public void NonGenericType_ReturnsEmptyEnumerable()
        {
            var nonGenericType = typeof(int);
            var resolver = new ContravariantBindingResolver();
            var result = resolver.Resolve(null, nonGenericType);
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
