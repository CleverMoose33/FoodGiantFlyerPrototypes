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
    [Export(typeof(DatabaseMaintainerViewModel))]
    public class DatabaseMaintainerViewModel : PropertyChangedBase //Or Screen if visual
    {
        private readonly IEventAggregator _eventAggregator;
        private DatabaseInterface dbInt;
        #region Binding Items

        #region Item Parameters
        private string _ItemName;

        public string ItemName
        {
            get
            { return _ItemName; }
            set
            {
                _ItemName = value;
                NotifyOfPropertyChange(() => ItemName);
            }
        }

        private string _ItemCategory;

        public string ItemCategory
        {
            get
            { return _ItemCategory; }
            set
            {
                _ItemCategory = value;
                NotifyOfPropertyChange(() => ItemCategory);
            }
        }

        private string _Price;

        public string Price
        {
            get
            { return _Price; }
            set
            {
                _Price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }

        private string _Image1Src;

        public string Image1Src
        {
            get
            { return _Image1Src; }
            set
            {
                _Image1Src = value;
                NotifyOfPropertyChange(() => Image1Src);
            }
        }

        private string _Image2Src;

        public string Image2Src
        {
            get
            { return _Image2Src; }
            set
            {
                _Image2Src = value;
                NotifyOfPropertyChange(() => Image2Src);
            }
        }

        private string _Image3Src;

        public string Image3Src
        {
            get
            { return _Image3Src; }
            set
            {
                _Image3Src = value;
                NotifyOfPropertyChange(() => Image3Src);
            }
        }
        #endregion

        #region Button Parameters
        private string _Item1SlctnBtn;

        public string Item1SlctnBtn
        {
            get
            { return _Item1SlctnBtn; }
            set
            {
                _Item1SlctnBtn = value;
                NotifyOfPropertyChange(() => Item1SlctnBtn);
            }
        }

        private string _Item2SlctnBtn;

        public string Item2SlctnBtn
        {
            get
            { return _Item2SlctnBtn; }
            set
            {
                _Item2SlctnBtn = value;
                NotifyOfPropertyChange(() => Item2SlctnBtn);
            }
        }

        private string _Item3SlctnBtn;

        public string Item3SlctnBtn
        {
            get
            { return _Item3SlctnBtn; }
            set
            {
                _Item3SlctnBtn = value;
                NotifyOfPropertyChange(() => Item3SlctnBtn);
            }
        }
        #endregion

        #endregion

        public DatabaseMaintainerViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);

            dbInt = new DatabaseInterface();
        }

        private void SetDefaultValues()
        {
            ItemName = "Enter Item Name Here";
            ItemCategory = "Enter Item Category Here";
            Price = "$0.00";
            Item1SlctnBtn = Item2SlctnBtn = Item3SlctnBtn = "Select an Image";
        }

        public void AddItemToDatabase()
        {
            //Pull items, create new FlyerItemModel

            FlyerDataModel newModelItem = new FlyerDataModel(ItemName, ItemCategory, Image1Src, Image2Src, Image3Src);
            //Validate Params
            dbInt.AddNewItem(newModelItem);
        }

    }
}
