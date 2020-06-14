using DogWalker.V3Files.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker.V3Files.ModelViews
{
    public class ModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string txt)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(txt));
        }

        private List<OWNER> owners;
        public List<OWNER> Owners
        {
            get
            {
                return owners;
            }
            set
            {
                owners = value;
                OnPropertyChanged("Owners");
            }
        }

        private List<DOG> dogs;
        public List<DOG> Dogs
        {
            get
            {
                return dogs;
            }
            set
            {
                dogs = value;
                OnPropertyChanged("Dogs");
            }
        }

        private List<WALK> walks;
        public List<WALK> Walks
        {
            get
            {
                return walks;
            }
            set
            {
                walks = value;
                OnPropertyChanged("Walks");
            }
        }

        private List<SCHEDULE> schedule;
        public List<SCHEDULE> Schedule
        {
            get
            {
                return schedule;
            }
            set
            {
                schedule = value;
                OnPropertyChanged("Schedule");
            }
        }

    }
}
