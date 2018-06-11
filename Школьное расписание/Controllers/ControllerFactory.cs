using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Routing;
using Школьное_расписание.Models;

namespace Школьное_расписание.Controllers
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext request, Type contrType)
        {
            return Activator.CreateInstance(contrType, new DataManager()) as IController;
        }
    }
}