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

        private readonly int _MaxFlyerItems = 16;

        private string _SelectedFlyerTemplate;
        private int _NumDisplayedFlyerItems;
        private FlyerItemViewModel[] _FlyerItemList;
        private Visibility[] _FlyerItemVisList;

        string tempImgLocation = Environment.CurrentDirectory + @"\Images\";

        #region Binding Items
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

        private string _StoreName;

        public string StoreName
        {
            get
            { return _StoreName; }
            set
            {
                _StoreName = value;
                NotifyOfPropertyChange();
            }
        }

        private string _StoreImage;

        public string StoreImage
        {
            get
            { return _StoreImage; }
            set
            {
                _StoreImage = value;
                NotifyOfPropertyChange();
            }
        }

        private string _StoreAddress;

        public string StoreAddress
        {
            get
            { return _StoreAddress; }
            set
            {
                _StoreAddress = value;
                NotifyOfPropertyChange();
            }
        }


        private string _StoreNumber;

        public string StoreNumber
        {
            get
            { return _StoreNumber; }
            set
            {
                _StoreNumber = value;
                NotifyOfPropertyChange();
            }
        }

        private string _SaleDates;

        public string SaleDates
        {
            get
            { return _SaleDates; }
            set
            {
                _SaleDates = value;
                NotifyOfPropertyChange();
            }
        }

        private Brush _FlyerBackgroundColor;

        public Brush FlyerBackgroundColor
        {
            get
            { return _FlyerBackgroundColor; }
            set
            {
                _FlyerBackgroundColor = value;
                NotifyOfPropertyChange();
            }
        }

        private DateTime _SaleStartDate;
        public DateTime SaleStartDate
        {
            get
            { return SaleStartDate; }
            set
            {
                SaleStartDate = value;
                NotifyOfPropertyChange();
            }
        }

        private DateTime _SaleEndDate;
        public DateTime SaleEndDate
        {
            get
            { return _SaleEndDate; }
            set
            {
                _SaleEndDate = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _ShowSupply;

        public Visibility ShowSupply
        {
            get { return _ShowSupply; }
            set
            {
                _ShowSupply = value;
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

        private FlyerItemViewModel _FlyerItem7;

        public FlyerItemViewModel FlyerItem7
        {
            get
            { return _FlyerItem7; }
            set
            {
                _FlyerItem7 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem8;

        public FlyerItemViewModel FlyerItem8
        {
            get
            { return _FlyerItem8; }
            set
            {
                _FlyerItem8 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem9;

        public FlyerItemViewModel FlyerItem9
        {
            get
            { return _FlyerItem9; }
            set
            {
                _FlyerItem9 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem10;

        public FlyerItemViewModel FlyerItem10
        {
            get
            { return _FlyerItem10; }
            set
            {
                _FlyerItem10 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem11;

        public FlyerItemViewModel FlyerItem11
        {
            get
            { return _FlyerItem11; }
            set
            {
                _FlyerItem11 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem12;

        public FlyerItemViewModel FlyerItem12
        {
            get
            { return _FlyerItem12; }
            set
            {
                _FlyerItem12 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem13;

        public FlyerItemViewModel FlyerItem13
        {
            get
            { return _FlyerItem13; }
            set
            {
                _FlyerItem13 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem14;

        public FlyerItemViewModel FlyerItem14
        {
            get
            { return _FlyerItem14; }
            set
            {
                _FlyerItem14 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem15;

        public FlyerItemViewModel FlyerItem15
        {
            get
            { return _FlyerItem15; }
            set
            {
                _FlyerItem15 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemViewModel _FlyerItem16;

        public FlyerItemViewModel FlyerItem16
        {
            get
            { return _FlyerItem16; }
            set
            {
                _FlyerItem16 = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion

        #region Flyer Item Visibilities
        private Visibility _Item1Vis;

        public Visibility Item1Vis
        {
            get
            { return _Item1Vis; }
            set
            {
                _Item1Vis = value;
                NotifyOfPropertyChange();
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
                NotifyOfPropertyChange();
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
                NotifyOfPropertyChange();
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
                NotifyOfPropertyChange();
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
                NotifyOfPropertyChange();
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
                NotifyOfPropertyChange();
            }
        }

        private Visibility _Item7Vis;

        public Visibility Item7Vis
        {
            get
            { return _Item7Vis; }
            set
            {
                _Item7Vis = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _Item8Vis;

        public Visibility Item8Vis
        {
            get
            { return _Item8Vis; }
            set
            {
                _Item8Vis = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _Item9Vis;

        public Visibility Item9Vis
        {
            get
            { return _Item9Vis; }
            set
            {
                _Item9Vis = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _Item10Vis;

        public Visibility Item10Vis
        {
            get
            { return _Item10Vis; }
            set
            {
                _Item10Vis = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _Item11Vis;

        public Visibility Item11Vis
        {
            get
            { return _Item11Vis; }
            set
            {
                _Item11Vis = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _Item12Vis;

        public Visibility Item12Vis
        {
            get
            { return _Item12Vis; }
            set
            {
                _Item12Vis = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _Item13Vis;

        public Visibility Item13Vis
        {
            get
            { return _Item13Vis; }
            set
            {
                _Item13Vis = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _Item14Vis;

        public Visibility Item14Vis
        {
            get
            { return _Item14Vis; }
            set
            {
                _Item14Vis = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _Item15Vis;

        public Visibility Item15Vis
        {
            get
            { return _Item15Vis; }
            set
            {
                _Item15Vis = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _Item16Vis;

        public Visibility Item16Vis
        {
            get
            { return _Item16Vis; }
            set
            {
                _Item16Vis = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion
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
        private void SetupFlyerLayout(FlyerSettingsModel settings, FlyerDataModel[] flyerData, DateTime startDate, DateTime endDate)
        {
            StoreName = settings.StoreName;

            SetStoreTypeImages(StoreName);

            StoreNumber = settings.StoreNumber;
            StoreAddress = settings.StoreAddress;

            if (settings.RainChkd)
                ShowRaincheck = Visibility.Visible;
            else
                ShowRaincheck = Visibility.Hidden;

            if (settings.SupplyChkd)
                ShowSupply = Visibility.Visible;
            else
                ShowSupply = Visibility.Hidden;

            //Finish sale dates
            string saleDates = startDate.ToShortDateString() + " TO " + endDate.ToShortDateString();
        }

        private void SetStoreTypeImages(string storeName)
        {

           // StoreLocCmboBox.Add("Piggly Wiggly");
           // StoreLocCmboBox.Add("Food Giant");
           // StoreLocCmboBox.Add("Pic-N-Sav");
           // StoreLocCmboBox.Add("Citronelle Marketplace");
        }


        /// <summary>
        /// Shows/Hides elements based on user selection, will be used for
        /// aspx page to inform it of how many items it will be generating
        /// </summary>
        /// <param name="numVisElements"></param>
        public void ShowHideElements(int numVisElements)
        {
            for (int i = 0; i < _MaxFlyerItems; i++)
            {
                if (i < numVisElements)
                    _FlyerItemVisList[i] = Visibility.Visible;
                else
                    _FlyerItemVisList[i] = Visibility.Hidden;
            }

            Item1Vis = _FlyerItemVisList[0];
            Item2Vis = _FlyerItemVisList[1];
            Item3Vis = _FlyerItemVisList[2];
            Item4Vis = _FlyerItemVisList[3];
            Item5Vis = _FlyerItemVisList[4];
            Item6Vis = _FlyerItemVisList[5];
            Item7Vis = _FlyerItemVisList[6];
            Item8Vis = _FlyerItemVisList[7];
            Item9Vis = _FlyerItemVisList[8];
            Item10Vis = _FlyerItemVisList[9];
            Item11Vis = _FlyerItemVisList[10];
            Item12Vis = _FlyerItemVisList[11];
            Item13Vis = _FlyerItemVisList[12];
            Item14Vis = _FlyerItemVisList[13];
            Item15Vis = _FlyerItemVisList[14];
            Item16Vis = _FlyerItemVisList[15];
        }

    }
}
