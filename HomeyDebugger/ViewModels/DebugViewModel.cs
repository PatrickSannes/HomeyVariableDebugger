using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using Caliburn.Micro;
using System.Threading.Tasks;
using HomeyDebugger.Api;

namespace HomeyDebugger.ViewModels
{
    class DebugViewModel : PropertyChangedBase, IHandle<Variable>
    {
        private readonly IEventAggregator events;
        private string port;
        public BindableCollection<VariableViewModel> VariableList { get; } = new BindableCollection<VariableViewModel>();
        public BindableCollection<LogRow> LogList { get; } = new BindableCollection<LogRow>();

        public string Port
        {
            get { return port; }
            set
            {
                if (value == port) return;
                port = value;
                NotifyOfPropertyChange();
            }
        }

        public DebugViewModel(IEventAggregator events)
        {
            this.events = events;
            events.Subscribe(this);
            port = ConfigurationManager.AppSettings["Address"];
        }

        public void Handle(Variable variable)
        {
            if (VariableList.Any(x => x.Key == variable.Key))
            {
                VariableList.First(x => x.Key == variable.Key).Value = variable.Value;
                Refresh();
            }
            else
            {
                VariableList.Add(new VariableViewModel() {Key = variable.Key, Value = variable.Value});
            }

            LogList.Add(new LogRow()
            {
                TimeStamp = DateTime.Now,
                Message  = $"Variable: {variable.Key} has new value: {variable.Value}"
            });
            Refresh();
        }
    }
}
