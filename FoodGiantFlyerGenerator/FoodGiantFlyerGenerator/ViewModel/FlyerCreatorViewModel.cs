﻿using Caliburn.Micro;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(FlyerCreatorViewModel))]
    public class FlyerCreatorViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;

        /*
     Number Of Flyer Items 1-15
Store Type
Store Address and Phone Number
Flyer Type
Checkboxes for 
    •	While supplies last
    •	No rainchecks given
        */
        #region Binding Items
        #region Flyer Binding Items
        private FlyerItemViewModel _FlyerItem1;

        public FlyerItemViewModel FlyerItem1
        {
            get
            { return _FlyerItem1; }
            set
            {
                _FlyerItem1 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem2;

        public FlyerItemViewModel FlyerItem2
        {
            get
            { return _FlyerItem2; }
            set
            {
                _FlyerItem2 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem3;

        public FlyerItemViewModel FlyerItem3
        {
            get
            { return _FlyerItem3; }
            set
            {
                _FlyerItem3 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem4;

        public FlyerItemViewModel FlyerItem4
        {
            get
            { return _FlyerItem4; }
            set
            {
                _FlyerItem4 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem5;

        public FlyerItemViewModel FlyerItem5
        {
            get
            { return _FlyerItem5; }
            set
            {
                _FlyerItem5 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem6;

        public FlyerItemViewModel FlyerItem6
        {
            get
            { return _FlyerItem6; }
            set
            {
                _FlyerItem6 = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion
        #region Visibility
        private Visibility _Item1Vis;

        public Visibility Item1Vis
        {
            get
            { return _Item1Vis; }
            set
            {
                _Item1Vis = value;
                NotifyOfPropertyChange(() => Item1Vis);
            }
        }

        private Visibility _Item2Vis;

        public Visibility Item2Vis
        {
            get
            { return _Item2Vis; }
            set
            {
                _Item2Vis = value;
                NotifyOfPropertyChange(() => Item2Vis);
            }
        }

        private Visibility _Item3Vis;

        public Visibility Item3Vis
        {
            get
            { return _Item3Vis; }
            set
            {
                _Item3Vis = value;
                NotifyOfPropertyChange(() => Item3Vis);
            }
        }

        private Visibility _Item4Vis;

        public Visibility Item4Vis
        {
            get
            { return _Item4Vis; }
            set
            {
                _Item4Vis = value;
                NotifyOfPropertyChange(() => Item4Vis);
            }
        }

        private Visibility _Item5Vis;

        public Visibility Item5Vis
        {
            get
            { return _Item5Vis; }
            set
            {
                _Item5Vis = value;
                NotifyOfPropertyChange(() => Item5Vis);
            }
        }

        private Visibility _Item6Vis;

        public Visibility Item6Vis
        {
            get
            { return _Item6Vis; }
            set
            {
                _Item6Vis = value;
                NotifyOfPropertyChange(() => Item6Vis);
            }
        }
        #endregion
        #endregion

        public FlyerCreatorViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);

            FlyerItem1 = new FlyerItemViewModel();
            FlyerItem2 = new FlyerItemViewModel();
            FlyerItem3 = new FlyerItemViewModel();
            FlyerItem4 = new FlyerItemViewModel();
            FlyerItem5 = new FlyerItemViewModel();
            FlyerItem6 = new FlyerItemViewModel();
        }


        #region User Events

        #region FlyerGeneration
        public void GenerateFlyer()
        {

        }
        #endregion

        #region Visibility

        /// <summary>
        /// Shows/Hides elements based on user selection, will be used for
        /// aspx page to inform it of how many items it will be generating
        /// </summary>
        /// <param name="numVisElements"></param>
        public void ShowHideElements(int numVisElements)
        {
            Item1Vis = Visibility.Visible;

            if (numVisElements >= 2)
                Item2Vis = Visibility.Visible;
            else
                Item2Vis = Visibility.Hidden;

            if (numVisElements >= 3)
                Item3Vis = Visibility.Visible;
            else
                Item3Vis = Visibility.Hidden;

            if (numVisElements >= 4)
                Item4Vis = Visibility.Visible;
            else
                Item4Vis = Visibility.Hidden;

            if (numVisElements >= 5)
                Item5Vis = Visibility.Visible;
            else
                Item5Vis = Visibility.Hidden;

            if (numVisElements >= 6)
                Item6Vis = Visibility.Visible;
            else
                Item6Vis = Visibility.Hidden;
        }
        #endregion
        #endregion

    }
}
