using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestKayakNancy.Services
{
    public class Service : IService
    {
        public string SayHello(string name)
        {
            return "Hello " + name;
        }
    }
}
