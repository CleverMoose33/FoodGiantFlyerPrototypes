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
    //Temp class to handle user login.  There will be server side login in full version
    //This is just for prototype to call on other classes
    [Export(typeof(LoginControlViewModel))]
    public class LoginControlViewModel : Conductor<object>
    {
        #region Binding Items
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
        #endregion

        private readonly IEventAggregator _eventAggregator;
        public LoginControlViewModel()
        {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _eventAggregator.Subscribe(this);
        }

        /// <summary>
        /// TODO - Design - This is temp method to populate different page based on user permissions.  This will be done in server side document
        /// </summary>
        public void UpdateLoginScreen()
        {
            if (UserAccount != null && UserAccount.Content != null)
            {
                string userName = UserAccount.Content.ToString();

                
                if (userName.Equals("Store Manager"))
                {
                    WindowManager wm = new WindowManager();
                    FlyerCreatorViewModel temp = new FlyerCreatorViewModel(userName);
                    wm.ShowWindow(temp);
                }
                else if (userName.Equals("District Manager"))
                {
                    WindowManager wm = new WindowManager();
                    FlyerCreatorViewModel temp = new FlyerCreatorViewModel(userName);
                    wm.ShowWindow(temp);
                }
            }
        }

        /// <summary>
        /// Event handler for user acccount changed.  Will also not be used in final version
        /// </summary>
        /// <param name="sender"></param>
        public void ComboBox_SelectionChanged(object sender)
        {
            ComboBox accountBox = sender as ComboBox;
            if (accountBox != null)
                UserAccount = accountBox.SelectedItem as ComboBoxItem;
        }

    }
}
