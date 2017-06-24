using Caliburn.Micro;
using FoodGiantFlyerGenerator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(GenericFlyerViewModel))]
    public class GenericFlyerViewModel : Screen 
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

        private Visibility _ShowRaincheck;

        public Visibility ShowRaincheck
        {
            get { return _ShowRaincheck; }
            set
            {
                _ShowRaincheck = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion

        public GenericFlyerViewModel(FlyerSettingsModel settings, FlyerDataModel[] flyerData)
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);

            SetupFlyerLayout(settings, flyerData);
        }

        public void SetupFlyerLayout(FlyerSettingsModel settings, FlyerDataModel[] flyerData)
        {
            if (settings.RainChkd)
                ShowRaincheck = Visibility.Visible;
            else
                ShowRaincheck = Visibility.Hidden;
        }

    }
}
