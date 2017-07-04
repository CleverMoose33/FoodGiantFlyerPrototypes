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

        public ProgramSelectorViewModel()
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);
        }
        public void FlyerCreatorClicked()
        {
            //ActivateItem(new FlyerCreatorViewModel());
            WindowManager wm = new WindowManager();
            FlyerCreatorViewModel fcvm = new FlyerCreatorViewModel();
            wm.ShowWindow(fcvm);
        }

        public void DatabaseClicked()
        {
            //  ActivateItem(new DatabaseMaintainerViewModel());
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