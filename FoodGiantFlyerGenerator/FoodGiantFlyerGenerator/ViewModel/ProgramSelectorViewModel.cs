using Caliburn.Micro;
using FoodGiantFlyerGenerator.Model;
using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(ProgramSelectorViewModel))]
    public class ProgramSelectorViewModel : Conductor<object> //Or Screen if visual
    {
        private readonly IEventAggregator _EventAggregator;

        private string _Title;
        public string Title
        {
            get
            { return _Title; }
            set
            {
                _Title = value;
                NotifyOfPropertyChange();
            }
        }

        public ProgramSelectorViewModel()
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);
            Title = "Food Giant Program Selector";
        }
        public void FlyerCreatorClicked()
        {
            WindowManager wm = new WindowManager();
            FlyerCreatorViewModel fcvm = new FlyerCreatorViewModel();
            wm.ShowWindow(fcvm);
        }

        public void DatabaseClicked()
        {
            WindowManager wm = new WindowManager();
            DatabaseMaintainerViewModel dbvm = new DatabaseMaintainerViewModel();
            wm.ShowWindow(dbvm);
        }

        public void FlyerHistoryClicked()
        {
            WindowManager wm = new WindowManager();
            FlyerHistoryViewModel fhvm = new FlyerHistoryViewModel();
            wm.ShowWindow(fhvm);
        }
    }
}