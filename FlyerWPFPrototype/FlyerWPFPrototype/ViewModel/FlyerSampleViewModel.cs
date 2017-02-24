using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlyerWPFPrototype.ViewModel
{
    public class FlyerSampleViewModel : Screen
    {
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

        public FlyerSampleViewModel()
        {

        }

        public FlyerSampleViewModel(string userName)
        {

        }
    }
}
