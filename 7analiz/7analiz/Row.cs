﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7analiz
{
    public class Row : INotifyPropertyChanged
    {
        private double value;
        public string Number { get; set; }

        public string Name { get; set; }
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
                OnPropertyChanged("Value");
            }
        }
        public string GroupName { get; set; }
        public bool IsHeader { get; set; }

        public double min = 0;
        public double max = 1; // areused for cheking in set

        public event PropertyChangedEventHandler PropertyChanged;

        //invoking event after property changed
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
