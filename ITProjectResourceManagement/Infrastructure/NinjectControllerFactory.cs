using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;

namespace ITProjectResourceManagement.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernal;

        public NinjectControllerFactory()
        {
            ninjectKernal = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext
            requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernal.Get(controllerType);
        }

        private void AddBindings()
        {
        }
    }
}