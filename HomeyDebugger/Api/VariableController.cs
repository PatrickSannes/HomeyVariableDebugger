using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Caliburn.Micro;
using HomeyDebugger.ViewModels;
using Newtonsoft.Json;

namespace HomeyDebugger.Api
{
    public class VariableController : ApiController
    {
        private readonly IEventAggregator events;

        public VariableController(IEventAggregator events)
        {
            this.events = events;
        }

        public void Post([FromBody]Variable variable)
        {

           events.PublishOnUIThread(variable);
        }
    }
}
