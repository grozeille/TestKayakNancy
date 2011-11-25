using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.Bootstrappers.Ninject;
using Ninject.Modules;
using Nancy.ViewEngines.Razor;

namespace TestKayakNancy.Application
{
    public class MyApplicationBootstrapper : NinjectNancyBootstrapper
    {
        /*protected override IEnumerable<Type> ViewEngines
        {
            get
            {
                return new Type[] { typeof(RazorViewEngine) };
            }
        }*/


        protected override void ConfigureApplicationContainer(Ninject.IKernel existingContainer)
        {
            base.ConfigureApplicationContainer(existingContainer);
            existingContainer.Load(new INinjectModule[]{ new MyApplicationModule() });
        }
        
        protected override void ConfigureRequestContainer(Ninject.IKernel container)
        {
            base.ConfigureRequestContainer(container);
            //container.Bind<MyModule>();
        }

        byte[] favicon;

        protected override byte[] DefaultFavIcon
        {
            get
            {
                if (favicon == null)
                {
                    using (var resourceStream = GetType().Assembly.GetManifestResourceStream("TestKayakNancy.favicon.ico"))
                    {
                        var tempFavicon = new byte[resourceStream.Length];
                        resourceStream.Read(tempFavicon, 0, (int)resourceStream.Length);
                        favicon = tempFavicon;
                    }
                }
                return favicon;
            }
        }
    }
}
