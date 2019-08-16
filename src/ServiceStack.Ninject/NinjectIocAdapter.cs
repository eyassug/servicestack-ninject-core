﻿namespace ServiceStack.Ninject
{
    using global::Ninject;
    using ServiceStack.Configuration;

    public class NinjectIocAdapter : IContainerAdapter
    {
        private readonly IKernel _kernel;

        public NinjectIocAdapter(IKernel kernel) => _kernel = kernel;

        public T Resolve<T>()
        {
            return _kernel.Get<T>();
        }

        public T TryResolve<T>()
        {
            return _kernel.TryGet<T>();
        }
    }
}
