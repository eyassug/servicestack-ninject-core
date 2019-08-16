namespace MediatR.CQRS.Ninject
{
    using System.Reflection;
    using global::Ninject;
    using global::Ninject.Extensions.Conventions;
    using global::Ninject.Planning.Bindings.Resolvers;
    using MediatR.Pipeline;

    public static class NinjectKernelExtensions
    {
        public static void BuildMediatR(this IKernel kernel, params Assembly[] assembliesWithHandlers)
        {
            kernel.Components.Add<IBindingResolver, ContravariantBindingResolver>();

            kernel.Bind(scan => scan.FromAssemblyContaining<IMediator>().SelectAllClasses().BindDefaultInterface());

            kernel.Bind(scan => scan.From(assembliesWithHandlers).SelectAllClasses().InheritedFrom(typeof(IRequestHandler<,>)).BindAllInterfaces());
            kernel.Bind(scan => scan.From(assembliesWithHandlers).SelectAllClasses().InheritedFrom(typeof(INotificationHandler<>)).BindAllInterfaces());

            //Pipeline
            kernel.Bind(typeof(IPipelineBehavior<,>)).To(typeof(RequestPreProcessorBehavior<,>));
            kernel.Bind(typeof(IPipelineBehavior<,>)).To(typeof(RequestPostProcessorBehavior<,>));

            kernel.Bind<ServiceFactory>().ToMethod(ctx => t => ctx.Kernel.TryGet(t));
        }
    }
}
