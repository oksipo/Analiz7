using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7analiz
{
    public class Row : INotifyPropertyChanged
    {
        //row value
        private double value;

        //row number
        public string Number { get; set; }

        //row name
        public string Name { get; set; }

        //row value (property)
        public double Value
        {
            get
            {
                return value;
            }

            set
            {
                if (value<min || value> max)
                    return;

                this.value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        //row group
        public string GroupName { get; set; }

        //is row a header
        public bool IsHeader { get; set; }

        //minimum value
        public double min = 0;

        //maximum value
        public double max = 1;

        //event on property changing
        public event PropertyChangedEventHandler PropertyChanged;

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //invoking event after property changed
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
