using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(ProgramSelectorViewModel))]
    public class ProgramSelectorViewModel : PropertyChangedBase //Or Screen if visual
    {
        private readonly IEventAggregator _eventAggregator;

        #region Binding Items
        private string _BaseItem;

        public string BaseItem
        {
            get { return _BaseItem; }
            set
            {
                _BaseItem = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion

        public ProgramSelectorViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
        }

        public void FlyerClicked(object var)
        {
            Button something = (Button)var;
        }

        public void FlyerClicked()
        {
            //WindowManager wm = new WindowManager();
            //FlyerCreatorViewModel temp = new FlyerCreatorViewModel();
            //wm.ShowWindow(temp);
        }

        public void DatabaseClicked(object var)
        {
            //WindowManager dbwin = new WindowManager();
            //DatabaseMaintainerViewModel db = new DatabaseMaintainerViewModel();
            //dbwin.ShowWindow(db);
        }
    }
}