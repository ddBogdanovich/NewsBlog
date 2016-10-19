using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using NewsBlog2.Domain.Abstract;
using NewsBlog2.Domain.Concrete;
using System.Web.Mvc;
using System.Configuration;

namespace NewsBlog2.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {

        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {

            kernel.Bind<INewsRepository>().To<EFNewsRepository>();
           
       //     kernel.Bind<IAuthProvider>().To<FormsAuthProvider>(); //TODO read about IoC with identity
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}