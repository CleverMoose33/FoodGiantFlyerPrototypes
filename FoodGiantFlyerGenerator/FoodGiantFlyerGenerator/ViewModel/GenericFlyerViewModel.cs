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

        /// <summary>
        /// Constructor for Flyer
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="flyerData"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public GenericFlyerViewModel(FlyerSettingsModel settings, FlyerDataModel[] flyerData, DateTime startDate, DateTime endDate)
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);

            SetupFlyerLayout(settings, flyerData, startDate, endDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="flyerData"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void SetupFlyerLayout(FlyerSettingsModel settings, FlyerDataModel[] flyerData, DateTime startDate, DateTime endDate)
        {
            if (settings.RainChkd)
                ShowRaincheck = Visibility.Visible;
            else
                ShowRaincheck = Visibility.Hidden;
        }

    }
}
