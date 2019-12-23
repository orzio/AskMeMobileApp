using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AskMeMobileApp.Utils
{
    public class PropertyChangedClass:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(params string[] name)
        {

            if (PropertyChanged != null)
            {
                foreach (string item in name)
                    PropertyChanged(this, new PropertyChangedEventArgs(item));
            }
        }
    }
}
