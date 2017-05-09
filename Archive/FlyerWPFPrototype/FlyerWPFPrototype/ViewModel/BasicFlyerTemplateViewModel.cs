using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FlyerWPFPrototype
{
    [Export(typeof(BasicFlyerTemplateViewModel))]
    public class BasicFlyerTemplateViewModel : Screen
    {
        #region Binding Items
        #region ItemName Bindings
        private string _Item1Txt;

        public string Item1Txt
        {
            get
            { return _Item1Txt; }
            set
            {
                _Item1Txt = value;
                NotifyOfPropertyChange(() => Item1Txt);
            }
        }

        private string _Item2Txt;

        public string Item2Txt
        {
            get
            { return _Item2Txt; }
            set
            {
                _Item2Txt = value;
                NotifyOfPropertyChange(() => Item2Txt);
            }
        }

        private string _Item3Txt;

        public string Item3Txt
        {
            get
            { return _Item3Txt; }
            set
            {
                _Item3Txt = value;
                NotifyOfPropertyChange(() => Item3Txt);
            }
        }

        private string _Item4Txt;

        public string Item4Txt
        {
            get
            { return _Item4Txt; }
            set
            {
                _Item4Txt = value;
                NotifyOfPropertyChange(() => Item4Txt);
            }
        }

        private string _Item5Txt;

        public string Item5Txt
        {
            get
            { return _Item5Txt; }
            set
            {
                _Item5Txt = value;
                NotifyOfPropertyChange(() => Item5Txt);
            }
        }

        private string _Item6Txt;

        public string Item6Txt
        {
            get
            { return _Item6Txt; }
            set
            {
                _Item6Txt = value;
                NotifyOfPropertyChange(() => Item6Txt);
            }
        }
        #endregion

        #region Price Texts
        private string _Price1Txt;

        public string Price1Txt
        {
            get
            { return _Price1Txt; }
            set
            {
                _Price1Txt = value;
                NotifyOfPropertyChange(() => Price1Txt);
            }
        }

        private string _Price2Txt;

        public string Price2Txt
        {
            get
            { return _Price2Txt; }
            set
            {
                _Price2Txt = value;
                NotifyOfPropertyChange(() => Price2Txt);
            }
        }

        private string _Price3Txt;

        public string Price3Txt
        {
            get
            { return _Price3Txt; }
            set
            {
                _Price3Txt = value;
                NotifyOfPropertyChange(() => Price3Txt);
            }
        }

        private string _Price4Txt;

        public string Price4Txt
        {
            get
            { return _Price4Txt; }
            set
            {
                _Price4Txt = value;
                NotifyOfPropertyChange(() => Price4Txt);
            }
        }

        private string _Price5Txt;

        public string Price5Txt
        {
            get
            { return _Price5Txt; }
            set
            {
                _Price5Txt = value;
                NotifyOfPropertyChange(() => Price5Txt);
            }
        }

        private string _Price6Txt;

        public string Price6Txt
        {
            get
            { return _Price6Txt; }
            set
            {
                _Price6Txt = value;
                NotifyOfPropertyChange(() => Price6Txt);
            }
        }
        #endregion

        #region Image Sources
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

        #region FlyerSetupBindings
        private string _GroceryStoreImage;

        public string GroceryStoreImage
        {
            get
            { return _GroceryStoreImage; }
            set
            {
                _GroceryStoreImage = value;
                NotifyOfPropertyChange(() => GroceryStoreImage);
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
                NotifyOfPropertyChange(() => SaleDates);
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
                NotifyOfPropertyChange(() => FlyerBackgroundColor);
            }
        }
        #endregion

        #endregion

        private string imageDirectory = Environment.CurrentDirectory + @"\Images\";
        private DateTime saleDate = DateTime.Now;

        private readonly IEventAggregator _eventAggregator;
        public BasicFlyerTemplateViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
            GroceryStoreImage = imageDirectory + @"picnsav.PNG";
        }

        public BasicFlyerTemplateViewModel(List<string> itemNames, List<string> prices, List<string> imageSrcs, string saleDates, string storeType)
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);

            //Defaulting to picnsav layout, this will need to be passed from parameters
            GroceryStoreImage = imageDirectory + @"picnsav.PNG";
            FlyerBackgroundColor = Brushes.Red;
            SaleDates = saleDate.ToLongDateString();

            //Temp
            HideImages();
            PopulateFlyerData(itemNames, prices, imageSrcs);
            //PopulateFlyerPrices(prices);
            //PopulateFlyerImages(imageSrcs);
        }

        #region Flyer Population Methods
        private void HideImages()
        {
            Item1Vis = Visibility.Hidden;
            Item2Vis = Visibility.Hidden;
            Item3Vis = Visibility.Hidden;
            Item4Vis = Visibility.Hidden;
            Item5Vis = Visibility.Hidden;
            Item6Vis = Visibility.Hidden;
        }
        private void PopulateFlyerData(List<string> itemNames, List<string> prices, List<string> imageSrcs)
        {
            Item1Txt = itemNames[0];
            Price1Txt = prices[0];
            Image1Src = imageSrcs[0];
            Item1Vis = Visibility.Visible;

            if (itemNames.Count > 1)
            {
                Item2Txt = itemNames[1];
                Price2Txt = prices[1];
                Image2Src = imageSrcs[1];
                Item2Vis = Visibility.Visible;
            }

            if (itemNames.Count > 2)
            {
                Item3Txt = itemNames[2];
                Price3Txt = prices[2];
                Image3Src = imageSrcs[2];
                Item3Vis = Visibility.Visible;
            }

            if (itemNames.Count > 3)
            {
                Item4Txt = itemNames[3];
                Price4Txt = prices[3];
                Image4Src = imageSrcs[3];
                Item4Vis = Visibility.Visible;
            }

            if (itemNames.Count > 4)
            {
                Item5Txt = itemNames[4];
                Price5Txt = prices[4];
                Image5Src = imageSrcs[4];
                Item5Vis = Visibility.Visible;
            }

            if (itemNames.Count > 5)
            {
                Item6Txt = itemNames[5];
                Price6Txt = prices[5];
                Image6Src = imageSrcs[5];
                Item6Vis = Visibility.Visible;
            }
        }

        private void PopulateFlyerPrices(List<string> prices)
        {
            for (int i = 0; i < prices.Count; i++)
            {
                Price1Txt = prices[0];

                if (prices.Count > 1)
                    Price2Txt = prices[1];
                if (prices.Count > 2)
                    Price3Txt = prices[2];
                if (prices.Count > 3)
                    Price4Txt = prices[3];
                if (prices.Count > 4)
                    Price5Txt = prices[4];
                if (prices.Count > 5)
                    Price6Txt = prices[5];
            }
        }

        private void PopulateFlyerImages(List<string> imageSrcs)
        {
            for (int i = 0; i < imageSrcs.Count; i++)
            {
                Image1Src = imageSrcs[0];

                if (imageSrcs.Count > 1)
                    Image2Src = imageSrcs[1];
                if (imageSrcs.Count > 2)
                    Image3Src = imageSrcs[2];
                if (imageSrcs.Count > 3)
                    Image4Src = imageSrcs[3];
                if (imageSrcs.Count > 4)
                    Image5Src = imageSrcs[4];
                if (imageSrcs.Count > 5)
                    Image6Src = imageSrcs[5];
            }
        }
        #endregion

    }
}