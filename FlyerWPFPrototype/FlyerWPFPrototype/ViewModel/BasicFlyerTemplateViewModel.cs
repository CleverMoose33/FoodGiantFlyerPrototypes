using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlyerWPFPrototype
{
    [Export(typeof(BasicFlyerTemplateViewModel))]
    public class BasicFlyerTemplateViewModel : Screen
    {
        #region Binding Items
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
        #endregion


        private readonly IEventAggregator _eventAggregator;
        public BasicFlyerTemplateViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
        }
    }
}