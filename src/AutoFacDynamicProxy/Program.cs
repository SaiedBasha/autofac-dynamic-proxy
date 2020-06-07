using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace AutoFacDynamicProxy
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ContainerBuilder();

            // Named registration
            //builder.Register(c => new CallLogger(Console.Out))
            //    .Named<IInterceptor>("log-calls");

            // Typed registration
            builder.Register(c => new CallLogger(Console.Out));

            builder.RegisterType<SomeType>()
                .As<ISomeInterface>()
                .EnableClassInterceptors()
                //.InterceptedBy(typeof(CallLogger))//;
                //.EnableInterfaceInterceptors()
                .InterceptedBy(typeof(CallLogger));

            builder.RegisterType<First>().EnableClassInterceptors();

            builder.RegisterType<Second>();

            var container = builder.Build();

            var willBeIntercepted = container.Resolve<ISomeInterface>();

            var value = willBeIntercepted.sum(10, 20);

            var output = willBeIntercepted.GetOutput(new SomeInput1() {Id = 1}, new SomeInput2() {Id = 2});


            container.Resolve<First>().GetValue();


            Console.WriteLine("Hello World!");
        }
    }
}
