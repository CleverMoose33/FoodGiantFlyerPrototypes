using Caliburn.Micro;
using FoodGiantFlyerGenerator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(FlyerHistoryViewModel))]
    public class FlyerHistoryViewModel : PropertyChangedBase //Or Screen if visual
    {
        private readonly IEventAggregator _EventAggregator;
        private readonly DatabaseInterface _DbInt;

        #region Binding Items
        private BindableCollection<string> _ItemNameList;

        public BindableCollection<string> ItemNameList
        {
            get
            {
                return _ItemNameList;
            }
            set
            {
                _ItemNameList = value;
                NotifyOfPropertyChange();
            }
        }

        private string _ItemName;

        public string ItemName
        {
            get
            { return _ItemName; }
            set
            {
                _ItemName = value;
                NotifyOfPropertyChange();
            }
        }

        private List<string> _ManagerListCmboBox;

        public List<string> ManagerListCmboBox
        {
            get
            {
                return _ManagerListCmboBox;
            }
            set
            {
                _ManagerListCmboBox = value;
                NotifyOfPropertyChange();
            }
        }

        private string _SelectedManager;

        public string SelectedManager
        {
            get
            { return _SelectedManager; }
            set
            {
                _SelectedManager = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion

        public FlyerHistoryViewModel()
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);

            _DbInt = new DatabaseInterface();
        }

        /// <summary>
        /// Updates selected item name value
        /// </summary>
        /// <param name="selectedItmCmboBox"></param>
        public void ItemListCmboBox_SelectionChanged(ComboBox selectedItmCmboBox)
        {

        }

        public void ManagerListCmboBox_SelectionChanged(object managers)
        {

        }


        public void PickStartSaleDate(DatePicker selectedDate)
        {
            _DbInt.GetFlyerHistoryItemsByDate(selectedDate.DisplayDate);
        }

        public void GetAllFlyerHistoryItems()
        {
            List<FlyerHistoryModel> results = _DbInt.GetFlyerHistoryItems();

           
        }

        public void GenerateFlyer()
        {

        }

    }
}
