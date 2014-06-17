using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WPFObjects
{
    public interface INotifyDirtyData
    {
        event PropertyChangedEventHandler DirtyStatusChanged;
        Object GetChangedData(string propertyName);
        void ClearChangedData();
        bool HasChangedData { get; }
    } 
}
