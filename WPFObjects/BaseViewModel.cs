using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFObjects
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected IMessageBoxService MessageBoxService { get; private set; }

        public BaseViewModel(IMessageBoxService messageBoxService=null) 
        {
            this.MessageBoxService = messageBoxService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
