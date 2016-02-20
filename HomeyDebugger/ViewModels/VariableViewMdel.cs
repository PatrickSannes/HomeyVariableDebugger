using System.ComponentModel;
using Caliburn.Micro;

namespace HomeyDebugger.ViewModels
{
    public class VariableViewModel : PropertyChangedBase
    {
        public string Key
        {
            get { return key; }
            set
            {
                if (value == key) return;
                key = value;
                NotifyOfPropertyChange();
            }
        }

        public string Value
        {
            get { return val; }
            set
            {
                if (value == val) return;
                val = value;
                NotifyOfPropertyChange();
            }
        }

        private string key { get; set; }
        private string val { get; set; }
    }
}