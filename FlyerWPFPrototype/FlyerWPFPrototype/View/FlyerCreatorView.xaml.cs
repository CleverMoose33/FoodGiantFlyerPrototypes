using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlyerWPFPrototype
{
    /// <summary>
    /// Interaction logic for FlyerCreatorView.xaml
    /// </summary>
    public partial class FlyerCreatorView : Window
    {
        public FlyerCreatorView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Temp method to play with resource dictionary style bindings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StyleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox style = sender as ComboBox;
            if (style != null && style.SelectedItem != null)
            {
                ComboBoxItem seltItm = style.SelectedItem as ComboBoxItem;
                if (seltItm.Content.ToString().Equals("Pretty Style"))
                {
                    Style borderStyle = (Style)this.Resources["BorderStyle"];
                }
            }

        }
    }
}
