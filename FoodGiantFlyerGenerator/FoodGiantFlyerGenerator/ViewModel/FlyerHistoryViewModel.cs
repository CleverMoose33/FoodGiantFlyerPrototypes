using Caliburn.Micro;
using FoodGiantFlyerGenerator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(FlyerHistoryViewModel))]
    public class FlyerHistoryViewModel : PropertyChangedBase //Or Screen if visual
    {
        private readonly IEventAggregator _EventAggregator;
        private readonly DatabaseInterface _DbInt;
        private DateTime _SearchDate;
        private string _DateSearchType;

        #region Binding Items
        private List<FlyerHistoryModel> _ItemNameList;

        public List<FlyerHistoryModel> ItemNameList
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

        private FlyerHistoryModel _ItemName;

        public FlyerHistoryModel ItemName
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

        private string _Title;

        public string Title
        {
            get
            { return _Title; }
            set
            {
                _Title = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _DatePickerVis;

        public Visibility DatePickerVis
        {
            get
            { return _DatePickerVis; }
            set
            {
                _DatePickerVis = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _ManagerListCmboBoxSortVis;

        public Visibility ManagerListCmboBoxSortVis
        {
            get
            { return _ManagerListCmboBoxSortVis; }
            set
            {
                _ManagerListCmboBoxSortVis = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public FlyerHistoryViewModel()
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);

            _DbInt = new DatabaseInterface();

            bool isUserAdmin = false;
            foreach (string userAccount in _DbInt.GetAccountList())
                if (Environment.UserName.ToUpper().Equals(userAccount.ToUpper()))
                    isUserAdmin = true;
            if (!isUserAdmin)
                Environment.Exit(0);

            Title = "Flyer History";

            ManagerListCmboBoxSortVis = Visibility.Collapsed;
            DatePickerVis = Visibility.Collapsed;
        }

        /// <summary>
        /// Updates selected item name value
        /// </summary>
        /// <param name="selectedItmCmboBox"></param>
        public void ItemListCmboBox_SelectionChanged(ComboBox selectedItmCmboBox)
        {
            ItemName = selectedItmCmboBox.SelectedItem as FlyerHistoryModel;
        }

        public void GetFlyerHistoryItemsByUser()
        {
            ManagerListCmboBox = _DbInt.GetManagerList();
            ManagerListCmboBoxSortVis = Visibility.Visible;
            DatePickerVis = Visibility.Collapsed;
        }

        /// <summary>
        /// Queries Database by Selected Manager Name
        /// </summary>
        /// <param name="managers"></param>
        public void ManagerListCmboBox_SelectionChanged(ComboBox selectedItmCmboBox)
        {
            ItemNameList = _DbInt.GetFlyerHistoryItemsByManager(selectedItmCmboBox.SelectedItem.ToString());
        }

        /// <summary>
        /// Queries Database by Selected Flyer Start Date
        /// </summary>
        /// <param name="selectedDate"></param>
        public void GetAllFlyerHistoryItemsByDate(DatePicker selectedDate)
        {
            _SearchDate = selectedDate.DisplayDate;
            ItemNameList = _DbInt.GetFlyerHistoryItemsByDate(_SearchDate, _DateSearchType);
        }

        /// <summary>
        /// Makes calendar visible
        /// </summary>
        public void PickDateSearchType(RadioButton btn)
        {
            _DateSearchType = btn.Content.ToString();
            DatePickerVis = Visibility.Visible;
            ManagerListCmboBoxSortVis = Visibility.Collapsed;
        }

        /// <summary>
        /// Queries Database for all Flyer History entries
        /// </summary>
        public void GetAllFlyerHistoryItems()
        {
            DatePickerVis = Visibility.Collapsed;
            ManagerListCmboBoxSortVis = Visibility.Collapsed;
            ItemNameList = _DbInt.GetFlyerHistoryItems();
        }

        /// <summary>
        /// Generate Flyer based in selected FlyerHistory
        /// </summary>
        public void GenerateFlyer()
        {
            WindowManager wm = new WindowManager();
            GenericFlyerViewModel gfvm = new GenericFlyerViewModel(ItemName);
            wm.ShowWindow(gfvm);
        }

    }
}
