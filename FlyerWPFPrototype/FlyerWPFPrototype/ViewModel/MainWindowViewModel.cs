using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlyerWPFPrototype
{
    [Export(typeof(MainWindowViewModel))]
    class MainWindowViewModel : PropertyChangedBase
    {
        private readonly IEventAggregator _eventAggregator;

        public MainWindowViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
        }
    }
}
