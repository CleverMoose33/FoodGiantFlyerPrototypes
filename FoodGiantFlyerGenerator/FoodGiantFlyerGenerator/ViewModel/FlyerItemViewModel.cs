using Caliburn.Micro;
using FoodGiantFlyerGenerator.Model;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(FlyerItemViewModel))]
    public class FlyerItemViewModel : PropertyChangedBase
    {
        private readonly IEventAggregator _EventAggregator;

        #region Binding Items
        private BindableCollection<FlyerDataModel> _ItemNameList;

        public BindableCollection<FlyerDataModel> ItemNameList
        {
            get
            {
                return _ItemNameList;
            }
            set
            {
                _ItemNameList = value;
                NotifyOfPropertyChange();
            }
        }

        private BindableCollection<string> _ItemSizeList;

        public BindableCollection<string> ItemSizeList
        {
            get
            {
                return _ItemSizeList;
            }
            set
            {
                _ItemSizeList = value;
                NotifyOfPropertyChange();
            }
        }

        private string _SelectedItemName;

        public string SelectedItemName
        {
            get
            { return _SelectedItemName; }
            set
            {
                _SelectedItemName = value;
                NotifyOfPropertyChange();
            }
        }

        private string _PriceTxtBlk;

        public string PriceTxtBlk
        {
            get
            { return _PriceTxtBlk; }
            set
            {
                _PriceTxtBlk = value;
                NotifyOfPropertyChange();
            }
        }

        private string _SelectedItemSize;

        public string SelectedItemSize
        {
            get
            { return _SelectedItemSize; }
            set
            {
                _SelectedItemSize = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _ItemSizeCmboBoxBlockVis;

        public Visibility ItemSizeCmboBoxBlockVis
        {
            get
            { return _ItemSizeCmboBoxBlockVis; }
            set
            {
                _ItemSizeCmboBoxBlockVis = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _ItemSizeTxtBlockVis;

        public Visibility ItemSizeTxtBlockVis
        {
            get
            { return _ItemSizeTxtBlockVis; }
            set
            {
                _ItemSizeTxtBlockVis = value;
                NotifyOfPropertyChange();
            }
        }

        private string _ItemDesTxtBlk;

        public string ItemDesTxtBlk
        {
            get
            { return _ItemDesTxtBlk; }
            set
            {
                _ItemDesTxtBlk = value;
                NotifyOfPropertyChange();
            }
        }

        //Not implemented
        private string _ItemCategory;

        public string ItemCategory
        {
            get
            { return _ItemCategory; }
            set
            {
                _ItemCategory = value;
                NotifyOfPropertyChange();
            }
        }

        #region Images and Border Brushes
        private SolidColorBrush _BdrBrsh1;

        public SolidColorBrush BdrBrsh1
        {
            get
            { return _BdrBrsh1; }
            set
            {
                _BdrBrsh1 = value;
                NotifyOfPropertyChange();
            }
        }

        private SolidColorBrush _BdrBrsh2;

        public SolidColorBrush BdrBrsh2
        {
            get
            { return _BdrBrsh2; }
            set
            {
                _BdrBrsh2 = value;
                NotifyOfPropertyChange();
            }
        }

        private SolidColorBrush _BdrBrsh3;

        public SolidColorBrush BdrBrsh3
        {
            get
            { return _BdrBrsh3; }
            set
            {
                _BdrBrsh3 = value;
                NotifyOfPropertyChange();
            }
        }

        private string _ImgSrc1;

        public string ImgSrc1
        {
            get
            { return _ImgSrc1; }
            set
            {
                _ImgSrc1 = value;
                NotifyOfPropertyChange();
            }
        }

        private string _ImgSrc2;

        public string ImgSrc2
        {
            get
            { return _ImgSrc2; }
            set
            {
                _ImgSrc2 = value;
                NotifyOfPropertyChange();
            }
        }

        private string _ImgSrc3;

        public string ImgSrc3
        {
            get
            { return _ImgSrc3; }
            set
            {
                _ImgSrc3 = value;
                NotifyOfPropertyChange();
            }
        }

        private string _SelectedImage;

        public string SelectedImage
        {
            get
            { return _SelectedImage; }
            set
            {
                _SelectedImage = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public FlyerItemViewModel()
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);

            DatabaseInterface dbInt = new DatabaseInterface();
            ItemNameList = dbInt.PullFlyerItems();

            SetDefaultTextFields();
            SetDefaultBdrBrsh();

            //Set combo box as visible item by default, hide text box
            ItemSizeCmboBoxBlockVis = Visibility.Visible;
            ItemSizeTxtBlockVis = Visibility.Collapsed;
        }

        /// <summary>
        /// Create values for each flyer item
        /// Potential future improvement: read from database?
        /// </summary>
        public void SetDefaultTextFields()
        {
            PriceTxtBlk = "Enter Price Here";
            ItemDesTxtBlk = "Enter Item Description";

            ItemSizeList = new BindableCollection<string>();
            ItemSizeList.Add("Oz");
            ItemSizeList.Add("Bag");
            ItemSizeList.Add("Per Pound");
            ItemSizeList.Add("Each");
            ItemSizeList.Add("Jumbo Pack");
            ItemSizeList.Add("Family Pack");

            ItemSizeList.Add("Custom");
        }

        /// <summary>
        /// Initialize and set brush color
        /// </summary>
        public void SetDefaultBdrBrsh()
        {
            BdrBrsh1 = Brushes.Black;
            BdrBrsh2 = Brushes.Black;
            BdrBrsh3 = Brushes.Black;
        }

        #region Item Event Handlers
        /// <summary>
        /// Updates selected item name value
        /// </summary>
        /// <param name="selectedItmCmboBox"></param>
        public void ItemListCmboBox_SelectionChanged(ComboBox selectedItmCmboBox)
        {
            string tempImgLocation = Environment.CurrentDirectory + @"\Images\";
            if (selectedItmCmboBox != null)
            {
                FlyerDataModel selectedFlyerModel = selectedItmCmboBox.SelectedItem as FlyerDataModel;
                SelectedItemName = selectedFlyerModel.ItemName;
                ImgSrc1 = tempImgLocation + selectedFlyerModel.ImgName1;
                ImgSrc2 = tempImgLocation + selectedFlyerModel.ImgName2;
                ImgSrc3 = tempImgLocation + selectedFlyerModel.ImgName3;
            }
        }

        /// <summary>
        /// Updates selected item size value
        /// If user selects Custom, box changes to block, allowing manual user entry
        /// </summary>
        /// <param name="selectedItmCmboBox"></param>
        public void ItemSizeCmboBox_SelectionChanged(ComboBox selectedItmCmboBox)
        {
            if (selectedItmCmboBox != null)
            {
                if (selectedItmCmboBox.SelectedItem.ToString().Equals("Custom"))
                {
                    ItemSizeTxtBlockVis = Visibility.Visible;
                    ItemSizeCmboBoxBlockVis = Visibility.Collapsed;
                }
                else
                    SelectedItemSize = selectedItmCmboBox.SelectedItem.ToString();
            }
        }

        /// <summary>
        /// Highlight selected Img border
        /// </summary>
        /// <param name="selectedImg"></param>
        public void ImgSrc1Changed()
        {
            BdrBrsh1 = Brushes.Gold;
            BdrBrsh2 = Brushes.Black;
            BdrBrsh3 = Brushes.Black;

            SelectedImage = ImgSrc1;
        }

        /// <summary>
        /// Highlight selected Img border
        /// </summary>
        /// <param name="selectedImg"></param>
        public void ImgSrc2Changed()
        {
            BdrBrsh1 = Brushes.Black;
            BdrBrsh2 = Brushes.Gold;
            BdrBrsh3 = Brushes.Black;

            SelectedImage = ImgSrc2;
        }


        /// <summary>
        /// Highlight selected Img border
        /// </summary>
        /// <param name="selectedImg"></param>
        public void ImgSrc3Changed()
        {
            BdrBrsh1 = Brushes.Black;
            BdrBrsh2 = Brushes.Black;
            BdrBrsh3 = Brushes.Gold;

            SelectedImage = ImgSrc3;
        }
        #endregion
    }
}
