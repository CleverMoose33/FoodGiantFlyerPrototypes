using Caliburn.Micro;
using FoodGiantFlyerGenerator.Model;
using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using System.Windows.Media;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(FlyerItemViewModel))]
    public class FlyerItemViewModel : PropertyChangedBase //Or Screen if visual
    {
        private readonly IEventAggregator _eventAggregator;

        #region Binding Items
        private BindableCollection<FlyerDataModel> _ItemList;

        public BindableCollection<FlyerDataModel> ItemList
        {
            get
            {
                return _ItemList;
            }
            set
            {
                _ItemList = value;
                NotifyOfPropertyChange();
            }
        }

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
        #endregion

        public FlyerItemViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);

            DatabaseInterface dbInt = new DatabaseInterface();
            ItemList = dbInt.PullItems();

            SetDefaultBdrBrsh();

        }

        #region Item Event Handlers
        public void ItemListCmboBox_SelectionChanged(ComboBox selectedItmCmboBox)
        {
            string tempImgLocation = Environment.CurrentDirectory + @"\Images\";
            if (selectedItmCmboBox != null)
            {
                FlyerDataModel selectedFlyerModel = selectedItmCmboBox.SelectedItem as FlyerDataModel;

                ImgSrc1 = tempImgLocation + selectedFlyerModel.ImgName1;
                ImgSrc2 = tempImgLocation + selectedFlyerModel.ImgName2;
                ImgSrc3 = tempImgLocation + selectedFlyerModel.ImgName3;
            }
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

        /// <summary>
        /// Highlight selected Img border
        /// </summary>
        /// <param name="selectedImg"></param>
        public void ImgSrc1Changed()
        {
            BdrBrsh1 = Brushes.Gold;
            BdrBrsh2 = Brushes.Black;
            BdrBrsh3 = Brushes.Black;
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
        }

        #endregion
    }
}
