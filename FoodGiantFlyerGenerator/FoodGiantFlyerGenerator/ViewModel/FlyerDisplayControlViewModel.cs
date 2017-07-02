using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(FlyerDisplayControlViewModel))]
    public class FlyerDisplayControlViewModel : PropertyChangedBase //Or Screen if visual
    {
        private readonly IEventAggregator _EventAggregator;

        #region Binding Items
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

        //public FlyerDisplayControlViewModel(ContentControl selectedFlyer)
        //{
        //    _EventAggregator = IoC.Get<IEventAggregator>();
        //    _EventAggregator.Subscribe(this);

        //    SelectedFlyerType = selectedFlyer;

        //}

        public FlyerDisplayControlViewModel(GenericFlyerViewModel selectedFlyer)
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);

            SelectedFlyerType = selectedFlyer;

        }

        public void PrintFlyer()
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
                //pd.PrintVisual( SelectedFlyerType.PrintVisual(), "something");
                pd.PrintDocument(((IDocumentPaginatorSource)SelectedFlyerType).DocumentPaginator, "Flyer");
        }
    }
}
