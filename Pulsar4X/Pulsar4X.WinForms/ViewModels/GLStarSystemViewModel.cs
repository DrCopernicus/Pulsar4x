﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulsar4X.Entities;
using System.ComponentModel;
using Pulsar4X.Stargen;
using System.Linq.Expressions;

namespace Pulsar4X.ViewModels
{
    public class GLStarSystemViewModel: INotifyPropertyChanged
    {

        public BindingList<StarSystem> StarSystems { get; set; }
        private StarSystem _currentstarsystem;
        public StarSystem CurrentStarSystem
        {
            get
            {
                return _currentstarsystem;
            }
            set
            {
                if (_currentstarsystem != value)
                {
                    _currentstarsystem = value;
                    OnPropertyChanged(() => CurrentStarSystem);
                }
            }
        }

        public GLStarSystemViewModel()
        {
            // For now, just create a new starsystem
            var ssf = new StarSystemFactory(false);
            CurrentStarSystem = ssf.Create("FooBar");

            StarSystems = new BindingList<StarSystem>();
            StarSystems.Add(CurrentStarSystem);
        }


        private void OnPropertyChanged(Expression<Func<object>> property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(BindingHelper.Name(property)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
