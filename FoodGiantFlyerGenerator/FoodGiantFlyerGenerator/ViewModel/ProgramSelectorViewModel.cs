using Caliburn.Micro;
using System.ComponentModel.Composition;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(ProgramSelectorViewModel))]
    public class ProgramSelectorViewModel : PropertyChangedBase //Or Screen if visual
    {
        private readonly IEventAggregator _eventAggregator;

        public ProgramSelectorViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
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
            //DatabaseMaintainerViewModel dbvm = new DatabaseMaintainerViewModel();
            //wm.ShowWindow(dbvm);
        }

        public void FlyerHistoryClicked()
        {
            WindowManager wm = new WindowManager();
            //FlyerHistoryViewModel fhvm = new FlyerHistoryViewModel();
            //wm.ShowWindow(fhvm);
        }
    }
}