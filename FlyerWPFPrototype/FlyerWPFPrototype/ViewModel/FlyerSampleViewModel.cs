﻿using Caliburn.Micro;
using FlyerWPFPrototype.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FlyerWPFPrototype
{
    [Export(typeof(FlyerSampleViewModel))]
    public class FlyerSampleViewModel : Screen
    {
        #region Binding Items
        private ComboBoxItem _NumImages;

        public ComboBoxItem NumImages
        {
            get
            { return _NumImages; }
            set
            {
                _NumImages = value;
                NotifyOfPropertyChange(() => NumImages);
            }
        }

        private BindableCollection<ComboBoxItem> _NumImagesCmboBox;

        public BindableCollection<ComboBoxItem> NumImagesCmboBox
        {
            get
            {
                return _NumImagesCmboBox;
            }
            set
            {
                _NumImagesCmboBox = value;
                NotifyOfPropertyChange(() => NumImagesCmboBox);
            }
        }
        

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
                NotifyOfPropertyChange(() => ItemList);
            }
        }

        #region Price Bindings
        private string _Price1;

        public string Price1
        {
            get
            { return _Price1; }
            set
            {
                _Price1 = value;
                NotifyOfPropertyChange(() => Price1);
            }
        }

        private string _Price2;

        public string Price2
        {
            get
            { return _Price2; }
            set
            {
                _Price2 = value;
                NotifyOfPropertyChange(() => Price2);
            }
        }

        private string _Price3;

        public string Price3
        {
            get
            { return _Price3; }
            set
            {
                _Price3 = value;
                NotifyOfPropertyChange(() => Price3);
            }
        }

        private string _Price4;

        public string Price4
        {
            get
            { return _Price4; }
            set
            {
                _Price4 = value;
                NotifyOfPropertyChange(() => Price4);
            }
        }

        private string _Price5;

        public string Price5
        {
            get
            { return _Price5; }
            set
            {
                _Price5 = value;
                NotifyOfPropertyChange(() => Price5);
            }
        }

        private string _Price6;

        public string Price6
        {
            get
            { return _Price6; }
            set
            {
                _Price6 = value;
                NotifyOfPropertyChange(() => Price6);
            }
        }
        #endregion

        #region ImageSources
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

        private string _Image4Src;

        public string Image4Src
        {
            get
            { return _Image4Src; }
            set
            {
                _Image4Src = value;
                NotifyOfPropertyChange(() => Image4Src);
            }
        }

        private string _Image5Src;

        public string Image5Src
        {
            get
            { return _Image5Src; }
            set
            {
                _Image5Src = value;
                NotifyOfPropertyChange(() => Image5Src);
            }
        }

        private string _Image6Src;

        public string Image6Src
        {
            get
            { return _Image6Src; }
            set
            {
                _Image6Src = value;
                NotifyOfPropertyChange(() => Image6Src);
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

        private readonly IEventAggregator _eventAggregator;
        public FlyerSampleViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);

            PopulateNumImages();
        }

        public FlyerSampleViewModel(string userName)
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
            NumImagesCmboBox = new BindableCollection<ComboBoxItem>();

            PopulateNumImages();
            PopulateItemList();

        }

        protected override void OnActivate()
        {
            base.OnActivate();
        }

        //Checking TODO
        private void PopulateNumImages()
        {
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Content = "1";

            ComboBoxItem item2 = new ComboBoxItem();
            item2.Content = "2";

            ComboBoxItem item3 = new ComboBoxItem();
            item3.Content = "3";

            ComboBoxItem item4 = new ComboBoxItem();
            item4.Content = "4";

            ComboBoxItem item5 = new ComboBoxItem();
            item5.Content = "5";

            ComboBoxItem item6 = new ComboBoxItem();
            item6.Content = "6";

            NumImagesCmboBox.Add(item1);
            NumImagesCmboBox.Add(item2);
            NumImagesCmboBox.Add(item3);
            NumImagesCmboBox.Add(item4);
            NumImagesCmboBox.Add(item5);
            NumImagesCmboBox.Add(item6);
        }

        private void PopulateItemList()
        {
            DatabaseInterface dbInt = new DatabaseInterface();

            ItemList = dbInt.PopulateItemList();
        }

        public void NumImagesCmboBox_SelectionChanged(object sender)
        {
            ComboBox accountBox = sender as ComboBox;
            if (accountBox != null)
                NumImages = accountBox.SelectedItem as ComboBoxItem;

            if(NumImages.Content != null)
            {
                int numVisElements = int.Parse(NumImages.Content.ToString());

                if (numVisElements > 0)
                    ShowHideElements(numVisElements);
            }
        }

        //First attempt at populating item based on user selection
        public void ItemListCmboBox_SelectionChanged(object sender)
        {
            ComboBox itemCmboBox = sender as ComboBox;
            if (itemCmboBox != null)
            {
                ComboBoxItem selectedItemCmboItem = itemCmboBox.SelectedItem as ComboBoxItem;

                if (selectedItemCmboItem != null)
                {
                    FlyerDataModel selectedItem = selectedItemCmboItem.Content as FlyerDataModel;
                    //Maybe store in database once we complete design of image location?
                    string tempImageLocation = Environment.CurrentDirectory + @"Images\";
                    string itemNum = selectedItemCmboItem.Name;                    

                    if (string.IsNullOrEmpty(itemNum) && itemNum.Equals("item1CmboBox"))
                    {
                        Price1 = selectedItem.itemPrice;
                        Image1Src = tempImageLocation + selectedItem.imageName1;
                    }

                    if (string.IsNullOrEmpty(itemNum) && itemNum.Equals("item2CmboBox"))
                    {
                        Price2 = selectedItem.itemPrice;
                        Image2Src = tempImageLocation + selectedItem.imageName1;
                    }

                    if (string.IsNullOrEmpty(itemNum) && itemNum.Equals("item3CmboBox"))
                    {
                        Price3 = selectedItem.itemPrice;
                        Image3Src = tempImageLocation + selectedItem.imageName1;
                    }

                    if (string.IsNullOrEmpty(itemNum) && itemNum.Equals("item4CmboBox"))
                    {
                        Price4 = selectedItem.itemPrice;
                        Image4Src = tempImageLocation + selectedItem.imageName1;
                    }

                    if (string.IsNullOrEmpty(itemNum) && itemNum.Equals("item5CmboBox"))
                    {
                        Price5 = selectedItem.itemPrice;
                        Image5Src = tempImageLocation + selectedItem.imageName1;
                    }

                    if (string.IsNullOrEmpty(itemNum) && itemNum.Equals("item6CmboBox"))
                    {
                        Price6 = selectedItem.itemPrice;
                        Image6Src = tempImageLocation + selectedItem.imageName1;
                    }
                }
            }
        }

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


    }
}
