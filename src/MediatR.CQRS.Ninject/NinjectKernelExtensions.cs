namespace MediatR.CQRS.Ninject
{
    using System;
    using System.Reflection;
    using global::Ninject;
    using global::Ninject.Extensions.Conventions;

    public static class NinjectKernelExtensions
    {
        public static void BuildMediatR(this IKernel kernel, params Assembly[] assemblies)
        {
            throw new NotImplementedException();
        }
    }
}
