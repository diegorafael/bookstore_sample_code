using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;

namespace WebApi.Controllers
{
    public abstract class BasicController<TServiceContract> : ControllerBase 
    {
        protected TServiceContract Service { get; }
        public BasicController(TServiceContract service)
        {
            Service = service;
        }
    }
}
