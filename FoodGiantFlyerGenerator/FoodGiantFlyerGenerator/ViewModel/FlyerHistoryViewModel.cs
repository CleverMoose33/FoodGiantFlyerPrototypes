using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(FlyerHistoryViewModel))]
    public class FlyerHistoryViewModel : PropertyChangedBase //Or Screen if visual
    {
        private readonly IEventAggregator _EventAggregator;

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

        public FlyerHistoryViewModel()
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);
        }
    }
}
