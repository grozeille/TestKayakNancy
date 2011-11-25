using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using TestKayakNancy.Services;

namespace TestKayakNancy
{
    public class MyModule : NancyModule
    {
        private readonly IService service;

        public MyModule(IService service) : base("/mymodule")
        {
            this.service = service;
            
            this.Get[@"/js/{name}"] = x =>
            {
                return Response.AsJs(string.Format("js/{0}", (string)x.name));
            };

            this.Get[@"/css/{name}"] = x =>
            {
                return Response.AsCss(string.Format("css/{0}", (string)x.name));
            };

            this.Get[@"/img/{name}"] = x =>
            {
                return Response.AsImage(string.Format("img/{0}", (string)x.name));
            };

            this.Get["/"] = this.Index;

            this.Get["/test/{name}"] = this.Test;

            this.Post["/go"] = this.Go;
        }

        public Response Go(dynamic x)
        {
            string message = this.service.SayHello(this.Request.Form.Name);
            return this.Response.AsJson<String>(message);
        }

        public Response Index(dynamic x)
        {
            return View["Index.cshtml", new { Message = "Who are you?" }];
        }

        public Response Test(dynamic x)
        {
            return "<h1>" + service.SayHello(x.Name) + "</h1>";
        }
    }
}
