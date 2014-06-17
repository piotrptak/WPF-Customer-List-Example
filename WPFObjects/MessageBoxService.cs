using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WPFObjects
{
    public interface IMessageBoxService
    {
        MessageBoxResult Show(string message, string caption, MessageBoxButton buttons, MessageBoxImage image);
    }
    public class MessageBoxService : IMessageBoxService
    {

        public MessageBoxResult Show(string message, string caption, MessageBoxButton buttons, MessageBoxImage image)
        {
            return MessageBox.Show(message, caption, buttons, image);
        }
    }
}
