using Caliburn.Micro;
using System;
using System.ComponentModel.Composition;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(FlyerDisplayControlViewModel))]
    public class FlyerDisplayControlViewModel : PropertyChangedBase //Or Screen if visual
    {
        private readonly IEventAggregator _EventAggregator;

        #region Binding Items
        //Hardcoded to GenericFlyerViewModel
        //This could become a generic object that is then populated in Content Control
        //Can do on next iteration of software, if happens
        private GenericFlyerViewModel _SelectedFlyerType;

        public GenericFlyerViewModel SelectedFlyerType
        {
            get { return _SelectedFlyerType; }
            set
            {
                _SelectedFlyerType = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="selectedFlyer"></param>
        public FlyerDisplayControlViewModel(GenericFlyerViewModel selectedFlyer)
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);

            SelectedFlyerType = selectedFlyer;
        }

        /// <summary>
        /// Print Selected Flyer by using Content Control
        /// Room for improvement here, ugly style of coding
        /// </summary>
        /// <param name="flyerDisplayControlView"></param>
        public void PrintFlyer(FlyerDisplayControlView flyerDisplayControlView)
        {
            Grid flyerDisplayControlGrid = flyerDisplayControlView.Content as Grid;

            if (flyerDisplayControlGrid != null)
            {
                Button btn = flyerDisplayControlGrid.Children[0] as Button;
                btn.Visibility = Visibility.Hidden;
                ContentControl printableArea = flyerDisplayControlGrid.Children[1] as ContentControl;
                if (printableArea != null)
                {
                    PrintDialog printDlg = new PrintDialog();
                    PageMediaSize pageSize = new PageMediaSize(PageMediaSizeName.NorthAmericaLetter);
                    printDlg.PrintTicket.PageMediaSize = pageSize;
                    printDlg.ShowDialog();

                    PrintTicket pt = printDlg.PrintTicket;
                    Double printableWidth = pt.PageMediaSize.Width.Value;
                    Double printableHeight = pt.PageMediaSize.Height.Value;
                    printableArea.RenderSize = new Size(printableWidth, printableHeight);
                    printDlg.PrintVisual(printableArea, "Store Flyer - date" + DateTime.Now.ToShortDateString());
                }
            }
        }
    }
}