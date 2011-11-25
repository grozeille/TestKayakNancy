using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.Hosting.Self;
using Nancy.Bootstrappers.Ninject;
using System.Diagnostics;
using TestKayakNancy.Application;
using System.IO;

namespace TestKayakNancy
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var host = new NancyHost(new Uri("http://localhost:8445"), new MyApplicationBootstrapper());
            host.Start();
            Process.Start("http://localhost:8445");
            System.Windows.Forms.Application.Run(new ApplicationIcon()); 
            host.Stop();
        }
    }
}
