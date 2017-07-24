using Caliburn.Micro;
using FoodGiantFlyerGenerator.Model;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Media;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(GenericFlyerViewModel))]
    public class GenericFlyerViewModel : Screen
    {
        private readonly IEventAggregator _EventAggregator;

        private readonly int _MaxFlyerItems = 16;
        private FlyerItemContainerViewModel[] _FlyerItemList;
        public FlyerDataModel[] _FlyerData;
        private Visibility[] _FlyerItemVisList;
        
        public DateTime _StartDate;
        public DateTime _EndDate;

        //Future Improvements: Make Gneric Flyer Interface to force flyers to inherit data
        #region Binding Items

        #region StoreLogo Items
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

        private string _LogoImgSrc;

        public string LogoImgSrc
        {
            get
            { return _LogoImgSrc; }
            set
            {
                _LogoImgSrc = value;
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

        #region DateBindings
        private string _FirstDayName;

        public string FirstDayName
        {
            get
            { return _FirstDayName; }
            set
            {
                _FirstDayName = value;
                NotifyOfPropertyChange();
            }
        }

        private string _SecondDayName;

        public string SecondDayName
        {
            get
            { return _SecondDayName; }
            set
            {
                _SecondDayName = value;
                NotifyOfPropertyChange();
            }
        }

        private string _ThirdDayName;

        public string ThirdDayName
        {
            get
            { return _ThirdDayName; }
            set
            {
                _ThirdDayName = value;
                NotifyOfPropertyChange();
            }
        }

        private string _FirstDayNum;

        public string FirstDayNum
        {
            get
            { return _FirstDayNum; }
            set
            {
                _FirstDayNum = value;
                NotifyOfPropertyChange();
            }
        }

        private string _SecondDayNum;

        public string SecondDayNum
        {
            get
            { return _SecondDayNum; }
            set
            {
                _SecondDayNum = value;
                NotifyOfPropertyChange();
            }
        }

        private string _ThirdDayNum;

        public string ThirdDayNum
        {
            get
            { return _ThirdDayNum; }
            set
            {
                _ThirdDayNum = value;
                NotifyOfPropertyChange();
            }
        }

        #endregion

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
        #endregion

        #region Flyer Binding Items
        private FlyerItemContainerViewModel _FlyerItem1;

        public FlyerItemContainerViewModel FlyerItem1
        {
            get
            { return _FlyerItem1; }
            set
            {
                _FlyerItem1 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem2;

        public FlyerItemContainerViewModel FlyerItem2
        {
            get
            { return _FlyerItem2; }
            set
            {
                _FlyerItem2 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem3;

        public FlyerItemContainerViewModel FlyerItem3
        {
            get
            { return _FlyerItem3; }
            set
            {
                _FlyerItem3 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem4;

        public FlyerItemContainerViewModel FlyerItem4
        {
            get
            { return _FlyerItem4; }
            set
            {
                _FlyerItem4 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem5;

        public FlyerItemContainerViewModel FlyerItem5
        {
            get
            { return _FlyerItem5; }
            set
            {
                _FlyerItem5 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem6;

        public FlyerItemContainerViewModel FlyerItem6
        {
            get
            { return _FlyerItem6; }
            set
            {
                _FlyerItem6 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem7;

        public FlyerItemContainerViewModel FlyerItem7
        {
            get
            { return _FlyerItem7; }
            set
            {
                _FlyerItem7 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem8;

        public FlyerItemContainerViewModel FlyerItem8
        {
            get
            { return _FlyerItem8; }
            set
            {
                _FlyerItem8 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem9;

        public FlyerItemContainerViewModel FlyerItem9
        {
            get
            { return _FlyerItem9; }
            set
            {
                _FlyerItem9 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem10;

        public FlyerItemContainerViewModel FlyerItem10
        {
            get
            { return _FlyerItem10; }
            set
            {
                _FlyerItem10 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem11;

        public FlyerItemContainerViewModel FlyerItem11
        {
            get
            { return _FlyerItem11; }
            set
            {
                _FlyerItem11 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem12;

        public FlyerItemContainerViewModel FlyerItem12
        {
            get
            { return _FlyerItem12; }
            set
            {
                _FlyerItem12 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem13;

        public FlyerItemContainerViewModel FlyerItem13
        {
            get
            { return _FlyerItem13; }
            set
            {
                _FlyerItem13 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem14;

        public FlyerItemContainerViewModel FlyerItem14
        {
            get
            { return _FlyerItem14; }
            set
            {
                _FlyerItem14 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem15;

        public FlyerItemContainerViewModel FlyerItem15
        {
            get
            { return _FlyerItem15; }
            set
            {
                _FlyerItem15 = value;
                NotifyOfPropertyChange();
            }
        }

        private FlyerItemContainerViewModel _FlyerItem16;

        public FlyerItemContainerViewModel FlyerItem16
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

            SetFlyerVisList();
            SetupFlyerLayout(settings, startDate, endDate);
            PopulateFlyerValues(flyerData);
        }

        /// <summary>
        /// Constructor for Flyer
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="flyerData"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public GenericFlyerViewModel(FlyerHistoryModel flyerHistory)
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);

            SetFlyerVisList();

            FlyerSettingsModel settings = new FlyerSettingsModel(flyerHistory.StoreName, flyerHistory.StoreAddress, 
                flyerHistory.StoreNumber, flyerHistory.SupplyChecked, flyerHistory.RaincheckChecked);

            DateTime startDate = DateTime.Parse(flyerHistory.FlyerStartDate);
            DateTime endDate = DateTime.Parse(flyerHistory.FlyerEndDate);

            SetupFlyerLayout(settings, startDate, endDate);

            FlyerDataModel[] flyerDataArray = new FlyerDataModel[flyerHistory.flyerItemLst.Count];

            for(int i = 0; i< flyerHistory.flyerItemLst.Count; i++)
            {
                flyerDataArray[i] = flyerHistory.flyerItemLst[i];
            }
            
            PopulateFlyerValues(flyerDataArray);
        }

        #region Generic Flyer Methods
        /// <summary>
        /// Set array based on number of user selected items
        /// </summary>
        private void SetFlyerVisList()
        {
            _FlyerItemVisList = new Visibility[_MaxFlyerItems];
        }

        /// <summary>
        /// Add all selected flyer items to Generic Flyer
        /// </summary>
        /// <param name="flyerDataArray"></param>
        private void PopulateFlyerValues(FlyerDataModel[] flyerDataArray)
        {
            _FlyerData = flyerDataArray;
            GenerateFlyerItems();

            for (int i = 0; i < flyerDataArray.Length; i++)
            {
                _FlyerItemList[i].PopulateFlyerValues(flyerDataArray[i]);
            }

            ShowHideElements(flyerDataArray.Length);
        }

        /// <summary>
        /// Instantiate max number of Flyer Items
        /// Could use case to limit unnecessary calls
        /// </summary>
        /// <param name="flyerData"></param>
        private void GenerateFlyerItems()
        {
            FlyerItem1 = new FlyerItemContainerViewModel();
            FlyerItem2 = new FlyerItemContainerViewModel();
            FlyerItem3 = new FlyerItemContainerViewModel();
            FlyerItem4 = new FlyerItemContainerViewModel();
            FlyerItem5 = new FlyerItemContainerViewModel();
            FlyerItem6 = new FlyerItemContainerViewModel();
            FlyerItem7 = new FlyerItemContainerViewModel();
            FlyerItem8 = new FlyerItemContainerViewModel();
            FlyerItem9 = new FlyerItemContainerViewModel();
            FlyerItem10 = new FlyerItemContainerViewModel();
            FlyerItem11 = new FlyerItemContainerViewModel();
            FlyerItem12 = new FlyerItemContainerViewModel();
            FlyerItem13 = new FlyerItemContainerViewModel();
            FlyerItem14 = new FlyerItemContainerViewModel();
            FlyerItem15 = new FlyerItemContainerViewModel();
            FlyerItem16 = new FlyerItemContainerViewModel();

            //Add Flyer Items to Array
            _FlyerItemList = new FlyerItemContainerViewModel[_MaxFlyerItems];
            _FlyerItemList[0] = FlyerItem1;
            _FlyerItemList[1] = FlyerItem2;
            _FlyerItemList[2] = FlyerItem3;
            _FlyerItemList[3] = FlyerItem4;
            _FlyerItemList[4] = FlyerItem5;
            _FlyerItemList[5] = FlyerItem6;
            _FlyerItemList[6] = FlyerItem7;
            _FlyerItemList[7] = FlyerItem8;
            _FlyerItemList[8] = FlyerItem9;
            _FlyerItemList[9] = FlyerItem10;
            _FlyerItemList[10] = FlyerItem11;
            _FlyerItemList[11] = FlyerItem12;
            _FlyerItemList[12] = FlyerItem13;
            _FlyerItemList[13] = FlyerItem14;
            _FlyerItemList[14] = FlyerItem15;
            _FlyerItemList[15] = FlyerItem16;
        }

        /// <summary>
        /// Set store image based on user selection
        /// </summary>
        /// <param name="storeName"></param>
        private void SetStoreTypeImages(string storeName)
        {
            string tempImageLocation = Environment.CurrentDirectory + @"\Program Images\";
            if (storeName.Equals("Piggly Wiggly"))
                LogoImgSrc = tempImageLocation + "PIGLogo.PNG";
            else if (storeName.Equals("Food Giant"))
                LogoImgSrc = tempImageLocation + "FGLogo.png";
            else if (storeName.Equals("Pic-N-Sav"))
                LogoImgSrc = tempImageLocation + "PICNSAVLogo.PNG";
            else if (storeName.Equals("Citronelle Marketplace"))
                LogoImgSrc = tempImageLocation + "MarketLogo.PNG";
        }

        /// <summary>
        /// Shows/Hides elements based on user selection, will be used for
        /// aspx page to inform it of how many items it will be generating
        /// </summary>
        /// <param name="numVisElements"></param>
        private void ShowHideElements(int numVisElements)
        {
            for (int i = 0; i < _MaxFlyerItems; i++)
            {
                if (i < numVisElements)
                    _FlyerItemVisList[i] = Visibility.Visible;
                else
                    _FlyerItemVisList[i] = Visibility.Collapsed;
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
        #endregion

        /// <summary>
        /// Use objects generated from FlyerCreatorVM to populate Generic Flyer
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="flyerData"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        private void SetupFlyerLayout(FlyerSettingsModel settings, DateTime startDate, DateTime endDate)
        {
            SetSaleDates(startDate, endDate);

            StoreName = settings.StoreName;

            SetStoreTypeImages(StoreName);

            StoreNumber = settings.StoreNumber;
            StoreAddress = settings.StoreAddress;

            if (settings.RainChkd)
                ShowRaincheck = Visibility.Visible;
            else
                ShowRaincheck = Visibility.Collapsed;

            if (settings.SupplyChkd)
                ShowSupply = Visibility.Visible;
            else
                ShowSupply = Visibility.Collapsed;
        }

        /// <summary>
        /// Set Calendar dates
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        private void SetSaleDates(DateTime startDate, DateTime endDate)
        {
            _StartDate = startDate;
            _EndDate = endDate;

            DateTime secondDate = startDate.AddDays(1);

            FirstDayName = startDate.DayOfWeek.ToString().Remove(3);
            SecondDayName = secondDate.DayOfWeek.ToString().Remove(3);
            ThirdDayName = endDate.DayOfWeek.ToString().Remove(3);

            FirstDayNum = startDate.Day.ToString();
            SecondDayNum = secondDate.Day.ToString();
            ThirdDayNum = endDate.Day.ToString();
        }

    }
}