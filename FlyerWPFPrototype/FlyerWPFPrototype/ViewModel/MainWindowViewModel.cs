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

        private object _ActiveViewModel;

        public object ActiveViewModel
        {
            get
            { return _ActiveViewModel; }
            set
            {
                _ActiveViewModel = value;
                NotifyOfPropertyChange(() => _ActiveViewModel);
            }
        }

        public MainWindowViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);

            _ActiveViewModel = new LoginControlViewModel();
        }
        
    }
}
