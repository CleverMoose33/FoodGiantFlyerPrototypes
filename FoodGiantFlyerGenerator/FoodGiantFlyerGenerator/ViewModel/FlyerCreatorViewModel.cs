using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
    Items they wish to use
        ComboBox for Item selection
        Item Price
        Item Size Drop Down
            •	Per Pound
            •	Each
            •	Jumbo Pack
            •	Family Pack
        Item Description Text Box
        Three Image selelction boxes
            Border around images
 
         */

        #region Binding Items
        private string _BaseItem;

        public string BaseItem
        {
            get { return _BaseItem; }
            set
            {
                _BaseItem = value;
                NotifyOfPropertyChange();
            }
        }

        private object _FlyerItem1;

        public object FlyerItem1
        {
            get { return _FlyerItem1; }
            set
            {
                _FlyerItem1 = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion

        public FlyerCreatorViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
        }

        public void SomeEvent()
        {
            string whatever = "sdfds";
        }

        public void SomeEvent(object something)
        {
            string whatever = "sdfds";
        }
    }
}
