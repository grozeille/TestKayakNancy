using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;

namespace TestKayakNancy.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            this.Get["/"] = x => this.Response.AsRedirect("/mymodule/");
        }
    }
}
