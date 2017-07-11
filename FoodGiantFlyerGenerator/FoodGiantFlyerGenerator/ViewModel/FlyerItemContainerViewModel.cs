using Caliburn.Micro;
using FoodGiantFlyerGenerator.Model;
using System;
using System.ComponentModel.Composition;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(FlyerItemContainerViewModel))]
    public class FlyerItemContainerViewModel : PropertyChangedBase //Or Screen if visual
    {
        private readonly IEventAggregator _EventAggregator;

        #region Binding Items
        private string _ItemImageSrc;

        public string ItemImageSrc
        {
            get { return _ItemImageSrc; }
            set
            {
                _ItemImageSrc = value;
                NotifyOfPropertyChange();
            }
        }

        private string _ItemPriceDollar;

        public string ItemPriceDollar
        {
            get { return _ItemPriceDollar; }
            set
            {
                _ItemPriceDollar = value;
                NotifyOfPropertyChange();
            }
        }

        private string _ItemPriceCents;

        public string ItemPriceCents
        {
            get { return _ItemPriceCents; }
            set
            {
                _ItemPriceCents = value;
                NotifyOfPropertyChange();
            }
        }

        private string _ItemSize;

        public string ItemSize
        {
            get { return _ItemSize; }
            set
            {
                _ItemSize = value;
                NotifyOfPropertyChange();
            }
        }

        private string _ItemNameAndDesc;

        public string ItemNameAndDesc
        {
            get { return _ItemNameAndDesc; }
            set
            {
                _ItemNameAndDesc = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion

        public FlyerItemContainerViewModel()
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);
        }

        public void PopulateFlyerValues(FlyerDataModel flyerData)
        {
            ItemImageSrc = flyerData.ImgName1;
            if (!flyerData.ItemPrice.Contains(@"/"))
            {
                string[] priceValues = flyerData.ItemPrice.Split('.');
                ItemPriceDollar = priceValues[0] + ".";
                ItemPriceCents = priceValues[1];
            }
            else
                ItemPriceDollar = flyerData.ItemPrice;

            ItemSize = flyerData.ItemSize;
            ItemNameAndDesc = flyerData.ItemName + Environment.NewLine + flyerData.ItemDesc;
        }
    }
}
