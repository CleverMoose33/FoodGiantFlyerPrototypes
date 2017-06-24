using Caliburn.Micro;
using FoodGiantFlyerGenerator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FoodGiantFlyerGenerator
{
    [Export(typeof(DatabaseMaintainerViewModel))]
    public class DatabaseMaintainerViewModel : PropertyChangedBase //Or Screen if visual
    {
        private readonly IEventAggregator _EventAggregator;
        private DatabaseInterface _DbInt;

        private string _SafeImage1;
        private string _SafeImage2;
        private string _SafeImage3;

        #region Binding Items
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

        #region Item Parameters
        private string _ItemName;

        public string ItemName
        {
            get
            { return _ItemName; }
            set
            {
                _ItemName = value;
                NotifyOfPropertyChange(() => ItemName);
            }
        }

        private string _ItemCategory;

        public string ItemCategory
        {
            get
            { return _ItemCategory; }
            set
            {
                _ItemCategory = value;
                NotifyOfPropertyChange();
            }
        }

        private string _Image1Src;

        public string Image1Src
        {
            get
            { return _Image1Src; }
            set
            {
                _Image1Src = value;
                NotifyOfPropertyChange();
            }
        }

        private string _Image2Src;

        public string Image2Src
        {
            get
            { return _Image2Src; }
            set
            {
                _Image2Src = value;
                NotifyOfPropertyChange();
            }
        }

        private string _Image3Src;

        public string Image3Src
        {
            get
            { return _Image3Src; }
            set
            {
                _Image3Src = value;
                NotifyOfPropertyChange();
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public DatabaseMaintainerViewModel()
        {
            _EventAggregator = IoC.Get<IEventAggregator>();
            _EventAggregator.Subscribe(this);
            Title = "Database Maintainer";
            _DbInt = new DatabaseInterface();
        }

        /// <summary>
        /// Sets initial values of View
        /// </summary>
        private void SetDefaultValues()
        {
            ItemName = "Enter Item Name Here";
            ItemCategory = "Enter Item Category Here";
        }

        /// <summary>
        /// Validate User Input, then add Item to Database
        /// </summary>
        public void AddItemToDatabase()
        {
            //Validate items, create new FlyerItemModel
            if (EntriesValid())
            {
                FlyerDataModel newModelItem = new FlyerDataModel(ItemName, ItemCategory, _SafeImage1, _SafeImage2, _SafeImage3);

                if (_DbInt.AddNewItem(newModelItem))
                {
                    string tempImgLocation = Environment.CurrentDirectory + @"\Images\";
                    //Copy new image to images directory
                    if (!File.Exists(tempImgLocation + _SafeImage1))
                        File.Copy(Image1Src, tempImgLocation + _SafeImage1);

                    if(!string.IsNullOrEmpty(Image2Src) && !File.Exists(tempImgLocation + _SafeImage2))
                        File.Copy(Image2Src, tempImgLocation + _SafeImage2);

                    if (!string.IsNullOrEmpty(Image3Src) && !File.Exists(tempImgLocation + _SafeImage3))
                        File.Copy(Image3Src, tempImgLocation + _SafeImage3);

                    MessageBox.Show("New Item " + ItemName + " Added to Database");
                }
            }
        }

        /// <summary>
        /// Verifies user completed all previous forms
        /// </summary>
        /// <returns></returns>
        public bool EntriesValid()
        {
            bool validEntry = false;

            if (!string.IsNullOrEmpty(ItemName) && !string.IsNullOrEmpty(ItemCategory) && !string.IsNullOrEmpty(Image1Src))
                validEntry = true;

            return validEntry;
        }

        #region Image Selection Events
        /// <summary>
        /// Open Dialog box to allow user to select image
        /// </summary>
        public void SelectImage1()
        {
            System.Windows.Forms.OpenFileDialog opnfldlg = new System.Windows.Forms.OpenFileDialog();
            opnfldlg.InitialDirectory = Environment.CurrentDirectory;
            opnfldlg.Multiselect = false;
            opnfldlg.Filter = "All supported image formats|*.jpg;*.jpeg;*.bmp;*.png;*.gif|jpg|*.jpg|jpeg|*.jpeg|bmp|*.bmp|png|*.png|gif|*.gif";

            if (opnfldlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (opnfldlg.CheckFileExists)
                {
                    Image1Src = opnfldlg.FileName;
                    _SafeImage1 = opnfldlg.SafeFileName;
                }
            }
        }

        /// <summary>
        /// Open Dialog box to allow user to select image
        /// </summary>
        public void SelectImage2()
        {
            System.Windows.Forms.OpenFileDialog opnfldlg = new System.Windows.Forms.OpenFileDialog();
            opnfldlg.InitialDirectory = Environment.CurrentDirectory;
            opnfldlg.Multiselect = false;
            opnfldlg.Filter = "All supported image formats|*.jpg;*.jpeg;*.bmp;*.png;*.gif|jpg|*.jpg|jpeg|*.jpeg|bmp|*.bmp|png|*.png|gif|*.gif";

            if (opnfldlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (opnfldlg.CheckFileExists)
                {
                    Image2Src = opnfldlg.FileName;
                    _SafeImage2 = opnfldlg.SafeFileName;
                }
            }
        }

        /// <summary>
        /// Open Dialog box to allow user to select image
        /// </summary>
        public void SelectImage3()
        {
            System.Windows.Forms.OpenFileDialog opnfldlg = new System.Windows.Forms.OpenFileDialog();
            opnfldlg.InitialDirectory = Environment.CurrentDirectory;
            opnfldlg.Multiselect = false;
            opnfldlg.Filter = "All supported image formats|*.jpg;*.jpeg;*.bmp;*.png;*.gif|jpg|*.jpg|jpeg|*.jpeg|bmp|*.bmp|png|*.png|gif|*.gif";

            if (opnfldlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (opnfldlg.CheckFileExists)
                {
                    Image3Src = opnfldlg.FileName;
                    _SafeImage3 = opnfldlg.SafeFileName;
                }
            }
        }
        #endregion

    }
}
