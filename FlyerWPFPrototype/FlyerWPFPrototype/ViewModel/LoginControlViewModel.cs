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
    [Export(typeof(LoginControlViewModel))]
    class LoginControlViewModel : Conductor<object>
    {

        private ComboBoxItem _UserAccount;

        public ComboBoxItem UserAccount
        {
            get
            { return _UserAccount; }
            set
            {
                _UserAccount = value;
                NotifyOfPropertyChange(() => UserAccount);
            }
        }

        private readonly IEventAggregator _eventAggregator;
        public LoginControlViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
        }

        public void UpdateLoginScreen()
        {
            if (UserAccount != null && UserAccount.Content != null)
            {
                string someName = UserAccount.Content.ToString();

                if (someName.Equals("Store Manager"))
                {
                    //Load basic guy
                }
                else if (someName.Equals("District Manager"))
                {
                    //Load basic guy
                }
                else if (someName.Equals("Big John"))
                {
                    //Load basic guy
                }
            }
        }


        public void ComboBox_SelectionChanged(object sender)
        {
            ComboBox accountBox = sender as ComboBox;
            if (accountBox != null)
                UserAccount = accountBox.SelectedItem as ComboBoxItem;
        }

    }
}
