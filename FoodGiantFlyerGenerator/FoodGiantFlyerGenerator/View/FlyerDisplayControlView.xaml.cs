using System.Windows;
using System.Windows.Controls;

namespace FoodGiantFlyerGenerator
{
    /// <summary>
    /// Interaction logic for BaseView.xaml
    /// </summary>
    public partial class FlyerDisplayControlView : Window
    {
        public FlyerDisplayControlView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
                pd.PrintVisual(SelectedFlyerType, "something");

        }
    }
}
