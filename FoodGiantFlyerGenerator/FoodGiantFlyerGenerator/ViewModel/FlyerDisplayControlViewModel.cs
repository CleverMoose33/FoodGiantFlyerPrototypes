using Caliburn.Micro;
using FoodGiantFlyerGenerator.Model;
using System;
using System.Collections.Generic;
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
        private readonly DatabaseInterface _DbInt;
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
            _DbInt = new DatabaseInterface();

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
                _DbInt.AddNewFlyerHistoryEntry(GenerateFlyerHistoryModel());
                //Button btn = flyerDisplayControlGrid.Children[0] as Button;
                //btn.Visibility = Visibility.Hidden;
                //ContentControl printableArea = flyerDisplayControlGrid.Children[1] as ContentControl;
                //if (printableArea != null)
                //{
                //    PrintDialog printDlg = new PrintDialog();
                //    PageMediaSize pageSize = new PageMediaSize(PageMediaSizeName.NorthAmericaLetter);
                //    printDlg.PrintTicket.PageMediaSize = pageSize;
                //    if(printDlg.ShowDialog().Value)
                //    {
                //        PrintTicket pt = printDlg.PrintTicket;
                //        Double printableWidth = pt.PageMediaSize.Width.Value;
                //        Double printableHeight = pt.PageMediaSize.Height.Value;
                //        printableArea.RenderSize = new Size(printableWidth, printableHeight);
                //        printDlg.PrintVisual(printableArea, "Store Flyer - date" + DateTime.Now.ToShortDateString());                      
                //    }
                //}
            }
        }

        private FlyerHistoryModel GenerateFlyerHistoryModel()
        {
            FlyerHistoryModel flyerHisMdl = new FlyerHistoryModel();
            flyerHisMdl.ManagerName = Environment.UserName;
            flyerHisMdl.TemplateName = SelectedFlyerType.ToString();
            flyerHisMdl.StoreAddress = SelectedFlyerType.StoreAddress;
            flyerHisMdl.StoreNumber = SelectedFlyerType.StoreNumber;
            flyerHisMdl.FlyerCreationDate = DateTime.Today.ToShortDateString();
            flyerHisMdl.FlyerSaleDates = SelectedFlyerType._StartDate.ToShortDateString() + SelectedFlyerType._EndDate.ToShortDateString();

            if (SelectedFlyerType.ShowSupply == Visibility.Visible)
                flyerHisMdl.SupplyChecked = true;
            else
                flyerHisMdl.SupplyChecked = false;

            if (SelectedFlyerType.ShowRaincheck == Visibility.Visible)
                flyerHisMdl.RaincheckChecked = true;
            else
                flyerHisMdl.RaincheckChecked = false;

            flyerHisMdl.flyerItemLst = new List<FlyerDataModel>(SelectedFlyerType._FlyerData);
            return flyerHisMdl;

        }
    }
}