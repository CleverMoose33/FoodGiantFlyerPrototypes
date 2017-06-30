using Caliburn.Micro;
using FoodGiantFlyerGenerator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(FlyerCreatorViewModel))]
    public class FlyerCreatorViewModel : Screen
    {
        private readonly IEventAggregator _EventAggregator;

        private readonly int _MaxFlyerItems = 16;

        private string _SelectedFlyerTemplate;
        private int _NumDisplayedFlyerItems;
        private FlyerItemViewModel[] _FlyerItemList;
        private Visibility[] _FlyerItemVisList;

        private DateTime _SelectedStartDate;
        private DateTime _SelectedEndDate;

        #region Binding Items

        #region Check Boxes
        private bool _SupplyChkBox;

        private bool _RainChkBox;
        #endregion

        #region ComboBox Bindings
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

        private List<string> _StoreLocCmboBox;

        public List<string> StoreLocCmboBox
        {
            get
            {
                return _StoreLocCmboBox;
            }
            set
            {
                _StoreLocCmboBox = value;
                NotifyOfPropertyChange();
            }
        }

        private List<int> _NumItemsCmboBox;

        public List<int> NumItemsCmboBox
        {
            get
            {
                return _NumItemsCmboBox;
            }
            set
            {
                _NumItemsCmboBox = value;
                NotifyOfPropertyChange();
            }
        }

        private List<string> _FlyerTemplatesCmboBox;

        public List<string> FlyerTemplatesCmboBox
        {
            get
            {
                return _FlyerTemplatesCmboBox;
            }
            set
            {
                _FlyerTemplatesCmboBox = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion

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
        /// Constructor for Class
        /// </summary>
        public FlyerCreatorViewModel()
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);

            CreateStoreLocs();
            CreateFlyerTemplates();
            CreateFlyerItems();
            SetFlyerVisList();
            PopulateNumFlyerItems();
            Title = "Food Giant Flyer Creator";
        }

        #region Flyer Creator Items Instantiation
        /// <summary>
        /// Create initial Store Location Combo Box Values
        /// </summary>
        public void CreateStoreLocs()
        {
            StoreLocCmboBox = new List<string>();
            StoreLocCmboBox.Add("Piggly Wiggly");
            StoreLocCmboBox.Add("Food Giant");
            StoreLocCmboBox.Add("Pic-N-Sav");
            StoreLocCmboBox.Add("Citronelle Marketplace");
        }

        /// <summary>
        /// Create initial Flyer Template Combo Box Values
        /// </summary>
        public void CreateFlyerTemplates()
        {
            FlyerTemplatesCmboBox = new List<string>();
            FlyerTemplatesCmboBox.Add("Generic 3 day Flyer");
            FlyerTemplatesCmboBox.Add("Generic 12 hour Flyer");

            _SelectedFlyerTemplate = FlyerTemplatesCmboBox[0];
        }

        /// <summary>
        /// Instantiate flyer items
        /// </summary>
        public void CreateFlyerItems()
        {
            FlyerItem1 = new FlyerItemViewModel();
            FlyerItem2 = new FlyerItemViewModel();
            FlyerItem3 = new FlyerItemViewModel();
            FlyerItem4 = new FlyerItemViewModel();
            FlyerItem5 = new FlyerItemViewModel();
            FlyerItem6 = new FlyerItemViewModel();
            FlyerItem7 = new FlyerItemViewModel();
            FlyerItem8 = new FlyerItemViewModel();
            FlyerItem9 = new FlyerItemViewModel();
            FlyerItem10 = new FlyerItemViewModel();
            FlyerItem11 = new FlyerItemViewModel();
            FlyerItem12 = new FlyerItemViewModel();
            FlyerItem13 = new FlyerItemViewModel();
            FlyerItem14 = new FlyerItemViewModel();
            FlyerItem15 = new FlyerItemViewModel();
            FlyerItem16 = new FlyerItemViewModel();

            //Add Flyer Items to Array
            _FlyerItemList = new FlyerItemViewModel[_MaxFlyerItems];
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
        /// Add visibility objects to array. Used for ShowHideElements method
        /// </summary>
        public void SetFlyerVisList()
        {
            _FlyerItemVisList = new Visibility[_MaxFlyerItems];
        }

        /// <summary>
        /// Populated ascending list for Flyer Items in variable NumImagesCmboBox
        /// Lets user select how many flyer items that want added
        /// </summary>
        private void PopulateNumFlyerItems()
        {
            NumItemsCmboBox = new List<int>();
            for (int i = 0; i < _MaxFlyerItems; i++)
            {
                //Adding one due to arrays starting at 0
                NumItemsCmboBox.Add(i + 1);
            }

            //Method to force control to hide images by default
            //Showing 3 flyer items initially
            _NumDisplayedFlyerItems = NumItemsCmboBox[2];
            ShowHideElements(_NumDisplayedFlyerItems);
        }
        #endregion

        #region User Events
        #region FlyerGeneration
        public void GenerateFlyer()
        {
            FlyerDataModel[] flyerData = new FlyerDataModel[_NumDisplayedFlyerItems];
            for (int i = 0; i < _NumDisplayedFlyerItems; i++)
            {
                flyerData[i] = new FlyerDataModel();
                flyerData[i].ItemName = _FlyerItemList[i].SelectedItemName;
                flyerData[i].ItemPrice = _FlyerItemList[i].PriceTxtBlk;
                flyerData[i].ItemSize = _FlyerItemList[i].SelectedItemSize;
                flyerData[i].ItemDesc = _FlyerItemList[i].ItemDesTxtBlk;
                flyerData[i].ImgName1 = _FlyerItemList[i].SelectedImage;

                //Future implementation for Item Category
                //flyerData[i].ItemCategory = _FlyerItemList[i].ItemCategory;
            }
            FlyerSettingsModel settings = new FlyerSettingsModel(StoreName, StoreAddress, StoreNumber, _SupplyChkBox, _RainChkBox);

            //Outside current SRS TODO: Launch different flyers based on user choice
            //if (_SelectedFlyerTemplate.Equals("Generic Flyer"))
            //{
            //    WindowManager wm = new WindowManager();
            //    GenericFlyerViewModel gfvm = new GenericFlyerViewModel(settings, flyerData, _SelectedStartDate, _SelectedEndDate);
            //    wm.ShowDialog(gfvm);
            //}
            //Currently launching generic flyer, TODO launch from Flyer display control model at some point
            WindowManager wm = new WindowManager();
            GenericFlyerViewModel gfvm = new GenericFlyerViewModel(settings, flyerData, _SelectedStartDate, _SelectedEndDate);
            wm.ShowDialog(gfvm);

        }
        #endregion

        #region ComboBox Entry Events
        /// <summary>
        /// Event for selection changed, updates Visual Elements
        /// </summary>
        /// <param name="numVisElements"></param>
        public void NumImagesCmboBox_SelectionChanged(int numVisElements)
        {
            _NumDisplayedFlyerItems = numVisElements;
            ShowHideElements(_NumDisplayedFlyerItems);
        }

        public void StoreLocCmboBox_SelectionChanged(string storeName)
        {
            StoreName = storeName;
        }

        public void StoreAddress_TextChanged(string storeAddress)
        {
            StoreAddress = storeAddress;
        }

        public void StoreNumber_TextChanged(string storeNumber)
        {
            StoreNumber = storeNumber;
        }

        public void FlyerTemplateCmboBox_SelectionChanged(string flyerTemplateName)
        {
            _SelectedFlyerTemplate = flyerTemplateName;
        }

        public void SupplyChkBox_SelectionChanged(CheckBox chkBox)
        {
            _SupplyChkBox = chkBox.IsChecked.Value;
        }

        public void RainChkBox_SelectionChanged(CheckBox chkBox)
        {
            _RainChkBox = chkBox.IsChecked.Value;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedDate"></param>
        public void PickStartSaleDate(DatePicker selectedDate)
        {
            _SelectedStartDate = selectedDate.DisplayDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedDate"></param>
        public void PickEndSaleDate(DatePicker selectedDate)
        {
            _SelectedEndDate = selectedDate.DisplayDate;
        }

        #region Visibility

            /// <summary>
            /// Shows/Hides elements based on user selection, will be used for
            /// aspx page to inform it of how many items it will be generating
            /// </summary>
            /// <param name="numVisElements"></param>
        public void ShowHideElements(int numVisElements)
        {
            for(int i = 0; i < _MaxFlyerItems; i++)
            {
                if (i < numVisElements)
                    _FlyerItemVisList[i] = Visibility.Visible;
                else
                    _FlyerItemVisList[i] = Visibility.Collapsed;
            }

            Item1Vis = _FlyerItemVisList[0];
            Item2Vis =_FlyerItemVisList[1];
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
        #endregion

    }
}
